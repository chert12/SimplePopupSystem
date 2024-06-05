using System.Linq;
using Abstractions;
using Data;
using UnityEngine;

namespace Services
{
    public class PopupFactory : IPopupFactory
    {
        private readonly PopupsLibrary _popupsLibrary;

        public PopupFactory(PopupsLibrary popupsLibrary)
        {
            _popupsLibrary = popupsLibrary;
        }

        public APopup InstantiatePopup(APopupData popupData, Transform parent)
        {
            if (popupData == null || parent == null)
            {
                Debug.LogError($"[{nameof(PopupFactory)}] - Unable to instantiate popup. Null data");
                return null;
            }
            
            var data = _popupsLibrary.PopupItems.FirstOrDefault(t => t.Type.Equals(popupData.GetType().Name));
            if (data == null)
            {
                Debug.LogError($"[{nameof(PopupFactory)}] - Unable to instantiate popup. Can't find {nameof(APopupData)} popup");
                return null;
            }

            if (data.Popup == null)
            {
                Debug.LogError($"[{nameof(PopupFactory)}] - Unable to instantiate popup. {nameof(APopupData)} popup is null");
                return null;
            }

            var popup = GameObject.Instantiate(data.Popup, parent);
            popup.Setup(popupData);
            return popup;
        }
    }
}