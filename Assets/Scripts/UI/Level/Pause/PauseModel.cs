using UnityEngine.SceneManagement;

namespace UI.Level.Pause
{
    /// <summary>
    /// Implements click actions on UI elements of the <see cref="PauseView"/>
    /// </summary>
    public sealed class PauseModel
    {
        private IPanel _hudView;

        public PauseModel(IPanel hudView)
        {
            _hudView = hudView;
        }

        public void Exit()
        {
            UnityEngine.Time.timeScale = 1;
            SceneManager.LoadScene(Infrastructure.SceneName.Menu.ToString());
        }

        public void Restart()
        {
            UnityEngine.Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Continue()
        {
            UnityEngine.Time.timeScale = 1;
            _hudView.Open();
        }
    }
}