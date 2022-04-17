using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project2.Concretes.Managers
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.StartGame();
        }
        public void NoButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
