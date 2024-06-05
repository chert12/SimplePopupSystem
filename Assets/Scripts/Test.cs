using Abstractions;
using Data;
using Popups.Data;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private PopupsLibrary _popupsLibrary;
    [SerializeField] private Transform _prefabsRoot;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonMessage;
    [SerializeField] private Button _buttonUrgent;
    private IPopupMessageService _popupMessageService;

    private void Start()
    {
        _popupMessageService = new PopupMessageService(new PopupFactory(_popupsLibrary), _prefabsRoot);
        _buttonSettings.onClick.AddListener(() =>
            _popupMessageService.PushPopup(new SettingsPopupData(Priority.Low, "Some settings text", "Settings")));
        _buttonMessage.onClick.AddListener(() =>
            _popupMessageService.PushPopup(new MessagePopupData(Priority.High, "Some message text", "Message")));
        _buttonUrgent.onClick.AddListener(() =>
            _popupMessageService.PushPopup(new ErrorPopupData(Priority.Urgent, "Urgent error", "Error")));
    }
}
