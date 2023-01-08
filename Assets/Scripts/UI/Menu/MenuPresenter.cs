using UnityEngine;
using Configs.Level;
using Audio;
using Config.Audio;

namespace UI.Menu
{
    /// <summary>
    /// Associates the view and model of the menu panel
    /// </summary>
    [RequireComponent(typeof(MenuView))]
    public sealed class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedLevelInfo _selectedLevelInfo;
        [SerializeField] private GameAudioMixer _audioMixer;

        private MenuView _view;
        private MenuModel _model;

        private void Awake()
        {
            _view = GetComponent<MenuView>();
            _model = new MenuModel(_selectedLevelInfo, _audioMixer);
        }

        private void OnEnable()
        {
            _view.OnExit += Exit;
            _view.OnPlay += Play;
            _view.OnGunConstPool += SetGunConstPool;
            _view.OnPoolLength += SetGunConstPoolLength;
            _view.OnGunRandomPool += SetGunRandomPool;
            _view.OnMusic += Music;
            _view.OnSound += Sound;
        }

        private void Exit()
        {
            _model.Exit();
        }

        private void Play()
        {
            _model.Play();
        }

        private void SetGunConstPool()
        {
            _model.SetGunConstPool();
        }

        private void SetGunConstPoolLength(int value)
        {
            _model.SetGunConstPoolLength(value);
        }

        private void SetGunRandomPool()
        {
            _model.SetGunRandomPool();
        }

        private void Music(bool state)
        {
            _model.Music(state);
        }

        private void Sound(bool state)
        {
            _model.Sound(state);
        }


        private void OnDisable()
        {
            
        }
    }
}