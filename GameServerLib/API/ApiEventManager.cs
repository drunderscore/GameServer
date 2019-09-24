using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LeagueSandbox.GameServer.API.Events;
using LeagueSandbox.GameServer.Logging;
using log4net;

/*
 * Possible Events:
[OnActivate]
[OnAddPAR]
[OnAllowAdd]
[OnAssist]
[OnAssistUnit]
[OnBeingDodged]
[OnBeingHit]
[OnBeingSpellHit]
[OnCollision]
[OnCollisionTerrain]
[OnDeactivate]
[OnDealDamage]
[OnDeath]
[OnDodge]
[OnHeal]
[OnHitUnit]
[OnKill]
[OnKillUnit]
[OnLaunchAttack]
[OnLaunchMissile]
[OnLevelUp]
[OnLevelUpSpell]
[OnMiss]
[OnMissileEnd]
[OnMissileUpdate]
[OnMoveEnd]
[OnMoveFailure]
[OnMoveSuccess]
[OnNearbyDeath]
[OnPreAttack]
[OnPreDamage]
[OnPreDealDamage]
[OnPreMitigationDamage]
[OnResurrect]
[OnSpellCast]
[OnSpellHit]
[OnTakeDamage]
[OnUpdateActions]
[OnUpdateAmmo]
[OnUpdateStats]
[OnZombie]
 */

namespace LeagueSandbox.GameServer.API
{
    public static class ApiEventManager
    {
        private static Game _game;
        private static ILog _logger;
        private static readonly List<Tuple<object, MethodInfo, Listener>> _listeners = new List<Tuple<object, MethodInfo, Listener>>();

        internal static void SetGame( Game game )
        {
            _game = game;
            _logger = LoggerProvider.GetLogger();
        }

        /// <summary>
        /// Subscribe an object instance for API events.
        /// </summary>
        /// <param name="owner">The instance to subscribe for listeners.</param>
        public static void Subscribe( object owner )
        {
            foreach ( MethodInfo m in owner.GetType().GetMethods() )
            {
                var a = m.GetCustomAttribute<Listener>();
                if ( a != null )
                    _listeners.Add( Tuple.Create( owner, m, a ) );
            }
        }

        /// <summary>
        /// Unsubscribe an object instance from API events.
        /// </summary>
        /// <param name="owner">The instance to unsubscribe for listeners.</param>
        public static void Unsubscribe( object owner )
        {
            _listeners.RemoveAll( e => e.Item1 == owner );
        }

        /// <summary>
        /// For use in a <code>using</code> block, which will automatically publish the PRE and POST events.
        /// </summary>
        /// <typeparam name="T">Event class type</typeparam>
        /// <param name="evt">Event arguments</param>
        public static Publisher<T> DoPublish<T>( T evt ) where T : Event
        {
            return new Publisher<T>( evt );
        }

        public static void Publish<T>( T evt ) where T : Event
        {
            Publish( evt, EventType.POST );
        }

        /// <summary>
        /// Publish an event to listeners.
        /// </summary>
        /// <typeparam name="T">Event class type</typeparam>
        /// <param name="evt">Event arguments</param>
        /// <param name="type">When should this event execute</param>
        public static void Publish<T>( T evt, EventType type ) where T : Event
        {
            foreach ( var e in _listeners.Where( e => e.Item2.GetParameters().Length == 1 && e.Item2.GetParameters()[0].ParameterType == typeof( T ) && e.Item3.Type == type ) )
                e.Item2.Invoke( e.Item1, new object[] { evt } );
        }
    }
};