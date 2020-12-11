using System;
using OpenKnife;
using OpenKnife.States;
using UnityEngine;
using UnityEngine.UI;
using OpenKnife.Levels;

namespace OpenKnife.UI
{
    public class UIManager : MonoBehaviour, GameStates
    {

        public static UIManager instance;

        public GameObject mainMenuPanel;
        public GameObject inGamePanel;
        public GameObject gameOverPanel;

        private LevelManager levelManager;

        [Header("References")]
        public Text stageText;
        public Text fruitsText;
        public Text scoreText;
        public ShootsPanel shootsPanel;
        public Text stageTitle;

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
        }

        private void Start()
        {
            levelManager = GameManager.instance.GetComponent<LevelManager>();
            GameManager.instance.gameStates.Add(this);
            UpdateFruitsText(0);
            UpdateScoreText(0);
            UpdateStageText(0);

            levelManager.onShoot.AddListener(delegate
            {
                shootsPanel.Shoot();
            });
            levelManager.onStageFinish.AddListener(delegate
            {
                stageTitle.gameObject.SetActive(false);
            });
            levelManager.onStageInit.AddListener(delegate
            {
                UpdateStageTitleText(levelManager.ActualStage);
                shootsPanel.SetNewShoots(levelManager.Shoots);
            });
            levelManager.onScore.AddListener(delegate
            {
                UpdateScoreText(levelManager.ActualScore);
            });
            levelManager.onStageInit.AddListener(delegate
            {
                UpdateStageText(levelManager.ActualStage);
            });
            levelManager.onFruitSlice.AddListener(delegate
            {
                UpdateFruitsText(levelManager.Fruits);
            });
        }

        private void OnDisable()
        {
            GameManager.instance.gameStates.Remove(this);
        }

        public void UpdateFruitsText(int fruits)
        {
            fruitsText.text = fruits.ToString();
        }

        public void GameOver(GameState newState, GameState oldState)
        {
            mainMenuPanel.SetActive(false);
            inGamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        public void MainMenu(GameState newState, GameState oldState)
        {
            mainMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }

        public void StartGame(GameState newState, GameState oldState)
        {
            mainMenuPanel.SetActive(false);
            inGamePanel.SetActive(true);
            gameOverPanel.SetActive(false);
            UpdateScoreText(0);
            UpdateFruitsText(0);
        }


        public void UpdateStageText(int stage)
        {
            stageText.text = (stage + 1).ToString();
        }

        public void UpdateScoreText(int value)
        {
            scoreText.text = value.ToString();
        }

        public void UpdateStageTitleText(int value)
        {
            stageTitle.gameObject.SetActive(true);
            stageTitle.text = "STAGE "+(value+1);
        }
    }
}

