using UnityEngine;
using UnityEngine.UI;
using Game.Management;
using Game.Events;

namespace Game.Controllers
{
    public class StartupController : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;

        private void OnEnable()
        {
            Messenger<int, int>.AddListener(StartupEvent.ManagersProgress, this.OnManagersProgressEvent);
            Messenger.AddListener(StartupEvent.ManagersStarted, this.OnManagersStartedEvent);
        }

        private void OnDisable()
        {
            Messenger<int, int>.RemoveListener(StartupEvent.ManagersProgress, this.OnManagersProgressEvent);
            Messenger.RemoveListener(StartupEvent.ManagersStarted, this.OnManagersStartedEvent);
        }

        private void OnManagersProgressEvent(int numReady, int numModules)
        {
            float progress = (float)numReady / numModules;
            this.progressBar.value = progress;
        }

        private void OnManagersStartedEvent()
        {
            Managers.GameLocation.GoToMenu();
        }
    }	
}
