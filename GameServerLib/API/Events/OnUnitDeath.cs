using GameServerCore.Domain.GameObjects;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnUnitDeath : Event
    {
        public IAttackableUnit Unit { get; }
        public IAttackableUnit Killer { get; }

        public OnUnitDeath(IAttackableUnit unit, IAttackableUnit killer)
        {
            Unit = unit;
            Killer = killer;
        }
    }
}
