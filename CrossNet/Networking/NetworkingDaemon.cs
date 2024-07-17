﻿namespace CrossNet.Networking;

/// <summary>
/// Represents a networking daemon and brokers behavior, packet handling, and connections between itself and one or more
/// networking daemons.
/// </summary>
public abstract class NetworkingDaemon
{
    private readonly List<NetConnection> connections = [];

    internal NetworkingDaemon()
    {
    }

    public bool AllowsIPv6 { get; internal set; }

    public bool AllowsIPv4 { get; internal set; }

    public bool UDPEnabled { get; internal set; }

    public bool TCPEnabled { get; internal set; }

    public bool SOCKS5Enabled { get; internal set; }

    /// <summary>
    /// The port number that this <see cref="NetworkingDaemon" /> is listening on.
    /// </summary>
    public ushort PortNumber { get; internal set; }

    public void StartListening()
    {
    }

    public void StopListening()
    {
    }

    public void Cleanup()
    {
    }

    public void DisconnectFrom(NetConnection connection, string? additionalReason)
    {
        this.DisconnectFrom(connection, DisconnectReason.ConnectionClosedByRemote, additionalReason);
    }

    public void DisconnectFromAll(string? additionalReason)
    {
        this.DisconnectFromAll(DisconnectReason.ConnectionClosedByRemote, additionalReason);
    }

    protected void DisconnectFrom(NetConnection connection, DisconnectReason reason, string? additionalReason)
    { }

    protected void DisconnectFromAll(DisconnectReason reason, string? additionalReason)
    { }
}