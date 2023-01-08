namespace UI.Level.HUD
{
    /// <summary>
    /// Implements click actions on UI elements of the <see cref="HUDView"/>
    /// </summary>
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