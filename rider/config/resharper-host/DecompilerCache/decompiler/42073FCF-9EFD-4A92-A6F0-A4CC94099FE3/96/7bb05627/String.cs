// Decompiled with JetBrains decompiler
// Type: System.String
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 42073FCF-9EFD-4A92-A6F0-A4CC94099FE3
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;

namespace System
{
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public sealed class String : IComparable, ICloneable, IConvertible, IEnumerable, IComparable<string>, IEnumerable<char>, IEquatable<string>
  {
    [NonSerialized]
    private int m_stringLength;
    [NonSerialized]
    private char m_firstChar;
    private const int TrimHead = 0;
    private const int TrimTail = 1;
    private const int TrimBoth = 2;
    [__DynamicallyInvokable]
    public static readonly string Empty;
    private const int charPtrAlignConst = 3;
    private const int alignConst = 7;

    [__DynamicallyInvokable]
    public static string Join(string separator, params string[] value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      return string.Join(separator, value, 0, value.Length);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public static string Join(string separator, params object[] values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      if (values.Length == 0 || values[0] == null)
        return string.Empty;
      if (separator == null)
        separator = string.Empty;
      StringBuilder sb = StringBuilderCache.Acquire(16);
      string str1 = values[0].ToString();
      if (str1 != null)
        sb.Append(str1);
      for (int index = 1; index < values.Length; ++index)
      {
        sb.Append(separator);
        if (values[index] != null)
        {
          string str2 = values[index].ToString();
          if (str2 != null)
            sb.Append(str2);
        }
      }
      return StringBuilderCache.GetStringAndRelease(sb);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public static string Join<T>(string separator, IEnumerable<T> values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      if (separator == null)
        separator = string.Empty;
      using (IEnumerator<T> enumerator = values.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return string.Empty;
        StringBuilder sb = StringBuilderCache.Acquire(16);
        if ((object) enumerator.Current != null)
        {
          string str = enumerator.Current.ToString();
          if (str != null)
            sb.Append(str);
        }
        while (enumerator.MoveNext())
        {
          sb.Append(separator);
          if ((object) enumerator.Current != null)
          {
            string str = enumerator.Current.ToString();
            if (str != null)
              sb.Append(str);
          }
        }
        return StringBuilderCache.GetStringAndRelease(sb);
      }
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public static string Join(string separator, IEnumerable<string> values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      if (separator == null)
        separator = string.Empty;
      using (IEnumerator<string> enumerator = values.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          return string.Empty;
        StringBuilder sb = StringBuilderCache.Acquire(16);
        if (enumerator.Current != null)
          sb.Append(enumerator.Current);
        while (enumerator.MoveNext())
        {
          sb.Append(separator);
          if (enumerator.Current != null)
            sb.Append(enumerator.Current);
        }
        return StringBuilderCache.GetStringAndRelease(sb);
      }
    }

    internal char FirstChar
    {
      get
      {
        return this.m_firstChar;
      }
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static unsafe string Join(string separator, string[] value, int startIndex, int count)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
      if (startIndex > value.Length - count)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCountBuffer"));
      if (separator == null)
        separator = string.Empty;
      if (count == 0)
        return string.Empty;
      int num1 = 0;
      int num2 = startIndex + count - 1;
      for (int index = startIndex; index <= num2; ++index)
      {
        if (value[index] != null)
          num1 += value[index].Length;
      }
      int num3 = num1 + (count - 1) * separator.Length;
      if (num3 < 0 || num3 + 1 < 0)
        throw new OutOfMemoryException();
      if (num3 == 0)
        return string.Empty;
      string str = string.FastAllocateString(num3);
      fixed (char* buffer = &str.m_firstChar)
      {
        UnSafeCharBuffer unSafeCharBuffer = new UnSafeCharBuffer(buffer, num3);
        unSafeCharBuffer.AppendString(value[startIndex]);
        for (int index = startIndex + 1; index <= num2; ++index)
        {
          unSafeCharBuffer.AppendString(separator);
          unSafeCharBuffer.AppendString(value[index]);
        }
      }
      return str;
    }

    [SecuritySafeCritical]
    private static unsafe int CompareOrdinalIgnoreCaseHelper(string strA, string strB)
    {
      int num1 = Math.Min(strA.Length, strB.Length);
      fixed (char* chPtr1 = &strA.m_firstChar)
        fixed (char* chPtr2 = &strB.m_firstChar)
        {
          char* chPtr3 = chPtr1;
          char* chPtr4 = chPtr2;
          for (; num1 != 0; --num1)
          {
            int num2 = (int) *chPtr3;
            int num3 = (int) *chPtr4;
            if ((uint) (num2 - 97) <= 25U)
              num2 -= 32;
            if ((uint) (num3 - 97) <= 25U)
              num3 -= 32;
            if (num2 != num3)
              return num2 - num3;
            chPtr3 += 2;
            chPtr4 += 2;
          }
          return strA.Length - strB.Length;
        }
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int nativeCompareOrdinalEx(string strA, int indexA, string strB, int indexB, int count);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern unsafe int nativeCompareOrdinalIgnoreCaseWC(string strA, sbyte* strBBytes);

    [SecuritySafeCritical]
    internal static unsafe string SmallCharToUpper(string strIn)
    {
      int length = strIn.Length;
      string str = string.FastAllocateString(length);
      fixed (char* chPtr1 = &strIn.m_firstChar)
        fixed (char* chPtr2 = &str.m_firstChar)
        {
          for (int index = 0; index < length; ++index)
          {
            int num = (int) chPtr1[index];
            if ((uint) (num - 97) <= 25U)
              num -= 32;
            chPtr2[index] = (char) num;
          }
        }
      return str;
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    private static unsafe bool EqualsHelper(string strA, string strB)
    {
      int length = strA.Length;
      fixed (char* chPtr1 = &strA.m_firstChar)
        fixed (char* chPtr2 = &strB.m_firstChar)
        {
          char* chPtr3 = chPtr1;
          char* chPtr4 = chPtr2;
          while (length >= 12)
          {
            if (*(long*) chPtr3 != *(long*) chPtr4 || *(long*) (chPtr3 + 4) != *(long*) (chPtr4 + 4) || *(long*) (chPtr3 + 8) != *(long*) (chPtr4 + 8))
              return false;
            chPtr3 += 12;
            chPtr4 += 12;
            length -= 12;
          }
          while (length > 0 && *(int*) chPtr3 == *(int*) chPtr4)
          {
            chPtr3 += 2;
            chPtr4 += 2;
            length -= 2;
          }
          return length <= 0;
        }
    }

    [SecuritySafeCritical]
    private static unsafe bool EqualsIgnoreCaseAsciiHelper(string strA, string strB)
    {
      int length = strA.Length;
      fixed (char* chPtr1 = &strA.m_firstChar)
        fixed (char* chPtr2 = &strB.m_firstChar)
        {
          char* chPtr3 = chPtr1;
          char* chPtr4 = chPtr2;
          for (; length != 0; --length)
          {
            int num1 = (int) *chPtr3;
            int num2 = (int) *chPtr4;
            if (num1 != num2 && ((num1 | 32) != (num2 | 32) || (uint) ((num1 | 32) - 97) > 25U))
              return false;
            chPtr3 += 2;
            chPtr4 += 2;
          }
          return true;
        }
    }

    [SecuritySafeCritical]
    private static unsafe int CompareOrdinalHelper(string strA, string strB)
    {
      int num1 = Math.Min(strA.Length, strB.Length);
      int num2 = -1;
      fixed (char* chPtr1 = &strA.m_firstChar)
        fixed (char* chPtr2 = &strB.m_firstChar)
        {
          char* chPtr3 = chPtr1;
          char* chPtr4 = chPtr2;
          while (num1 >= 10)
          {
            if (*(int*) chPtr3 != *(int*) chPtr4)
            {
              num2 = 0;
              break;
            }
            if (*(int*) (chPtr3 + 2) != *(int*) (chPtr4 + 2))
            {
              num2 = 2;
              break;
            }
            if (*(int*) (chPtr3 + 4) != *(int*) (chPtr4 + 4))
            {
              num2 = 4;
              break;
            }
            if (*(int*) (chPtr3 + 6) != *(int*) (chPtr4 + 6))
            {
              num2 = 6;
              break;
            }
            if (*(int*) (chPtr3 + 8) != *(int*) (chPtr4 + 8))
            {
              num2 = 8;
              break;
            }
            chPtr3 += 10;
            chPtr4 += 10;
            num1 -= 10;
          }
          if (num2 != -1)
          {
            char* chPtr5 = chPtr3 + num2;
            char* chPtr6 = chPtr4 + num2;
            int num3;
            if ((num3 = (int) *chPtr5 - (int) *chPtr6) != 0)
              return num3;
            return (int) *(ushort*) ((IntPtr) chPtr5 + 2) - (int) *(ushort*) ((IntPtr) chPtr6 + 2);
          }
          while (num1 > 0 && *(int*) chPtr3 == *(int*) chPtr4)
          {
            chPtr3 += 2;
            chPtr4 += 2;
            num1 -= 2;
          }
          if (num1 <= 0)
            return strA.Length - strB.Length;
          int num4;
          if ((num4 = (int) *chPtr3 - (int) *chPtr4) != 0)
            return num4;
          return (int) *(ushort*) ((IntPtr) chPtr3 + 2) - (int) *(ushort*) ((IntPtr) chPtr4 + 2);
        }
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public override bool Equals(object obj)
    {
      if (this == null)
        throw new NullReferenceException();
      string strB = obj as string;
      if (strB == null)
        return false;
      if ((object) this == obj)
        return true;
      if (this.Length != strB.Length)
        return false;
      return string.EqualsHelper(this, strB);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public bool Equals(string value)
    {
      if (this == null)
        throw new NullReferenceException();
      if (value == null)
        return false;
      if ((object) this == (object) value)
        return true;
      if (this.Length != value.Length)
        return false;
      return string.EqualsHelper(this, value);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public bool Equals(string value, StringComparison comparisonType)
    {
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
        case StringComparison.CurrentCultureIgnoreCase:
        case StringComparison.InvariantCulture:
        case StringComparison.InvariantCultureIgnoreCase:
        case StringComparison.Ordinal:
        case StringComparison.OrdinalIgnoreCase:
          if ((object) this == (object) value)
            return true;
          if (value == null)
            return false;
          switch (comparisonType)
          {
            case StringComparison.CurrentCulture:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
            case StringComparison.CurrentCultureIgnoreCase:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
            case StringComparison.InvariantCulture:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.None) == 0;
            case StringComparison.InvariantCultureIgnoreCase:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(this, value, CompareOptions.IgnoreCase) == 0;
            case StringComparison.Ordinal:
              if (this.Length != value.Length)
                return false;
              return string.EqualsHelper(this, value);
            case StringComparison.OrdinalIgnoreCase:
              if (this.Length != value.Length)
                return false;
              if (this.IsAscii() && value.IsAscii())
                return string.EqualsIgnoreCaseAsciiHelper(this, value);
              return TextInfo.CompareOrdinalIgnoreCase(this, value) == 0;
            default:
              throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
          }
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    [__DynamicallyInvokable]
    public static bool Equals(string a, string b)
    {
      if ((object) a == (object) b)
        return true;
      if (a == null || b == null || a.Length != b.Length)
        return false;
      return string.EqualsHelper(a, b);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static bool Equals(string a, string b, StringComparison comparisonType)
    {
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
        case StringComparison.CurrentCultureIgnoreCase:
        case StringComparison.InvariantCulture:
        case StringComparison.InvariantCultureIgnoreCase:
        case StringComparison.Ordinal:
        case StringComparison.OrdinalIgnoreCase:
          if ((object) a == (object) b)
            return true;
          if (a == null || b == null)
            return false;
          switch (comparisonType)
          {
            case StringComparison.CurrentCulture:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
            case StringComparison.CurrentCultureIgnoreCase:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
            case StringComparison.InvariantCulture:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.None) == 0;
            case StringComparison.InvariantCultureIgnoreCase:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(a, b, CompareOptions.IgnoreCase) == 0;
            case StringComparison.Ordinal:
              if (a.Length != b.Length)
                return false;
              return string.EqualsHelper(a, b);
            case StringComparison.OrdinalIgnoreCase:
              if (a.Length != b.Length)
                return false;
              if (a.IsAscii() && b.IsAscii())
                return string.EqualsIgnoreCaseAsciiHelper(a, b);
              return TextInfo.CompareOrdinalIgnoreCase(a, b) == 0;
            default:
              throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
          }
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    [__DynamicallyInvokable]
    public static bool operator ==(string a, string b)
    {
      return string.Equals(a, b);
    }

    [__DynamicallyInvokable]
    public static bool operator !=(string a, string b)
    {
      return !string.Equals(a, b);
    }

    [__DynamicallyInvokable]
    [IndexerName("Chars")]
    public extern char this[int index] { [SecuritySafeCritical, __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
    {
      if (destination == null)
        throw new ArgumentNullException(nameof (destination));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
      if (sourceIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (sourceIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count > this.Length - sourceIndex)
        throw new ArgumentOutOfRangeException(nameof (sourceIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
      if (destinationIndex > destination.Length - count || destinationIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (destinationIndex), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
      if (count <= 0)
        return;
      fixed (char* chPtr1 = &this.m_firstChar)
        fixed (char* chPtr2 = destination)
          string.wstrcpy(chPtr2 + destinationIndex, chPtr1 + sourceIndex, count);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe char[] ToCharArray()
    {
      int length = this.Length;
      char[] chArray = new char[length];
      if (length > 0)
      {
        fixed (char* smem = &this.m_firstChar)
          fixed (char* dmem = chArray)
            string.wstrcpy(dmem, smem, length);
      }
      return chArray;
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe char[] ToCharArray(int startIndex, int length)
    {
      if (startIndex < 0 || startIndex > this.Length || startIndex > this.Length - length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      char[] chArray = new char[length];
      if (length > 0)
      {
        fixed (char* chPtr = &this.m_firstChar)
          fixed (char* dmem = chArray)
            string.wstrcpy(dmem, chPtr + startIndex, length);
      }
      return chArray;
    }

    [__DynamicallyInvokable]
    public static bool IsNullOrEmpty(string value)
    {
      if (value != null)
        return value.Length == 0;
      return true;
    }

    [__DynamicallyInvokable]
    public static bool IsNullOrWhiteSpace(string value)
    {
      if (value == null)
        return true;
      for (int index = 0; index < value.Length; ++index)
      {
        if (!char.IsWhiteSpace(value[index]))
          return false;
      }
      return true;
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern int InternalMarvin32HashString(string s, int strLen, long additionalEntropy);

    [SecuritySafeCritical]
    internal static bool UseRandomizedHashing()
    {
      return string.InternalUseRandomizedHashing();
    }

    [SecurityCritical]
    [SuppressUnmanagedCodeSecurity]
    [DllImport("QCall", CharSet = CharSet.Unicode)]
    private static extern bool InternalUseRandomizedHashing();

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public override unsafe int GetHashCode()
    {
      if (HashHelpers.s_UseRandomizedStringHashing)
        return string.InternalMarvin32HashString(this, this.Length, 0L);
      string str = this;
      char* chPtr1 = (char*) str;
      if ((IntPtr) chPtr1 != IntPtr.Zero)
        chPtr1 += RuntimeHelpers.OffsetToStringData;
      int num1 = 5381;
      int num2 = num1;
      char* chPtr2 = chPtr1;
      int num3;
      while ((num3 = (int) *chPtr2) != 0)
      {
        num1 = (num1 << 5) + num1 ^ num3;
        int num4 = (int) *(ushort*) ((IntPtr) chPtr2 + 2);
        if (num4 != 0)
        {
          num2 = (num2 << 5) + num2 ^ num4;
          chPtr2 += 2;
        }
        else
          break;
      }
      return num1 + num2 * 1566083941;
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    internal unsafe int GetLegacyNonRandomizedHashCode()
    {
      string str = this;
      char* chPtr1 = (char*) str;
      if ((IntPtr) chPtr1 != IntPtr.Zero)
        chPtr1 += RuntimeHelpers.OffsetToStringData;
      int num1 = 5381;
      int num2 = num1;
      char* chPtr2 = chPtr1;
      int num3;
      while ((num3 = (int) *chPtr2) != 0)
      {
        num1 = (num1 << 5) + num1 ^ num3;
        int num4 = (int) *(ushort*) ((IntPtr) chPtr2 + 2);
        if (num4 != 0)
        {
          num2 = (num2 << 5) + num2 ^ num4;
          chPtr2 += 2;
        }
        else
          break;
      }
      return num1 + num2 * 1566083941;
    }

    [__DynamicallyInvokable]
    public extern int Length { [SecuritySafeCritical, __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [__DynamicallyInvokable]
    public string[] Split(params char[] separator)
    {
      return this.SplitInternal(separator, int.MaxValue, StringSplitOptions.None);
    }

    [__DynamicallyInvokable]
    public string[] Split(char[] separator, int count)
    {
      return this.SplitInternal(separator, count, StringSplitOptions.None);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public string[] Split(char[] separator, StringSplitOptions options)
    {
      return this.SplitInternal(separator, int.MaxValue, options);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public string[] Split(char[] separator, int count, StringSplitOptions options)
    {
      return this.SplitInternal(separator, count, options);
    }

    [ComVisible(false)]
    internal string[] SplitInternal(char[] separator, int count, StringSplitOptions options)
    {
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
      switch (options)
      {
        case StringSplitOptions.None:
        case StringSplitOptions.RemoveEmptyEntries:
          bool flag = options == StringSplitOptions.RemoveEmptyEntries;
          if (count == 0 || flag && this.Length == 0)
            return new string[0];
          int[] sepList = new int[this.Length];
          int numReplaces = this.MakeSeparatorList(separator, ref sepList);
          if (numReplaces == 0 || count == 1)
            return new string[1]{ this };
          if (flag)
            return this.InternalSplitOmitEmptyEntries(sepList, (int[]) null, numReplaces, count);
          return this.InternalSplitKeepEmptyEntries(sepList, (int[]) null, numReplaces, count);
        default:
          throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", (object) options));
      }
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public string[] Split(string[] separator, StringSplitOptions options)
    {
      return this.Split(separator, int.MaxValue, options);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public string[] Split(string[] separator, int count, StringSplitOptions options)
    {
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
      switch (options)
      {
        case StringSplitOptions.None:
        case StringSplitOptions.RemoveEmptyEntries:
          bool flag = options == StringSplitOptions.RemoveEmptyEntries;
          if (separator == null || separator.Length == 0)
            return this.SplitInternal((char[]) null, count, options);
          if (count == 0 || flag && this.Length == 0)
            return new string[0];
          int[] sepList = new int[this.Length];
          int[] lengthList = new int[this.Length];
          int numReplaces = this.MakeSeparatorList(separator, ref sepList, ref lengthList);
          if (numReplaces == 0 || count == 1)
            return new string[1]{ this };
          if (flag)
            return this.InternalSplitOmitEmptyEntries(sepList, lengthList, numReplaces, count);
          return this.InternalSplitKeepEmptyEntries(sepList, lengthList, numReplaces, count);
        default:
          throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", (object) options));
      }
    }

    private string[] InternalSplitKeepEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
    {
      int startIndex = 0;
      int index1 = 0;
      --count;
      int num = numReplaces < count ? numReplaces : count;
      string[] strArray = new string[num + 1];
      for (int index2 = 0; index2 < num && startIndex < this.Length; ++index2)
      {
        strArray[index1++] = this.Substring(startIndex, sepList[index2] - startIndex);
        startIndex = sepList[index2] + (lengthList == null ? 1 : lengthList[index2]);
      }
      if (startIndex < this.Length && num >= 0)
        strArray[index1] = this.Substring(startIndex);
      else if (index1 == num)
        strArray[index1] = string.Empty;
      return strArray;
    }

    private string[] InternalSplitOmitEmptyEntries(int[] sepList, int[] lengthList, int numReplaces, int count)
    {
      int length1 = numReplaces < count ? numReplaces + 1 : count;
      string[] strArray1 = new string[length1];
      int startIndex = 0;
      int length2 = 0;
      for (int index = 0; index < numReplaces && startIndex < this.Length; ++index)
      {
        if (sepList[index] - startIndex > 0)
          strArray1[length2++] = this.Substring(startIndex, sepList[index] - startIndex);
        startIndex = sepList[index] + (lengthList == null ? 1 : lengthList[index]);
        if (length2 == count - 1)
        {
          while (index < numReplaces - 1 && startIndex == sepList[++index])
            startIndex += lengthList == null ? 1 : lengthList[index];
          break;
        }
      }
      if (startIndex < this.Length)
        strArray1[length2++] = this.Substring(startIndex);
      string[] strArray2 = strArray1;
      if (length2 != length1)
      {
        strArray2 = new string[length2];
        for (int index = 0; index < length2; ++index)
          strArray2[index] = strArray1[index];
      }
      return strArray2;
    }

    [SecuritySafeCritical]
    private unsafe int MakeSeparatorList(char[] separator, ref int[] sepList)
    {
      int num1 = 0;
      if (separator == null || separator.Length == 0)
      {
        fixed (char* chPtr = &this.m_firstChar)
        {
          for (int index = 0; index < this.Length && num1 < sepList.Length; ++index)
          {
            if (char.IsWhiteSpace(chPtr[index]))
              sepList[num1++] = index;
          }
        }
      }
      else
      {
        int length1 = sepList.Length;
        int length2 = separator.Length;
        fixed (char* chPtr1 = &this.m_firstChar)
          fixed (char* chPtr2 = separator)
          {
            for (int index = 0; index < this.Length && num1 < length1; ++index)
            {
              char* chPtr3 = chPtr2;
              int num2 = 0;
              while (num2 < length2)
              {
                if ((int) chPtr1[index] == (int) *chPtr3)
                {
                  sepList[num1++] = index;
                  break;
                }
                ++num2;
                chPtr3 += 2;
              }
            }
          }
      }
      return num1;
    }

    [SecuritySafeCritical]
    private unsafe int MakeSeparatorList(string[] separators, ref int[] sepList, ref int[] lengthList)
    {
      int index1 = 0;
      int length1 = sepList.Length;
      int length2 = separators.Length;
      fixed (char* chPtr = &this.m_firstChar)
      {
        for (int indexA = 0; indexA < this.Length && index1 < length1; ++indexA)
        {
          for (int index2 = 0; index2 < separators.Length; ++index2)
          {
            string separator = separators[index2];
            if (!string.IsNullOrEmpty(separator))
            {
              int length3 = separator.Length;
              if ((int) chPtr[indexA] == (int) separator[0] && length3 <= this.Length - indexA && (length3 == 1 || string.CompareOrdinal(this, indexA, separator, 0, length3) == 0))
              {
                sepList[index1] = indexA;
                lengthList[index1] = length3;
                ++index1;
                indexA += length3 - 1;
                break;
              }
            }
          }
        }
      }
      return index1;
    }

    [__DynamicallyInvokable]
    public string Substring(int startIndex)
    {
      return this.Substring(startIndex, this.Length - startIndex);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public string Substring(int startIndex, int length)
    {
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (startIndex > this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndexLargerThanLength"));
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
      if (startIndex > this.Length - length)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_IndexLength"));
      if (length == 0)
        return string.Empty;
      if (startIndex == 0 && length == this.Length)
        return this;
      return this.InternalSubString(startIndex, length);
    }

    [SecurityCritical]
    private unsafe string InternalSubString(int startIndex, int length)
    {
      string str = string.FastAllocateString(length);
      fixed (char* dmem = &str.m_firstChar)
        fixed (char* chPtr = &this.m_firstChar)
          string.wstrcpy(dmem, chPtr + startIndex, length);
      return str;
    }

    [__DynamicallyInvokable]
    public string Trim(params char[] trimChars)
    {
      if (trimChars == null || trimChars.Length == 0)
        return this.TrimHelper(2);
      return this.TrimHelper(trimChars, 2);
    }

    [__DynamicallyInvokable]
    public string TrimStart(params char[] trimChars)
    {
      if (trimChars == null || trimChars.Length == 0)
        return this.TrimHelper(0);
      return this.TrimHelper(trimChars, 0);
    }

    [__DynamicallyInvokable]
    public string TrimEnd(params char[] trimChars)
    {
      if (trimChars == null || trimChars.Length == 0)
        return this.TrimHelper(1);
      return this.TrimHelper(trimChars, 1);
    }

    [SecurityCritical]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern unsafe String(char* value);

    [SecurityCritical]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern unsafe String(char* value, int startIndex, int length);

    [SecurityCritical]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern unsafe String(sbyte* value);

    [SecurityCritical]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern unsafe String(sbyte* value, int startIndex, int length);

    [SecurityCritical]
    [CLSCompliant(false)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern unsafe String(sbyte* value, int startIndex, int length, Encoding enc);

    [SecurityCritical]
    private static unsafe string CreateString(sbyte* value, int startIndex, int length, Encoding enc)
    {
      if (enc == null)
        return new string(value, startIndex, length);
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (value + startIndex < value)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
      byte[] numArray = new byte[length];
      try
      {
        Buffer.Memcpy(numArray, 0, (byte*) value, startIndex, length);
      }
      catch (NullReferenceException ex)
      {
        throw new ArgumentOutOfRangeException(nameof (value), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
      }
      return enc.GetString(numArray);
    }

    [SecurityCritical]
    internal static unsafe string CreateStringFromEncoding(byte* bytes, int byteLength, Encoding encoding)
    {
      int charCount = encoding.GetCharCount(bytes, byteLength, (DecoderNLS) null);
      if (charCount == 0)
        return string.Empty;
      string str = string.FastAllocateString(charCount);
      fixed (char* chars = &str.m_firstChar)
        encoding.GetChars(bytes, byteLength, chars, charCount, (DecoderNLS) null);
      return str;
    }

    [SecuritySafeCritical]
    internal unsafe int GetBytesFromEncoding(byte* pbNativeBuffer, int cbNativeBuffer, Encoding encoding)
    {
      fixed (char* chars = &this.m_firstChar)
        return encoding.GetBytes(chars, this.m_stringLength, pbNativeBuffer, cbNativeBuffer);
    }

    [SecuritySafeCritical]
    internal unsafe int ConvertToAnsi(byte* pbNativeBuffer, int cbNativeBuffer, bool fBestFit, bool fThrowOnUnmappableChar)
    {
      uint flags = fBestFit ? 0U : 1024U;
      uint num = 0;
      int multiByte;
      fixed (char* pwzSource = &this.m_firstChar)
        multiByte = Win32Native.WideCharToMultiByte(0U, flags, pwzSource, this.Length, pbNativeBuffer, cbNativeBuffer, IntPtr.Zero, fThrowOnUnmappableChar ? new IntPtr((void*) &num) : IntPtr.Zero);
      if (num != 0U)
        throw new ArgumentException(Environment.GetResourceString("Interop_Marshal_Unmappable_Char"));
      pbNativeBuffer[multiByte] = (byte) 0;
      return multiByte;
    }

    public bool IsNormalized()
    {
      return this.IsNormalized(NormalizationForm.FormC);
    }

    [SecuritySafeCritical]
    public bool IsNormalized(NormalizationForm normalizationForm)
    {
      if (this.IsFastSort() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || (normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD)))
        return true;
      return Normalization.IsNormalized(this, normalizationForm);
    }

    public string Normalize()
    {
      return this.Normalize(NormalizationForm.FormC);
    }

    [SecuritySafeCritical]
    public string Normalize(NormalizationForm normalizationForm)
    {
      if (this.IsAscii() && (normalizationForm == NormalizationForm.FormC || normalizationForm == NormalizationForm.FormKC || (normalizationForm == NormalizationForm.FormD || normalizationForm == NormalizationForm.FormKD)))
        return this;
      return Normalization.Normalize(this, normalizationForm);
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern string FastAllocateString(int length);

    [SecuritySafeCritical]
    private static unsafe void FillStringChecked(string dest, int destPos, string src)
    {
      if (src.Length > dest.Length - destPos)
        throw new IndexOutOfRangeException();
      fixed (char* chPtr = &dest.m_firstChar)
        fixed (char* smem = &src.m_firstChar)
          string.wstrcpy(chPtr + destPos, smem, src.Length);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern String(char[] value, int startIndex, int length);

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern String(char[] value);

    [SecurityCritical]
    internal static unsafe void wstrcpy(char* dmem, char* smem, int charCount)
    {
      Buffer.Memcpy((byte*) dmem, (byte*) smem, charCount * 2);
    }

    [SecuritySafeCritical]
    private unsafe string CtorCharArray(char[] value)
    {
      if (value == null || value.Length == 0)
        return string.Empty;
      string str1 = string.FastAllocateString(value.Length);
      string str2 = str1;
      char* dmem = (char*) str2;
      if ((IntPtr) dmem != IntPtr.Zero)
        dmem += RuntimeHelpers.OffsetToStringData;
      fixed (char* smem = value)
      {
        string.wstrcpy(dmem, smem, value.Length);
        str2 = (string) null;
      }
      return str1;
    }

    [SecuritySafeCritical]
    private unsafe string CtorCharArrayStartLength(char[] value, int startIndex, int length)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
      if (startIndex > value.Length - length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (length <= 0)
        return string.Empty;
      string str1 = string.FastAllocateString(length);
      string str2 = str1;
      char* dmem = (char*) str2;
      if ((IntPtr) dmem != IntPtr.Zero)
        dmem += RuntimeHelpers.OffsetToStringData;
      fixed (char* chPtr = value)
      {
        string.wstrcpy(dmem, chPtr + startIndex, length);
        str2 = (string) null;
      }
      return str1;
    }

    [SecuritySafeCritical]
    private unsafe string CtorCharCount(char c, int count)
    {
      if (count > 0)
      {
        string str1 = string.FastAllocateString(count);
        if (c != char.MinValue)
        {
          string str2 = str1;
          char* chPtr1 = (char*) str2;
          if ((IntPtr) chPtr1 != IntPtr.Zero)
            chPtr1 += RuntimeHelpers.OffsetToStringData;
          char* chPtr2;
          for (chPtr2 = chPtr1; ((int) (uint) chPtr2 & 3) != 0 && count > 0; --count)
            *chPtr2++ = c;
          uint num = (uint) c << 16 | (uint) c;
          if (count >= 4)
          {
            count -= 4;
            do
            {
              *(int*) chPtr2 = (int) num;
              *(int*) ((IntPtr) chPtr2 + 4) = (int) num;
              chPtr2 += 4;
              count -= 4;
            }
            while (count >= 0);
          }
          if ((count & 2) != 0)
          {
            *(int*) chPtr2 = (int) num;
            chPtr2 += 2;
          }
          if ((count & 1) != 0)
            *chPtr2 = c;
          str2 = (string) null;
        }
        return str1;
      }
      if (count == 0)
        return string.Empty;
      throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_MustBeNonNegNum", (object) nameof (count)));
    }

    [SecurityCritical]
    private static unsafe int wcslen(char* ptr)
    {
      char* chPtr = ptr;
      while (((int) (uint) chPtr & 3) != 0 && *chPtr != char.MinValue)
        chPtr += 2;
      if (*chPtr != char.MinValue)
      {
        while (((int) *chPtr & (int) *(ushort*) ((IntPtr) chPtr + 2)) != 0 || *chPtr != char.MinValue && *(ushort*) ((IntPtr) chPtr + 2) != (ushort) 0)
          chPtr += 2;
      }
      while (*chPtr != char.MinValue)
        chPtr += 2;
      return (int) (chPtr - ptr);
    }

    [SecurityCritical]
    private unsafe string CtorCharPtr(char* ptr)
    {
      if ((IntPtr) ptr == IntPtr.Zero)
        return string.Empty;
      if ((UIntPtr) ptr < new UIntPtr(64000))
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeStringPtrNotAtom"));
      try
      {
        int num = string.wcslen(ptr);
        if (num == 0)
          return string.Empty;
        string str1 = string.FastAllocateString(num);
        string str2;
        try
        {
          str2 = str1;
          char* dmem = (char*) str2;
          if ((IntPtr) dmem != IntPtr.Zero)
            dmem += RuntimeHelpers.OffsetToStringData;
          string.wstrcpy(dmem, ptr, num);
        }
        finally
        {
          str2 = (string) null;
        }
        return str1;
      }
      catch (NullReferenceException ex)
      {
        throw new ArgumentOutOfRangeException(nameof (ptr), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
      }
    }

    [SecurityCritical]
    private unsafe string CtorCharPtrStartLength(char* ptr, int startIndex, int length)
    {
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      char* smem = ptr + startIndex;
      if (smem < ptr)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
      if (length == 0)
        return string.Empty;
      string str1 = string.FastAllocateString(length);
      try
      {
        string str2;
        try
        {
          str2 = str1;
          char* dmem = (char*) str2;
          if ((IntPtr) dmem != IntPtr.Zero)
            dmem += RuntimeHelpers.OffsetToStringData;
          string.wstrcpy(dmem, smem, length);
        }
        finally
        {
          str2 = (string) null;
        }
        return str1;
      }
      catch (NullReferenceException ex)
      {
        throw new ArgumentOutOfRangeException(nameof (ptr), Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
      }
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern String(char c, int count);

    [__DynamicallyInvokable]
    public static int Compare(string strA, string strB)
    {
      return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
    }

    [__DynamicallyInvokable]
    public static int Compare(string strA, string strB, bool ignoreCase)
    {
      if (ignoreCase)
        return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
      return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static int Compare(string strA, string strB, StringComparison comparisonType)
    {
      if ((uint) (comparisonType - 0) > 5U)
        throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      if ((object) strA == (object) strB)
        return 0;
      if (strA == null)
        return -1;
      if (strB == null)
        return 1;
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
          return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
        case StringComparison.CurrentCultureIgnoreCase:
          return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
        case StringComparison.InvariantCulture:
          return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.None);
        case StringComparison.InvariantCultureIgnoreCase:
          return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
        case StringComparison.Ordinal:
          if ((int) strA.m_firstChar - (int) strB.m_firstChar != 0)
            return (int) strA.m_firstChar - (int) strB.m_firstChar;
          return string.CompareOrdinalHelper(strA, strB);
        case StringComparison.OrdinalIgnoreCase:
          if (strA.IsAscii() && strB.IsAscii())
            return string.CompareOrdinalIgnoreCaseHelper(strA, strB);
          return TextInfo.CompareOrdinalIgnoreCase(strA, strB);
        default:
          throw new NotSupportedException(Environment.GetResourceString("NotSupported_StringComparison"));
      }
    }

    [__DynamicallyInvokable]
    public static int Compare(string strA, string strB, CultureInfo culture, CompareOptions options)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      return culture.CompareInfo.Compare(strA, strB, options);
    }

    public static int Compare(string strA, string strB, bool ignoreCase, CultureInfo culture)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      if (ignoreCase)
        return culture.CompareInfo.Compare(strA, strB, CompareOptions.IgnoreCase);
      return culture.CompareInfo.Compare(strA, strB, CompareOptions.None);
    }

    [__DynamicallyInvokable]
    public static int Compare(string strA, int indexA, string strB, int indexB, int length)
    {
      int length1 = length;
      int length2 = length;
      if (strA != null && strA.Length - indexA < length1)
        length1 = strA.Length - indexA;
      if (strB != null && strB.Length - indexB < length2)
        length2 = strB.Length - indexB;
      return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
    }

    public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase)
    {
      int length1 = length;
      int length2 = length;
      if (strA != null && strA.Length - indexA < length1)
        length1 = strA.Length - indexA;
      if (strB != null && strB.Length - indexB < length2)
        length2 = strB.Length - indexB;
      if (ignoreCase)
        return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.IgnoreCase);
      return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
    }

    public static int Compare(string strA, int indexA, string strB, int indexB, int length, bool ignoreCase, CultureInfo culture)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      int length1 = length;
      int length2 = length;
      if (strA != null && strA.Length - indexA < length1)
        length1 = strA.Length - indexA;
      if (strB != null && strB.Length - indexB < length2)
        length2 = strB.Length - indexB;
      if (ignoreCase)
        return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.IgnoreCase);
      return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, CompareOptions.None);
    }

    public static int Compare(string strA, int indexA, string strB, int indexB, int length, CultureInfo culture, CompareOptions options)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      int length1 = length;
      int length2 = length;
      if (strA != null && strA.Length - indexA < length1)
        length1 = strA.Length - indexA;
      if (strB != null && strB.Length - indexB < length2)
        length2 = strB.Length - indexB;
      return culture.CompareInfo.Compare(strA, indexA, length1, strB, indexB, length2, options);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static int Compare(string strA, int indexA, string strB, int indexB, int length, StringComparison comparisonType)
    {
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
        case StringComparison.CurrentCultureIgnoreCase:
        case StringComparison.InvariantCulture:
        case StringComparison.InvariantCultureIgnoreCase:
        case StringComparison.Ordinal:
        case StringComparison.OrdinalIgnoreCase:
          if (strA == null || strB == null)
          {
            if ((object) strA == (object) strB)
              return 0;
            return strA != null ? 1 : -1;
          }
          if (length < 0)
            throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NegativeLength"));
          if (indexA < 0)
            throw new ArgumentOutOfRangeException(nameof (indexA), Environment.GetResourceString("ArgumentOutOfRange_Index"));
          if (indexB < 0)
            throw new ArgumentOutOfRangeException(nameof (indexB), Environment.GetResourceString("ArgumentOutOfRange_Index"));
          if (strA.Length - indexA < 0)
            throw new ArgumentOutOfRangeException(nameof (indexA), Environment.GetResourceString("ArgumentOutOfRange_Index"));
          if (strB.Length - indexB < 0)
            throw new ArgumentOutOfRangeException(nameof (indexB), Environment.GetResourceString("ArgumentOutOfRange_Index"));
          if (length == 0 || strA == strB && indexA == indexB)
            return 0;
          int num1 = length;
          int num2 = length;
          if (strA != null && strA.Length - indexA < num1)
            num1 = strA.Length - indexA;
          if (strB != null && strB.Length - indexB < num2)
            num2 = strB.Length - indexB;
          switch (comparisonType)
          {
            case StringComparison.CurrentCulture:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.None);
            case StringComparison.CurrentCultureIgnoreCase:
              return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.IgnoreCase);
            case StringComparison.InvariantCulture:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.None);
            case StringComparison.InvariantCultureIgnoreCase:
              return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, num1, strB, indexB, num2, CompareOptions.IgnoreCase);
            case StringComparison.Ordinal:
              return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
            case StringComparison.OrdinalIgnoreCase:
              return TextInfo.CompareOrdinalIgnoreCaseEx(strA, indexA, strB, indexB, num1, num2);
            default:
              throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"));
          }
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    public int CompareTo(object value)
    {
      if (value == null)
        return 1;
      if (!(value is string))
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeString"));
      return string.Compare(this, (string) value, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int CompareTo(string strB)
    {
      if (strB == null)
        return 1;
      return CultureInfo.CurrentCulture.CompareInfo.Compare(this, strB, CompareOptions.None);
    }

    [__DynamicallyInvokable]
    public static int CompareOrdinal(string strA, string strB)
    {
      if ((object) strA == (object) strB)
        return 0;
      if (strA == null)
        return -1;
      if (strB == null)
        return 1;
      if ((int) strA.m_firstChar - (int) strB.m_firstChar != 0)
        return (int) strA.m_firstChar - (int) strB.m_firstChar;
      return string.CompareOrdinalHelper(strA, strB);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static int CompareOrdinal(string strA, int indexA, string strB, int indexB, int length)
    {
      if (strA != null && strB != null)
        return string.nativeCompareOrdinalEx(strA, indexA, strB, indexB, length);
      if ((object) strA == (object) strB)
        return 0;
      return strA != null ? 1 : -1;
    }

    [__DynamicallyInvokable]
    public bool Contains(string value)
    {
      return this.IndexOf(value, StringComparison.Ordinal) >= 0;
    }

    [__DynamicallyInvokable]
    public bool EndsWith(string value)
    {
      return this.EndsWith(value, StringComparison.CurrentCulture);
    }

    [SecuritySafeCritical]
    [ComVisible(false)]
    [__DynamicallyInvokable]
    public bool EndsWith(string value, StringComparison comparisonType)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
        case StringComparison.CurrentCultureIgnoreCase:
        case StringComparison.InvariantCulture:
        case StringComparison.InvariantCultureIgnoreCase:
        case StringComparison.Ordinal:
        case StringComparison.OrdinalIgnoreCase:
          if ((object) this == (object) value || value.Length == 0)
            return true;
          switch (comparisonType)
          {
            case StringComparison.CurrentCulture:
              return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
            case StringComparison.CurrentCultureIgnoreCase:
              return CultureInfo.CurrentCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
            case StringComparison.InvariantCulture:
              return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.None);
            case StringComparison.InvariantCultureIgnoreCase:
              return CultureInfo.InvariantCulture.CompareInfo.IsSuffix(this, value, CompareOptions.IgnoreCase);
            case StringComparison.Ordinal:
              if (this.Length >= value.Length)
                return string.nativeCompareOrdinalEx(this, this.Length - value.Length, value, 0, value.Length) == 0;
              return false;
            case StringComparison.OrdinalIgnoreCase:
              if (this.Length >= value.Length)
                return TextInfo.CompareOrdinalIgnoreCaseEx(this, this.Length - value.Length, value, 0, value.Length, value.Length) == 0;
              return false;
            default:
              throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
          }
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if ((object) this == (object) value)
        return true;
      return (culture != null ? culture : CultureInfo.CurrentCulture).CompareInfo.IsSuffix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
    }

    internal bool EndsWith(char value)
    {
      int length = this.Length;
      return length != 0 && (int) this[length - 1] == (int) value;
    }

    [__DynamicallyInvokable]
    public int IndexOf(char value)
    {
      return this.IndexOf(value, 0, this.Length);
    }

    [__DynamicallyInvokable]
    public int IndexOf(char value, int startIndex)
    {
      return this.IndexOf(value, startIndex, this.Length - startIndex);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int IndexOf(char value, int startIndex, int count);

    [__DynamicallyInvokable]
    public int IndexOfAny(char[] anyOf)
    {
      return this.IndexOfAny(anyOf, 0, this.Length);
    }

    [__DynamicallyInvokable]
    public int IndexOfAny(char[] anyOf, int startIndex)
    {
      return this.IndexOfAny(anyOf, startIndex, this.Length - startIndex);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int IndexOfAny(char[] anyOf, int startIndex, int count);

    [__DynamicallyInvokable]
    public int IndexOf(string value)
    {
      return this.IndexOf(value, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int IndexOf(string value, int startIndex)
    {
      return this.IndexOf(value, startIndex, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int IndexOf(string value, int startIndex, int count)
    {
      if (startIndex < 0 || startIndex > this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || count > this.Length - startIndex)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      return this.IndexOf(value, startIndex, count, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int IndexOf(string value, StringComparison comparisonType)
    {
      return this.IndexOf(value, 0, this.Length, comparisonType);
    }

    [__DynamicallyInvokable]
    public int IndexOf(string value, int startIndex, StringComparison comparisonType)
    {
      return this.IndexOf(value, startIndex, this.Length - startIndex, comparisonType);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public int IndexOf(string value, int startIndex, int count, StringComparison comparisonType)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (startIndex < 0 || startIndex > this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || startIndex > this.Length - count)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
          return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
        case StringComparison.CurrentCultureIgnoreCase:
          return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
        case StringComparison.InvariantCulture:
          return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
        case StringComparison.InvariantCultureIgnoreCase:
          return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
        case StringComparison.Ordinal:
          return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
        case StringComparison.OrdinalIgnoreCase:
          if (value.IsAscii() && this.IsAscii())
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
          return TextInfo.IndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(char value)
    {
      return this.LastIndexOf(value, this.Length - 1, this.Length);
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(char value, int startIndex)
    {
      return this.LastIndexOf(value, startIndex, startIndex + 1);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int LastIndexOf(char value, int startIndex, int count);

    [__DynamicallyInvokable]
    public int LastIndexOfAny(char[] anyOf)
    {
      return this.LastIndexOfAny(anyOf, this.Length - 1, this.Length);
    }

    [__DynamicallyInvokable]
    public int LastIndexOfAny(char[] anyOf, int startIndex)
    {
      return this.LastIndexOfAny(anyOf, startIndex, startIndex + 1);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int LastIndexOfAny(char[] anyOf, int startIndex, int count);

    [__DynamicallyInvokable]
    public int LastIndexOf(string value)
    {
      return this.LastIndexOf(value, this.Length - 1, this.Length, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(string value, int startIndex)
    {
      return this.LastIndexOf(value, startIndex, startIndex + 1, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(string value, int startIndex, int count)
    {
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      return this.LastIndexOf(value, startIndex, count, StringComparison.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(string value, StringComparison comparisonType)
    {
      return this.LastIndexOf(value, this.Length - 1, this.Length, comparisonType);
    }

    [__DynamicallyInvokable]
    public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
    {
      return this.LastIndexOf(value, startIndex, startIndex + 1, comparisonType);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (this.Length == 0 && (startIndex == -1 || startIndex == 0))
        return value.Length != 0 ? -1 : 0;
      if (startIndex < 0 || startIndex > this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (startIndex == this.Length)
      {
        --startIndex;
        if (count > 0)
          --count;
        if (value.Length == 0 && count >= 0 && startIndex - count + 1 >= 0)
          return startIndex;
      }
      if (count < 0 || startIndex - count + 1 < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
          return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
        case StringComparison.CurrentCultureIgnoreCase:
          return CultureInfo.CurrentCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
        case StringComparison.InvariantCulture:
          return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.None);
        case StringComparison.InvariantCultureIgnoreCase:
          return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
        case StringComparison.Ordinal:
          return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
        case StringComparison.OrdinalIgnoreCase:
          if (value.IsAscii() && this.IsAscii())
            return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
          return TextInfo.LastIndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    [__DynamicallyInvokable]
    public string PadLeft(int totalWidth)
    {
      return this.PadHelper(totalWidth, ' ', false);
    }

    [__DynamicallyInvokable]
    public string PadLeft(int totalWidth, char paddingChar)
    {
      return this.PadHelper(totalWidth, paddingChar, false);
    }

    [__DynamicallyInvokable]
    public string PadRight(int totalWidth)
    {
      return this.PadHelper(totalWidth, ' ', true);
    }

    [__DynamicallyInvokable]
    public string PadRight(int totalWidth, char paddingChar)
    {
      return this.PadHelper(totalWidth, paddingChar, true);
    }

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string PadHelper(int totalWidth, char paddingChar, bool isRightPadded);

    [__DynamicallyInvokable]
    public bool StartsWith(string value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      return this.StartsWith(value, StringComparison.CurrentCulture);
    }

    [SecuritySafeCritical]
    [ComVisible(false)]
    [__DynamicallyInvokable]
    public bool StartsWith(string value, StringComparison comparisonType)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      switch (comparisonType)
      {
        case StringComparison.CurrentCulture:
        case StringComparison.CurrentCultureIgnoreCase:
        case StringComparison.InvariantCulture:
        case StringComparison.InvariantCultureIgnoreCase:
        case StringComparison.Ordinal:
        case StringComparison.OrdinalIgnoreCase:
          if ((object) this == (object) value || value.Length == 0)
            return true;
          switch (comparisonType)
          {
            case StringComparison.CurrentCulture:
              return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
            case StringComparison.CurrentCultureIgnoreCase:
              return CultureInfo.CurrentCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
            case StringComparison.InvariantCulture:
              return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.None);
            case StringComparison.InvariantCultureIgnoreCase:
              return CultureInfo.InvariantCulture.CompareInfo.IsPrefix(this, value, CompareOptions.IgnoreCase);
            case StringComparison.Ordinal:
              if (this.Length < value.Length)
                return false;
              return string.nativeCompareOrdinalEx(this, 0, value, 0, value.Length) == 0;
            case StringComparison.OrdinalIgnoreCase:
              if (this.Length < value.Length)
                return false;
              return TextInfo.CompareOrdinalIgnoreCaseEx(this, 0, value, 0, value.Length, value.Length) == 0;
            default:
              throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
          }
        default:
          throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), nameof (comparisonType));
      }
    }

    public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if ((object) this == (object) value)
        return true;
      return (culture != null ? culture : CultureInfo.CurrentCulture).CompareInfo.IsPrefix(this, value, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
    }

    [__DynamicallyInvokable]
    public string ToLower()
    {
      return this.ToLower(CultureInfo.CurrentCulture);
    }

    public string ToLower(CultureInfo culture)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      return culture.TextInfo.ToLower(this);
    }

    [__DynamicallyInvokable]
    public string ToLowerInvariant()
    {
      return this.ToLower(CultureInfo.InvariantCulture);
    }

    [__DynamicallyInvokable]
    public string ToUpper()
    {
      return this.ToUpper(CultureInfo.CurrentCulture);
    }

    public string ToUpper(CultureInfo culture)
    {
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      return culture.TextInfo.ToUpper(this);
    }

    [__DynamicallyInvokable]
    public string ToUpperInvariant()
    {
      return this.ToUpper(CultureInfo.InvariantCulture);
    }

    [__DynamicallyInvokable]
    public override string ToString()
    {
      return this;
    }

    public string ToString(IFormatProvider provider)
    {
      return this;
    }

    public object Clone()
    {
      return (object) this;
    }

    private static bool IsBOMWhitespace(char c)
    {
      return false;
    }

    [__DynamicallyInvokable]
    public string Trim()
    {
      return this.TrimHelper(2);
    }

    [SecuritySafeCritical]
    private string TrimHelper(int trimType)
    {
      int end = this.Length - 1;
      int start = 0;
      if (trimType != 1)
      {
        start = 0;
        while (start < this.Length && (char.IsWhiteSpace(this[start]) || string.IsBOMWhitespace(this[start])))
          ++start;
      }
      if (trimType != 0)
      {
        end = this.Length - 1;
        while (end >= start && (char.IsWhiteSpace(this[end]) || string.IsBOMWhitespace(this[start])))
          --end;
      }
      return this.CreateTrimmedString(start, end);
    }

    [SecuritySafeCritical]
    private string TrimHelper(char[] trimChars, int trimType)
    {
      int end = this.Length - 1;
      int start = 0;
      if (trimType != 1)
      {
        for (start = 0; start < this.Length; ++start)
        {
          char ch = this[start];
          int index = 0;
          while (index < trimChars.Length && (int) trimChars[index] != (int) ch)
            ++index;
          if (index == trimChars.Length)
            break;
        }
      }
      if (trimType != 0)
      {
        for (end = this.Length - 1; end >= start; --end)
        {
          char ch = this[end];
          int index = 0;
          while (index < trimChars.Length && (int) trimChars[index] != (int) ch)
            ++index;
          if (index == trimChars.Length)
            break;
        }
      }
      return this.CreateTrimmedString(start, end);
    }

    [SecurityCritical]
    private string CreateTrimmedString(int start, int end)
    {
      int length = end - start + 1;
      if (length == this.Length)
        return this;
      if (length == 0)
        return string.Empty;
      return this.InternalSubString(start, length);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe string Insert(int startIndex, string value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      if (startIndex < 0 || startIndex > this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex));
      int length1 = this.Length;
      int length2 = value.Length;
      int length3 = length1 + length2;
      if (length3 == 0)
        return string.Empty;
      string str = string.FastAllocateString(length3);
      fixed (char* smem1 = &this.m_firstChar)
        fixed (char* smem2 = &value.m_firstChar)
          fixed (char* dmem = &str.m_firstChar)
          {
            string.wstrcpy(dmem, smem1, startIndex);
            string.wstrcpy(dmem + startIndex, smem2, length2);
            string.wstrcpy(dmem + startIndex + length2, smem1 + startIndex, length1 - startIndex);
          }
      return str;
    }

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string ReplaceInternal(char oldChar, char newChar);

    [__DynamicallyInvokable]
    public string Replace(char oldChar, char newChar)
    {
      return this.ReplaceInternal(oldChar, newChar);
    }

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern string ReplaceInternal(string oldValue, string newValue);

    [__DynamicallyInvokable]
    public string Replace(string oldValue, string newValue)
    {
      if (oldValue == null)
        throw new ArgumentNullException(nameof (oldValue));
      return this.ReplaceInternal(oldValue, newValue);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe string Remove(int startIndex, int count)
    {
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_NegativeCount"));
      if (count > this.Length - startIndex)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_IndexCount"));
      int length = this.Length - count;
      if (length == 0)
        return string.Empty;
      string str = string.FastAllocateString(length);
      fixed (char* smem = &this.m_firstChar)
        fixed (char* dmem = &str.m_firstChar)
        {
          string.wstrcpy(dmem, smem, startIndex);
          string.wstrcpy(dmem + startIndex, smem + startIndex + count, length - startIndex);
        }
      return str;
    }

    [__DynamicallyInvokable]
    public string Remove(int startIndex)
    {
      if (startIndex < 0)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndex"));
      if (startIndex >= this.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_StartIndexLessThanLength"));
      return this.Substring(0, startIndex);
    }

    [__DynamicallyInvokable]
    public static string Format(string format, object arg0)
    {
      return string.FormatHelper((IFormatProvider) null, format, new ParamsArray(arg0));
    }

    [__DynamicallyInvokable]
    public static string Format(string format, object arg0, object arg1)
    {
      return string.FormatHelper((IFormatProvider) null, format, new ParamsArray(arg0, arg1));
    }

    [__DynamicallyInvokable]
    public static string Format(string format, object arg0, object arg1, object arg2)
    {
      return string.FormatHelper((IFormatProvider) null, format, new ParamsArray(arg0, arg1, arg2));
    }

    [__DynamicallyInvokable]
    public static string Format(string format, params object[] args)
    {
      if (args == null)
        throw new ArgumentNullException(format == null ? nameof (format) : nameof (args));
      return string.FormatHelper((IFormatProvider) null, format, new ParamsArray(args));
    }

    [__DynamicallyInvokable]
    public static string Format(IFormatProvider provider, string format, object arg0)
    {
      return string.FormatHelper(provider, format, new ParamsArray(arg0));
    }

    [__DynamicallyInvokable]
    public static string Format(IFormatProvider provider, string format, object arg0, object arg1)
    {
      return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1));
    }

    [__DynamicallyInvokable]
    public static string Format(IFormatProvider provider, string format, object arg0, object arg1, object arg2)
    {
      return string.FormatHelper(provider, format, new ParamsArray(arg0, arg1, arg2));
    }

    [__DynamicallyInvokable]
    public static string Format(IFormatProvider provider, string format, params object[] args)
    {
      if (args == null)
        throw new ArgumentNullException(format == null ? nameof (format) : nameof (args));
      return string.FormatHelper(provider, format, new ParamsArray(args));
    }

    private static string FormatHelper(IFormatProvider provider, string format, ParamsArray args)
    {
      if (format == null)
        throw new ArgumentNullException(nameof (format));
      return StringBuilderCache.GetStringAndRelease(StringBuilderCache.Acquire(format.Length + args.Length * 8).AppendFormatHelper(provider, format, args));
    }

    [SecuritySafeCritical]
    public static unsafe string Copy(string str)
    {
      if (str == null)
        throw new ArgumentNullException(nameof (str));
      int length = str.Length;
      string str1 = string.FastAllocateString(length);
      fixed (char* dmem = &str1.m_firstChar)
        fixed (char* smem = &str.m_firstChar)
          string.wstrcpy(dmem, smem, length);
      return str1;
    }

    [__DynamicallyInvokable]
    public static string Concat(object arg0)
    {
      if (arg0 == null)
        return string.Empty;
      return arg0.ToString();
    }

    [__DynamicallyInvokable]
    public static string Concat(object arg0, object arg1)
    {
      if (arg0 == null)
        arg0 = (object) string.Empty;
      if (arg1 == null)
        arg1 = (object) string.Empty;
      return arg0.ToString() + arg1.ToString();
    }

    [__DynamicallyInvokable]
    public static string Concat(object arg0, object arg1, object arg2)
    {
      if (arg0 == null)
        arg0 = (object) string.Empty;
      if (arg1 == null)
        arg1 = (object) string.Empty;
      if (arg2 == null)
        arg2 = (object) string.Empty;
      return arg0.ToString() + arg1.ToString() + arg2.ToString();
    }

    [CLSCompliant(false)]
    public static string Concat(object arg0, object arg1, object arg2, object arg3, __arglist)
    {
      ArgIterator argIterator = new ArgIterator(__arglist);
      int length = argIterator.GetRemainingCount() + 4;
      object[] objArray = new object[length];
      objArray[0] = arg0;
      objArray[1] = arg1;
      objArray[2] = arg2;
      objArray[3] = arg3;
      for (int index = 4; index < length; ++index)
        objArray[index] = TypedReference.ToObject(argIterator.GetNextArg());
      return string.Concat(objArray);
    }

    [__DynamicallyInvokable]
    public static string Concat(params object[] args)
    {
      if (args == null)
        throw new ArgumentNullException(nameof (args));
      string[] values = new string[args.Length];
      int totalLength = 0;
      for (int index = 0; index < args.Length; ++index)
      {
        object obj = args[index];
        values[index] = obj == null ? string.Empty : obj.ToString();
        if (values[index] == null)
          values[index] = string.Empty;
        totalLength += values[index].Length;
        if (totalLength < 0)
          throw new OutOfMemoryException();
      }
      return string.ConcatArray(values, totalLength);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public static string Concat<T>(IEnumerable<T> values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      StringBuilder sb = StringBuilderCache.Acquire(16);
      using (IEnumerator<T> enumerator = values.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if ((object) enumerator.Current != null)
          {
            string str = enumerator.Current.ToString();
            if (str != null)
              sb.Append(str);
          }
        }
      }
      return StringBuilderCache.GetStringAndRelease(sb);
    }

    [ComVisible(false)]
    [__DynamicallyInvokable]
    public static string Concat(IEnumerable<string> values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      StringBuilder sb = StringBuilderCache.Acquire(16);
      using (IEnumerator<string> enumerator = values.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if (enumerator.Current != null)
            sb.Append(enumerator.Current);
        }
      }
      return StringBuilderCache.GetStringAndRelease(sb);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static string Concat(string str0, string str1)
    {
      if (string.IsNullOrEmpty(str0))
      {
        if (string.IsNullOrEmpty(str1))
          return string.Empty;
        return str1;
      }
      if (string.IsNullOrEmpty(str1))
        return str0;
      int length = str0.Length;
      string dest = string.FastAllocateString(length + str1.Length);
      string.FillStringChecked(dest, 0, str0);
      string.FillStringChecked(dest, length, str1);
      return dest;
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static string Concat(string str0, string str1, string str2)
    {
      if (str0 == null && str1 == null && str2 == null)
        return string.Empty;
      if (str0 == null)
        str0 = string.Empty;
      if (str1 == null)
        str1 = string.Empty;
      if (str2 == null)
        str2 = string.Empty;
      string dest = string.FastAllocateString(str0.Length + str1.Length + str2.Length);
      string.FillStringChecked(dest, 0, str0);
      string.FillStringChecked(dest, str0.Length, str1);
      string.FillStringChecked(dest, str0.Length + str1.Length, str2);
      return dest;
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static string Concat(string str0, string str1, string str2, string str3)
    {
      if (str0 == null && str1 == null && (str2 == null && str3 == null))
        return string.Empty;
      if (str0 == null)
        str0 = string.Empty;
      if (str1 == null)
        str1 = string.Empty;
      if (str2 == null)
        str2 = string.Empty;
      if (str3 == null)
        str3 = string.Empty;
      string dest = string.FastAllocateString(str0.Length + str1.Length + str2.Length + str3.Length);
      string.FillStringChecked(dest, 0, str0);
      string.FillStringChecked(dest, str0.Length, str1);
      string.FillStringChecked(dest, str0.Length + str1.Length, str2);
      string.FillStringChecked(dest, str0.Length + str1.Length + str2.Length, str3);
      return dest;
    }

    [SecuritySafeCritical]
    private static string ConcatArray(string[] values, int totalLength)
    {
      string dest = string.FastAllocateString(totalLength);
      int destPos = 0;
      for (int index = 0; index < values.Length; ++index)
      {
        string.FillStringChecked(dest, destPos, values[index]);
        destPos += values[index].Length;
      }
      return dest;
    }

    [__DynamicallyInvokable]
    public static string Concat(params string[] values)
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      int totalLength = 0;
      string[] values1 = new string[values.Length];
      for (int index = 0; index < values.Length; ++index)
      {
        string str = values[index];
        values1[index] = str == null ? string.Empty : str;
        totalLength += values1[index].Length;
        if (totalLength < 0)
          throw new OutOfMemoryException();
      }
      return string.ConcatArray(values1, totalLength);
    }

    [SecuritySafeCritical]
    public static string Intern(string str)
    {
      if (str == null)
        throw new ArgumentNullException(nameof (str));
      return Thread.GetDomain().GetOrInternString(str);
    }

    [SecuritySafeCritical]
    public static string IsInterned(string str)
    {
      if (str == null)
        throw new ArgumentNullException(nameof (str));
      return Thread.GetDomain().IsStringInterned(str);
    }

    public TypeCode GetTypeCode()
    {
      return TypeCode.String;
    }

    [__DynamicallyInvokable]
    bool IConvertible.ToBoolean(IFormatProvider provider)
    {
      return Convert.ToBoolean(this, provider);
    }

    [__DynamicallyInvokable]
    char IConvertible.ToChar(IFormatProvider provider)
    {
      return Convert.ToChar(this, provider);
    }

    [__DynamicallyInvokable]
    sbyte IConvertible.ToSByte(IFormatProvider provider)
    {
      return Convert.ToSByte(this, provider);
    }

    [__DynamicallyInvokable]
    byte IConvertible.ToByte(IFormatProvider provider)
    {
      return Convert.ToByte(this, provider);
    }

    [__DynamicallyInvokable]
    short IConvertible.ToInt16(IFormatProvider provider)
    {
      return Convert.ToInt16(this, provider);
    }

    [__DynamicallyInvokable]
    ushort IConvertible.ToUInt16(IFormatProvider provider)
    {
      return Convert.ToUInt16(this, provider);
    }

    [__DynamicallyInvokable]
    int IConvertible.ToInt32(IFormatProvider provider)
    {
      return Convert.ToInt32(this, provider);
    }

    [__DynamicallyInvokable]
    uint IConvertible.ToUInt32(IFormatProvider provider)
    {
      return Convert.ToUInt32(this, provider);
    }

    [__DynamicallyInvokable]
    long IConvertible.ToInt64(IFormatProvider provider)
    {
      return Convert.ToInt64(this, provider);
    }

    [__DynamicallyInvokable]
    ulong IConvertible.ToUInt64(IFormatProvider provider)
    {
      return Convert.ToUInt64(this, provider);
    }

    [__DynamicallyInvokable]
    float IConvertible.ToSingle(IFormatProvider provider)
    {
      return Convert.ToSingle(this, provider);
    }

    [__DynamicallyInvokable]
    double IConvertible.ToDouble(IFormatProvider provider)
    {
      return Convert.ToDouble(this, provider);
    }

    [__DynamicallyInvokable]
    Decimal IConvertible.ToDecimal(IFormatProvider provider)
    {
      return Convert.ToDecimal(this, provider);
    }

    [__DynamicallyInvokable]
    DateTime IConvertible.ToDateTime(IFormatProvider provider)
    {
      return Convert.ToDateTime(this, provider);
    }

    [__DynamicallyInvokable]
    object IConvertible.ToType(Type type, IFormatProvider provider)
    {
      return Convert.DefaultToType((IConvertible) this, type, provider);
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool IsFastSort();

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool IsAscii();

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern void SetTrailByte(byte data);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern bool TryGetTrailByte(out byte data);

    public CharEnumerator GetEnumerator()
    {
      return new CharEnumerator(this);
    }

    [__DynamicallyInvokable]
    IEnumerator<char> IEnumerable<char>.GetEnumerator()
    {
      return (IEnumerator<char>) new CharEnumerator(this);
    }

    [__DynamicallyInvokable]
    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new CharEnumerator(this);
    }

    [SecurityCritical]
    internal static unsafe void InternalCopy(string src, IntPtr dest, int len)
    {
      if (len == 0)
        return;
      fixed (char* chPtr = &src.m_firstChar)
        Buffer.Memcpy((byte*) (void*) dest, (byte*) chPtr, len);
    }
  }
}
