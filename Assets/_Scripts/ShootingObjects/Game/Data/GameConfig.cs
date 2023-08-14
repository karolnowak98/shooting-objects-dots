using UnityEngine;

namespace ShootingObjects.Game.Data
{
    [CreateAssetMenu(menuName = "Configs/Game Config", fileName = "Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int[] _objectsToSpawn;

        public int[] ObjectsToSpawn => _objectsToSpawn;
    }
}