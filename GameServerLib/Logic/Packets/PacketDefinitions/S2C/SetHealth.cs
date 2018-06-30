using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.Logic.Packets.PacketHandlers;

namespace LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.S2C
{
    public class SetHealth : BasePacket
    {
        public SetHealth(AttackableUnit u)
            : base(PacketCmd.PKT_S2C_SET_HEALTH, u.NetId)
        {
            _buffer.Write((short)0x0000); // unk,maybe flags for physical/magical/true dmg
            _buffer.Write(u.Stats.HealthPoints.Total);
            _buffer.Write(u.Stats.CurrentHealth);
        }

        public SetHealth(uint itemHash)
            : base(PacketCmd.PKT_S2C_SET_HEALTH, itemHash)
        {
            _buffer.Write((short)0);
        }

    }
}