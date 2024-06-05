using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Data;
using UnityEngine;

namespace Services
{
    public class PopupMessageService : IPopupMessageService
    {
        
        #region data
        
        private List<APopupData> _popupsToShow;
        private APopup _openedPopup;
        private APopup _hidedPopup;
        private readonly IPopupFactory _popupsFactory;
        private readonly Transform _prefabsRoot;
        
        #endregion
        
        #region interface

        public PopupMessageService(IPopupFactory popupsFactory, Transform prefabsRoot)
        {
            _popupsFactory = popupsFactory;
            _prefabsRoot = prefabsRoot;
            _popupsToShow = new List<APopupData>();
        }
        
        /// <inheritdoc/>
        public void PushPopup(APopupData data)
        {
            if (data == null)
            {
                Debug.LogError($"[{nameof(PopupMessageService)}] - Unable to push message. Null APopupData");
                return;
            }

            _popupsToShow ??= new List<APopupData>();
            _popupsToShow.Add(data);
            ShowPopup();
        }

        /// <inheritdoc/>
        public int GetQueueSize()
        {
            return _popupsToShow?.Count ?? 0;
        }

        /// <inheritdoc/>
        public APopup GetOpenedPopup()
        {
            return _openedPopup;
        }
        
        #endregion 
        
        #region implementation

        private void ShowPopup()
        {
            if (_openedPopup == null && _hidedPopup != null)
            {
                _hidedPopup.Open();
                _openedPopup = _hidedPopup;
                _hidedPopup = null;
                return;
            }

            var popupData = GetPopupToShow();
            if (popupData == null || (_openedPopup != null && popupData.Priority != Priority.Urgent)) return;

            if (popupData.Priority == Priority.Urgent && _openedPopup != null)
            {
                _openedPopup.Hide();
                _hidedPopup = _openedPopup;
                _openedPopup = null;
            }

            _popupsToShow.Remove(popupData);
            _openedPopup = _popupsFactory.InstantiatePopup(popupData, _prefabsRoot);
            _openedPopup.OnClosed += PopupOnClosedHandler;
            _openedPopup.Open();
        }

        private void PopupOnClosedHandler(PopupResultData obj)
        {
            _openedPopup.OnClosed -= PopupOnClosedHandler;
            _openedPopup = null;
            ShowPopup();
        }

        private APopupData GetPopupToShow()
        {
            if (GetQueueSize() == 0) return null;
        
            var prioritizedList = _popupsToShow.OrderByDescending(t => t.Priority);
            return prioritizedList.FirstOrDefault();
        }
        
        #endregion
    }
}