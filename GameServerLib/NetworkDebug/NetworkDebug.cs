using LeagueSandbox.GameServer;
using LeagueSandbox.GameServer.Logging;
using log4net;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Threading;

namespace NetworkDebugServer
{
    public enum NetworkCmd : int
    {
        kAck, // acknowledgment, sent when client connects
        kPrintLog,
        kDrawCircle,
        kUnk = -1
    };

    public class NetworkDebug
    {
        private UDPSocket _sock;
        private Game _game;
        private ILog _logger;

        public static NetworkDebug Debug { get; internal set; }

        public NetworkDebug( Game game )
        {
            _game = game;
            _logger = LoggerProvider.GetLogger();

            _logger.Info( "Starting NetworkDebug" );

            _sock = new UDPSocket( 37645 );
            Debug = this;
        }

        public void SendConsoleLog( string msg )
        {
            using ( var bw = new BinaryWriter( new MemoryStream() ) )
            {
                bw.Write( (int)NetworkCmd.kAck );
                bw.WriteString( msg );
                _sock.Send( ( (MemoryStream)bw.BaseStream ).ToArray() );
            }
        }

        public void DrawWorldCircle( Vector2 pos, float radius )
        {
            using ( var bw = new BinaryWriter( new MemoryStream() ) )
            {
                bw.Write( (int)NetworkCmd.kDrawCircle );
                bw.Write( pos );
                bw.Write( radius );
                _sock.Send( ( (MemoryStream)bw.BaseStream ).ToArray() );
            }
        }
    }
}
