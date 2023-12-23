using UnityEngine;

namespace Game.UI.Popups
{
    public class BasePopup : MonoBehaviour
    {
        public void Open()
        {
            this.gameObject.SetActive(true);
        }
    
        public void Close()
        {
            this.gameObject.SetActive(false);
        }
    }
}