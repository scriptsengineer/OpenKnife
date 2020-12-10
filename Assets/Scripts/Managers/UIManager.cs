using System;
using OpenKnife.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace OpenKnife.UI
{
    public class UIManager : MonoBehaviour, GameStates
    {

        public GameObject mainMenuPanel;
        public GameObject inGamePanel;
        public GameObject gameOverPanel;

        [Header("References")]
        public Text stageText;
        public Text fruitsText;
        public Text scoreText;
        public ShootsPanel shootsPanel;
        public Text stageTitle;

        private void Start()
        {
            GameManager.instance.gameStates.Add(this);
            UpdateFruitsText(0);
            UpdateScoreText(0);
            UpdateStageText(0);
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

