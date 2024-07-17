using CrossNet.Networking;

namespace CrossNet.Configuration;

/// <summary>
/// The <see cref="INetworkingDaemonBuilder" /> configuration object that holds all of the configured settings.
/// </summary>
public sealed class NetworkingDaemonBuilder : INetworkingDaemonBuilder
{
    /// <inheritdoc />
    public IClientDaemonBuilder AsClient()
    {
        return new SpecificDaemonBuilder<ClientDaemon>() { Daemon = new ClientDaemon() };
    }

    /// <inheritdoc />
    public IPeerDaemonBuilder AsPeer()
    {
        return new SpecificDaemonBuilder<PeerDaemon>() { Daemon = new PeerDaemon() };
    }

    /// <inheritdoc />
    public IServerDaemonBuilder AsServer()
    {
        return new SpecificDaemonBuilder<ServerDaemon>() { Daemon = new ServerDaemon() };
    }
}