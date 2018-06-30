using LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.C2S;
using LeagueSandbox.GameServer.Logic.Packets.PacketHandlers;

namespace LeagueSandbox.GameServer.Logic.Packets.PacketDefinitions.S2C
{
    public class PingLoadInfoResponse : BasePacket
    {
        public PingLoadInfoResponse(PingLoadInfoRequest loadInfo, long id) : base(PacketCmd.PKT_S2C_PING_LOAD_INFO, loadInfo.NetId)
        {
            _buffer.Write((uint)loadInfo.Position);
            _buffer.Write((ulong)id);
            _buffer.Write(loadInfo.Loaded);
            _buffer.Write(loadInfo.Unk2);
            _buffer.Write(loadInfo.Ping);
            _buffer.Write(loadInfo.Unk3);
            _buffer.Write(loadInfo.Unk4);
        }
    }
}