using System;
using UnityEngine;
using UnityEngine.UI;

namespace OpenKnife.Managers
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

        private void Start()
        {
            GameManager.instance.gameStates.Add(this);
            UpdateFruits(0);
            UpdateScoreText(0);
            UpdateStageText(0);
        }

        private void OnDisable()
        {
            GameManager.instance.gameStates.Remove(this);
        }

        public void UpdateFruits(int fruits)
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
        }


        public void UpdateStageText(int stage)
        {
            stageText.text = (stage + 1).ToString();
        }

        public void UpdateScoreText(int value)
        {
            scoreText.text = value.ToString();
        }
    }
}

