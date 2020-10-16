using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class MainMenu : MonoBehaviour
    {
        #region Constants

        private const int FIRST_LEVEL = 2;

        #endregion


        #region Fields

        [SerializeField] private Button startGame;
        [SerializeField] private Button exitGame;

        #endregion


        #region Methods

        public void Play(int index)
        {
            PlayerPrefs.SetInt("LvlIndex", FIRST_LEVEL);
            SceneManager.LoadScene(index);
        }

        public void Exit()
        {
            Application.Quit();
        }

        #endregion
    }
}
