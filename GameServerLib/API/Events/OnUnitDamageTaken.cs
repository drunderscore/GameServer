using GameServerCore.Domain.GameObjects;
using GameServerCore.Enums;
using LeagueSandbox.GameServer.GameObjects.AttackableUnits;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnUnitDamageTaken : Event, ICancelable
    {
        public DamageType Type { get; }
        public DamageSource Source { get; }
        public DamageText Text { get; }
        public IAttackableUnit Unit { get; }
        public IAttackableUnit Attacker { get; }
        public float Damage { get; set; }
        public bool Canceled { get; set; }

        public OnUnitDamageTaken(AttackableUnit unit, IAttackableUnit attacker, float damage, DamageType type, DamageSource source, DamageText damageText)
        {
            Unit = unit;
            Attacker = attacker;
            Damage = damage;
            Type = type;
            Source = source;
            Text = damageText;
        }
    }
}
