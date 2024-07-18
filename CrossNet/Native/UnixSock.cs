﻿using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace CrossNet.Native;

internal static unsafe class UnixSock
{
    private const string LibraryName = "libc";

    [DllImport(LibraryName, SetLastError = true)]
    public static extern int recvfrom(
        nint socketHandle,
        [In, Out] byte[] pinnedBuffer,
        [In] int len,
        [In] SocketFlags socketFlags,
        [Out] byte[] socketAddress,
        [In, Out] ref int socketAddressSize);

    [DllImport(LibraryName, SetLastError = true)]
    internal static extern int sendto(
        nint socketHandle,
        byte* pinnedBuffer,
        [In] int len,
        [In] SocketFlags socketFlags,
        [In] byte[] socketAddress,
        [In] int socketAddressSize);
}