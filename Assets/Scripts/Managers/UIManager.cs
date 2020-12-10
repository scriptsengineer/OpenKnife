using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, GameStates
{

    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject gameOverPanel;

    [Header("References")]
    public Text stageText;

    public Text scoreText;

    private void Start()
    {
        GameManager.instance.gameStates.Add(this);
    }

    private void OnDisable()
    {
        GameManager.instance.gameStates.Remove(this);
    }

    public void GameOver(GameState newState,GameState oldState)
    {
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void MainMenu(GameState newState,GameState oldState)
    {
        mainMenuPanel.SetActive(true);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void StartGame(GameState newState,GameState oldState)
    {
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }


    public void UpdateStageText(int stage)
    {
        stageText.text = (stage+1).ToString();
    }

    public void UpdateScoreText(int value)
    {
        scoreText.text = value.ToString();
    }
}