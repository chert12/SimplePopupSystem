using Abstractions;
using Data;

namespace Popups.Data
{
    public class ErrorPopupData : APopupData
    {
        public ErrorPopupData(Priority priority, string message, string title) : base(priority, message, title)
        {
        }
    }
}