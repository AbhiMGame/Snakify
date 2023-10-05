using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeGame
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Text motuScoreText;
        [SerializeField] private Text patluScoreText;
        [SerializeField] private Text WinText;

        [SerializeField] private GameObject MainMenuPanel;
        [SerializeField] private GameObject GameOverPanel;
        [SerializeField] private GameObject ResumePanel;

		private void Start()
		{
            MainMenuPanel.SetActive(true);
            GameOverPanel.SetActive(false);
            ResumePanel.SetActive(false);
        }
		public void UpdateScore(int[] score)
		{
            motuScoreText.text = $"Motu : {score[(int)Team.Motu]}"; 
            patluScoreText.text = $"Patlu : {score[(int)Team.Patlu]}";
        }

		public void StartGame()
		{
			GameManager.Instance.StartGame();
            MainMenuPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            ResumePanel.SetActive(false);

        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            ResumePanel.SetActive(true);
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
            ResumePanel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }
        public void GameOver(Team team, bool isSuicide)
		{
            GameOverPanel.SetActive(true);
                
            int[] scores = GameManager.Instance.scoreController.Score;
            if (isSuicide)
                scores[(int)team] = -100000;

            //if(scores[(int)Team.Motu] == scores[(int)Team.Patlu])
			//{
           //     WinText.text = "DRAW";
               // return;
			//}

            string winTeam = (scores[(int)Team.Motu] > scores[(int)Team.Patlu]) ? "Motu" : "Patlu";
            WinText.text = $"{winTeam} WINS";
        }

	}
}
