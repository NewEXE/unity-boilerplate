using Game.Management;
using UnityEngine;

namespace Game.Controllers
{
    public class MenuController : MonoBehaviour
    {
        private void OnToStartGameClicked()
        {
            Managers.GameLocation.GoToGameProcess();
        }
        
        private void OnToExitClicked()
        {
            Managers.GameLocation.CloseApp();
        }
    }
}
