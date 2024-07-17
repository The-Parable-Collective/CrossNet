using CrossNet.Networking;

namespace CrossNet.Configuration;

public interface ISpecificDaemonBuilder<T> where T : NetworkingDaemon
{
    /// <summary>
    /// Binds to the specified port.
    /// </summary>
    /// <param name="portNumber">The port number to bind to.</param>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> BindPort(ushort portNumber);

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use TCP only.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseTCP();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use UDP only. Note that if you don't specify TCP as well, SOCKS5
    /// cannot be used.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseUDP();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use TCP and UDP. When sending packets, the default will be UDP.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseTCPAndUDP();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use the SOCKS5 protocol. Note that enabling this feature requires
    /// either TCP or TCP and UDP. Sending UDP packets will do UDP associate.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseSOCKS5();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use NAT Punch-Through.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseNATPunchThrough();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to allow IPv6 addresses. Note that the default is IPv4 only.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> AllowIPv6();

    /// <summary>
    /// Forces the <see cref="NetworkingDaemon" /> to accept only IPv6 addresses. Note that the default is IPv4 only.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> ForceIPv6();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use the CRC32C algorithm for error correction of packets.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseCRC32Checksum();

    /// <summary>
    /// Configures the <see cref="NetworkingDaemon" /> to use basic encryption incoming and outgoing packets. Note that this
    /// must be enabled or disabled on both sides, or one of the <see cref="NetworkingDaemon">NetworkingDaemons</see> will just
    /// read gibberish.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> UseBasicEncryption();

    /// <summary>
    /// Sets the interval at which the <see cref="NetworkingDaemon" /> will automatically poll for incoming events and packets.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> AutomaticPollInterval(TimeSpan pollInterval);

    /// <summary>
    /// Disables automatic polling of incoming events and packets, and requires the consumer to manually tell the <see
    /// cref="NetworkingDaemon" /> when to poll for changes.
    /// </summary>
    /// <returns>This <see cref="ISpecificDaemonBuilder{T}" />.</returns>
    public ISpecificDaemonBuilder<T> DisableAutomaticPolling();

    /// <summary>
    /// Builds the <see cref="NetworkingDaemon" /> from the specified configuration. The <see cref="NetworkingDaemon" /> will be
    /// of type <typeparamref name="T" />.
    /// </summary>
    /// <returns>The <see cref="NetworkingDaemon" />.</returns>
    /// <remarks>
    /// Once the <see cref="NetworkingDaemon" /> is configured, its settings cannot be changed. This is to prevent anomalous
    /// behavior while it is running, and support for ad-hoc configuration adds unnecessary complexity.
    /// </remarks>
    public T Build();
}