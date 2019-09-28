using GameServerCore.Domain.GameObjects;
using System.IO;
using System.Numerics;
using System.Text;

namespace NetworkDebugServer
{
    public static class LeagueBinaryWriter
    {
        /// <summary>
        /// Write a null-terminated string to the BinaryWriter.
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="str">The string to write</param>
        public static void WriteString( this BinaryWriter bw, string str )
        {
            bw.Write( Encoding.ASCII.GetBytes( str ) );
            bw.Write( (byte)0 );
        }

        public static void Write( this BinaryWriter bw, IGameObject obj )
        {
            bw.Write( obj.NetId );
        }

        public static void Write( this BinaryWriter bw, Vector2 pos )
        {
            bw.Write( pos.X );
            bw.Write( pos.Y );
        }

        public static void Write( this BinaryWriter bw, Vector3 pos )
        {
            bw.Write( pos.X );
            bw.Write( pos.Y );
            bw.Write( pos.Z );
        }

        public static void Write( this BinaryWriter bw, float x, float y )
        {
            bw.Write( x );
            bw.Write( y );
        }

        public static void Write( this BinaryWriter bw, float x, float y, float z )
        {
            bw.Write( x );
            bw.Write( y );
            bw.Write( z );
        }
    }
}
