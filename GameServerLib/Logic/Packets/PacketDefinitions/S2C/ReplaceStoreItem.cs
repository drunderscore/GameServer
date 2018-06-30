using LeagueSandbox.GameServer.Logic.GameObjects.AttackableUnits;
using LeagueSandbox.GameServer.Logic.Packets.PacketHandlers;

namespace LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.S2C
{
    public class ReplaceStoreItem : BasePacket
    {
        public ReplaceStoreItem(AttackableUnit u, uint replacedItemHash, uint newItemHash)
            : base(PacketCmd.PKT_S2C_REPLACE_STORE_ITEM, u.NetId)
        {
            _buffer.Write(replacedItemHash);
            _buffer.Write(newItemHash);
        }
    }
}