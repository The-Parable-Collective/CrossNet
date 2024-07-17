namespace CrossNet.Networking;

/// <summary>
/// Represents a networking daemon and brokers behavior, packet handling, and connections between itself and one or more
/// networking daemons.
/// </summary>
public abstract class NetworkingDaemon
{
    internal NetworkingDaemon()
    {
    }

    public bool AllowsIPv6 { get; internal set; }

    public bool AllowsIPv4 { get; internal set; }

    public bool UDPEnabled { get; internal set; }

    public bool TCPEnabled { get; internal set; }

    public bool SOCKS5Enabled { get; internal set; }
}