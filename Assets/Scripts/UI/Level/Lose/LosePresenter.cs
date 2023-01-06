using UnityEngine;

namespace UI.Level.Lose
{
    [RequireComponent(typeof(LoseView))]
    public sealed class LosePresenter : MonoBehaviour
    {
        private LoseView _view;
        private LoseModel _model;

        private void Awake()
        {
            _view = GetComponent<LoseView>();
            _model = new LoseModel();
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