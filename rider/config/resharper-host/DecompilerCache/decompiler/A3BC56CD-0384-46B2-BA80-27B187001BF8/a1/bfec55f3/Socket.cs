// Decompiled with JetBrains decompiler
// Type: System.Net.Sockets.Socket
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: A3BC56CD-0384-46B2-BA80-27B187001BF8
// Assembly location: D:\Unity\Editor\Data\MonoBleedingEdge\lib\mono\4.5\System.dll

using Mono;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Sockets
{
  public class Socket : IDisposable
  {
    private static AsyncCallback AcceptAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.AcceptSocket = asyncState.current_socket.EndAccept(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        if (asyncState.AcceptSocket == null)
          asyncState.AcceptSocket = new Socket(asyncState.current_socket.AddressFamily, asyncState.current_socket.SocketType, asyncState.current_socket.ProtocolType, (SafeSocketHandle) null);
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginAcceptCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      Socket socket;
      try
      {
        if (socketAsyncResult.AcceptSocket == null)
        {
          socket = socketAsyncResult.socket.Accept();
        }
        else
        {
          socket = socketAsyncResult.AcceptSocket;
          socketAsyncResult.socket.Accept(socket);
        }
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete(socket);
    });
    private static IOAsyncCallback BeginAcceptReceiveCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      Socket socket;
      try
      {
        if (socketAsyncResult.AcceptSocket == null)
        {
          socket = socketAsyncResult.socket.Accept();
        }
        else
        {
          socket = socketAsyncResult.AcceptSocket;
          socketAsyncResult.socket.Accept(socket);
        }
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      int total = 0;
      if (socketAsyncResult.Size > 0)
      {
        try
        {
          SocketError errorCode;
          total = socket.Receive(socketAsyncResult.Buffer, socketAsyncResult.Offset, socketAsyncResult.Size, socketAsyncResult.SockFlags, out errorCode);
          if (errorCode != SocketError.Success)
          {
            socketAsyncResult.Complete((Exception) new SocketException((int) errorCode));
            return;
          }
        }
        catch (Exception ex)
        {
          socketAsyncResult.Complete(ex);
          return;
        }
      }
      socketAsyncResult.Complete(socket, total);
    });
    private static AsyncCallback ConnectAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.current_socket.EndConnect(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginConnectCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      if (socketAsyncResult.EndPoint == null)
      {
        socketAsyncResult.Complete((Exception) new SocketException(10049));
      }
      else
      {
        SocketAsyncResult asyncState = socketAsyncResult.AsyncState as SocketAsyncResult;
        bool flag = asyncState != null && asyncState.Addresses != null;
        try
        {
          EndPoint endPoint = socketAsyncResult.EndPoint;
          int socketOption = (int) socketAsyncResult.socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Error);
          if (socketOption == 0)
          {
            if (flag)
              socketAsyncResult = asyncState;
            socketAsyncResult.socket.seed_endpoint = endPoint;
            socketAsyncResult.socket.is_connected = true;
            socketAsyncResult.socket.is_bound = true;
            socketAsyncResult.socket.connect_in_progress = false;
            socketAsyncResult.error = 0;
            socketAsyncResult.Complete();
          }
          else if (!flag)
          {
            socketAsyncResult.socket.connect_in_progress = false;
            socketAsyncResult.Complete((Exception) new SocketException(socketOption));
          }
          else if (asyncState.CurrentAddress >= asyncState.Addresses.Length)
            asyncState.Complete((Exception) new SocketException(socketOption));
          else
            asyncState.socket.BeginMConnect(asyncState);
        }
        catch (Exception ex)
        {
          socketAsyncResult.socket.connect_in_progress = false;
          if (flag)
            socketAsyncResult = asyncState;
          socketAsyncResult.Complete(ex);
        }
      }
    });
    private static AsyncCallback DisconnectAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.current_socket.EndDisconnect(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginDisconnectCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      try
      {
        socketAsyncResult.socket.Disconnect(socketAsyncResult.ReuseSocket);
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete();
    });
    private static AsyncCallback ReceiveAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.BytesTransferred = asyncState.current_socket.EndReceive(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginReceiveCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      int total;
      try
      {
        total = Socket.Receive_internal(socketAsyncResult.socket.m_Handle, socketAsyncResult.Buffer, socketAsyncResult.Offset, socketAsyncResult.Size, socketAsyncResult.SockFlags, out socketAsyncResult.error, socketAsyncResult.socket.is_blocking);
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete(total);
    });
    private static IOAsyncCallback BeginReceiveGenericCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      int total;
      try
      {
        total = socketAsyncResult.socket.Receive(socketAsyncResult.Buffers, socketAsyncResult.SockFlags);
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete(total);
    });
    private static AsyncCallback ReceiveFromAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.BytesTransferred = asyncState.current_socket.EndReceiveFrom(ares, ref asyncState.remote_ep);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginReceiveFromCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      int from;
      try
      {
        SocketError errorCode;
        from = socketAsyncResult.socket.ReceiveFrom(socketAsyncResult.Buffer, socketAsyncResult.Offset, socketAsyncResult.Size, socketAsyncResult.SockFlags, ref socketAsyncResult.EndPoint, out errorCode);
        if (errorCode != SocketError.Success)
        {
          socketAsyncResult.Complete((Exception) new SocketException(errorCode));
          return;
        }
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete(from);
    });
    private static AsyncCallback SendAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.BytesTransferred = asyncState.current_socket.EndSend(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    private static IOAsyncCallback BeginSendGenericCallback = (IOAsyncCallback) (ares =>
    {
      SocketAsyncResult socketAsyncResult = (SocketAsyncResult) ares;
      int total;
      try
      {
        total = socketAsyncResult.socket.Send(socketAsyncResult.Buffers, socketAsyncResult.SockFlags);
      }
      catch (Exception ex)
      {
        socketAsyncResult.Complete(ex);
        return;
      }
      socketAsyncResult.Complete(total);
    });
    private static AsyncCallback SendToAsyncCallback = (AsyncCallback) (ares =>
    {
      SocketAsyncEventArgs asyncState = (SocketAsyncEventArgs) ((IOAsyncResult) ares).AsyncState;
      if (Interlocked.Exchange(ref asyncState.in_progress, 0) != 1)
        throw new InvalidOperationException("No operation in progress");
      try
      {
        asyncState.BytesTransferred = asyncState.current_socket.EndSendTo(ares);
      }
      catch (SocketException ex)
      {
        asyncState.SocketError = ex.SocketErrorCode;
      }
      catch (ObjectDisposedException ex)
      {
        asyncState.SocketError = SocketError.OperationAborted;
      }
      finally
      {
        asyncState.Complete();
      }
    });
    internal SemaphoreSlim ReadSem = new SemaphoreSlim(1, 1);
    internal SemaphoreSlim WriteSem = new SemaphoreSlim(1, 1);
    internal bool is_blocking = true;
    private static object s_InternalSyncObject;
    internal static volatile bool s_SupportsIPv4;
    internal static volatile bool s_SupportsIPv6;
    internal static volatile bool s_OSSupportsIPv6;
    internal static volatile bool s_Initialized;
    private static volatile bool s_LoggingEnabled;
    internal static volatile bool s_PerfCountersEnabled;
    internal const int DefaultCloseTimeout = -1;
    private const int SOCKET_CLOSED_CODE = 10004;
    private const string TIMEOUT_EXCEPTION_MSG = "A connection attempt failed because the connected party did not properly respondafter a period of time, or established connection failed because connected host has failed to respond";
    private bool is_closed;
    private bool is_listening;
    private bool useOverlappedIO;
    private int linger_timeout;
    private AddressFamily addressFamily;
    private SocketType socketType;
    private ProtocolType protocolType;
    internal SafeSocketHandle m_Handle;
    internal EndPoint seed_endpoint;
    internal bool is_bound;
    internal bool is_connected;
    private int m_IntCleanedUp;
    internal bool connect_in_progress;

    public Socket(SocketType socketType, ProtocolType protocolType)
      : this(AddressFamily.InterNetworkV6, socketType, protocolType)
    {
      this.DualMode = true;
    }

    public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
    {
      Socket.s_LoggingEnabled = Logging.On;
      int num1 = Socket.s_LoggingEnabled ? 1 : 0;
      Socket.InitializeSockets();
      int error;
      this.m_Handle = new SafeSocketHandle(this.Socket_internal(addressFamily, socketType, protocolType, out error), true);
      if (this.m_Handle.IsInvalid)
        throw new SocketException();
      this.addressFamily = addressFamily;
      this.socketType = socketType;
      this.protocolType = protocolType;
      IPProtectionLevel ipProtectionLevel = SettingsSectionInternal.Section.IPProtectionLevel;
      if (ipProtectionLevel != IPProtectionLevel.Unspecified)
        this.SetIPProtectionLevel(ipProtectionLevel);
      this.SocketDefaults();
      int num2 = Socket.s_LoggingEnabled ? 1 : 0;
    }

    [Obsolete("SupportsIPv4 is obsoleted for this type, please use OSSupportsIPv4 instead. http://go.microsoft.com/fwlink/?linkid=14202")]
    public static bool SupportsIPv4
    {
      get
      {
        Socket.InitializeSockets();
        return Socket.s_SupportsIPv4;
      }
    }

    public static bool OSSupportsIPv4
    {
      get
      {
        Socket.InitializeSockets();
        return Socket.s_SupportsIPv4;
      }
    }

    [Obsolete("SupportsIPv6 is obsoleted for this type, please use OSSupportsIPv6 instead. http://go.microsoft.com/fwlink/?linkid=14202")]
    public static bool SupportsIPv6
    {
      get
      {
        Socket.InitializeSockets();
        return Socket.s_SupportsIPv6;
      }
    }

    internal static bool LegacySupportsIPv6
    {
      get
      {
        Socket.InitializeSockets();
        return Socket.s_SupportsIPv6;
      }
    }

    public static bool OSSupportsIPv6
    {
      get
      {
        Socket.InitializeSockets();
        return Socket.s_OSSupportsIPv6;
      }
    }

    public IntPtr Handle
    {
      get
      {
        return this.m_Handle.DangerousGetHandle();
      }
    }

    public bool UseOnlyOverlappedIO
    {
      get
      {
        return this.useOverlappedIO;
      }
      set
      {
        this.useOverlappedIO = value;
      }
    }

    public AddressFamily AddressFamily
    {
      get
      {
        return this.addressFamily;
      }
    }

    public SocketType SocketType
    {
      get
      {
        return this.socketType;
      }
    }

    public ProtocolType ProtocolType
    {
      get
      {
        return this.protocolType;
      }
    }

    public bool ExclusiveAddressUse
    {
      get
      {
        return (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse) != 0;
      }
      set
      {
        if (this.IsBound)
          throw new InvalidOperationException(SR.GetString("The socket must not be bound or connected."));
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, value ? 1 : 0);
      }
    }

    public int ReceiveBufferSize
    {
      get
      {
        return (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer);
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (value));
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, value);
      }
    }

    public int SendBufferSize
    {
      get
      {
        return (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer);
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (value));
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, value);
      }
    }

    public int ReceiveTimeout
    {
      get
      {
        return (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
      }
      set
      {
        if (value < -1)
          throw new ArgumentOutOfRangeException(nameof (value));
        if (value == -1)
          value = 0;
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, value);
      }
    }

    public int SendTimeout
    {
      get
      {
        return (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout);
      }
      set
      {
        if (value < -1)
          throw new ArgumentOutOfRangeException(nameof (value));
        if (value == -1)
          value = 0;
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, value);
      }
    }

    public LingerOption LingerState
    {
      get
      {
        return (LingerOption) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger);
      }
      set
      {
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, (object) value);
      }
    }

    public short Ttl
    {
      get
      {
        if (this.addressFamily == AddressFamily.InterNetwork)
          return (short) (int) this.GetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress);
        if (this.addressFamily == AddressFamily.InterNetworkV6)
          return (short) (int) this.GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.ReuseAddress);
        throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
      }
      set
      {
        if (value < (short) 0 || value > (short) byte.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (value));
        if (this.addressFamily == AddressFamily.InterNetwork)
        {
          this.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, (int) value);
        }
        else
        {
          if (this.addressFamily != AddressFamily.InterNetworkV6)
            throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
          this.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.ReuseAddress, (int) value);
        }
      }
    }

    public bool DontFragment
    {
      get
      {
        if (this.addressFamily != AddressFamily.InterNetwork)
          throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
        return (int) this.GetSocketOption(SocketOptionLevel.IP, SocketOptionName.DontFragment) != 0;
      }
      set
      {
        if (this.addressFamily != AddressFamily.InterNetwork)
          throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
        this.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DontFragment, value ? 1 : 0);
      }
    }

    public bool DualMode
    {
      get
      {
        if (this.AddressFamily != AddressFamily.InterNetworkV6)
          throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
        return (int) this.GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only) == 0;
      }
      set
      {
        if (this.AddressFamily != AddressFamily.InterNetworkV6)
          throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
        this.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, value ? 0 : 1);
      }
    }

    private bool IsDualMode
    {
      get
      {
        if (this.AddressFamily == AddressFamily.InterNetworkV6)
          return this.DualMode;
        return false;
      }
    }

    internal bool CanTryAddressFamily(AddressFamily family)
    {
      if (family == this.addressFamily)
        return true;
      if (family == AddressFamily.InterNetwork)
        return this.IsDualMode;
      return false;
    }

    public void Connect(IPAddress[] addresses, int port)
    {
      int num1 = Socket.s_LoggingEnabled ? 1 : 0;
      if (this.CleanedUp)
        throw new ObjectDisposedException(this.GetType().FullName);
      if (addresses == null)
        throw new ArgumentNullException(nameof (addresses));
      if (addresses.Length == 0)
        throw new ArgumentException(SR.GetString("The number of specified IP addresses has to be greater than 0."), nameof (addresses));
      if (!ValidationHelper.ValidateTcpPort(port))
        throw new ArgumentOutOfRangeException(nameof (port));
      if (this.addressFamily != AddressFamily.InterNetwork && this.addressFamily != AddressFamily.InterNetworkV6)
        throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
      Exception exception = (Exception) null;
      foreach (IPAddress address in addresses)
      {
        if (this.CanTryAddressFamily(address.AddressFamily))
        {
          try
          {
            this.Connect((EndPoint) new IPEndPoint(address, port));
            exception = (Exception) null;
            break;
          }
          catch (Exception ex)
          {
            if (NclUtilities.IsFatal(ex))
              throw;
            else
              exception = ex;
          }
        }
      }
      if (exception != null)
        throw exception;
      if (!this.Connected)
        throw new ArgumentException(SR.GetString("None of the discovered or specified addresses match the socket address family."), nameof (addresses));
      int num2 = Socket.s_LoggingEnabled ? 1 : 0;
    }

    public int Send(byte[] buffer, int size, SocketFlags socketFlags)
    {
      return this.Send(buffer, 0, size, socketFlags);
    }

    public int Send(byte[] buffer, SocketFlags socketFlags)
    {
      return this.Send(buffer, 0, buffer != null ? buffer.Length : 0, socketFlags);
    }

    public int Send(byte[] buffer)
    {
      return this.Send(buffer, 0, buffer != null ? buffer.Length : 0, SocketFlags.None);
    }

    public int Send(IList<ArraySegment<byte>> buffers)
    {
      return this.Send(buffers, SocketFlags.None);
    }

    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
      SocketError errorCode;
      int num = this.Send(buffers, socketFlags, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    public void SendFile(string fileName)
    {
      this.SendFile(fileName, (byte[]) null, (byte[]) null, TransmitFileOptions.UseDefaultWorkerThread);
    }

    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
      SocketError errorCode;
      int num = this.Send(buffer, offset, size, socketFlags, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    public int SendTo(byte[] buffer, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
      return this.SendTo(buffer, 0, size, socketFlags, remoteEP);
    }

    public int SendTo(byte[] buffer, SocketFlags socketFlags, EndPoint remoteEP)
    {
      return this.SendTo(buffer, 0, buffer != null ? buffer.Length : 0, socketFlags, remoteEP);
    }

    public int SendTo(byte[] buffer, EndPoint remoteEP)
    {
      return this.SendTo(buffer, 0, buffer != null ? buffer.Length : 0, SocketFlags.None, remoteEP);
    }

    public int Receive(byte[] buffer, int size, SocketFlags socketFlags)
    {
      return this.Receive(buffer, 0, size, socketFlags);
    }

    public int Receive(byte[] buffer, SocketFlags socketFlags)
    {
      return this.Receive(buffer, 0, buffer != null ? buffer.Length : 0, socketFlags);
    }

    public int Receive(byte[] buffer)
    {
      return this.Receive(buffer, 0, buffer != null ? buffer.Length : 0, SocketFlags.None);
    }

    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags)
    {
      SocketError errorCode;
      int num = this.Receive(buffer, offset, size, socketFlags, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    public int Receive(IList<ArraySegment<byte>> buffers)
    {
      return this.Receive(buffers, SocketFlags.None);
    }

    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags)
    {
      SocketError errorCode;
      int num = this.Receive(buffers, socketFlags, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    public int ReceiveFrom(byte[] buffer, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
      return this.ReceiveFrom(buffer, 0, size, socketFlags, ref remoteEP);
    }

    public int ReceiveFrom(byte[] buffer, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
      return this.ReceiveFrom(buffer, 0, buffer != null ? buffer.Length : 0, socketFlags, ref remoteEP);
    }

    public int ReceiveFrom(byte[] buffer, ref EndPoint remoteEP)
    {
      return this.ReceiveFrom(buffer, 0, buffer != null ? buffer.Length : 0, SocketFlags.None, ref remoteEP);
    }

    public int IOControl(IOControlCode ioControlCode, byte[] optionInValue, byte[] optionOutValue)
    {
      return this.IOControl((int) ioControlCode, optionInValue, optionOutValue);
    }

    public void SetIPProtectionLevel(IPProtectionLevel level)
    {
      if (level == IPProtectionLevel.Unspecified)
        throw new ArgumentException(SR.GetString("The specified value is not valid."), nameof (level));
      if (this.addressFamily == AddressFamily.InterNetworkV6)
      {
        this.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPProtectionLevel, (int) level);
      }
      else
      {
        if (this.addressFamily != AddressFamily.InterNetwork)
          throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
        this.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IPProtectionLevel, (int) level);
      }
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginSendFile(string fileName, AsyncCallback callback, object state)
    {
      return this.BeginSendFile(fileName, (byte[]) null, (byte[]) null, TransmitFileOptions.UseDefaultWorkerThread, callback, state);
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginConnect(IPAddress address, int port, AsyncCallback requestCallback, object state)
    {
      int num1 = Socket.s_LoggingEnabled ? 1 : 0;
      if (this.CleanedUp)
        throw new ObjectDisposedException(this.GetType().FullName);
      if (address == null)
        throw new ArgumentNullException(nameof (address));
      if (!ValidationHelper.ValidateTcpPort(port))
        throw new ArgumentOutOfRangeException(nameof (port));
      if (!this.CanTryAddressFamily(address.AddressFamily))
        throw new NotSupportedException(SR.GetString("This protocol version is not supported."));
      IAsyncResult asyncResult = this.BeginConnect((EndPoint) new IPEndPoint(address, port), requestCallback, state);
      int num2 = Socket.s_LoggingEnabled ? 1 : 0;
      return asyncResult;
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      SocketError errorCode;
      IAsyncResult asyncResult = this.BeginSend(buffer, offset, size, socketFlags, out errorCode, callback, state);
      if (errorCode == SocketError.Success || errorCode == SocketError.IOPending)
        return asyncResult;
      throw new SocketException(errorCode);
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      SocketError errorCode;
      IAsyncResult asyncResult = this.BeginSend(buffers, socketFlags, out errorCode, callback, state);
      if (errorCode == SocketError.Success || errorCode == SocketError.IOPending)
        return asyncResult;
      throw new SocketException(errorCode);
    }

    public int EndSend(IAsyncResult asyncResult)
    {
      SocketError errorCode;
      int num = this.EndSend(asyncResult, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      SocketError errorCode;
      IAsyncResult asyncResult = this.BeginReceive(buffer, offset, size, socketFlags, out errorCode, callback, state);
      if (errorCode == SocketError.Success || errorCode == SocketError.IOPending)
        return asyncResult;
      throw new SocketException(errorCode);
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      SocketError errorCode;
      IAsyncResult asyncResult = this.BeginReceive(buffers, socketFlags, out errorCode, callback, state);
      if (errorCode == SocketError.Success || errorCode == SocketError.IOPending)
        return asyncResult;
      throw new SocketException(errorCode);
    }

    public int EndReceive(IAsyncResult asyncResult)
    {
      SocketError errorCode;
      int num = this.EndReceive(asyncResult, out errorCode);
      if (errorCode == SocketError.Success)
        return num;
      throw new SocketException(errorCode);
    }

    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public IAsyncResult BeginAccept(int receiveSize, AsyncCallback callback, object state)
    {
      return this.BeginAccept((Socket) null, receiveSize, callback, state);
    }

    public Socket EndAccept(out byte[] buffer, IAsyncResult asyncResult)
    {
      byte[] buffer1;
      int bytesTransferred;
      Socket socket = this.EndAccept(out buffer1, out bytesTransferred, asyncResult);
      buffer = new byte[bytesTransferred];
      Array.Copy((Array) buffer1, (Array) buffer, bytesTransferred);
      return socket;
    }

    private static object InternalSyncObject
    {
      get
      {
        if (Socket.s_InternalSyncObject == null)
        {
          object obj = new object();
          Interlocked.CompareExchange(ref Socket.s_InternalSyncObject, obj, (object) null);
        }
        return Socket.s_InternalSyncObject;
      }
    }

    internal bool CleanedUp
    {
      get
      {
        return this.m_IntCleanedUp == 1;
      }
    }

    internal static void InitializeSockets()
    {
      if (Socket.s_Initialized)
        return;
      lock (Socket.InternalSyncObject)
      {
        if (Socket.s_Initialized)
          return;
        int num = Socket.IsProtocolSupported(NetworkInterfaceComponent.IPv4) ? 1 : 0;
        bool flag = Socket.IsProtocolSupported(NetworkInterfaceComponent.IPv6);
        if (flag)
        {
          Socket.s_OSSupportsIPv6 = true;
          flag = SettingsSectionInternal.Section.Ipv6Enabled;
        }
        Socket.s_SupportsIPv4 = num != 0;
        Socket.s_SupportsIPv6 = flag;
        Socket.s_Initialized = true;
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~Socket()
    {
      this.Dispose(false);
    }

    public static bool ConnectAsync(SocketType socketType, ProtocolType protocolType, SocketAsyncEventArgs e)
    {
      int num1 = Socket.s_LoggingEnabled ? 1 : 0;
      if (e.m_BufferList != null)
        throw new ArgumentException(SR.GetString("Multiple buffers cannot be used with this method."), "BufferList");
      if (e.RemoteEndPoint == null)
        throw new ArgumentNullException("remoteEP");
      EndPoint remoteEndPoint = e.RemoteEndPoint;
      DnsEndPoint endPoint = remoteEndPoint as DnsEndPoint;
      bool flag;
      if (endPoint != null)
      {
        Socket socket = (Socket) null;
        MultipleConnectAsync args;
        if (endPoint.AddressFamily == AddressFamily.Unspecified)
        {
          args = (MultipleConnectAsync) new MultipleSocketMultipleConnectAsync(socketType, protocolType);
        }
        else
        {
          socket = new Socket(endPoint.AddressFamily, socketType, protocolType);
          args = (MultipleConnectAsync) new SingleSocketMultipleConnectAsync(socket, false);
        }
        e.StartOperationCommon(socket);
        e.StartOperationWrapperConnect(args);
        flag = args.StartConnectAsync(e, endPoint);
      }
      else
        flag = new Socket(remoteEndPoint.AddressFamily, socketType, protocolType).ConnectAsync(e);
      int num2 = Socket.s_LoggingEnabled ? 1 : 0;
      return flag;
    }

    internal void InternalShutdown(SocketShutdown how)
    {
      if (!this.is_connected || this.CleanedUp)
        return;
      int error;
      Socket.Shutdown_internal(this.m_Handle, how, out error);
    }

    internal IAsyncResult UnsafeBeginConnect(EndPoint remoteEP, AsyncCallback callback, object state)
    {
      return this.BeginConnect(remoteEP, callback, state);
    }

    internal IAsyncResult UnsafeBeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      return this.BeginSend(buffer, offset, size, socketFlags, callback, state);
    }

    internal IAsyncResult UnsafeBeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      return this.BeginReceive(buffer, offset, size, socketFlags, callback, state);
    }

    internal IAsyncResult BeginMultipleSend(BufferOffsetSize[] buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      ArraySegment<byte>[] arraySegmentArray = new ArraySegment<byte>[buffers.Length];
      for (int index = 0; index < buffers.Length; ++index)
        arraySegmentArray[index] = new ArraySegment<byte>(buffers[index].Buffer, buffers[index].Offset, buffers[index].Size);
      return this.BeginSend((IList<ArraySegment<byte>>) arraySegmentArray, socketFlags, callback, state);
    }

    internal IAsyncResult UnsafeBeginMultipleSend(BufferOffsetSize[] buffers, SocketFlags socketFlags, AsyncCallback callback, object state)
    {
      return this.BeginMultipleSend(buffers, socketFlags, callback, state);
    }

    internal int EndMultipleSend(IAsyncResult asyncResult)
    {
      return this.EndSend(asyncResult);
    }

    internal void MultipleSend(BufferOffsetSize[] buffers, SocketFlags socketFlags)
    {
      ArraySegment<byte>[] arraySegmentArray = new ArraySegment<byte>[buffers.Length];
      for (int index = 0; index < buffers.Length; ++index)
        arraySegmentArray[index] = new ArraySegment<byte>(buffers[index].Buffer, buffers[index].Offset, buffers[index].Size);
      this.Send((IList<ArraySegment<byte>>) arraySegmentArray, socketFlags);
    }

    internal void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue, bool silent)
    {
      if (this.CleanedUp && this.is_closed)
      {
        if (!silent)
          throw new ObjectDisposedException(this.GetType().ToString());
      }
      else
      {
        int error;
        Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) null, (byte[]) null, optionValue, out error);
        if (!silent && error != 0)
          throw new SocketException(error);
      }
    }

    public Socket(SocketInformation socketInformation)
    {
      this.is_listening = (uint) (socketInformation.Options & SocketInformationOptions.Listening) > 0U;
      this.is_connected = (uint) (socketInformation.Options & SocketInformationOptions.Connected) > 0U;
      this.is_blocking = (socketInformation.Options & SocketInformationOptions.NonBlocking) == (SocketInformationOptions) 0;
      this.useOverlappedIO = (uint) (socketInformation.Options & SocketInformationOptions.UseOnlyOverlappedIO) > 0U;
      IList list = DataConverter.Unpack("iiiil", socketInformation.ProtocolInformation, 0);
      this.addressFamily = (AddressFamily) list[0];
      this.socketType = (SocketType) list[1];
      this.protocolType = (ProtocolType) list[2];
      this.is_bound = (uint) (int) list[3] > 0U;
      this.m_Handle = new SafeSocketHandle((IntPtr) ((long) list[4]), true);
      Socket.InitializeSockets();
      this.SocketDefaults();
    }

    internal Socket(AddressFamily family, SocketType type, ProtocolType proto, SafeSocketHandle safe_handle)
    {
      this.addressFamily = family;
      this.socketType = type;
      this.protocolType = proto;
      this.m_Handle = safe_handle;
      this.is_connected = true;
      Socket.InitializeSockets();
    }

    private void SocketDefaults()
    {
      try
      {
        if (this.addressFamily == AddressFamily.InterNetwork)
        {
          this.DontFragment = false;
          if (this.protocolType != ProtocolType.Tcp)
            return;
          this.NoDelay = false;
        }
        else
        {
          if (this.addressFamily != AddressFamily.InterNetworkV6)
            return;
          this.DualMode = true;
        }
      }
      catch (SocketException ex)
      {
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern IntPtr Socket_internal(AddressFamily family, SocketType type, ProtocolType proto, out int error);

    public int Available
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        int error;
        int num = Socket.Available_internal(this.m_Handle, out error);
        if (error == 0)
          return num;
        throw new SocketException(error);
      }
    }

    private static int Available_internal(SafeSocketHandle safeHandle, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        return Socket.Available_internal(safeHandle.DangerousGetHandle(), out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Available_internal(IntPtr socket, out int error);

    public bool EnableBroadcast
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        if (this.protocolType != ProtocolType.Udp)
          throw new SocketException(10042);
        return (uint) (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast) > 0U;
      }
      set
      {
        this.ThrowIfDisposedAndClosed();
        if (this.protocolType != ProtocolType.Udp)
          throw new SocketException(10042);
        this.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, value ? 1 : 0);
      }
    }

    public bool IsBound
    {
      get
      {
        return this.is_bound;
      }
    }

    public bool MulticastLoopback
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        if (this.protocolType == ProtocolType.Tcp)
          throw new SocketException(10042);
        switch (this.addressFamily)
        {
          case AddressFamily.InterNetwork:
            return (uint) (int) this.GetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastLoopback) > 0U;
          case AddressFamily.InterNetworkV6:
            return (uint) (int) this.GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.MulticastLoopback) > 0U;
          default:
            throw new NotSupportedException("This property is only valid for InterNetwork and InterNetworkV6 sockets");
        }
      }
      set
      {
        this.ThrowIfDisposedAndClosed();
        if (this.protocolType == ProtocolType.Tcp)
          throw new SocketException(10042);
        switch (this.addressFamily)
        {
          case AddressFamily.InterNetwork:
            this.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastLoopback, value ? 1 : 0);
            break;
          case AddressFamily.InterNetworkV6:
            this.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.MulticastLoopback, value ? 1 : 0);
            break;
          default:
            throw new NotSupportedException("This property is only valid for InterNetwork and InterNetworkV6 sockets");
        }
      }
    }

    public EndPoint LocalEndPoint
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        if (this.seed_endpoint == null)
          return (EndPoint) null;
        int error;
        SocketAddress socketAddress = Socket.LocalEndPoint_internal(this.m_Handle, (int) this.addressFamily, out error);
        if (error != 0)
          throw new SocketException(error);
        return this.seed_endpoint.Create(socketAddress);
      }
    }

    private static SocketAddress LocalEndPoint_internal(SafeSocketHandle safeHandle, int family, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        return Socket.LocalEndPoint_internal(safeHandle.DangerousGetHandle(), family, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern SocketAddress LocalEndPoint_internal(IntPtr socket, int family, out int error);

    public bool Blocking
    {
      get
      {
        return this.is_blocking;
      }
      set
      {
        this.ThrowIfDisposedAndClosed();
        int error;
        Socket.Blocking_internal(this.m_Handle, value, out error);
        if (error != 0)
          throw new SocketException(error);
        this.is_blocking = value;
      }
    }

    private static void Blocking_internal(SafeSocketHandle safeHandle, bool block, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.Blocking_internal(safeHandle.DangerousGetHandle(), block, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Blocking_internal(IntPtr socket, bool block, out int error);

    public bool Connected
    {
      get
      {
        return this.is_connected;
      }
      internal set
      {
        this.is_connected = value;
      }
    }

    public bool NoDelay
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        this.ThrowIfUdp();
        return (uint) (int) this.GetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug) > 0U;
      }
      set
      {
        this.ThrowIfDisposedAndClosed();
        this.ThrowIfUdp();
        this.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, value ? 1 : 0);
      }
    }

    public EndPoint RemoteEndPoint
    {
      get
      {
        this.ThrowIfDisposedAndClosed();
        if (!this.is_connected || this.seed_endpoint == null)
          return (EndPoint) null;
        int error;
        SocketAddress socketAddress = Socket.RemoteEndPoint_internal(this.m_Handle, (int) this.addressFamily, out error);
        if (error != 0)
          throw new SocketException(error);
        return this.seed_endpoint.Create(socketAddress);
      }
    }

    private static SocketAddress RemoteEndPoint_internal(SafeSocketHandle safeHandle, int family, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        return Socket.RemoteEndPoint_internal(safeHandle.DangerousGetHandle(), family, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern SocketAddress RemoteEndPoint_internal(IntPtr socket, int family, out int error);

    public static void Select(IList checkRead, IList checkWrite, IList checkError, int microSeconds)
    {
      List<Socket> sockets = new List<Socket>();
      Socket.AddSockets(sockets, checkRead, nameof (checkRead));
      Socket.AddSockets(sockets, checkWrite, nameof (checkWrite));
      Socket.AddSockets(sockets, checkError, nameof (checkError));
      if (sockets.Count == 3)
        throw new ArgumentNullException("checkRead, checkWrite, checkError", "All the lists are null or empty.");
      Socket[] array = sockets.ToArray();
      int error;
      Socket.Select_internal(ref array, microSeconds, out error);
      if (error != 0)
        throw new SocketException(error);
      if (array == null)
      {
        checkRead?.Clear();
        checkWrite?.Clear();
        checkError?.Clear();
      }
      else
      {
        int num1 = 0;
        int length = array.Length;
        IList list = checkRead;
        int index1 = 0;
        for (int index2 = 0; index2 < length; ++index2)
        {
          Socket socket = array[index2];
          if (socket == null)
          {
            if (list != null)
            {
              int num2 = list.Count - index1;
              for (int index3 = 0; index3 < num2; ++index3)
                list.RemoveAt(index1);
            }
            list = num1 == 0 ? checkWrite : checkError;
            index1 = 0;
            ++num1;
          }
          else
          {
            if (num1 == 1 && list == checkWrite && (!socket.is_connected && (int) socket.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Error) == 0))
              socket.is_connected = true;
            while ((Socket) list[index1] != socket)
              list.RemoveAt(index1);
            ++index1;
          }
        }
      }
    }

    private static void AddSockets(List<Socket> sockets, IList list, string name)
    {
      if (list != null)
      {
        foreach (Socket socket in (IEnumerable) list)
        {
          if (socket == null)
            throw new ArgumentNullException(name, "Contains a null element");
          sockets.Add(socket);
        }
      }
      sockets.Add((Socket) null);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Select_internal(ref Socket[] sockets, int microSeconds, out int error);

    public bool Poll(int microSeconds, SelectMode mode)
    {
      this.ThrowIfDisposedAndClosed();
      if (mode != SelectMode.SelectRead && mode != SelectMode.SelectWrite && mode != SelectMode.SelectError)
        throw new NotSupportedException("'mode' parameter is not valid.");
      int error;
      bool flag = Socket.Poll_internal(this.m_Handle, mode, microSeconds, out error);
      if (error != 0)
        throw new SocketException(error);
      if (mode == SelectMode.SelectWrite & flag && !this.is_connected && (int) this.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Error) == 0)
        this.is_connected = true;
      return flag;
    }

    private static bool Poll_internal(SafeSocketHandle safeHandle, SelectMode mode, int timeout, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        return Socket.Poll_internal(safeHandle.DangerousGetHandle(), mode, timeout, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool Poll_internal(IntPtr socket, SelectMode mode, int timeout, out int error);

    public Socket Accept()
    {
      this.ThrowIfDisposedAndClosed();
      int error = 0;
      SafeSocketHandle safe_handle = Socket.Accept_internal(this.m_Handle, out error, this.is_blocking);
      if (error != 0)
      {
        if (this.is_closed)
          error = 10004;
        throw new SocketException(error);
      }
      return new Socket(this.AddressFamily, this.SocketType, this.ProtocolType, safe_handle)
      {
        seed_endpoint = this.seed_endpoint,
        Blocking = this.Blocking
      };
    }

    internal void Accept(Socket acceptSocket)
    {
      this.ThrowIfDisposedAndClosed();
      int error = 0;
      SafeSocketHandle safeSocketHandle = Socket.Accept_internal(this.m_Handle, out error, this.is_blocking);
      if (error != 0)
      {
        if (this.is_closed)
          error = 10004;
        throw new SocketException(error);
      }
      acceptSocket.addressFamily = this.AddressFamily;
      acceptSocket.socketType = this.SocketType;
      acceptSocket.protocolType = this.ProtocolType;
      acceptSocket.m_Handle = safeSocketHandle;
      acceptSocket.is_connected = true;
      acceptSocket.seed_endpoint = this.seed_endpoint;
      acceptSocket.Blocking = this.Blocking;
    }

    public bool AcceptAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_bound)
        throw new InvalidOperationException("You must call the Bind method before performing this operation.");
      if (!this.is_listening)
        throw new InvalidOperationException("You must call the Listen method before performing this operation.");
      if (e.BufferList != null)
        throw new ArgumentException("Multiple buffers cannot be used with this method.");
      if (e.Count < 0)
        throw new ArgumentOutOfRangeException("e.Count");
      Socket acceptSocket = e.AcceptSocket;
      if (acceptSocket != null && (acceptSocket.is_bound || acceptSocket.is_connected))
        throw new InvalidOperationException("AcceptSocket: The socket must not be bound or connected.");
      this.InitSocketAsyncEventArgs(e, Socket.AcceptAsyncCallback, (object) e, SocketOperation.Accept);
      this.QueueIOSelectorJob(this.ReadSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginAcceptCallback, (IOAsyncResult) e.socket_async_result));
      return true;
    }

    public IAsyncResult BeginAccept(AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_bound || !this.is_listening)
        throw new InvalidOperationException();
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.Accept);
      this.QueueIOSelectorJob(this.ReadSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginAcceptCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public IAsyncResult BeginAccept(Socket acceptSocket, int receiveSize, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (receiveSize < 0)
        throw new ArgumentOutOfRangeException(nameof (receiveSize), "receiveSize is less than zero");
      if (acceptSocket != null)
      {
        this.ThrowIfDisposedAndClosed(acceptSocket);
        if (acceptSocket.IsBound)
          throw new InvalidOperationException();
        if (acceptSocket.ProtocolType != ProtocolType.Tcp)
          throw new SocketException(10022);
      }
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.AcceptReceive)
      {
        Buffer = new byte[receiveSize],
        Offset = 0,
        Size = receiveSize,
        SockFlags = SocketFlags.None,
        AcceptSocket = acceptSocket
      };
      this.QueueIOSelectorJob(this.ReadSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginAcceptReceiveCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public Socket EndAccept(IAsyncResult result)
    {
      byte[] buffer;
      int bytesTransferred;
      return this.EndAccept(out buffer, out bytesTransferred, result);
    }

    public Socket EndAccept(out byte[] buffer, out int bytesTransferred, IAsyncResult asyncResult)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(asyncResult, nameof (EndAccept), nameof (asyncResult));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      socketAsyncResult.CheckIfThrowDelayedException();
      buffer = socketAsyncResult.Buffer;
      bytesTransferred = socketAsyncResult.Total;
      return socketAsyncResult.AcceptedSocket;
    }

    private static SafeSocketHandle Accept_internal(SafeSocketHandle safeHandle, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return new SafeSocketHandle(Socket.Accept_internal(safeHandle.DangerousGetHandle(), out error, blocking), true);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern IntPtr Accept_internal(IntPtr sock, out int error, bool blocking);

    public void Bind(EndPoint localEP)
    {
      this.ThrowIfDisposedAndClosed();
      if (localEP == null)
        throw new ArgumentNullException(nameof (localEP));
      IPEndPoint input = localEP as IPEndPoint;
      if (input != null)
        localEP = (EndPoint) this.RemapIPEndPoint(input);
      int error;
      Socket.Bind_internal(this.m_Handle, localEP.Serialize(), out error);
      if (error != 0)
        throw new SocketException(error);
      if (error == 0)
        this.is_bound = true;
      this.seed_endpoint = localEP;
    }

    private static void Bind_internal(SafeSocketHandle safeHandle, SocketAddress sa, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.Bind_internal(safeHandle.DangerousGetHandle(), sa, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Bind_internal(IntPtr sock, SocketAddress sa, out int error);

    public void Listen(int backlog)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_bound)
        throw new SocketException(10022);
      int error;
      Socket.Listen_internal(this.m_Handle, backlog, out error);
      if (error != 0)
        throw new SocketException(error);
      this.is_listening = true;
    }

    private static void Listen_internal(SafeSocketHandle safeHandle, int backlog, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.Listen_internal(safeHandle.DangerousGetHandle(), backlog, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Listen_internal(IntPtr sock, int backlog, out int error);

    public void Connect(IPAddress address, int port)
    {
      this.Connect((EndPoint) new IPEndPoint(address, port));
    }

    public void Connect(string host, int port)
    {
      this.Connect(Dns.GetHostAddresses(host), port);
    }

    public void Connect(EndPoint remoteEP)
    {
      this.ThrowIfDisposedAndClosed();
      if (remoteEP == null)
        throw new ArgumentNullException(nameof (remoteEP));
      IPEndPoint input = remoteEP as IPEndPoint;
      if (input != null && this.socketType != SocketType.Dgram && (input.Address.Equals((object) IPAddress.Any) || input.Address.Equals((object) IPAddress.IPv6Any)))
        throw new SocketException(10049);
      if (this.is_listening)
        throw new InvalidOperationException();
      if (input != null)
        remoteEP = (EndPoint) this.RemapIPEndPoint(input);
      SocketAddress sa = remoteEP.Serialize();
      int error = 0;
      Socket.Connect_internal(this.m_Handle, sa, out error, this.is_blocking);
      if (error == 0 || error == 10035)
        this.seed_endpoint = remoteEP;
      if (error != 0)
      {
        if (this.is_closed)
          error = 10004;
        throw new SocketException(error);
      }
      this.is_connected = this.socketType != SocketType.Dgram || input == null || !input.Address.Equals((object) IPAddress.Any) && !input.Address.Equals((object) IPAddress.IPv6Any);
      this.is_bound = true;
    }

    public bool ConnectAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (this.is_listening)
        throw new InvalidOperationException("You may not perform this operation after calling the Listen method.");
      if (e.RemoteEndPoint == null)
        throw new ArgumentNullException("remoteEP");
      this.InitSocketAsyncEventArgs(e, (AsyncCallback) null, (object) e, SocketOperation.Connect);
      try
      {
        IPAddress[] addresses;
        SocketAsyncResult socketAsyncResult;
        if (!this.GetCheckedIPs(e, out addresses))
        {
          socketAsyncResult = (SocketAsyncResult) this.BeginConnect(e.RemoteEndPoint, Socket.ConnectAsyncCallback, (object) e);
        }
        else
        {
          DnsEndPoint remoteEndPoint = (DnsEndPoint) e.RemoteEndPoint;
          socketAsyncResult = (SocketAsyncResult) this.BeginConnect(addresses, remoteEndPoint.Port, Socket.ConnectAsyncCallback, (object) e);
        }
        if (socketAsyncResult.IsCompleted)
        {
          if (socketAsyncResult.CompletedSynchronously)
          {
            socketAsyncResult.CheckIfThrowDelayedException();
            return false;
          }
        }
      }
      catch (Exception ex)
      {
        e.socket_async_result.Complete(ex, true);
        return false;
      }
      return true;
    }

    public static void CancelConnectAsync(SocketAsyncEventArgs e)
    {
      if (e == null)
        throw new ArgumentNullException(nameof (e));
      if (e.in_progress == 0 || e.LastOperation != SocketAsyncOperation.Connect)
        return;
      e.current_socket.Close();
    }

    public IAsyncResult BeginConnect(string host, int port, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (host == null)
        throw new ArgumentNullException(nameof (host));
      if (this.addressFamily != AddressFamily.InterNetwork && this.addressFamily != AddressFamily.InterNetworkV6)
        throw new NotSupportedException("This method is valid only for sockets in the InterNetwork and InterNetworkV6 families");
      if (port <= 0 || port > (int) ushort.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (port), "Must be > 0 and < 65536");
      if (this.is_listening)
        throw new InvalidOperationException();
      return this.BeginConnect(Dns.GetHostAddresses(host), port, callback, state);
    }

    public IAsyncResult BeginConnect(EndPoint end_point, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (end_point == null)
        throw new ArgumentNullException(nameof (end_point));
      if (this.is_listening)
        throw new InvalidOperationException();
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.Connect)
      {
        EndPoint = end_point
      };
      if (end_point is IPEndPoint)
      {
        IPEndPoint input = (IPEndPoint) end_point;
        if (input.Address.Equals((object) IPAddress.Any) || input.Address.Equals((object) IPAddress.IPv6Any))
        {
          socketAsyncResult.Complete((Exception) new SocketException(10049), true);
          return (IAsyncResult) socketAsyncResult;
        }
        socketAsyncResult.EndPoint = end_point = (EndPoint) this.RemapIPEndPoint(input);
      }
      int error = 0;
      if (this.connect_in_progress)
      {
        this.connect_in_progress = false;
        this.m_Handle.Dispose();
        this.m_Handle = new SafeSocketHandle(this.Socket_internal(this.addressFamily, this.socketType, this.protocolType, out error), true);
        if (error != 0)
          throw new SocketException(error);
      }
      int num = this.is_blocking ? 1 : 0;
      if (num != 0)
        this.Blocking = false;
      Socket.Connect_internal(this.m_Handle, end_point.Serialize(), out error, false);
      if (num != 0)
        this.Blocking = true;
      switch (error)
      {
        case 0:
          this.is_connected = true;
          this.is_bound = true;
          socketAsyncResult.Complete(true);
          return (IAsyncResult) socketAsyncResult;
        case 10035:
        case 10036:
          this.is_connected = false;
          this.is_bound = false;
          this.connect_in_progress = true;
          IOSelector.Add(socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Write, Socket.BeginConnectCallback, (IOAsyncResult) socketAsyncResult));
          return (IAsyncResult) socketAsyncResult;
        default:
          this.is_connected = false;
          this.is_bound = false;
          socketAsyncResult.Complete((Exception) new SocketException(error), true);
          return (IAsyncResult) socketAsyncResult;
      }
    }

    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (addresses == null)
        throw new ArgumentNullException(nameof (addresses));
      if (addresses.Length == 0)
        throw new ArgumentException("Empty addresses list");
      if (this.AddressFamily != AddressFamily.InterNetwork && this.AddressFamily != AddressFamily.InterNetworkV6)
        throw new NotSupportedException("This method is only valid for addresses in the InterNetwork or InterNetworkV6 families");
      if (port <= 0 || port > (int) ushort.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (port), "Must be > 0 and < 65536");
      if (this.is_listening)
        throw new InvalidOperationException();
      SocketAsyncResult sockares = new SocketAsyncResult(this, callback, state, SocketOperation.Connect)
      {
        Addresses = addresses,
        Port = port
      };
      this.is_connected = false;
      return this.BeginMConnect(sockares);
    }

    internal IAsyncResult BeginMConnect(SocketAsyncResult sockares)
    {
      SocketAsyncResult ares = (SocketAsyncResult) null;
      Exception exception = (Exception) null;
      for (int currentAddress = sockares.CurrentAddress; currentAddress < sockares.Addresses.Length; ++currentAddress)
      {
        try
        {
          ++sockares.CurrentAddress;
          ares = (SocketAsyncResult) this.BeginConnect((EndPoint) new IPEndPoint(sockares.Addresses[currentAddress], sockares.Port), (AsyncCallback) null, (object) sockares);
          if (ares.IsCompleted)
          {
            if (ares.CompletedSynchronously)
            {
              ares.CheckIfThrowDelayedException();
              AsyncCallback callback = ares.AsyncCallback;
              if (callback != null)
              {
                ThreadPool.UnsafeQueueUserWorkItem((WaitCallback) (_ => callback((IAsyncResult) ares)), (object) null);
                break;
              }
              break;
            }
            break;
          }
          break;
        }
        catch (Exception ex)
        {
          exception = ex;
          ares = (SocketAsyncResult) null;
        }
      }
      if (ares == null)
        throw exception;
      return (IAsyncResult) sockares;
    }

    public void EndConnect(IAsyncResult result)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(result, nameof (EndConnect), nameof (result));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      socketAsyncResult.CheckIfThrowDelayedException();
    }

    private static void Connect_internal(SafeSocketHandle safeHandle, SocketAddress sa, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        Socket.Connect_internal(safeHandle.DangerousGetHandle(), sa, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Connect_internal(IntPtr sock, SocketAddress sa, out int error, bool blocking);

    private bool GetCheckedIPs(SocketAsyncEventArgs e, out IPAddress[] addresses)
    {
      addresses = (IPAddress[]) null;
      DnsEndPoint remoteEndPoint = e.RemoteEndPoint as DnsEndPoint;
      if (remoteEndPoint != null)
      {
        addresses = Dns.GetHostAddresses(remoteEndPoint.Host);
        return true;
      }
      e.ConnectByNameError = (Exception) null;
      return false;
    }

    public void Disconnect(bool reuseSocket)
    {
      this.ThrowIfDisposedAndClosed();
      int error = 0;
      Socket.Disconnect_internal(this.m_Handle, reuseSocket, out error);
      if (error != 0)
      {
        if (error == 50)
          throw new PlatformNotSupportedException();
        throw new SocketException(error);
      }
      this.is_connected = false;
      int num = reuseSocket ? 1 : 0;
    }

    public bool DisconnectAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      this.InitSocketAsyncEventArgs(e, Socket.DisconnectAsyncCallback, (object) e, SocketOperation.Disconnect);
      IOSelector.Add(e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Write, Socket.BeginDisconnectCallback, (IOAsyncResult) e.socket_async_result));
      return true;
    }

    public IAsyncResult BeginDisconnect(bool reuseSocket, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.Disconnect)
      {
        ReuseSocket = reuseSocket
      };
      IOSelector.Add(socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Write, Socket.BeginDisconnectCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public void EndDisconnect(IAsyncResult asyncResult)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(asyncResult, nameof (EndDisconnect), nameof (asyncResult));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      socketAsyncResult.CheckIfThrowDelayedException();
    }

    private static void Disconnect_internal(SafeSocketHandle safeHandle, bool reuse, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.Disconnect_internal(safeHandle.DangerousGetHandle(), reuse, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void Disconnect_internal(IntPtr sock, bool reuse, out int error);

    public int Receive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      int error;
      int num = Socket.Receive_internal(this.m_Handle, buffer, offset, size, socketFlags, out error, this.is_blocking);
      errorCode = (SocketError) error;
      if (errorCode != SocketError.Success && errorCode != SocketError.WouldBlock && errorCode != SocketError.InProgress)
      {
        this.is_connected = false;
        this.is_bound = false;
        return num;
      }
      this.is_connected = true;
      return num;
    }

    [CLSCompliant(false)]
    public int Receive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      if (buffers == null || buffers.Count == 0)
        throw new ArgumentNullException(nameof (buffers));
      int count = buffers.Count;
      Socket.WSABUF[] bufarray = new Socket.WSABUF[count];
      GCHandle[] gcHandleArray = new GCHandle[count];
      for (int index = 0; index < count; ++index)
      {
        ArraySegment<byte> buffer = buffers[index];
        if (buffer.Offset < 0 || buffer.Count < 0 || buffer.Count > buffer.Array.Length - buffer.Offset)
          throw new ArgumentOutOfRangeException("segment");
        gcHandleArray[index] = GCHandle.Alloc((object) buffer.Array, GCHandleType.Pinned);
        bufarray[index].len = buffer.Count;
        bufarray[index].buf = Marshal.UnsafeAddrOfPinnedArrayElement<byte>((M0[]) buffer.Array, buffer.Offset);
      }
      int error;
      int num;
      try
      {
        num = Socket.Receive_internal(this.m_Handle, bufarray, socketFlags, out error, this.is_blocking);
      }
      finally
      {
        for (int index = 0; index < count; ++index)
        {
          if (gcHandleArray[index].IsAllocated)
            gcHandleArray[index].Free();
        }
      }
      errorCode = (SocketError) error;
      return num;
    }

    public bool ReceiveAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (e.Buffer == null && e.BufferList == null)
        throw new NullReferenceException("Either e.Buffer or e.BufferList must be valid buffers.");
      if (e.Buffer == null)
      {
        this.InitSocketAsyncEventArgs(e, Socket.ReceiveAsyncCallback, (object) e, SocketOperation.ReceiveGeneric);
        e.socket_async_result.Buffers = e.BufferList;
        this.QueueIOSelectorJob(this.ReadSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveGenericCallback, (IOAsyncResult) e.socket_async_result));
      }
      else
      {
        this.InitSocketAsyncEventArgs(e, Socket.ReceiveAsyncCallback, (object) e, SocketOperation.Receive);
        e.socket_async_result.Buffer = e.Buffer;
        e.socket_async_result.Offset = e.Offset;
        e.socket_async_result.Size = e.Count;
        this.QueueIOSelectorJob(this.ReadSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveCallback, (IOAsyncResult) e.socket_async_result));
      }
      return true;
    }

    public IAsyncResult BeginReceive(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      errorCode = SocketError.Success;
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.Receive)
      {
        Buffer = buffer,
        Offset = offset,
        Size = size,
        SockFlags = socketFlags
      };
      this.QueueIOSelectorJob(this.ReadSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    [CLSCompliant(false)]
    public IAsyncResult BeginReceive(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (buffers == null)
        throw new ArgumentNullException(nameof (buffers));
      errorCode = SocketError.Success;
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.ReceiveGeneric)
      {
        Buffers = buffers,
        SockFlags = socketFlags
      };
      this.QueueIOSelectorJob(this.ReadSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveGenericCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public int EndReceive(IAsyncResult asyncResult, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(asyncResult, nameof (EndReceive), nameof (asyncResult));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      errorCode = socketAsyncResult.ErrorCode;
      if (errorCode != SocketError.Success && errorCode != SocketError.WouldBlock && errorCode != SocketError.InProgress)
        this.is_connected = false;
      if (errorCode == SocketError.Success)
        socketAsyncResult.CheckIfThrowDelayedException();
      return socketAsyncResult.Total;
    }

    private static int Receive_internal(SafeSocketHandle safeHandle, Socket.WSABUF[] bufarray, SocketFlags flags, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.Receive_internal(safeHandle.DangerousGetHandle(), bufarray, flags, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Receive_internal(IntPtr sock, Socket.WSABUF[] bufarray, SocketFlags flags, out int error, bool blocking);

    private static int Receive_internal(SafeSocketHandle safeHandle, byte[] buffer, int offset, int count, SocketFlags flags, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.Receive_internal(safeHandle.DangerousGetHandle(), buffer, offset, count, flags, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Receive_internal(IntPtr sock, byte[] buffer, int offset, int count, SocketFlags flags, out int error, bool blocking);

    public int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (remoteEP == null)
        throw new ArgumentNullException(nameof (remoteEP));
      SocketError errorCode;
      int from = this.ReceiveFrom(buffer, offset, size, socketFlags, ref remoteEP, out errorCode);
      if (errorCode == SocketError.Success)
        return from;
      throw new SocketException(errorCode);
    }

    internal int ReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, out SocketError errorCode)
    {
      SocketAddress sockaddr = remoteEP.Serialize();
      int error;
      int fromInternal = Socket.ReceiveFrom_internal(this.m_Handle, buffer, offset, size, socketFlags, ref sockaddr, out error, this.is_blocking);
      errorCode = (SocketError) error;
      if (errorCode != SocketError.Success)
      {
        if (errorCode != SocketError.WouldBlock && errorCode != SocketError.InProgress)
          this.is_connected = false;
        else if (errorCode == SocketError.WouldBlock && this.is_blocking)
          errorCode = SocketError.TimedOut;
        return 0;
      }
      this.is_connected = true;
      this.is_bound = true;
      if (sockaddr != null)
        remoteEP = remoteEP.Create(sockaddr);
      this.seed_endpoint = remoteEP;
      return fromInternal;
    }

    public bool ReceiveFromAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (e.BufferList != null)
        throw new NotSupportedException("Mono doesn't support using BufferList at this point.");
      if (e.RemoteEndPoint == null)
        throw new ArgumentNullException("remoteEP", "Value cannot be null.");
      this.InitSocketAsyncEventArgs(e, Socket.ReceiveFromAsyncCallback, (object) e, SocketOperation.ReceiveFrom);
      e.socket_async_result.Buffer = e.Buffer;
      e.socket_async_result.Offset = e.Offset;
      e.socket_async_result.Size = e.Count;
      e.socket_async_result.EndPoint = e.RemoteEndPoint;
      e.socket_async_result.SockFlags = e.SocketFlags;
      this.QueueIOSelectorJob(this.ReadSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveFromCallback, (IOAsyncResult) e.socket_async_result));
      return true;
    }

    public IAsyncResult BeginReceiveFrom(byte[] buffer, int offset, int size, SocketFlags socket_flags, ref EndPoint remote_end, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (remote_end == null)
        throw new ArgumentNullException(nameof (remote_end));
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.ReceiveFrom)
      {
        Buffer = buffer,
        Offset = offset,
        Size = size,
        SockFlags = socket_flags,
        EndPoint = remote_end
      };
      this.QueueIOSelectorJob(this.ReadSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Read, Socket.BeginReceiveFromCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public int EndReceiveFrom(IAsyncResult result, ref EndPoint end_point)
    {
      this.ThrowIfDisposedAndClosed();
      if (end_point == null)
        throw new ArgumentNullException("remote_end");
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(result, nameof (EndReceiveFrom), nameof (result));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      socketAsyncResult.CheckIfThrowDelayedException();
      end_point = socketAsyncResult.EndPoint;
      return socketAsyncResult.Total;
    }

    private static int ReceiveFrom_internal(SafeSocketHandle safeHandle, byte[] buffer, int offset, int count, SocketFlags flags, ref SocketAddress sockaddr, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.ReceiveFrom_internal(safeHandle.DangerousGetHandle(), buffer, offset, count, flags, ref sockaddr, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int ReceiveFrom_internal(IntPtr sock, byte[] buffer, int offset, int count, SocketFlags flags, ref SocketAddress sockaddr, out int error, bool blocking);

    [MonoTODO("Not implemented")]
    public int ReceiveMessageFrom(byte[] buffer, int offset, int size, ref SocketFlags socketFlags, ref EndPoint remoteEP, out IPPacketInformation ipPacketInformation)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (remoteEP == null)
        throw new ArgumentNullException(nameof (remoteEP));
      throw new NotImplementedException();
    }

    [MonoTODO("Not implemented")]
    public bool ReceiveMessageFromAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      throw new NotImplementedException();
    }

    [MonoTODO]
    public IAsyncResult BeginReceiveMessageFrom(byte[] buffer, int offset, int size, SocketFlags socketFlags, ref EndPoint remoteEP, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (remoteEP == null)
        throw new ArgumentNullException(nameof (remoteEP));
      throw new NotImplementedException();
    }

    [MonoTODO]
    public int EndReceiveMessageFrom(IAsyncResult asyncResult, ref SocketFlags socketFlags, ref EndPoint endPoint, out IPPacketInformation ipPacketInformation)
    {
      this.ThrowIfDisposedAndClosed();
      if (endPoint == null)
        throw new ArgumentNullException(nameof (endPoint));
      this.ValidateEndIAsyncResult(asyncResult, nameof (EndReceiveMessageFrom), nameof (asyncResult));
      throw new NotImplementedException();
    }

    public int Send(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (size == 0)
      {
        errorCode = SocketError.Success;
        return 0;
      }
      int num = 0;
      do
      {
        int error;
        num += Socket.Send_internal(this.m_Handle, buffer, offset + num, size - num, socketFlags, out error, this.is_blocking);
        errorCode = (SocketError) error;
        if (errorCode != SocketError.Success && errorCode != SocketError.WouldBlock && errorCode != SocketError.InProgress)
        {
          this.is_connected = false;
          this.is_bound = false;
          break;
        }
        this.is_connected = true;
      }
      while (num < size);
      return num;
    }

    [CLSCompliant(false)]
    public int Send(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      if (buffers == null)
        throw new ArgumentNullException(nameof (buffers));
      if (buffers.Count == 0)
        throw new ArgumentException("Buffer is empty", nameof (buffers));
      int count = buffers.Count;
      Socket.WSABUF[] bufarray = new Socket.WSABUF[count];
      GCHandle[] gcHandleArray = new GCHandle[count];
      for (int index = 0; index < count; ++index)
      {
        ArraySegment<byte> buffer = buffers[index];
        if (buffer.Offset < 0 || buffer.Count < 0 || buffer.Count > buffer.Array.Length - buffer.Offset)
          throw new ArgumentOutOfRangeException("segment");
        gcHandleArray[index] = GCHandle.Alloc((object) buffer.Array, GCHandleType.Pinned);
        bufarray[index].len = buffer.Count;
        bufarray[index].buf = Marshal.UnsafeAddrOfPinnedArrayElement<byte>((M0[]) buffer.Array, buffer.Offset);
      }
      int error;
      int num;
      try
      {
        num = Socket.Send_internal(this.m_Handle, bufarray, socketFlags, out error, this.is_blocking);
      }
      finally
      {
        for (int index = 0; index < count; ++index)
        {
          if (gcHandleArray[index].IsAllocated)
            gcHandleArray[index].Free();
        }
      }
      errorCode = (SocketError) error;
      return num;
    }

    public bool SendAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (e.Buffer == null && e.BufferList == null)
        throw new NullReferenceException("Either e.Buffer or e.BufferList must be valid buffers.");
      if (e.Buffer == null)
      {
        this.InitSocketAsyncEventArgs(e, Socket.SendAsyncCallback, (object) e, SocketOperation.SendGeneric);
        e.socket_async_result.Buffers = e.BufferList;
        this.QueueIOSelectorJob(this.WriteSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Write, Socket.BeginSendGenericCallback, (IOAsyncResult) e.socket_async_result));
      }
      else
      {
        this.InitSocketAsyncEventArgs(e, Socket.SendAsyncCallback, (object) e, SocketOperation.Send);
        e.socket_async_result.Buffer = e.Buffer;
        e.socket_async_result.Offset = e.Offset;
        e.socket_async_result.Size = e.Count;
        this.QueueIOSelectorJob(this.WriteSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendCallback((SocketAsyncResult) s, 0)), (IOAsyncResult) e.socket_async_result));
      }
      return true;
    }

    public IAsyncResult BeginSend(byte[] buffer, int offset, int size, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (!this.is_connected)
      {
        errorCode = SocketError.NotConnected;
        return (IAsyncResult) null;
      }
      errorCode = SocketError.Success;
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.Send)
      {
        Buffer = buffer,
        Offset = offset,
        Size = size,
        SockFlags = socketFlags
      };
      this.QueueIOSelectorJob(this.WriteSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendCallback((SocketAsyncResult) s, 0)), (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    private static void BeginSendCallback(SocketAsyncResult sockares, int sent_so_far)
    {
      int total;
      try
      {
        total = Socket.Send_internal(sockares.socket.m_Handle, sockares.Buffer, sockares.Offset, sockares.Size, sockares.SockFlags, out sockares.error, false);
      }
      catch (Exception ex)
      {
        sockares.Complete(ex);
        return;
      }
      if (sockares.error == 0)
      {
        sent_so_far += total;
        sockares.Offset += total;
        sockares.Size -= total;
        if (sockares.socket.CleanedUp)
        {
          sockares.Complete(total);
          return;
        }
        if (sockares.Size > 0)
        {
          IOSelector.Add(sockares.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendCallback((SocketAsyncResult) s, sent_so_far)), (IOAsyncResult) sockares));
          return;
        }
        sockares.Total = sent_so_far;
      }
      sockares.Complete(total);
    }

    [CLSCompliant(false)]
    public IAsyncResult BeginSend(IList<ArraySegment<byte>> buffers, SocketFlags socketFlags, out SocketError errorCode, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (buffers == null)
        throw new ArgumentNullException(nameof (buffers));
      if (!this.is_connected)
      {
        errorCode = SocketError.NotConnected;
        return (IAsyncResult) null;
      }
      errorCode = SocketError.Success;
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.SendGeneric)
      {
        Buffers = buffers,
        SockFlags = socketFlags
      };
      this.QueueIOSelectorJob(this.WriteSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Write, Socket.BeginSendGenericCallback, (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    public int EndSend(IAsyncResult asyncResult, out SocketError errorCode)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(asyncResult, nameof (EndSend), nameof (asyncResult));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      errorCode = socketAsyncResult.ErrorCode;
      if (errorCode != SocketError.Success && errorCode != SocketError.WouldBlock && errorCode != SocketError.InProgress)
        this.is_connected = false;
      if (errorCode == SocketError.Success)
        socketAsyncResult.CheckIfThrowDelayedException();
      return socketAsyncResult.Total;
    }

    private static int Send_internal(SafeSocketHandle safeHandle, Socket.WSABUF[] bufarray, SocketFlags flags, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.Send_internal(safeHandle.DangerousGetHandle(), bufarray, flags, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Send_internal(IntPtr sock, Socket.WSABUF[] bufarray, SocketFlags flags, out int error, bool blocking);

    private static int Send_internal(SafeSocketHandle safeHandle, byte[] buf, int offset, int count, SocketFlags flags, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.Send_internal(safeHandle.DangerousGetHandle(), buf, offset, count, flags, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int Send_internal(IntPtr sock, byte[] buf, int offset, int count, SocketFlags flags, out int error, bool blocking);

    public int SendTo(byte[] buffer, int offset, int size, SocketFlags socketFlags, EndPoint remoteEP)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      if (remoteEP == null)
        throw new ArgumentNullException(nameof (remoteEP));
      int error;
      int num = Socket.SendTo_internal(this.m_Handle, buffer, offset, size, socketFlags, remoteEP.Serialize(), out error, this.is_blocking);
      switch ((SocketError) error)
      {
        case SocketError.Success:
          this.is_connected = true;
          this.is_bound = true;
          this.seed_endpoint = remoteEP;
          return num;
        case SocketError.WouldBlock:
        case SocketError.InProgress:
          throw new SocketException(error);
        default:
          this.is_connected = false;
          goto case SocketError.WouldBlock;
      }
    }

    public bool SendToAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      if (e.BufferList != null)
        throw new NotSupportedException("Mono doesn't support using BufferList at this point.");
      if (e.RemoteEndPoint == null)
        throw new ArgumentNullException("remoteEP", "Value cannot be null.");
      this.InitSocketAsyncEventArgs(e, Socket.SendToAsyncCallback, (object) e, SocketOperation.SendTo);
      e.socket_async_result.Buffer = e.Buffer;
      e.socket_async_result.Offset = e.Offset;
      e.socket_async_result.Size = e.Count;
      e.socket_async_result.SockFlags = e.SocketFlags;
      e.socket_async_result.EndPoint = e.RemoteEndPoint;
      this.QueueIOSelectorJob(this.WriteSem, e.socket_async_result.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendToCallback((SocketAsyncResult) s, 0)), (IOAsyncResult) e.socket_async_result));
      return true;
    }

    public IAsyncResult BeginSendTo(byte[] buffer, int offset, int size, SocketFlags socket_flags, EndPoint remote_end, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      this.ThrowIfBufferNull(buffer);
      this.ThrowIfBufferOutOfRange(buffer, offset, size);
      SocketAsyncResult socketAsyncResult = new SocketAsyncResult(this, callback, state, SocketOperation.SendTo)
      {
        Buffer = buffer,
        Offset = offset,
        Size = size,
        SockFlags = socket_flags,
        EndPoint = remote_end
      };
      this.QueueIOSelectorJob(this.WriteSem, socketAsyncResult.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendToCallback((SocketAsyncResult) s, 0)), (IOAsyncResult) socketAsyncResult));
      return (IAsyncResult) socketAsyncResult;
    }

    private static void BeginSendToCallback(SocketAsyncResult sockares, int sent_so_far)
    {
      try
      {
        int num = sockares.socket.SendTo(sockares.Buffer, sockares.Offset, sockares.Size, sockares.SockFlags, sockares.EndPoint);
        if (sockares.error == 0)
        {
          sent_so_far += num;
          sockares.Offset += num;
          sockares.Size -= num;
        }
        if (sockares.Size > 0)
        {
          IOSelector.Add(sockares.Handle, new IOSelectorJob(IOOperation.Write, (IOAsyncCallback) (s => Socket.BeginSendToCallback((SocketAsyncResult) s, sent_so_far)), (IOAsyncResult) sockares));
          return;
        }
        sockares.Total = sent_so_far;
      }
      catch (Exception ex)
      {
        sockares.Complete(ex);
        return;
      }
      sockares.Complete();
    }

    public int EndSendTo(IAsyncResult result)
    {
      this.ThrowIfDisposedAndClosed();
      SocketAsyncResult socketAsyncResult = this.ValidateEndIAsyncResult(result, nameof (EndSendTo), nameof (result));
      if (!socketAsyncResult.IsCompleted)
        socketAsyncResult.AsyncWaitHandle.WaitOne();
      socketAsyncResult.CheckIfThrowDelayedException();
      return socketAsyncResult.Total;
    }

    private static int SendTo_internal(SafeSocketHandle safeHandle, byte[] buffer, int offset, int count, SocketFlags flags, SocketAddress sa, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.SendTo_internal(safeHandle.DangerousGetHandle(), buffer, offset, count, flags, sa, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int SendTo_internal(IntPtr sock, byte[] buffer, int offset, int count, SocketFlags flags, SocketAddress sa, out int error, bool blocking);

    public void SendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_connected)
        throw new NotSupportedException();
      if (!this.is_blocking)
        throw new InvalidOperationException();
      int error = 0;
      if (Socket.SendFile_internal(this.m_Handle, fileName, preBuffer, postBuffer, flags, out error, this.is_blocking) && error == 0)
        return;
      SocketException socketException = new SocketException(error);
      if (socketException.ErrorCode == 2 || socketException.ErrorCode == 3)
        throw new FileNotFoundException();
      throw socketException;
    }

    public IAsyncResult BeginSendFile(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags, AsyncCallback callback, object state)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_connected)
        throw new NotSupportedException();
      if (!System.IO.File.Exists(fileName))
        throw new FileNotFoundException();
      Socket.SendFileHandler handler = new Socket.SendFileHandler(this.SendFile);
      return (IAsyncResult) new Socket.SendFileAsyncResult(handler, handler.BeginInvoke(fileName, preBuffer, postBuffer, flags, (AsyncCallback) (ar => callback((IAsyncResult) new Socket.SendFileAsyncResult(handler, ar))), state));
    }

    public void EndSendFile(IAsyncResult asyncResult)
    {
      this.ThrowIfDisposedAndClosed();
      if (asyncResult == null)
        throw new ArgumentNullException(nameof (asyncResult));
      Socket.SendFileAsyncResult sendFileAsyncResult = asyncResult as Socket.SendFileAsyncResult;
      if (sendFileAsyncResult == null)
        throw new ArgumentException("Invalid IAsyncResult", nameof (asyncResult));
      sendFileAsyncResult.Delegate.EndInvoke(sendFileAsyncResult.Original);
    }

    private static bool SendFile_internal(SafeSocketHandle safeHandle, string filename, byte[] pre_buffer, byte[] post_buffer, TransmitFileOptions flags, out int error, bool blocking)
    {
      try
      {
        safeHandle.RegisterForBlockingSyscall();
        return Socket.SendFile_internal(safeHandle.DangerousGetHandle(), filename, pre_buffer, post_buffer, flags, out error, blocking);
      }
      finally
      {
        safeHandle.UnRegisterForBlockingSyscall();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool SendFile_internal(IntPtr sock, string filename, byte[] pre_buffer, byte[] post_buffer, TransmitFileOptions flags, out int error, bool blocking);

    [MonoTODO("Not implemented")]
    public bool SendPacketsAsync(SocketAsyncEventArgs e)
    {
      this.ThrowIfDisposedAndClosed();
      throw new NotImplementedException();
    }

    [MonoLimitation("We do not support passing sockets across processes, we merely allow this API to pass the socket across AppDomains")]
    public SocketInformation DuplicateAndClose(int targetProcessId)
    {
      SocketInformation socketInformation = new SocketInformation();
      socketInformation.Options = (SocketInformationOptions) ((this.is_listening ? 4 : 0) | (this.is_connected ? 2 : 0) | (this.is_blocking ? 0 : 1) | (this.useOverlappedIO ? 8 : 0));
      IntPtr num;
      MonoIOError monoIoError;
      if (!MonoIO.DuplicateHandle(Process.GetCurrentProcess().Handle, this.Handle, new IntPtr(targetProcessId), ref num, 0, 0, 2, ref monoIoError))
        throw MonoIO.GetException(monoIoError);
      socketInformation.ProtocolInformation = DataConverter.Pack("iiiil", new object[5]
      {
        (object) this.addressFamily,
        (object) this.socketType,
        (object) this.protocolType,
        (object) (this.is_bound ? 1 : 0),
        (object) (long) num
      });
      this.m_Handle = (SafeSocketHandle) null;
      return socketInformation;
    }

    public void GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
      this.ThrowIfDisposedAndClosed();
      if (optionValue == null)
        throw new SocketException(10014, "Error trying to dereference an invalid pointer");
      int error;
      Socket.GetSocketOption_arr_internal(this.m_Handle, optionLevel, optionName, ref optionValue, out error);
      if (error != 0)
        throw new SocketException(error);
    }

    public byte[] GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionLength)
    {
      this.ThrowIfDisposedAndClosed();
      byte[] byte_val = new byte[optionLength];
      int error;
      Socket.GetSocketOption_arr_internal(this.m_Handle, optionLevel, optionName, ref byte_val, out error);
      if (error != 0)
        throw new SocketException(error);
      return byte_val;
    }

    public object GetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName)
    {
      this.ThrowIfDisposedAndClosed();
      object obj_val;
      int error;
      Socket.GetSocketOption_obj_internal(this.m_Handle, optionLevel, optionName, out obj_val, out error);
      if (error != 0)
        throw new SocketException(error);
      switch (optionName)
      {
        case SocketOptionName.AddMembership:
        case SocketOptionName.DropMembership:
          return (object) (MulticastOption) obj_val;
        case SocketOptionName.Linger:
          return (object) (LingerOption) obj_val;
        default:
          if (obj_val is int)
            return (object) (int) obj_val;
          return obj_val;
      }
    }

    private static void GetSocketOption_arr_internal(SafeSocketHandle safeHandle, SocketOptionLevel level, SocketOptionName name, ref byte[] byte_val, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.GetSocketOption_arr_internal(safeHandle.DangerousGetHandle(), level, name, ref byte_val, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetSocketOption_arr_internal(IntPtr socket, SocketOptionLevel level, SocketOptionName name, ref byte[] byte_val, out int error);

    private static void GetSocketOption_obj_internal(SafeSocketHandle safeHandle, SocketOptionLevel level, SocketOptionName name, out object obj_val, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.GetSocketOption_obj_internal(safeHandle.DangerousGetHandle(), level, name, out obj_val, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void GetSocketOption_obj_internal(IntPtr socket, SocketOptionLevel level, SocketOptionName name, out object obj_val, out int error);

    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, byte[] optionValue)
    {
      this.ThrowIfDisposedAndClosed();
      if (optionValue == null)
        throw new SocketException(10014, "Error trying to dereference an invalid pointer");
      int error;
      Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) null, optionValue, 0, out error);
      if (error == 0)
        return;
      if (error == 10022)
        throw new ArgumentException();
      throw new SocketException(error);
    }

    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, object optionValue)
    {
      this.ThrowIfDisposedAndClosed();
      if (optionValue == null)
        throw new ArgumentNullException(nameof (optionValue));
      int error;
      if (optionLevel == SocketOptionLevel.Socket && optionName == SocketOptionName.Linger)
      {
        LingerOption lingerOption = optionValue as LingerOption;
        if (lingerOption == null)
          throw new ArgumentException("A 'LingerOption' value must be specified.", nameof (optionValue));
        Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) lingerOption, (byte[]) null, 0, out error);
      }
      else if (optionLevel == SocketOptionLevel.IP && (optionName == SocketOptionName.AddMembership || optionName == SocketOptionName.DropMembership))
      {
        MulticastOption multicastOption = optionValue as MulticastOption;
        if (multicastOption == null)
          throw new ArgumentException("A 'MulticastOption' value must be specified.", nameof (optionValue));
        Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) multicastOption, (byte[]) null, 0, out error);
      }
      else
      {
        if (optionLevel != SocketOptionLevel.IPv6 || optionName != SocketOptionName.AddMembership && optionName != SocketOptionName.DropMembership)
          throw new ArgumentException("Invalid value specified.", nameof (optionValue));
        IPv6MulticastOption ipv6MulticastOption = optionValue as IPv6MulticastOption;
        if (ipv6MulticastOption == null)
          throw new ArgumentException("A 'IPv6MulticastOption' value must be specified.", nameof (optionValue));
        Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) ipv6MulticastOption, (byte[]) null, 0, out error);
      }
      if (error == 0)
        return;
      if (error == 10022)
        throw new ArgumentException();
      throw new SocketException(error);
    }

    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, bool optionValue)
    {
      int optionValue1 = optionValue ? 1 : 0;
      this.SetSocketOption(optionLevel, optionName, optionValue1);
    }

    public void SetSocketOption(SocketOptionLevel optionLevel, SocketOptionName optionName, int optionValue)
    {
      this.ThrowIfDisposedAndClosed();
      int error;
      Socket.SetSocketOption_internal(this.m_Handle, optionLevel, optionName, (object) null, (byte[]) null, optionValue, out error);
      if (error == 0)
        return;
      if (error == 10022)
        throw new ArgumentException();
      throw new SocketException(error);
    }

    private static void SetSocketOption_internal(SafeSocketHandle safeHandle, SocketOptionLevel level, SocketOptionName name, object obj_val, byte[] byte_val, int int_val, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.SetSocketOption_internal(safeHandle.DangerousGetHandle(), level, name, obj_val, byte_val, int_val, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void SetSocketOption_internal(IntPtr socket, SocketOptionLevel level, SocketOptionName name, object obj_val, byte[] byte_val, int int_val, out int error);

    public int IOControl(int ioControlCode, byte[] optionInValue, byte[] optionOutValue)
    {
      if (this.CleanedUp)
        throw new ObjectDisposedException(this.GetType().ToString());
      int error;
      int num = Socket.IOControl_internal(this.m_Handle, ioControlCode, optionInValue, optionOutValue, out error);
      if (error != 0)
        throw new SocketException(error);
      if (num != -1)
        return num;
      throw new InvalidOperationException("Must use Blocking property instead.");
    }

    private static int IOControl_internal(SafeSocketHandle safeHandle, int ioctl_code, byte[] input, byte[] output, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        return Socket.IOControl_internal(safeHandle.DangerousGetHandle(), ioctl_code, input, output, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int IOControl_internal(IntPtr sock, int ioctl_code, byte[] input, byte[] output, out int error);

    public void Close()
    {
      this.linger_timeout = 0;
      this.Dispose();
    }

    public void Close(int timeout)
    {
      this.linger_timeout = timeout;
      this.Dispose();
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Close_internal(IntPtr socket, out int error);

    public void Shutdown(SocketShutdown how)
    {
      this.ThrowIfDisposedAndClosed();
      if (!this.is_connected)
        throw new SocketException(10057);
      int error;
      Socket.Shutdown_internal(this.m_Handle, how, out error);
      if (error != 0)
        throw new SocketException(error);
    }

    private static void Shutdown_internal(SafeSocketHandle safeHandle, SocketShutdown how, out int error)
    {
      bool success = false;
      try
      {
        safeHandle.DangerousAddRef(ref success);
        Socket.Shutdown_internal(safeHandle.DangerousGetHandle(), how, out error);
      }
      finally
      {
        if (success)
          safeHandle.DangerousRelease();
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Shutdown_internal(IntPtr socket, SocketShutdown how, out int error);

    protected virtual void Dispose(bool disposing)
    {
      if (this.CleanedUp)
        return;
      this.m_IntCleanedUp = 1;
      bool isConnected = this.is_connected;
      this.is_connected = false;
      if (this.m_Handle == null)
        return;
      this.is_closed = true;
      IntPtr handle = this.Handle;
      if (isConnected)
        this.Linger(handle);
      this.m_Handle.Dispose();
    }

    private void Linger(IntPtr handle)
    {
      if (!this.is_connected || this.linger_timeout <= 0)
        return;
      int error;
      Socket.Shutdown_internal(handle, SocketShutdown.Receive, out error);
      if (error != 0)
        return;
      int seconds = this.linger_timeout / 1000;
      int num = this.linger_timeout % 1000;
      if (num > 0)
      {
        Socket.Poll_internal(handle, SelectMode.SelectRead, num * 1000, out error);
        if (error != 0)
          return;
      }
      if (seconds <= 0)
        return;
      LingerOption lingerOption = new LingerOption(true, seconds);
      Socket.SetSocketOption_internal(handle, SocketOptionLevel.Socket, SocketOptionName.Linger, (object) lingerOption, (byte[]) null, 0, out error);
    }

    private void ThrowIfDisposedAndClosed(Socket socket)
    {
      if (socket.CleanedUp && socket.is_closed)
        throw new ObjectDisposedException(socket.GetType().ToString());
    }

    private void ThrowIfDisposedAndClosed()
    {
      if (this.CleanedUp && this.is_closed)
        throw new ObjectDisposedException(this.GetType().ToString());
    }

    private void ThrowIfBufferNull(byte[] buffer)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
    }

    private void ThrowIfBufferOutOfRange(byte[] buffer, int offset, int size)
    {
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), "offset must be >= 0");
      if (offset > buffer.Length)
        throw new ArgumentOutOfRangeException(nameof (offset), "offset must be <= buffer.Length");
      if (size < 0)
        throw new ArgumentOutOfRangeException(nameof (size), "size must be >= 0");
      if (size > buffer.Length - offset)
        throw new ArgumentOutOfRangeException(nameof (size), "size must be <= buffer.Length - offset");
    }

    private void ThrowIfUdp()
    {
      if (this.protocolType == ProtocolType.Udp)
        throw new SocketException(10042);
    }

    private SocketAsyncResult ValidateEndIAsyncResult(IAsyncResult ares, string methodName, string argName)
    {
      if (ares == null)
        throw new ArgumentNullException(argName);
      SocketAsyncResult socketAsyncResult = ares as SocketAsyncResult;
      if (socketAsyncResult == null)
        throw new ArgumentException("Invalid IAsyncResult", argName);
      if (Interlocked.CompareExchange(ref socketAsyncResult.EndCalled, 1, 0) != 1)
        return socketAsyncResult;
      throw new InvalidOperationException(methodName + " can only be called once per asynchronous operation");
    }

    private void QueueIOSelectorJob(SemaphoreSlim sem, IntPtr handle, IOSelectorJob job)
    {
      sem.WaitAsync().ContinueWith((Action<Task>) (t =>
      {
        if (this.CleanedUp)
          job.MarkDisposed();
        else
          IOSelector.Add(handle, job);
      }));
    }

    private void InitSocketAsyncEventArgs(SocketAsyncEventArgs e, AsyncCallback callback, object state, SocketOperation operation)
    {
      e.socket_async_result.Init(this, callback, state, operation);
      if (e.AcceptSocket != null)
        e.socket_async_result.AcceptSocket = e.AcceptSocket;
      e.current_socket = this;
      e.SetLastOperation(this.SocketOperationToSocketAsyncOperation(operation));
      e.SocketError = SocketError.Success;
      e.BytesTransferred = 0;
    }

    private SocketAsyncOperation SocketOperationToSocketAsyncOperation(SocketOperation op)
    {
      switch (op)
      {
        case SocketOperation.Accept:
          return SocketAsyncOperation.Accept;
        case SocketOperation.Connect:
          return SocketAsyncOperation.Connect;
        case SocketOperation.Receive:
        case SocketOperation.ReceiveGeneric:
          return SocketAsyncOperation.Receive;
        case SocketOperation.ReceiveFrom:
          return SocketAsyncOperation.ReceiveFrom;
        case SocketOperation.Send:
        case SocketOperation.SendGeneric:
          return SocketAsyncOperation.Send;
        case SocketOperation.SendTo:
          return SocketAsyncOperation.SendTo;
        case SocketOperation.Disconnect:
          return SocketAsyncOperation.Disconnect;
        default:
          throw new NotImplementedException(string.Format("Operation {0} is not implemented", (object) op));
      }
    }

    private IPEndPoint RemapIPEndPoint(IPEndPoint input)
    {
      if (this.IsDualMode && input.AddressFamily == AddressFamily.InterNetwork)
        return new IPEndPoint(input.Address.MapToIPv6(), input.Port);
      return input;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void cancel_blocking_socket_operation(Thread thread);

    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool SupportsPortReuse(ProtocolType proto);

    internal static int FamilyHint
    {
      get
      {
        int num = 0;
        if (Socket.OSSupportsIPv4)
          num = 1;
        if (Socket.OSSupportsIPv6)
          num = num == 0 ? 2 : 0;
        return num;
      }
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool IsProtocolSupported_internal(NetworkInterfaceComponent networkInterface);

    private static bool IsProtocolSupported(NetworkInterfaceComponent networkInterface)
    {
      return Socket.IsProtocolSupported_internal(networkInterface);
    }

    private delegate void SendFileHandler(string fileName, byte[] preBuffer, byte[] postBuffer, TransmitFileOptions flags);

    private sealed class SendFileAsyncResult : IAsyncResult
    {
      private IAsyncResult ares;
      private Socket.SendFileHandler d;

      public SendFileAsyncResult(Socket.SendFileHandler d, IAsyncResult ares)
      {
        this.d = d;
        this.ares = ares;
      }

      public object AsyncState
      {
        get
        {
          return this.ares.AsyncState;
        }
      }

      public WaitHandle AsyncWaitHandle
      {
        get
        {
          return this.ares.AsyncWaitHandle;
        }
      }

      public bool CompletedSynchronously
      {
        get
        {
          return this.ares.CompletedSynchronously;
        }
      }

      public bool IsCompleted
      {
        get
        {
          return this.ares.IsCompleted;
        }
      }

      public Socket.SendFileHandler Delegate
      {
        get
        {
          return this.d;
        }
      }

      public IAsyncResult Original
      {
        get
        {
          return this.ares;
        }
      }
    }

    private struct WSABUF
    {
      public int len;
      public IntPtr buf;
    }
  }
}
