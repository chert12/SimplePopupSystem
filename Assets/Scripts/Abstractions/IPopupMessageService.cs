namespace Abstractions
{
    /// <summary>
    /// Interface describes base logic to work with popup system 
    /// </summary>
    public interface IPopupMessageService
    {
        /// <summary>
        /// Push popup message to the queue
        /// </summary>
        /// <param name="data">Popup data</param>
        void PushPopup(APopupData data);
        
        /// <summary>
        /// Get messages queue size
        /// </summary>
        /// <returns>Number of messages in the queue</returns>
        int GetQueueSize();
        
        /// <summary>
        /// Get opened popup object
        /// </summary>
        /// <returns>Popup object</returns>
        APopup GetOpenedPopup();
    }
}