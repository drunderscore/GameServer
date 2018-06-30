using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits.AI;
using LeagueSandbox.GameServer.Logic.Packets.PacketHandlers;

namespace LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.S2C
{
    public class AddGold : BasePacket
    {
        public AddGold(Champion richMan, AttackableUnit died, float gold)
            : base(PacketCmd.PKT_S2C_ADD_GOLD, richMan.NetId)
        {
            _buffer.Write(richMan.NetId);
            if (died != null)
            {
                _buffer.Write(died.NetId);
            }
            else
            {
                _buffer.Write(0);
            }

            _buffer.Write(gold);
        }
    }
}