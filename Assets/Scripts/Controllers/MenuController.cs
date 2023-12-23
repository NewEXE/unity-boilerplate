using Game.Management;
using UnityEngine;

namespace Game.Controllers
{
    public class MenuController : MonoBehaviour
    {
        public void OnToStartGameClicked()
        {
            Managers.GameLocation.GoToGameProcess();
        }
        
        public void OnToExitClicked()
        {
            Managers.GameLocation.CloseApp();
        }
    }
}
