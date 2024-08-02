using PlayerMove;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace PlayerMove
{
    public class LevelDistance : MonoBehaviour
    {
        public GameObject distanceDisplayObject;
        public GameObject endDisplayObject;

        private float currentDistance;
        private float previousDistance;
        private GameObject player;
        private PlayerController playerController;
        private HighScoreManager highScoreManager;

        private void Start()
        {
            InitializeHighScoreManager();
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Initialize currentDistance based on player's starting position
            currentDistance = 0;
            previousDistance = 0;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            UpdateHighScoreUI();
        }

        private void InitializeHighScoreManager()
        {
            highScoreManager = FindObjectOfType<HighScoreManager>();
            if (highScoreManager == null)
            {
                GameObject highScoreManagerObj = new GameObject("HighScoreManager");
                highScoreManager = highScoreManagerObj.AddComponent<HighScoreManager>();
                DontDestroyOnLoad(highScoreManagerObj);
            }
        }

        private void Update()
        {
            UpdatePlayerDistance();
            UpdateDisplay();
        }

        private void UpdatePlayerDistance()
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    playerController = player.GetComponent<PlayerController>();
                }
            }

            if (playerController != null)
            {
                float playerZPosition = player.transform.position.z;
                // Calculate the distance traveled
                currentDistance = playerZPosition;

                // Check if the distance has increased and update the high score
                if (currentDistance > previousDistance)
                {
                    highScoreManager.SaveHighScore((int)currentDistance);
                    previousDistance = currentDistance;
                }
            }
        }

        private void UpdateDisplay()
        {
            UpdateDisplayText(distanceDisplayObject, (int)currentDistance); // Cast to int
            UpdateDisplayText(endDisplayObject, (int)currentDistance); // Cast to int
        }

        private void UpdateDisplayText(GameObject displayObject, int value) // Change parameter type to int
        {
            TextMeshProUGUI textComponent = displayObject.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = $"{value} m"; // Display as int
            }
        }

        private void UpdateHighScoreUI()
        {
            InitializeHighScoreManager();
            highScoreManager.LoadHighScore(); // Load high score when the scene changes
        }
    }
}
