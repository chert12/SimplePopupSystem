using Abstractions;
using Data;

namespace Popups.Data
{
    public class SettingsPopupData : APopupData
    {
        public SettingsPopupData(Priority priority, string message, string title) : base(priority, message, title)
        {
        }
    }
}