using ShootingObjects.Game.Data;
using Unity.Scenes;
using UnityEngine;
using Zenject;

namespace ShootingObjects.Game.Logic
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private SubScene _entitySubScene;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameConfig);
            Container.BindInstance(_entitySubScene);
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        }
    }
}