using UnityEngine;

namespace UI.Level.HUD
{
    /// <summary>
    /// Associates the view and model of the HUD panel
    /// </summary>
    [RequireComponent(typeof(HUDView))]
    public sealed class HUDPresenter : MonoBehaviour
    {
        [SerializeField] private Pause.PauseView _pauseView;

        private HUDView _view;
        private HUDModel _model;

        private void Awake()
        {
            _view = GetComponent<HUDView>();
            _model = new HUDModel(_pauseView);
        }

        private void OnEnable()
        {
            _view.OnPause += Pause;
        }

        private void Pause()
        {
            _model.Pause();
        }

        private void OnDisable()
        {
            _view.OnPause -= Pause;
        }
    }
}