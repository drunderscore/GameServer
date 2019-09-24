namespace LeagueSandbox.GameServer.API.Events
{
    public class Event { }
    public interface ICancelable
    {
        bool Canceled { get; set; }
    }

    public enum EventType
    {
        PRE,
        POST
    }
}
