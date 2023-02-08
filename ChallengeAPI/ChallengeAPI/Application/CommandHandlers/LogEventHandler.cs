using ChallengeAPI.Application.Notifications;
using MediatR;

namespace ChallengeAPI.Application.CommandHandlers
{
    public class LogEventHandler : INotificationHandler<SignInNotification>, INotificationHandler<AddOperationNotification>, INotificationHandler<ErrorNotification>
    {
        public Task Handle(SignInNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{notification.Username} - {notification.Message} - {DateTime.UtcNow}");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"FATAL ERROR - {notification.Exception} - {notification.StackError} - {DateTime.UtcNow}");
            });
        }

        public Task Handle(AddOperationNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"OPERATION - {notification.Operation} - {notification.Message}");
            });
        }
    }
}
