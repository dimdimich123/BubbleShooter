using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Level.Win
{
    public sealed class WinModel
    {
        public void Exit()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(Infrastructure.SceneName.Menu.ToString());
        }

        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}