using Game.Events;
using Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers
{
    public class GameProcessController : MonoBehaviour
    {
        [SerializeField] private Text scoreLabel;
        
        private void OnEnable()
        {
            Messenger.AddListener(GameEvent.ScoreChanged, this.OnScoreChangedEvent);
            this.RefreshScore();
        }
        
        private void OnDisable()
        {
            Messenger.RemoveListener(GameEvent.ScoreChanged, this.OnScoreChangedEvent);
        }
    
        private void OnToMenuClicked()
        {
            Managers.GameLocation.GoToMenu();
        }
        
        private void OnIncreaseScoreClicked()
        {
            Managers.Score.IncreaseScore();
        }
        
        private void OnSaveGameClicked()
        {
            Managers.Data.SaveGameState();
        }
        
        private void OnLoadGameClicked()
        {
            Managers.Data.LoadGameState();
        }
        
        private void OnScoreChangedEvent()
        {
            this.RefreshScore();
        }

        private void RefreshScore()
        {
            string message = $"Score: {Managers.Score.score}";
            this.scoreLabel.text = message;
        }
    }    
}


