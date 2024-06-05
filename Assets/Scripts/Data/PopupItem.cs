using System;
using Abstractions;

namespace Data
{
    [Serializable]
    public class PopupItem
    {
        public string Type;
        public APopup Popup;
    }
}