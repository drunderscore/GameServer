using LeagueSandbox.GameServer.API.Events;
using System;

namespace LeagueSandbox.GameServer.API
{
    /// <summary>
    /// Don't use this, use <see cref="ApiEventManager.DoPublish{T}(T)"/> for more information.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Publisher<T> : IDisposable where T : Event
    {
        public T Args { get; }

        public Publisher( T args )
        {
            Args = args;
            ApiEventManager.Publish( args, EventType.PRE );
        }

        public void Dispose()
        {
            ApiEventManager.Publish( Args, EventType.POST );
        }
    }
}
