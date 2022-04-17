using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project2.Concretes.Managers
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleOnScoreChange;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleOnScoreChange;
        }

        private void HandleOnScoreChange(int score = 0)
        {
            scoreText.text = $"Score:{score}";
        }
    }

}