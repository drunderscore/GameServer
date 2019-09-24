using GameServerCore.Domain;
using GameServerCore.Domain.GameObjects;
using LeagueSandbox.GameServer.GameObjects.Missiles;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnSpellHit : Event
    {
        public IProjectile Projectile { get; }
        public IAttackableUnit Owner { get; }
        public ISpell Spell { get; }
        public IAttackableUnit Hit { get; }

        public OnSpellHit(IProjectile projectile, IAttackableUnit owner, ISpell spell, IAttackableUnit unit)
        {
            Projectile = projectile;
            Owner = owner;
            Spell = spell;
            Hit = unit;
        }
    }
}
