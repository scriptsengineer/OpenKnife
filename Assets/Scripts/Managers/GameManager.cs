using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // TODO salvar old state e enviar por eventos
    private GameState state;
    private GameState oldState;

    public UnityEvent onStartGame;
    public UnityEvent onGameOver;
    public UnityEvent onMainMenu;

    public static GameManager instance;

    [Header("Definir classes que tem gamestates chamados automaticamente quando modificado pelo gameManager")]
    public List<GameStates> gameStates = new List<GameStates>();

    public GameState State => state;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        GameStates[] internStates = GetComponents<GameStates>();
        gameStates.AddRange(internStates);
    }

    private void Start()
    {
        onChangeState();
    }

    public void ChangeState(GameState newState)
    {
        oldState = state;
        state = newState;
        onChangeState();
    }

    public void onChangeState()
    {
        switch (state)
        {
            case GameState.MAIN_MENU:
                OnMainMenu(state, oldState);
                break;
            case GameState.IN_GAME:
                OnStartGame(state, oldState);
                break;
            case GameState.GAME_OVER:
                OnGameOver(state, oldState);
                break;
        }
    }

    public void StartGame()
    {
        ChangeState(GameState.IN_GAME);
    }

    public void MainMenu()
    {
        ChangeState(GameState.MAIN_MENU);
    }

    public void GameOver()
    {
        ChangeState(GameState.GAME_OVER);
    }

    public void OnGameOver(GameState newGameState, GameState oldGameState)
    {
        onGameOver.Invoke();
        foreach (GameStates state in gameStates)
        {
            state.GameOver(newGameState, oldGameState);
        }
    }

    public void OnMainMenu(GameState newGameState, GameState oldGameState)
    {
        onMainMenu.Invoke();
        foreach (GameStates state in gameStates)
        {
            state.MainMenu(newGameState, oldGameState);
        }
    }

    public void OnStartGame(GameState newGameState, GameState oldGameState)
    {
        onStartGame.Invoke();
        foreach (GameStates state in gameStates)
        {
            state.StartGame(newGameState, oldGameState);
        }
    }
}