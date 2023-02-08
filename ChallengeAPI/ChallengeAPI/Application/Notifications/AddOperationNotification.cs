using MediatR;

namespace ChallengeAPI.Application.Notifications
{
    public class AddOperationNotification : INotification
    {
        public string Operation { get; set; }
        public string Message { get; set; }
    }
}
