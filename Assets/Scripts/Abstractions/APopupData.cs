using Data;

namespace Abstractions
{
    public abstract class APopupData
    {
        public Priority Priority { get; private set; }
        public string Message { get; private set; }
        public string Title { get; private set; }

        public APopupData(Priority priority, string message, string title)
        {
            Priority = priority;
            Message = message;
            Title = title;
        }
    }

    public class TestData : APopupData
    {
        public TestData(Priority priority, string message, string title) : base(priority, message, title)
        {
        }
    }
}