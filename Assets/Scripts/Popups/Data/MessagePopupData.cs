using Abstractions;
using Data;

namespace Popups.Data
{
    public class MessagePopupData : APopupData
    {
        public MessagePopupData(Priority priority, string message, string title) : base(priority, message, title)
        {
        }
    }
}