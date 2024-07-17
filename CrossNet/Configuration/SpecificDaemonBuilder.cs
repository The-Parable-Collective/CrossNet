using CrossNet.Networking;

namespace CrossNet.Configuration;

/// <summary>
/// The <see cref="ISpecificDaemonBuilder{T}" /> configuration object that holds all of the configured settings.
/// </summary>
public sealed class SpecificDaemonBuilder<T> : IClientDaemonBuilder, IServerDaemonBuilder, IPeerDaemonBuilder where T : NetworkingDaemon
{
    /// <summary>
    /// The <see cref="NetworkingDaemon" /> that is being configured.
    /// </summary>
    public required T Daemon { get; init; }

    public ISpecificDaemonBuilder<ClientDaemon> AutomaticPollInterval(TimeSpan pollInterval)
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> BindPort(ushort portNumber)
    {
        this.SetPort(portNumber);

        return this;
    }

    public ClientDaemon Build()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> DisableAutomaticPolling()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> ForceIPv6()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> UseBasicEncryption()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> UseCRC32Checksum()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> UseNATPunchThrough()
    {
        throw new NotImplementedException();
    }

    public ISpecificDaemonBuilder<ClientDaemon> UseSOCKS5()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ISpecificDaemonBuilder<ClientDaemon> UseTCP()
    {
        this.SetTCPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    public ISpecificDaemonBuilder<ClientDaemon> UseTCPAndUDP()
    {
        this.SetTCPEnabled(true);
        this.SetUDPEnabled(true);

        return this;
    }

    public ISpecificDaemonBuilder<ClientDaemon> UseUDP()
    {
        this.SetUDPEnabled(true);

        return this;
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.AutomaticPollInterval(TimeSpan pollInterval)
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.AutomaticPollInterval(TimeSpan pollInterval)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.BindPort(ushort portNumber)
    {
        this.SetPort(portNumber);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.BindPort(ushort portNumber)
    {
        this.SetPort(portNumber);

        return this;
    }

    ServerDaemon ISpecificDaemonBuilder<ServerDaemon>.Build()
    {
        throw new NotImplementedException();
    }

    PeerDaemon ISpecificDaemonBuilder<PeerDaemon>.Build()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.DisableAutomaticPolling()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.DisableAutomaticPolling()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.ForceIPv6()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.ForceIPv6()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseBasicEncryption()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseBasicEncryption()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseCRC32Checksum()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseCRC32Checksum()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseNATPunchThrough()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseNATPunchThrough()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseSOCKS5()
    {
        throw new NotImplementedException();
    }

    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseSOCKS5()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseTCP()
    {
        this.SetTCPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseTCP()
    {
        this.SetTCPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseTCPAndUDP()
    {
        this.SetTCPEnabled(true);
        this.SetUDPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseTCPAndUDP()
    {
        this.SetTCPEnabled(true);
        this.SetUDPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.UseUDP()
    {
        this.SetUDPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.UseUDP()
    {
        this.SetUDPEnabled(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<PeerDaemon> ISpecificDaemonBuilder<PeerDaemon>.AllowIPv6()
    {
        this.SetIPv6(true);

        return this;
    }

    /// <inheritdoc />
    ISpecificDaemonBuilder<ServerDaemon> ISpecificDaemonBuilder<ServerDaemon>.AllowIPv6()
    {
        this.SetIPv6(true);

        return this;
    }

    /// <inheritdoc />
    public ISpecificDaemonBuilder<ClientDaemon> AllowIPv6()
    {
        this.SetIPv6(true);

        return this;
    }

    private void SetPort(ushort portNumber)
    {
        this.Daemon.PortNumber = portNumber;
    }

    private void SetTCPEnabled(bool isEnabled)
    {
        this.Daemon.TCPEnabled = isEnabled;
    }

    private void SetUDPEnabled(bool isEnabled)
    {
        this.Daemon.UDPEnabled = isEnabled;
    }

    private void SetIPv6(bool isAllowed)
    {
        this.Daemon.AllowsIPv6 = isAllowed;
    }
}