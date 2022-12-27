using UnityEngine;
using GameCore.Grids;
using GameCore.Guns;
using GameCore.Players;
using Infrastructure.Factories;
using Infrastructure.Providers.Configs;
using Infrastructure.Providers.Prefabs;
using Configs.Level;

namespace Infrastructure.Level {
    public sealed class LevelBuilder : MonoBehaviour
    {
        private const int _fieldWidth = 15;
        private const int _fieldHeight = 12;

        [SerializeField] private Grid _grid;
        [SerializeField] private PlayerGun _gun;
        [SerializeField] private PlayerControl _control;

        private GunBubblePool _gunPool;
        private GunRandomPool _fieldPool;
        private BubbleGrid _bubbleGrid;
        private PrefabProvider _prefabProvider;
        private ConfigProvider _configProvider;

        private void Awake()
        {
            Build();
        }

        private void Build()
        {
            _bubbleGrid = new BubbleGrid(_grid, _fieldWidth, _fieldHeight);
            _prefabProvider = new PrefabProvider();
            _configProvider = new ConfigProvider();

            _configProvider.SelectedLevelInfo.GunPool = new GunRandomPool();

            BuildPlayer();
            BuildField();
            BuildUI();
        }

        private void BuildPlayer()
        {
            BubbleFactory gunBubbleFactory = new BubbleFactory(_bubbleGrid, _configProvider.BubbleColorsConfig, 
                _prefabProvider.Bubble, _configProvider.BubbleConfig.Speed, false);
            _gunPool = _configProvider.SelectedLevelInfo.GunPool;
            _gunPool.Init(gunBubbleFactory.Create);
            _gun.Init(_gunPool);
            _control.Init(_gun, _gun.transform, _configProvider.PlayerControlConfig.Angle);
        }

        private void BuildField()
        {
            LevelConfig levelConfig = _configProvider.GetLevelConfig(_configProvider.SelectedLevelInfo.LevelId);
            BubbleFactory fieldBubbleFactory = new BubbleFactory(_bubbleGrid, _configProvider.BubbleColorsConfig,
                _prefabProvider.Bubble, _configProvider.BubbleConfig.Speed, true);
            _fieldPool = new GunRandomPool();
            _fieldPool.Init(fieldBubbleFactory.Create);
            levelConfig.LevelBuilder.Build(_bubbleGrid, _fieldPool);
        }

        private void BuildUI()
        {
            Debug.Log("System.NotImplementedException()  :)");
        }
    }
}