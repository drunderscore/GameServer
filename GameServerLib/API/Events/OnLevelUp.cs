using GameServerCore.Domain.GameObjects;

namespace LeagueSandbox.GameServer.API.Events
{
    public class OnLevelUp : Event
    {
        public IChampion Champion { get; }
        public int Level { get; }
        public byte Skillpoints { get; set; }

        public OnLevelUp(IChampion champ, int level, byte skillpoints)
        {
            Champion = champ;
            Level = level;
            Skillpoints = skillpoints;
        }
    }
}
