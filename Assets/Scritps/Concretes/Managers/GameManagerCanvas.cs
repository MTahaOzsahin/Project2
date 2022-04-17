using Project2.Concretes.Controllers.MainCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Managers
{
    public class GameManagerCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;

        private void Awake()
        {
            gameOverPanel = transform.GetChild(1).gameObject;
        }
        private void Start()
        {
            MainCharacterCombat mainCharacterCombat = FindObjectOfType<MainCharacterCombat>();
            mainCharacterCombat.onDead += HandleOnDeath;
        }
        void HandleOnDeath()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
