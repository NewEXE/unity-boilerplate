using UnityEngine;
using Game.Services;
using UnityEngine.SceneManagement;

namespace Game.Management
{
    public enum GameLocation
    {
        Startup,
        Menu,
        GameProcess
    }
    
    public class GameLocationManager : BaseGameManager
    {
        public GameLocation currentLocation { get; private set; } = GameLocation.Startup;

        public override void Startup(NetworkService networkService)
        {
            this.status = ManagerStatus.Initializing;
		
            Debug.Log("GameLocationManager starting...");
		
            base.Startup(networkService);
        }

        public void UpdateData(GameLocation location)
        {
            this.currentLocation = location;
        }
        
        public void GoToMenu()
        {
            this.currentLocation = GameLocation.Menu;
            this.RestartCurrentLocation();
        }
        
        public void GoToGameProcess()
        {
            this.currentLocation = GameLocation.GameProcess;
            this.RestartCurrentLocation();
        }
        
        public void CloseApp()
        {
            Debug.Log("Quit app...");
            Application.Quit();
        }

        public void RestartCurrentLocation()
        {
            Debug.Log($"Loading scene: {this.currentLocation}");
            SceneManager.LoadScene(this.currentLocation.ToString());
        }
    }
}
