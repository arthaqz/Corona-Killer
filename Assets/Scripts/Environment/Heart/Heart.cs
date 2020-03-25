using System;
using UnityEngine;

namespace World
{
    public class Heart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameSettings.LevelCompleted = true;
                GameSettings.PlayerInvincible = true;
                GameSettings.PlayerControlsEnabled = false;
                GameSettings.CameraControlEnabled = false;
            }
        }
    }
}