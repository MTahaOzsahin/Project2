using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Managers
{
    public class GameCanvas : MonoBehaviour
    {
        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }

        public void StartButtonClick()
        {
            GameManager.Instance.StartGame();
        }
    }
}
