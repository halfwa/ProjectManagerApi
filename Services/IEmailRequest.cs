namespace ProjectManagerApi.Services
{
    public interface IEmailRequest
    {
        void SendMessageAsync(object message);
    }
}
