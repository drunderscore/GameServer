using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NetworkDebugServer
{
    public class UDPSocket
    {
        private Socket _socket;
        private Thread _receiveThread;
        private List<EndPoint> known = new List<EndPoint>();

        public UDPSocket( ushort port )
        {
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp );
            _socket.SetSocketOption( SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true );
            _socket.EnableBroadcast = true;
            _socket.Bind( new IPEndPoint( IPAddress.Any, port ) );

            _receiveThread = new Thread( Receive );
            _receiveThread.Start();
        }

        private void Receive()
        {
            byte[] data = new byte[1024 * 8];
            while ( _socket.IsBound )
            {
                EndPoint ep = new IPEndPoint( IPAddress.Any, 0 );
                int size = _socket.ReceiveFrom( data, ref ep );
                if ( !known.Contains( ep ) )
                    known.Add( ep );
            }
        }

        public void Send( byte[] data )
        {
            foreach ( EndPoint ep in known )
                _socket.SendTo( data, ep );
        }

        public void Close()
        {
            _socket.Close();
        }
    }
}
