using LeagueSandbox.GameServer.API.Events;
using System;

namespace LeagueSandbox.GameServer.API
{
    [AttributeUsage( AttributeTargets.Method )]
    public class Listener : Attribute
    {
        public EventType Type { get; }

        /// <summary>
        /// Mark a method as a listener for events. This constructor makes it listen for POST events.
        /// </summary>
        public Listener() : this( EventType.POST ) { }

        /// <summary>
        /// Mark a method as a listener for events.
        /// <para>
        /// PRE events will be invoked before the actual event occurs.
        /// POST events will be invoked after the actual event occurs.
        /// </para>
        /// </summary>
        /// <param name="t">When should this listener be invoked?</param>
        public Listener( EventType t )
        {
            Type = t;
        }
    }
}
