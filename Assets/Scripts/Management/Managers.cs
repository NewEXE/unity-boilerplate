using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Services;
using Game.Events;

namespace Game.Management
{
    [RequireComponent(typeof(DataManager))]
    [RequireComponent(typeof(GameLocationManager))]
    [RequireComponent(typeof(ScoreManager))]
    public class Managers : MonoBehaviour
    {
        public static DataManager Data { get; private set; }
        public static GameLocationManager GameLocation { get; private set; }
        public static ScoreManager Score { get; private set; }

        private List<IGameManager> startSequence;

        private void Awake()
        {
            // Share managers across all scenes
            DontDestroyOnLoad(this.gameObject);
            
            Managers.Data = this.GetComponent<DataManager>();
            Managers.GameLocation = this.GetComponent<GameLocationManager>();
            Managers.Score = this.GetComponent<ScoreManager>();

            this.startSequence = new List<IGameManager>();
            this.startSequence.Add(Managers.GameLocation);
            this.startSequence.Add(Managers.Score);
            
            // Because DataManager uses other managers (to update them), you
            // should make sure that the other managers appear earlier in the startup sequence.
            this.startSequence.Add(Managers.Data);

            this.StartCoroutine(this.StartupManagers());
        }

        private IEnumerator StartupManagers()
        {
            NetworkService networkService = new NetworkService();

            foreach (IGameManager manager in this.startSequence) {
                manager.Startup(networkService);
            }
            
            yield return null;

            int numModules = this.startSequence.Count;
            int numReady = 0;

            while (numReady < numModules) {
                int lastReady = numReady;
                numReady = 0;

                foreach (IGameManager manager in this.startSequence) {
                    if (manager.status == ManagerStatus.Started) {
                        numReady++;
                    }
                }

                if (numReady > lastReady) {
                    Debug.Log($"Progress: {numReady}/{numModules}");
                    Messenger<int, int>.Broadcast(StartupEvent.ManagersProgress, numReady, numModules);
                }
                
                yield return null;
            }

            Debug.Log("All managers started up");
            Messenger.Broadcast(StartupEvent.ManagersStarted);
        }
    }
}
