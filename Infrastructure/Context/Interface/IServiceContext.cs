using System.Collections.Generic;

namespace Infrastructure.Context.Interface
{
    public interface IServiceContext
    {
        IReadOnlyCollection<string> Notifications { get; }

        bool HasNotification();

        void AddNotification(string message);
    }
}