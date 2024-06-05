using UnityEngine;

namespace Abstractions
{
    public interface IPopupFactory
    {
        /// <summary>
        /// Create a new instance of APopup based on input data.
        /// </summary>
        /// <param name="popupData">Popup data.</param>
        /// <param name="parent">Popup parent Transform.</param>
        /// <returns>Returns new <see cref="APopup"/></returns>
        APopup InstantiatePopup(APopupData popupData, Transform parent);
    }
}