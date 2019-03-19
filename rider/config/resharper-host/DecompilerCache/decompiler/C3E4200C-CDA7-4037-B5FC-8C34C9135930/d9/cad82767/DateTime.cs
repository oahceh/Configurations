// Decompiled with JetBrains decompiler
// Type: System.DateTime
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System
{
  [__DynamicallyInvokable]
  [Serializable]
  [StructLayout(LayoutKind.Auto)]
  public struct DateTime : IComparable, IFormattable, IConvertible, ISerializable, IComparable<DateTime>, IEquatable<DateTime>
  {
    internal static readonly bool s_isLeapSecondsSupportedSystem = DateTime.IsLeapSecondsSupportedSystem();
    private static readonly int[] DaysToMonth365 = new int[13]
    {
      0,
      31,
      59,
      90,
      120,
      151,
      181,
      212,
      243,
      273,
      304,
      334,
      365
    };
    private static readonly int[] DaysToMonth366 = new int[13]
    {
      0,
      31,
      60,
      91,
      121,
      152,
      182,
      213,
      244,
      274,
      305,
      335,
      366
    };
    [__DynamicallyInvokable]
    public static readonly DateTime MinValue = new DateTime(0L, DateTimeKind.Unspecified);
    [__DynamicallyInvokable]
    public static readonly DateTime MaxValue = new DateTime(3155378975999999999L, DateTimeKind.Unspecified);
    private const long TicksPerMillisecond = 10000;
    private const long TicksPerSecond = 10000000;
    private const long TicksPerMinute = 600000000;
    private const long TicksPerHour = 36000000000;
    private const long TicksPerDay = 864000000000;
    private const int MillisPerSecond = 1000;
    private const int MillisPerMinute = 60000;
    private const int MillisPerHour = 3600000;
    private const int MillisPerDay = 86400000;
    private const int DaysPerYear = 365;
    private const int DaysPer4Years = 1461;
    private const int DaysPer100Years = 36524;
    private const int DaysPer400Years = 146097;
    private const int DaysTo1601 = 584388;
    private const int DaysTo1899 = 693593;
    internal const int DaysTo1970 = 719162;
    private const int DaysTo10000 = 3652059;
    internal const long MinTicks = 0;
    internal const long MaxTicks = 3155378975999999999;
    private const long MaxMillis = 315537897600000;
    private const long FileTimeOffset = 504911232000000000;
    private const long DoubleDateOffset = 599264352000000000;
    private const long OADateMinAsTicks = 31241376000000000;
    private const double OADateMinAsDouble = -657435.0;
    private const double OADateMaxAsDouble = 2958466.0;
    private const int DatePartYear = 0;
    private const int DatePartDayOfYear = 1;
    private const int DatePartMonth = 2;
    private const int DatePartDay = 3;
    private const ulong TicksMask = 4611686018427387903;
    private const ulong FlagsMask = 13835058055282163712;
    private const ulong LocalMask = 9223372036854775808;
    private const long TicksCeiling = 4611686018427387904;
    private const ulong KindUnspecified = 0;
    private const ulong KindUtc = 4611686018427387904;
    private const ulong KindLocal = 9223372036854775808;
    private const ulong KindLocalAmbiguousDst = 13835058055282163712;
    private const int KindShift = 62;
    private const string TicksField = "ticks";
    private const string DateDataField = "dateData";
    private ulong dateData;

    [__DynamicallyInvokable]
    public DateTime(long ticks)
    {
      if (ticks < 0L || ticks > 3155378975999999999L)
        throw new ArgumentOutOfRangeException(nameof (ticks), Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadTicks"));
      this.dateData = (ulong) ticks;
    }

    private DateTime(ulong dateData)
    {
      this.dateData = dateData;
    }

    [__DynamicallyInvokable]
    public DateTime(long ticks, DateTimeKind kind)
    {
      if (ticks < 0L || ticks > 3155378975999999999L)
        throw new ArgumentOutOfRangeException(nameof (ticks), Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadTicks"));
      switch (kind)
      {
        case DateTimeKind.Unspecified:
        case DateTimeKind.Utc:
        case DateTimeKind.Local:
          this.dateData = (ulong) (ticks | (long) kind << 62);
          break;
        default:
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDateTimeKind"), nameof (kind));
      }
    }

    internal DateTime(long ticks, DateTimeKind kind, bool isAmbiguousDst)
    {
      if (ticks < 0L || ticks > 3155378975999999999L)
        throw new ArgumentOutOfRangeException(nameof (ticks), Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadTicks"));
      this.dateData = (ulong) (ticks | (isAmbiguousDst ? -4611686018427387904L : long.MinValue));
    }

    [__DynamicallyInvokable]
    public DateTime(int year, int month, int day)
    {
      this.dateData = (ulong) DateTime.DateToTicks(year, month, day);
    }

    public DateTime(int year, int month, int day, Calendar calendar)
    {
      this = new DateTime(year, month, day, 0, 0, 0, calendar);
    }

    [__DynamicallyInvokable]
    public DateTime(int year, int month, int day, int hour, int minute, int second)
    {
      if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem && DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, minute, second, DateTimeKind.Unspecified))
        second = 59;
      this.dateData = (ulong) (DateTime.DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second));
    }

    [__DynamicallyInvokable]
    public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
    {
      switch (kind)
      {
        case DateTimeKind.Unspecified:
        case DateTimeKind.Utc:
        case DateTimeKind.Local:
          if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem && DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, minute, second, kind))
            second = 59;
          this.dateData = (ulong) (DateTime.DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second) | (long) kind << 62);
          break;
        default:
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDateTimeKind"), nameof (kind));
      }
    }

    public DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
    {
      if (calendar == null)
        throw new ArgumentNullException(nameof (calendar));
      int num = second;
      if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem)
        second = 59;
      this.dateData = (ulong) calendar.ToDateTime(year, month, day, hour, minute, second, 0).Ticks;
      if (num != 60)
        return;
      DateTime dateTime = new DateTime(this.dateData);
      if (!DateTime.IsValidTimeWithLeapSeconds(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 60, DateTimeKind.Unspecified))
        throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
    }

    [__DynamicallyInvokable]
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
      if (millisecond < 0 || millisecond >= 1000)
        throw new ArgumentOutOfRangeException(nameof (millisecond), Environment.GetResourceString("ArgumentOutOfRange_Range", (object) 0, (object) 999));
      if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem && DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, minute, second, DateTimeKind.Unspecified))
        second = 59;
      long num = DateTime.DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second) + (long) millisecond * 10000L;
      if (num < 0L || num > 3155378975999999999L)
        throw new ArgumentException(Environment.GetResourceString("Arg_DateTimeRange"));
      this.dateData = (ulong) num;
    }

    [__DynamicallyInvokable]
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
    {
      if (millisecond < 0 || millisecond >= 1000)
        throw new ArgumentOutOfRangeException(nameof (millisecond), Environment.GetResourceString("ArgumentOutOfRange_Range", (object) 0, (object) 999));
      switch (kind)
      {
        case DateTimeKind.Unspecified:
        case DateTimeKind.Utc:
        case DateTimeKind.Local:
          if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem && DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, minute, second, kind))
            second = 59;
          long num = DateTime.DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second) + (long) millisecond * 10000L;
          if (num < 0L || num > 3155378975999999999L)
            throw new ArgumentException(Environment.GetResourceString("Arg_DateTimeRange"));
          this.dateData = (ulong) (num | (long) kind << 62);
          break;
        default:
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDateTimeKind"), nameof (kind));
      }
    }

    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar)
    {
      if (calendar == null)
        throw new ArgumentNullException(nameof (calendar));
      if (millisecond < 0 || millisecond >= 1000)
        throw new ArgumentOutOfRangeException(nameof (millisecond), Environment.GetResourceString("ArgumentOutOfRange_Range", (object) 0, (object) 999));
      int num1 = second;
      if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem)
        second = 59;
      long num2 = calendar.ToDateTime(year, month, day, hour, minute, second, 0).Ticks + (long) millisecond * 10000L;
      if (num2 < 0L || num2 > 3155378975999999999L)
        throw new ArgumentException(Environment.GetResourceString("Arg_DateTimeRange"));
      this.dateData = (ulong) num2;
      if (num1 != 60)
        return;
      DateTime dateTime = new DateTime(this.dateData);
      if (!DateTime.IsValidTimeWithLeapSeconds(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 60, DateTimeKind.Unspecified))
        throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
    }

    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
    {
      if (calendar == null)
        throw new ArgumentNullException(nameof (calendar));
      if (millisecond < 0 || millisecond >= 1000)
        throw new ArgumentOutOfRangeException(nameof (millisecond), Environment.GetResourceString("ArgumentOutOfRange_Range", (object) 0, (object) 999));
      switch (kind)
      {
        case DateTimeKind.Unspecified:
        case DateTimeKind.Utc:
        case DateTimeKind.Local:
          int num1 = second;
          if (second == 60 && DateTime.s_isLeapSecondsSupportedSystem)
            second = 59;
          long num2 = calendar.ToDateTime(year, month, day, hour, minute, second, 0).Ticks + (long) millisecond * 10000L;
          if (num2 < 0L || num2 > 3155378975999999999L)
            throw new ArgumentException(Environment.GetResourceString("Arg_DateTimeRange"));
          this.dateData = (ulong) (num2 | (long) kind << 62);
          if (num1 != 60)
            break;
          DateTime dateTime = new DateTime(this.dateData);
          if (DateTime.IsValidTimeWithLeapSeconds(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 60, kind))
            break;
          throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
        default:
          throw new ArgumentException(Environment.GetResourceString("Argument_InvalidDateTimeKind"), nameof (kind));
      }
    }

    private DateTime(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      bool flag1 = false;
      bool flag2 = false;
      long num1 = 0;
      ulong num2 = 0;
      SerializationInfoEnumerator enumerator = info.GetEnumerator();
      while (enumerator.MoveNext())
      {
        string name = enumerator.Name;
        if (!(name == "ticks"))
        {
          if (name == nameof (dateData))
          {
            num2 = Convert.ToUInt64(enumerator.Value, (IFormatProvider) CultureInfo.InvariantCulture);
            flag2 = true;
          }
        }
        else
        {
          num1 = Convert.ToInt64(enumerator.Value, (IFormatProvider) CultureInfo.InvariantCulture);
          flag1 = true;
        }
      }
      if (flag2)
      {
        this.dateData = num2;
      }
      else
      {
        if (!flag1)
          throw new SerializationException(Environment.GetResourceString("Serialization_MissingDateTimeData"));
        this.dateData = (ulong) num1;
      }
      long internalTicks = this.InternalTicks;
      if (internalTicks < 0L || internalTicks > 3155378975999999999L)
        throw new SerializationException(Environment.GetResourceString("Serialization_DateTimeTicksOutOfRange"));
    }

    internal long InternalTicks
    {
      get
      {
        return (long) this.dateData & 4611686018427387903L;
      }
    }

    private ulong InternalKind
    {
      get
      {
        return this.dateData & 13835058055282163712UL;
      }
    }

    [__DynamicallyInvokable]
    public DateTime Add(TimeSpan value)
    {
      return this.AddTicks(value._ticks);
    }

    private DateTime Add(double value, int scale)
    {
      long num = (long) (value * (double) scale + (value >= 0.0 ? 0.5 : -0.5));
      if (num <= -315537897600000L || num >= 315537897600000L)
        throw new ArgumentOutOfRangeException(nameof (value), Environment.GetResourceString("ArgumentOutOfRange_AddValue"));
      return this.AddTicks(num * 10000L);
    }

    [__DynamicallyInvokable]
    public DateTime AddDays(double value)
    {
      return this.Add(value, 86400000);
    }

    [__DynamicallyInvokable]
    public DateTime AddHours(double value)
    {
      return this.Add(value, 3600000);
    }

    [__DynamicallyInvokable]
    public DateTime AddMilliseconds(double value)
    {
      return this.Add(value, 1);
    }

    [__DynamicallyInvokable]
    public DateTime AddMinutes(double value)
    {
      return this.Add(value, 60000);
    }

    [__DynamicallyInvokable]
    public DateTime AddMonths(int months)
    {
      if (months < -120000 || months > 120000)
        throw new ArgumentOutOfRangeException(nameof (months), Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadMonths"));
      int year1;
      int month;
      int day;
      this.GetDatePart(out year1, out month, out day);
      int num1 = month - 1 + months;
      int year2;
      if (num1 >= 0)
      {
        month = num1 % 12 + 1;
        year2 = year1 + num1 / 12;
      }
      else
      {
        month = 12 + (num1 + 1) % 12;
        year2 = year1 + (num1 - 11) / 12;
      }
      if (year2 < 1 || year2 > 9999)
        throw new ArgumentOutOfRangeException(nameof (months), Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
      int num2 = DateTime.DaysInMonth(year2, month);
      if (day > num2)
        day = num2;
      return new DateTime((ulong) (DateTime.DateToTicks(year2, month, day) + this.InternalTicks % 864000000000L) | this.InternalKind);
    }

    [__DynamicallyInvokable]
    public DateTime AddSeconds(double value)
    {
      return this.Add(value, 1000);
    }

    [__DynamicallyInvokable]
    public DateTime AddTicks(long value)
    {
      long internalTicks = this.InternalTicks;
      if (value > 3155378975999999999L - internalTicks || value < -internalTicks)
        throw new ArgumentOutOfRangeException(nameof (value), Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
      return new DateTime((ulong) (internalTicks + value) | this.InternalKind);
    }

    [__DynamicallyInvokable]
    public DateTime AddYears(int value)
    {
      if (value < -10000 || value > 10000)
        throw new ArgumentOutOfRangeException("years", Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadYears"));
      return this.AddMonths(value * 12);
    }

    [__DynamicallyInvokable]
    public static int Compare(DateTime t1, DateTime t2)
    {
      long internalTicks1 = t1.InternalTicks;
      long internalTicks2 = t2.InternalTicks;
      if (internalTicks1 > internalTicks2)
        return 1;
      return internalTicks1 < internalTicks2 ? -1 : 0;
    }

    public int CompareTo(object value)
    {
      if (value == null)
        return 1;
      if (!(value is DateTime))
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDateTime"));
      long internalTicks1 = ((DateTime) value).InternalTicks;
      long internalTicks2 = this.InternalTicks;
      if (internalTicks2 > internalTicks1)
        return 1;
      return internalTicks2 < internalTicks1 ? -1 : 0;
    }

    [__DynamicallyInvokable]
    public int CompareTo(DateTime value)
    {
      long internalTicks1 = value.InternalTicks;
      long internalTicks2 = this.InternalTicks;
      if (internalTicks2 > internalTicks1)
        return 1;
      return internalTicks2 < internalTicks1 ? -1 : 0;
    }

    private static long DateToTicks(int year, int month, int day)
    {
      if (year >= 1 && year <= 9999 && (month >= 1 && month <= 12))
      {
        int[] numArray = DateTime.IsLeapYear(year) ? DateTime.DaysToMonth366 : DateTime.DaysToMonth365;
        if (day >= 1 && day <= numArray[month] - numArray[month - 1])
        {
          int num = year - 1;
          return (long) (num * 365 + num / 4 - num / 100 + num / 400 + numArray[month - 1] + day - 1) * 864000000000L;
        }
      }
      throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_BadYearMonthDay"));
    }

    private static long TimeToTicks(int hour, int minute, int second)
    {
      if (hour >= 0 && hour < 24 && (minute >= 0 && minute < 60) && (second >= 0 && second < 60))
        return TimeSpan.TimeToTicks(hour, minute, second);
      throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_BadHourMinuteSecond"));
    }

    [__DynamicallyInvokable]
    public static int DaysInMonth(int year, int month)
    {
      if (month < 1 || month > 12)
        throw new ArgumentOutOfRangeException(nameof (month), Environment.GetResourceString("ArgumentOutOfRange_Month"));
      int[] numArray = DateTime.IsLeapYear(year) ? DateTime.DaysToMonth366 : DateTime.DaysToMonth365;
      return numArray[month] - numArray[month - 1];
    }

    internal static long DoubleDateToTicks(double value)
    {
      if (value >= 2958466.0 || value <= -657435.0)
        throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateInvalid"));
      long num1 = (long) (value * 86400000.0 + (value >= 0.0 ? 0.5 : -0.5));
      if (num1 < 0L)
        num1 -= num1 % 86400000L * 2L;
      long num2 = num1 + 59926435200000L;
      if (num2 < 0L || num2 >= 315537897600000L)
        throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateScale"));
      return num2 * 10000L;
    }

    [SecurityCritical]
    [SuppressUnmanagedCodeSecurity]
    [DllImport("QCall", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool LegacyParseMode();

    [SecurityCritical]
    [SuppressUnmanagedCodeSecurity]
    [DllImport("QCall", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool EnableAmPmParseAdjustment();

    [__DynamicallyInvokable]
    public override bool Equals(object value)
    {
      if (value is DateTime)
        return this.InternalTicks == ((DateTime) value).InternalTicks;
      return false;
    }

    [__DynamicallyInvokable]
    public bool Equals(DateTime value)
    {
      return this.InternalTicks == value.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool Equals(DateTime t1, DateTime t2)
    {
      return t1.InternalTicks == t2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static DateTime FromBinary(long dateData)
    {
      if ((dateData & long.MinValue) == 0L)
        return DateTime.FromBinaryRaw(dateData);
      long ticks1 = dateData & 4611686018427387903L;
      if (ticks1 > 4611685154427387904L)
        ticks1 -= 4611686018427387904L;
      bool isAmbiguousLocalDst = false;
      long ticks2;
      if (ticks1 < 0L)
        ticks2 = TimeZoneInfo.GetLocalUtcOffset(DateTime.MinValue, TimeZoneInfoOptions.NoThrowOnInvalidTime).Ticks;
      else if (ticks1 > 3155378975999999999L)
      {
        ticks2 = TimeZoneInfo.GetLocalUtcOffset(DateTime.MaxValue, TimeZoneInfoOptions.NoThrowOnInvalidTime).Ticks;
      }
      else
      {
        DateTime time = new DateTime(ticks1, DateTimeKind.Utc);
        bool isDaylightSavings = false;
        ticks2 = TimeZoneInfo.GetUtcOffsetFromUtc(time, TimeZoneInfo.Local, out isDaylightSavings, out isAmbiguousLocalDst).Ticks;
      }
      long ticks3 = ticks1 + ticks2;
      if (ticks3 < 0L)
        ticks3 += 864000000000L;
      if (ticks3 < 0L || ticks3 > 3155378975999999999L)
        throw new ArgumentException(Environment.GetResourceString("Argument_DateTimeBadBinaryData"), nameof (dateData));
      return new DateTime(ticks3, DateTimeKind.Local, isAmbiguousLocalDst);
    }

    internal static DateTime FromBinaryRaw(long dateData)
    {
      long num = dateData & 4611686018427387903L;
      if (num < 0L || num > 3155378975999999999L)
        throw new ArgumentException(Environment.GetResourceString("Argument_DateTimeBadBinaryData"), nameof (dateData));
      return new DateTime((ulong) dateData);
    }

    [__DynamicallyInvokable]
    public static DateTime FromFileTime(long fileTime)
    {
      return DateTime.FromFileTimeUtc(fileTime).ToLocalTime();
    }

    [__DynamicallyInvokable]
    public static DateTime FromFileTimeUtc(long fileTime)
    {
      if (fileTime < 0L || fileTime > 2650467743999999999L)
        throw new ArgumentOutOfRangeException(nameof (fileTime), Environment.GetResourceString("ArgumentOutOfRange_FileTimeInvalid"));
      if (DateTime.s_isLeapSecondsSupportedSystem)
        return DateTime.InternalFromFileTime(fileTime);
      return new DateTime(fileTime + 504911232000000000L, DateTimeKind.Utc);
    }

    [__DynamicallyInvokable]
    public static DateTime FromOADate(double d)
    {
      return new DateTime(DateTime.DoubleDateToTicks(d), DateTimeKind.Unspecified);
    }

    [SecurityCritical]
    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      info.AddValue("ticks", this.InternalTicks);
      info.AddValue("dateData", this.dateData);
    }

    [__DynamicallyInvokable]
    public bool IsDaylightSavingTime()
    {
      if (this.Kind == DateTimeKind.Utc)
        return false;
      return TimeZoneInfo.Local.IsDaylightSavingTime(this, TimeZoneInfoOptions.NoThrowOnInvalidTime);
    }

    [__DynamicallyInvokable]
    public static DateTime SpecifyKind(DateTime value, DateTimeKind kind)
    {
      return new DateTime(value.InternalTicks, kind);
    }

    [__DynamicallyInvokable]
    public long ToBinary()
    {
      if (this.Kind != DateTimeKind.Local)
        return (long) this.dateData;
      long num = this.Ticks - TimeZoneInfo.GetLocalUtcOffset(this, TimeZoneInfoOptions.NoThrowOnInvalidTime).Ticks;
      if (num < 0L)
        num = 4611686018427387904L + num;
      return num | long.MinValue;
    }

    internal long ToBinaryRaw()
    {
      return (long) this.dateData;
    }

    [__DynamicallyInvokable]
    public DateTime Date
    {
      [__DynamicallyInvokable] get
      {
        long internalTicks = this.InternalTicks;
        return new DateTime((ulong) (internalTicks - internalTicks % 864000000000L) | this.InternalKind);
      }
    }

    private int GetDatePart(int part)
    {
      int num1 = (int) (this.InternalTicks / 864000000000L);
      int num2 = num1 / 146097;
      int num3 = num1 - num2 * 146097;
      int num4 = num3 / 36524;
      if (num4 == 4)
        num4 = 3;
      int num5 = num3 - num4 * 36524;
      int num6 = num5 / 1461;
      int num7 = num5 - num6 * 1461;
      int num8 = num7 / 365;
      if (num8 == 4)
        num8 = 3;
      if (part == 0)
        return num2 * 400 + num4 * 100 + num6 * 4 + num8 + 1;
      int num9 = num7 - num8 * 365;
      if (part == 1)
        return num9 + 1;
      int[] numArray = num8 == 3 && (num6 != 24 || num4 == 3) ? DateTime.DaysToMonth366 : DateTime.DaysToMonth365;
      int index = num9 >> 6;
      while (num9 >= numArray[index])
        ++index;
      if (part == 2)
        return index;
      return num9 - numArray[index - 1] + 1;
    }

    internal void GetDatePart(out int year, out int month, out int day)
    {
      int num1 = (int) (this.InternalTicks / 864000000000L);
      int num2 = num1 / 146097;
      int num3 = num1 - num2 * 146097;
      int num4 = num3 / 36524;
      if (num4 == 4)
        num4 = 3;
      int num5 = num3 - num4 * 36524;
      int num6 = num5 / 1461;
      int num7 = num5 - num6 * 1461;
      int num8 = num7 / 365;
      if (num8 == 4)
        num8 = 3;
      year = num2 * 400 + num4 * 100 + num6 * 4 + num8 + 1;
      int num9 = num7 - num8 * 365;
      int[] numArray = num8 == 3 && (num6 != 24 || num4 == 3) ? DateTime.DaysToMonth366 : DateTime.DaysToMonth365;
      int index = (num9 >> 5) + 1;
      while (num9 >= numArray[index])
        ++index;
      month = index;
      day = num9 - numArray[index - 1] + 1;
    }

    [__DynamicallyInvokable]
    public int Day
    {
      [__DynamicallyInvokable] get
      {
        return this.GetDatePart(3);
      }
    }

    [__DynamicallyInvokable]
    public DayOfWeek DayOfWeek
    {
      [__DynamicallyInvokable] get
      {
        return (DayOfWeek) ((this.InternalTicks / 864000000000L + 1L) % 7L);
      }
    }

    [__DynamicallyInvokable]
    public int DayOfYear
    {
      [__DynamicallyInvokable] get
      {
        return this.GetDatePart(1);
      }
    }

    [__DynamicallyInvokable]
    public override int GetHashCode()
    {
      long internalTicks = this.InternalTicks;
      return (int) internalTicks ^ (int) (internalTicks >> 32);
    }

    [__DynamicallyInvokable]
    public int Hour
    {
      [__DynamicallyInvokable] get
      {
        return (int) (this.InternalTicks / 36000000000L % 24L);
      }
    }

    internal bool IsAmbiguousDaylightSavingTime()
    {
      return this.InternalKind == 13835058055282163712UL;
    }

    [__DynamicallyInvokable]
    public DateTimeKind Kind
    {
      [__DynamicallyInvokable] get
      {
        switch (this.InternalKind)
        {
          case 0:
            return DateTimeKind.Unspecified;
          case 4611686018427387904:
            return DateTimeKind.Utc;
          default:
            return DateTimeKind.Local;
        }
      }
    }

    [__DynamicallyInvokable]
    public int Millisecond
    {
      [__DynamicallyInvokable] get
      {
        return (int) (this.InternalTicks / 10000L % 1000L);
      }
    }

    [__DynamicallyInvokable]
    public int Minute
    {
      [__DynamicallyInvokable] get
      {
        return (int) (this.InternalTicks / 600000000L % 60L);
      }
    }

    [__DynamicallyInvokable]
    public int Month
    {
      [__DynamicallyInvokable] get
      {
        return this.GetDatePart(2);
      }
    }

    [__DynamicallyInvokable]
    public static DateTime Now
    {
      [__DynamicallyInvokable] get
      {
        DateTime utcNow = DateTime.UtcNow;
        bool isAmbiguousLocalDst = false;
        long ticks1 = TimeZoneInfo.GetDateTimeNowUtcOffsetFromUtc(utcNow, out isAmbiguousLocalDst).Ticks;
        long ticks2 = utcNow.Ticks + ticks1;
        if (ticks2 > 3155378975999999999L)
          return new DateTime(3155378975999999999L, DateTimeKind.Local);
        if (ticks2 < 0L)
          return new DateTime(0L, DateTimeKind.Local);
        return new DateTime(ticks2, DateTimeKind.Local, isAmbiguousLocalDst);
      }
    }

    [__DynamicallyInvokable]
    public static DateTime UtcNow
    {
      [SecuritySafeCritical, __DynamicallyInvokable] get
      {
        if (!DateTime.s_isLeapSecondsSupportedSystem)
          return new DateTime((ulong) (DateTime.GetSystemTimeAsFileTime() + 504911232000000000L | 4611686018427387904L));
        DateTime.FullSystemTime time = new DateTime.FullSystemTime();
        DateTime.GetSystemTimeWithLeapSecondsHandling(ref time);
        return DateTime.CreateDateTimeFromSystemTime(ref time);
      }
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern long GetSystemTimeAsFileTime();

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool ValidateSystemTime(ref DateTime.FullSystemTime time, bool localTime);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void GetSystemTimeWithLeapSecondsHandling(ref DateTime.FullSystemTime time);

    [SecuritySafeCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool IsLeapSecondsSupportedSystem();

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool SystemFileTimeToSystemTime(long fileTime, ref DateTime.FullSystemTime time);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern bool SystemTimeToSystemFileTime(ref DateTime.FullSystemTime time, ref long fileTime);

    [SecuritySafeCritical]
    internal static DateTime InternalFromFileTime(long fileTime)
    {
      DateTime.FullSystemTime time = new DateTime.FullSystemTime();
      if (!DateTime.SystemFileTimeToSystemTime(fileTime, ref time))
        throw new ArgumentOutOfRangeException(nameof (fileTime), Environment.GetResourceString("ArgumentOutOfRange_DateTimeBadTicks"));
      time.hundredNanoSecond = fileTime % 10000L;
      return DateTime.CreateDateTimeFromSystemTime(ref time);
    }

    [SecuritySafeCritical]
    internal static long InternalToFileTime(long ticks)
    {
      long fileTime = 0;
      DateTime.FullSystemTime time = new DateTime.FullSystemTime(ticks);
      if (DateTime.SystemTimeToSystemFileTime(ref time, ref fileTime))
        return fileTime + ticks % 10000L;
      throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_FileTimeInvalid"));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static DateTime CreateDateTimeFromSystemTime(ref DateTime.FullSystemTime time)
    {
      return new DateTime((ulong) (DateTime.DateToTicks((int) time.wYear, (int) time.wMonth, (int) time.wDay) + DateTime.TimeToTicks((int) time.wHour, (int) time.wMinute, (int) time.wSecond) + (long) time.wMillisecond * 10000L + time.hundredNanoSecond | 4611686018427387904L));
    }

    [SecuritySafeCritical]
    internal static bool IsValidTimeWithLeapSeconds(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
    {
      DateTime dateTime = new DateTime(year, month, day);
      DateTime.FullSystemTime time = new DateTime.FullSystemTime(year, month, dateTime.DayOfWeek, day, hour, minute, second);
      if (kind == DateTimeKind.Utc)
        return DateTime.ValidateSystemTime(ref time, false);
      if (kind == DateTimeKind.Local)
        return DateTime.ValidateSystemTime(ref time, true);
      if (!DateTime.ValidateSystemTime(ref time, true))
        return DateTime.ValidateSystemTime(ref time, false);
      return true;
    }

    [__DynamicallyInvokable]
    public int Second
    {
      [__DynamicallyInvokable] get
      {
        return (int) (this.InternalTicks / 10000000L % 60L);
      }
    }

    [__DynamicallyInvokable]
    public long Ticks
    {
      [__DynamicallyInvokable] get
      {
        return this.InternalTicks;
      }
    }

    [__DynamicallyInvokable]
    public TimeSpan TimeOfDay
    {
      [__DynamicallyInvokable] get
      {
        return new TimeSpan(this.InternalTicks % 864000000000L);
      }
    }

    [__DynamicallyInvokable]
    public static DateTime Today
    {
      [__DynamicallyInvokable] get
      {
        return DateTime.Now.Date;
      }
    }

    [__DynamicallyInvokable]
    public int Year
    {
      [__DynamicallyInvokable] get
      {
        return this.GetDatePart(0);
      }
    }

    [__DynamicallyInvokable]
    public static bool IsLeapYear(int year)
    {
      if (year < 1 || year > 9999)
        throw new ArgumentOutOfRangeException(nameof (year), Environment.GetResourceString("ArgumentOutOfRange_Year"));
      if (year % 4 != 0)
        return false;
      if (year % 100 == 0)
        return year % 400 == 0;
      return true;
    }

    [__DynamicallyInvokable]
    public static DateTime Parse(string s)
    {
      return DateTimeParse.Parse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None);
    }

    [__DynamicallyInvokable]
    public static DateTime Parse(string s, IFormatProvider provider)
    {
      return DateTimeParse.Parse(s, DateTimeFormatInfo.GetInstance(provider), DateTimeStyles.None);
    }

    [__DynamicallyInvokable]
    public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles)
    {
      DateTimeFormatInfo.ValidateStyles(styles, nameof (styles));
      return DateTimeParse.Parse(s, DateTimeFormatInfo.GetInstance(provider), styles);
    }

    [__DynamicallyInvokable]
    public static DateTime ParseExact(string s, string format, IFormatProvider provider)
    {
      return DateTimeParse.ParseExact(s, format, DateTimeFormatInfo.GetInstance(provider), DateTimeStyles.None);
    }

    [__DynamicallyInvokable]
    public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style)
    {
      DateTimeFormatInfo.ValidateStyles(style, nameof (style));
      return DateTimeParse.ParseExact(s, format, DateTimeFormatInfo.GetInstance(provider), style);
    }

    [__DynamicallyInvokable]
    public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style)
    {
      DateTimeFormatInfo.ValidateStyles(style, nameof (style));
      return DateTimeParse.ParseExactMultiple(s, formats, DateTimeFormatInfo.GetInstance(provider), style);
    }

    [__DynamicallyInvokable]
    public TimeSpan Subtract(DateTime value)
    {
      return new TimeSpan(this.InternalTicks - value.InternalTicks);
    }

    [__DynamicallyInvokable]
    public DateTime Subtract(TimeSpan value)
    {
      long internalTicks = this.InternalTicks;
      long ticks = value._ticks;
      if (internalTicks - 0L < ticks || internalTicks - 3155378975999999999L > ticks)
        throw new ArgumentOutOfRangeException(nameof (value), Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
      return new DateTime((ulong) (internalTicks - ticks) | this.InternalKind);
    }

    private static double TicksToOADate(long value)
    {
      if (value == 0L)
        return 0.0;
      if (value < 864000000000L)
        value += 599264352000000000L;
      if (value < 31241376000000000L)
        throw new OverflowException(Environment.GetResourceString("Arg_OleAutDateInvalid"));
      long num1 = (value - 599264352000000000L) / 10000L;
      if (num1 < 0L)
      {
        long num2 = num1 % 86400000L;
        if (num2 != 0L)
          num1 -= (86400000L + num2) * 2L;
      }
      return (double) num1 / 86400000.0;
    }

    [__DynamicallyInvokable]
    public double ToOADate()
    {
      return DateTime.TicksToOADate(this.InternalTicks);
    }

    [__DynamicallyInvokable]
    public long ToFileTime()
    {
      return this.ToUniversalTime().ToFileTimeUtc();
    }

    [__DynamicallyInvokable]
    public long ToFileTimeUtc()
    {
      long ticks = ((long) this.InternalKind & long.MinValue) != 0L ? this.ToUniversalTime().InternalTicks : this.InternalTicks;
      if (DateTime.s_isLeapSecondsSupportedSystem)
        return DateTime.InternalToFileTime(ticks);
      long num = ticks - 504911232000000000L;
      if (num < 0L)
        throw new ArgumentOutOfRangeException((string) null, Environment.GetResourceString("ArgumentOutOfRange_FileTimeInvalid"));
      return num;
    }

    [__DynamicallyInvokable]
    public DateTime ToLocalTime()
    {
      return this.ToLocalTime(false);
    }

    internal DateTime ToLocalTime(bool throwOnOverflow)
    {
      if (this.Kind == DateTimeKind.Local)
        return this;
      bool isDaylightSavings = false;
      bool isAmbiguousLocalDst = false;
      long ticks = this.Ticks + TimeZoneInfo.GetUtcOffsetFromUtc(this, TimeZoneInfo.Local, out isDaylightSavings, out isAmbiguousLocalDst).Ticks;
      if (ticks > 3155378975999999999L)
      {
        if (throwOnOverflow)
          throw new ArgumentException(Environment.GetResourceString("Arg_ArgumentOutOfRangeException"));
        return new DateTime(3155378975999999999L, DateTimeKind.Local);
      }
      if (ticks >= 0L)
        return new DateTime(ticks, DateTimeKind.Local, isAmbiguousLocalDst);
      if (throwOnOverflow)
        throw new ArgumentException(Environment.GetResourceString("Arg_ArgumentOutOfRangeException"));
      return new DateTime(0L, DateTimeKind.Local);
    }

    public string ToLongDateString()
    {
      return DateTimeFormat.Format(this, "D", DateTimeFormatInfo.CurrentInfo);
    }

    public string ToLongTimeString()
    {
      return DateTimeFormat.Format(this, "T", DateTimeFormatInfo.CurrentInfo);
    }

    public string ToShortDateString()
    {
      return DateTimeFormat.Format(this, "d", DateTimeFormatInfo.CurrentInfo);
    }

    public string ToShortTimeString()
    {
      return DateTimeFormat.Format(this, "t", DateTimeFormatInfo.CurrentInfo);
    }

    [__DynamicallyInvokable]
    public override string ToString()
    {
      return DateTimeFormat.Format(this, (string) null, DateTimeFormatInfo.CurrentInfo);
    }

    [__DynamicallyInvokable]
    public string ToString(string format)
    {
      return DateTimeFormat.Format(this, format, DateTimeFormatInfo.CurrentInfo);
    }

    [__DynamicallyInvokable]
    public string ToString(IFormatProvider provider)
    {
      return DateTimeFormat.Format(this, (string) null, DateTimeFormatInfo.GetInstance(provider));
    }

    [__DynamicallyInvokable]
    public string ToString(string format, IFormatProvider provider)
    {
      return DateTimeFormat.Format(this, format, DateTimeFormatInfo.GetInstance(provider));
    }

    [__DynamicallyInvokable]
    public DateTime ToUniversalTime()
    {
      return TimeZoneInfo.ConvertTimeToUtc(this, TimeZoneInfoOptions.NoThrowOnInvalidTime);
    }

    [__DynamicallyInvokable]
    public static bool TryParse(string s, out DateTime result)
    {
      return DateTimeParse.TryParse(s, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None, out result);
    }

    [__DynamicallyInvokable]
    public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result)
    {
      DateTimeFormatInfo.ValidateStyles(styles, nameof (styles));
      return DateTimeParse.TryParse(s, DateTimeFormatInfo.GetInstance(provider), styles, out result);
    }

    [__DynamicallyInvokable]
    public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result)
    {
      DateTimeFormatInfo.ValidateStyles(style, nameof (style));
      return DateTimeParse.TryParseExact(s, format, DateTimeFormatInfo.GetInstance(provider), style, out result);
    }

    [__DynamicallyInvokable]
    public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result)
    {
      DateTimeFormatInfo.ValidateStyles(style, nameof (style));
      return DateTimeParse.TryParseExactMultiple(s, formats, DateTimeFormatInfo.GetInstance(provider), style, out result);
    }

    [__DynamicallyInvokable]
    public static DateTime operator +(DateTime d, TimeSpan t)
    {
      long internalTicks = d.InternalTicks;
      long ticks = t._ticks;
      if (ticks > 3155378975999999999L - internalTicks || ticks < -internalTicks)
        throw new ArgumentOutOfRangeException(nameof (t), Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
      return new DateTime((ulong) (internalTicks + ticks) | d.InternalKind);
    }

    [__DynamicallyInvokable]
    public static DateTime operator -(DateTime d, TimeSpan t)
    {
      long internalTicks = d.InternalTicks;
      long ticks = t._ticks;
      if (internalTicks - 0L < ticks || internalTicks - 3155378975999999999L > ticks)
        throw new ArgumentOutOfRangeException(nameof (t), Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
      return new DateTime((ulong) (internalTicks - ticks) | d.InternalKind);
    }

    [__DynamicallyInvokable]
    public static TimeSpan operator -(DateTime d1, DateTime d2)
    {
      return new TimeSpan(d1.InternalTicks - d2.InternalTicks);
    }

    [__DynamicallyInvokable]
    public static bool operator ==(DateTime d1, DateTime d2)
    {
      return d1.InternalTicks == d2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool operator !=(DateTime d1, DateTime d2)
    {
      return d1.InternalTicks != d2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool operator <(DateTime t1, DateTime t2)
    {
      return t1.InternalTicks < t2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool operator <=(DateTime t1, DateTime t2)
    {
      return t1.InternalTicks <= t2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool operator >(DateTime t1, DateTime t2)
    {
      return t1.InternalTicks > t2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public static bool operator >=(DateTime t1, DateTime t2)
    {
      return t1.InternalTicks >= t2.InternalTicks;
    }

    [__DynamicallyInvokable]
    public string[] GetDateTimeFormats()
    {
      return this.GetDateTimeFormats((IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public string[] GetDateTimeFormats(IFormatProvider provider)
    {
      return DateTimeFormat.GetAllDateTimes(this, DateTimeFormatInfo.GetInstance(provider));
    }

    [__DynamicallyInvokable]
    public string[] GetDateTimeFormats(char format)
    {
      return this.GetDateTimeFormats(format, (IFormatProvider) CultureInfo.CurrentCulture);
    }

    [__DynamicallyInvokable]
    public string[] GetDateTimeFormats(char format, IFormatProvider provider)
    {
      return DateTimeFormat.GetAllDateTimes(this, format, DateTimeFormatInfo.GetInstance(provider));
    }

    public TypeCode GetTypeCode()
    {
      return TypeCode.DateTime;
    }

    [__DynamicallyInvokable]
    bool IConvertible.ToBoolean(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Boolean"));
    }

    [__DynamicallyInvokable]
    char IConvertible.ToChar(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Char"));
    }

    [__DynamicallyInvokable]
    sbyte IConvertible.ToSByte(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "SByte"));
    }

    [__DynamicallyInvokable]
    byte IConvertible.ToByte(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Byte"));
    }

    [__DynamicallyInvokable]
    short IConvertible.ToInt16(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Int16"));
    }

    [__DynamicallyInvokable]
    ushort IConvertible.ToUInt16(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "UInt16"));
    }

    [__DynamicallyInvokable]
    int IConvertible.ToInt32(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Int32"));
    }

    [__DynamicallyInvokable]
    uint IConvertible.ToUInt32(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "UInt32"));
    }

    [__DynamicallyInvokable]
    long IConvertible.ToInt64(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Int64"));
    }

    [__DynamicallyInvokable]
    ulong IConvertible.ToUInt64(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "UInt64"));
    }

    [__DynamicallyInvokable]
    float IConvertible.ToSingle(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Single"));
    }

    [__DynamicallyInvokable]
    double IConvertible.ToDouble(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Double"));
    }

    [__DynamicallyInvokable]
    Decimal IConvertible.ToDecimal(IFormatProvider provider)
    {
      throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", (object) nameof (DateTime), (object) "Decimal"));
    }

    [__DynamicallyInvokable]
    DateTime IConvertible.ToDateTime(IFormatProvider provider)
    {
      return this;
    }

    [__DynamicallyInvokable]
    object IConvertible.ToType(Type type, IFormatProvider provider)
    {
      return Convert.DefaultToType((IConvertible) this, type, provider);
    }

    internal static bool TryCreate(int year, int month, int day, int hour, int minute, int second, int millisecond, out DateTime result)
    {
      result = DateTime.MinValue;
      if (year < 1 || year > 9999 || (month < 1 || month > 12))
        return false;
      int[] numArray = DateTime.IsLeapYear(year) ? DateTime.DaysToMonth366 : DateTime.DaysToMonth365;
      if (day < 1 || day > numArray[month] - numArray[month - 1] || (hour < 0 || hour >= 24) || (minute < 0 || minute >= 60 || (second < 0 || second > 60)) || (millisecond < 0 || millisecond >= 1000))
        return false;
      if (second == 60)
      {
        if (!DateTime.s_isLeapSecondsSupportedSystem || !DateTime.IsValidTimeWithLeapSeconds(year, month, day, hour, minute, second, DateTimeKind.Unspecified))
          return false;
        second = 59;
      }
      long ticks = DateTime.DateToTicks(year, month, day) + DateTime.TimeToTicks(hour, minute, second) + (long) millisecond * 10000L;
      if (ticks < 0L || ticks > 3155378975999999999L)
        return false;
      result = new DateTime(ticks, DateTimeKind.Unspecified);
      return true;
    }

    internal struct FullSystemTime
    {
      internal ushort wYear;
      internal ushort wMonth;
      internal ushort wDayOfWeek;
      internal ushort wDay;
      internal ushort wHour;
      internal ushort wMinute;
      internal ushort wSecond;
      internal ushort wMillisecond;
      internal long hundredNanoSecond;

      internal FullSystemTime(int year, int month, DayOfWeek dayOfWeek, int day, int hour, int minute, int second)
      {
        this.wYear = (ushort) year;
        this.wMonth = (ushort) month;
        this.wDayOfWeek = (ushort) dayOfWeek;
        this.wDay = (ushort) day;
        this.wHour = (ushort) hour;
        this.wMinute = (ushort) minute;
        this.wSecond = (ushort) second;
        this.wMillisecond = (ushort) 0;
        this.hundredNanoSecond = 0L;
      }

      internal FullSystemTime(long ticks)
      {
        DateTime dateTime = new DateTime(ticks);
        int year;
        int month;
        int day;
        dateTime.GetDatePart(out year, out month, out day);
        this.wYear = (ushort) year;
        this.wMonth = (ushort) month;
        this.wDayOfWeek = (ushort) dateTime.DayOfWeek;
        this.wDay = (ushort) day;
        this.wHour = (ushort) dateTime.Hour;
        this.wMinute = (ushort) dateTime.Minute;
        this.wSecond = (ushort) dateTime.Second;
        this.wMillisecond = (ushort) dateTime.Millisecond;
        this.hundredNanoSecond = 0L;
      }
    }
  }
}
