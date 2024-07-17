using CrossNet.Networking;

namespace CrossNet.Configuration;

/// <summary>
/// Used to configure and generate a new <see cref="NetworkingDaemon" />. The type of <see cref="NetworkingDaemon" /> that is
/// returned will depend on the configuration settings.
/// </summary>
public interface INetworkingDaemonBuilder
{
    /// <summary>
    /// Configures this daemon to act as a server.
    /// </summary>
    /// <returns>This <see cref="IServerDaemonBuilder" />.</returns>
    public IServerDaemonBuilder AsServer();

    /// <summary>
    /// Configures this daemon to act as a client.
    /// </summary>
    /// <returns>This <see cref="IClientDaemonBuilder" />.</returns>
    public IClientDaemonBuilder AsClient();

    /// <summary>
    /// Enables P2P and configures the daemon to act as a peer.
    /// </summary>
    /// <returns>This <see cref="IPeerDaemonBuilder" />.</returns>
    public IPeerDaemonBuilder AsPeer();
}