using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Level.Lose
{
    /// <summary>
    /// Implements click actions on UI elements of the <see cref="LoseView"/>
    /// </summary>
    public sealed class LoseModel
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