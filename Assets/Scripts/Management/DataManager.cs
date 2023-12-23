using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Game.Services;

namespace Game.Management
{
    public class DataManager : BaseGameManager
    {
        private string filename;

        public override void Startup(NetworkService networkService)
        {
            this.status = ManagerStatus.Initializing;
		
            Debug.Log("DataManager starting...");

            this.filename = Path.Combine(Application.persistentDataPath, "gameState.dat");
		
            base.Startup(networkService);
        }

        public void SaveGameState()
        {
            Dictionary<string, object> gameState = new Dictionary<string, object>();
            
            gameState.Add("score", Managers.Score.score);

            using FileStream stream = File.Create(this.filename);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, gameState);
        }

        public void LoadGameState()
        {
            if (!File.Exists(this.filename)) {
                Debug.Log("No saved game");
                return;
            }

            Dictionary<string, object> gameState;

            using (FileStream stream = File.Open(this.filename, FileMode.Open)) {
                BinaryFormatter formatter = new BinaryFormatter();
                gameState = formatter.Deserialize(stream) as Dictionary<string, object>;
            }
            
            Managers.Score.UpdateData((int)gameState["score"]);
            
            Managers.GameLocation.RestartCurrentLocation();
        }
    }
}