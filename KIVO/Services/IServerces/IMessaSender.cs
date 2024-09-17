namespace KIVO.Services.IServerces
{
    public interface IMessageSender
    {
        Task<bool> SendMessageAsync(string recipientPhoneNumber, string message);
    }

}
