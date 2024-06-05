using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Abstractions
{
    public abstract class APopup : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _titleText;
        [SerializeField] protected TextMeshProUGUI _messageText;
        [SerializeField] protected Button _closeButton;

        public event Action OnOpened;
        public event Action<PopupResultData> OnClosed;
        public event Action OnHide;

        protected APopupData _popupData;
        
        protected virtual void Awake()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(Close);
            }
        }

        protected virtual void Start()
        {
            
        }

        public virtual void Setup(APopupData popupData)
        {
            _popupData = popupData;
        }
        
        protected void OnDestroy()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(Close);
            }
        }

        public virtual void Open()
        {
            _titleText.text = _popupData.Title;
            _messageText.text = _popupData.Message;
            gameObject.SetActive(true);
            OnOpened?.Invoke();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
        
        public virtual void Close()
        {
            OnClosed?.Invoke(new PopupResultData());
            Destroy(gameObject);
        }
    }
}