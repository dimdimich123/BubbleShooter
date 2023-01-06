using UnityEngine;
using UnityEngine.SceneManagement;
using Configs.Level;
using GameCore.Guns;

namespace UI.Menu
{
    public sealed class MenuModel
    {
        private SelectedLevelInfo _selectedLevelInfo;
        private int _gunConstPoolLength = 5;

        public MenuModel(SelectedLevelInfo selectedLevelInfo)
        {
            _selectedLevelInfo = selectedLevelInfo;
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene(Infrastructure.SceneName.Level.ToString());
        }

        public void SetGunConstPool()
        {
            _selectedLevelInfo.GunPool = new GunConstPool(_gunConstPoolLength);
        }

        public void SetGunConstPoolLength(int poolLength)
        {
            _gunConstPoolLength = poolLength;
        }

        public void SetGunRandomPool()
        {
            _selectedLevelInfo.GunPool = new GunRandomPool();
        }

        public void Music(bool state)
        {
            Debug.Log("Music " + state);
        }

        public void Sound(bool state)
        {
            Debug.Log("Sound " + state);
        }
    }
}