using UnityEngine;
using Game.Services;
using Game.Events;

namespace Game.Management
{
    public class ScoreManager : BaseGameManager
    {
        public int score { get; private set; }

        public override void Startup(NetworkService networkService)
        {
            this.status = ManagerStatus.Initializing;
		
            Debug.Log("ScoreManager starting...");
		
            base.Startup(networkService);
        }

        public void UpdateData(int score)
        {
            this.score = score;
            Messenger.Broadcast(GameEvent.ScoreChanged, MessengerMode.DontRequireListener);
        }
        
        public void IncreaseScore()
        {
            ++this.score;
            this.UpdateData(this.score);
        }
    }
}