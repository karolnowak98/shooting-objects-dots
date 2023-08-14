using System;
using ShootingObjects.Game.Data;
using Unity.Scenes;
using UnityEngine;
using Zenject;

namespace ShootingObjects.Game.Logic
{
    public class GameManager
    {
        public GameConfig GameConfig { get; private set; }
        public static int NumberOfCubesToSpawn { get; private set; }
        public SubScene EntitySubScene { get; private set; }

        public event Action OnRestartGame;
        
        [Inject]
        private void Construct(GameConfig gameConfig, SubScene entitySubScene)
        {
            GameConfig = gameConfig;
            EntitySubScene = entitySubScene;
        }
        
        public void RestartGame()
        {
            Debug.Log("Restart game");
        }

        public void StartGame(int numberToSpawn)
        {
            NumberOfCubesToSpawn = numberToSpawn;
            EntitySubScene.enabled = true;
        }
    }
}