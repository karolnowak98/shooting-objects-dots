using Core.UI;
using ShootingObjects.Game.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShootingObjects.Game.UI
{
    public class EndPanel : Panel
    {
        [SerializeField] private Button _restartBtn;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _restartBtn.onClick.AddListener(gameManager.RestartGame);
        }

        private void OnDestroy()
        {
            _restartBtn.onClick.RemoveAllListeners();
        }
    }
}