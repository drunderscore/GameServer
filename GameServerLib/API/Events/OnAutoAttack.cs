using GameServerCore.Domain.GameObjects;

namespace LeagueSandbox.GameServer.API.Events
{
    // TODO: should this be cancelable? I vote no, because blind exists.
    public class OnAutoAttack : Event
    {
        public IObjAiBase Attacker { get; }
        public IAttackableUnit Target { get; }
        public float Damage { get; set; }

        public OnAutoAttack(IObjAiBase attacker, IAttackableUnit target, float dmg)
        {
            Attacker = attacker;
            Target = target;
            Damage = dmg;
        }
    }
}
