using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LevelCompleted : MonoBehaviour
    {
        public static LevelCompleted Instance;
        
        [SerializeField] private TextMeshProUGUI levelCompletedText;

        private void Awake()
        {
            Instance = this;
        }

        public void ShowText(string levelName)
        {
            levelCompletedText.gameObject.SetActive(true);
            levelCompletedText.text = "LEVEL " + levelName + " COMPLETED";
        }
    }
}