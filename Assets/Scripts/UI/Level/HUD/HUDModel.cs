namespace UI.Level.HUD
{
    public sealed class HUDModel
    {
        private IPanel _pauseView;

        public HUDModel(IPanel pauseView)
        {
            _pauseView = pauseView;
        }

        public void Pause()
        {
            UnityEngine.Time.timeScale = 0;
            _pauseView.Open();
        }
    }
}