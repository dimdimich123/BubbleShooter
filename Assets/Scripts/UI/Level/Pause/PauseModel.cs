using UnityEngine.SceneManagement;

namespace UI.Level.Pause
{
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