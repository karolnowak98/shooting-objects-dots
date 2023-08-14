using Core.UI;
using ShootingObjects.Game.Logic;
using UnityEngine;
using Zenject;

namespace ShootingObjects.Game.UI
{
    public class MenuPanel : Panel
    {
        [SerializeField] private ObjectsButtonUI[] _buttons;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            for (var i = 0; i < gameManager.GameConfig.ObjectsToSpawn.Length; i++)
            {
                var number = gameManager.GameConfig.ObjectsToSpawn[i];
                _buttons[i].Label.text = number.ToString();
                _buttons[i].Button.onClick.AddListener(() => gameManager.StartGame(number));
                _buttons[i].Button.onClick.AddListener(Hide);
            }
        }

        private void OnDestroy()
        {
            foreach (var objectsButton in _buttons)
            {
                objectsButton.Button.onClick.RemoveAllListeners();
            }
        }
    }
}