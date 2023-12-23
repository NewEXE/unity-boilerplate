using Game.Events;
using Game.Management;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers
{
    public class GameProcessController : MonoBehaviour
    {
        [SerializeField] Text scoreLabel;
        
        void OnEnable()
        {
            Messenger.AddListener(GameEvent.ScoreChanged, this.OnScoreChangedEvent);
            this.OnScoreChangedEvent();
        }
        void OnDisable()
        {
            Messenger.RemoveListener(GameEvent.ScoreChanged, this.OnScoreChangedEvent);
        }
    
        public void OnToMenuClicked()
        {
            Managers.GameLocation.GoToMenu();
        }
        
        public void OnIncreaseScoreClicked()
        {
            Managers.Score.IncreaseScore();
        }
        
        public void OnSaveGameClicked()
        {
            Managers.Data.SaveGameState();
        }
        
        public void OnLoadGameClicked()
        {
            Managers.Data.LoadGameState();
        }
        
        private void OnScoreChangedEvent() {
            string message = $"Score: {Managers.Score.score}";
            scoreLabel.text = message;
        }
    }    
}


