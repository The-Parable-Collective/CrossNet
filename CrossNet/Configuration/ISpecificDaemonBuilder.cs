namespace CrossNet.Configuration;

public interface ISpecificDaemonBuilder
{
    public ISpecificDaemonBuilder BindPort(ushort portNumber);

    public ISpecificDaemonBuilder UseTCP();

    public ISpecificDaemonBuilder UseUDP();

    public ISpecificDaemonBuilder UseTCPAndUDP();

    public ISpecificDaemonBuilder UseSOCKS5();

    public ISpecificDaemonBuilder UseNATPunchThrough();

    public ISpecificDaemonBuilder AllowIPv6();

    public ISpecificDaemonBuilder ForceIPv6();

    public ISpecificDaemonBuilder UseCRC32Checksum();

    public ISpecificDaemonBuilder UseBasicEncryption();

    public ISpecificDaemonBuilder AutomaticPollInterval(TimeSpan pollInterval);

    public ISpecificDaemonBuilder DisableAutomaticPolling();
}