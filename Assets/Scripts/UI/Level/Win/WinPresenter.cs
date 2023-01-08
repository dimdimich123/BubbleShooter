using UnityEngine;

namespace UI.Level.Win
{
    /// <summary>
    /// Associates the view and model of the win panel
    /// </summary>
    [RequireComponent(typeof(WinView))]
    public sealed class WinPresenter : MonoBehaviour
    {
        private WinView _view;
        private WinModel _model;

        private void Awake()
        {
            _view = GetComponent<WinView>();
            _model = new WinModel();
        }

        private void OnEnable()
        {
            _view.OnExit += Exit;
            _view.OnRestart += Restart;
        }

        private void Exit()
        {
            _model.Exit();
        }

        private void Restart()
        {
            _model.Restart();
        }

        private void OnDisable()
        {
            _view.OnExit -= Exit;
            _view.OnRestart -= Restart;
        }
    }
}