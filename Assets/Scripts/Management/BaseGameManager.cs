using UnityEngine;
using Game.Services;
using Game.Events;

namespace Game.Management
{
    public class BaseGameManager : MonoBehaviour, IGameManager
    {
        public ManagerStatus status { get; protected set; } = ManagerStatus.Shutdown;

        protected NetworkService networkService;

        public virtual void Startup(NetworkService networkService)
        {
            this.networkService = networkService;

            // Any long-running startup tasks go here (in children classes),
            // and set status to 'Initializing' until those tasks are complete.
        
            this.status = ManagerStatus.Started;
        }
    }
}
