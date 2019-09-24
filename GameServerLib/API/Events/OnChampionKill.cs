using GameServerCore.Domain.GameObjects;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnChampionKill : Event
    {
        public IAttackableUnit Unit { get; }
        public IChampion Killer { get; }

        public OnChampionKill(IAttackableUnit unit, IChampion killer)
        {
            Unit = unit;
            Killer = killer;
        }
    }
}
