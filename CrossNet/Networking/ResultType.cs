namespace CrossNet.Networking;

public enum ResultType
{
    Success,
    NoBufferSpaceAvailable,
    Interrupted,
    Unreachable,
    OversizedPacket,
    AlreadyClosed,
    Unknown,
}