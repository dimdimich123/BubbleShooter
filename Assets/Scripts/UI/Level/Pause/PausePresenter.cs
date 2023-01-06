using UnityEngine;

namespace UI.Level.Pause
{
    [RequireComponent(typeof(PauseView))]
    public sealed class PausePresenter : MonoBehaviour
    {
        [SerializeField] private HUD.HUDView _hudView;

        private PauseView _pauseView;
        private PauseModel _pauseModel;

        private void Awake()
        {
            _pauseView = GetComponent<PauseView>();
            _pauseModel = new PauseModel(_hudView);
        }

        private void OnEnable()
        {
            _pauseView.OnExit += Exit;
            _pauseView.OnRestart += Restart;
            _pauseView.OnContinue += Continue;
        }

        private void Exit()
        {
            _pauseModel.Exit();
        }

        private void Restart()
        {
            _pauseModel.Restart();
        }

        private void Continue()
        {
            _pauseModel.Continue();
        }

        private void OnDisable()
        {
            _pauseView.OnExit -= Exit;
            _pauseView.OnRestart -= Restart;
            _pauseView.OnContinue -= Continue;
        }
    }
}