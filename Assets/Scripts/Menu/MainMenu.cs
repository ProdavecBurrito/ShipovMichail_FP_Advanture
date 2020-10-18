using UnityEngine;
using UnityEngine.SceneManagement;


namespace Shipov_FP_Adventure
{
    public class MainMenu : MonoBehaviour
    {

        #region Methods

        public void Play(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void Exit()
        {
            Application.Quit();
        }

        #endregion
    }
}
