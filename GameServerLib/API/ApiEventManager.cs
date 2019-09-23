using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits.AI;
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
        private static readonly List<Tuple<object, MethodInfo>> _listeners = new List<Tuple<object, MethodInfo>>();

        internal static void SetGame( Game game )
        {
            _game = game;
            _logger = LoggerProvider.GetLogger();
        }

        public static void Subscribe( object owner )
        {
            _logger.Info( $"subscribing {owner.GetType().Name}" );
            foreach ( MethodInfo m in owner.GetType().GetMethods() )
            {
                var a = m.GetCustomAttribute<Listener>();
                if ( a != null )
                {
                    _logger.Info( $"found {m.Name} for event" );
                    _listeners.Add( Tuple.Create( owner, m ) );
                }
            }
        }

        public static void Unsubscribe( object owner )
        {
            _listeners.RemoveAll( e => e.Item1 == owner );
        }

        public static void Publish<T>( T evt ) where T : Event
        {
            foreach ( var e in _listeners.Where( e => e.Item2.GetParameters().Length == 1 && e.Item2.GetParameters()[0].ParameterType == typeof( T ) ) )
            {
                e.Item2.Invoke( e.Item1, new object[] { evt } );
            }
        }
    }
};