// Decompiled with JetBrains decompiler
// Type: System.Array
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

namespace System
{
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public abstract class Array : ICloneable, IList, ICollection, IEnumerable, IStructuralComparable, IStructuralEquatable
  {
    internal const int MaxArrayLength = 2146435071;
    internal const int MaxByteArrayLength = 2147483591;

    internal Array()
    {
    }

    public static ReadOnlyCollection<T> AsReadOnly<T>(T[] array)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return new ReadOnlyCollection<T>((IList<T>) array);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Resize<T>(ref T[] array, int newSize)
    {
      if (newSize < 0)
        throw new ArgumentOutOfRangeException(nameof (newSize), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      T[] objArray1 = array;
      if (objArray1 == null)
      {
        array = new T[newSize];
      }
      else
      {
        if (objArray1.Length == newSize)
          return;
        T[] objArray2 = new T[newSize];
        Array.Copy((Array) objArray1, 0, (Array) objArray2, 0, objArray1.Length > newSize ? newSize : objArray1.Length);
        array = objArray2;
      }
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static unsafe Array CreateInstance(Type elementType, int length)
    {
      if ((object) elementType == null)
        throw new ArgumentNullException(nameof (elementType));
      if (length < 0)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if (underlyingSystemType == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (elementType));
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 1, &length, (int*) null);
    }

    [SecuritySafeCritical]
    public static unsafe Array CreateInstance(Type elementType, int length1, int length2)
    {
      if ((object) elementType == null)
        throw new ArgumentNullException(nameof (elementType));
      if (length1 < 0 || length2 < 0)
        throw new ArgumentOutOfRangeException(length1 < 0 ? nameof (length1) : nameof (length2), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if (underlyingSystemType == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (elementType));
      int* pLengths = stackalloc int[2];
      pLengths[0] = length1;
      *(int*) ((IntPtr) pLengths + 4) = length2;
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 2, pLengths, (int*) null);
    }

    [SecuritySafeCritical]
    public static unsafe Array CreateInstance(Type elementType, int length1, int length2, int length3)
    {
      if ((object) elementType == null)
        throw new ArgumentNullException(nameof (elementType));
      if (length1 < 0)
        throw new ArgumentOutOfRangeException(nameof (length1), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (length2 < 0)
        throw new ArgumentOutOfRangeException(nameof (length2), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (length3 < 0)
        throw new ArgumentOutOfRangeException(nameof (length3), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if (underlyingSystemType == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (elementType));
      int* pLengths = stackalloc int[3];
      pLengths[0] = length1;
      *(int*) ((IntPtr) pLengths + 4) = length2;
      pLengths[2] = length3;
      return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 3, pLengths, (int*) null);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static unsafe Array CreateInstance(Type elementType, params int[] lengths)
    {
      if ((object) elementType == null)
        throw new ArgumentNullException(nameof (elementType));
      if (lengths == null)
        throw new ArgumentNullException(nameof (lengths));
      if (lengths.Length == 0)
        throw new ArgumentException(Environment.GetResourceString("Arg_NeedAtLeast1Rank"));
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if (underlyingSystemType == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (elementType));
      for (int index = 0; index < lengths.Length; ++index)
      {
        if (lengths[index] < 0)
          throw new ArgumentOutOfRangeException("lengths[" + (object) index + "]", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      }
      fixed (int* pLengths = lengths)
        return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, lengths.Length, pLengths, (int*) null);
    }

    public static Array CreateInstance(Type elementType, params long[] lengths)
    {
      if (lengths == null)
        throw new ArgumentNullException(nameof (lengths));
      if (lengths.Length == 0)
        throw new ArgumentException(Environment.GetResourceString("Arg_NeedAtLeast1Rank"));
      int[] numArray = new int[lengths.Length];
      for (int index = 0; index < lengths.Length; ++index)
      {
        long length = lengths[index];
        if (length > (long) int.MaxValue || length < (long) int.MinValue)
          throw new ArgumentOutOfRangeException("len", Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
        numArray[index] = (int) length;
      }
      return Array.CreateInstance(elementType, numArray);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public static unsafe Array CreateInstance(Type elementType, int[] lengths, int[] lowerBounds)
    {
      if (elementType == (Type) null)
        throw new ArgumentNullException(nameof (elementType));
      if (lengths == null)
        throw new ArgumentNullException(nameof (lengths));
      if (lowerBounds == null)
        throw new ArgumentNullException(nameof (lowerBounds));
      if (lengths.Length != lowerBounds.Length)
        throw new ArgumentException(Environment.GetResourceString("Arg_RanksAndBounds"));
      if (lengths.Length == 0)
        throw new ArgumentException(Environment.GetResourceString("Arg_NeedAtLeast1Rank"));
      RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
      if (underlyingSystemType == (RuntimeType) null)
        throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), nameof (elementType));
      for (int index = 0; index < lengths.Length; ++index)
      {
        if (lengths[index] < 0)
          throw new ArgumentOutOfRangeException("lengths[" + (object) index + "]", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      }
      fixed (int* pLengths = lengths)
        fixed (int* pLowerBounds = lowerBounds)
          return Array.InternalCreate((void*) underlyingSystemType.TypeHandle.Value, lengths.Length, pLengths, pLowerBounds);
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe Array InternalCreate(void* elementType, int rank, int* pLengths, int* pLowerBounds);

    [SecurityCritical]
    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static Array UnsafeCreateInstance(Type elementType, int length)
    {
      return Array.CreateInstance(elementType, length);
    }

    [SecurityCritical]
    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static Array UnsafeCreateInstance(Type elementType, int length1, int length2)
    {
      return Array.CreateInstance(elementType, length1, length2);
    }

    [SecurityCritical]
    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static Array UnsafeCreateInstance(Type elementType, params int[] lengths)
    {
      return Array.CreateInstance(elementType, lengths);
    }

    [SecurityCritical]
    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static Array UnsafeCreateInstance(Type elementType, int[] lengths, int[] lowerBounds)
    {
      return Array.CreateInstance(elementType, lengths, lowerBounds);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Copy(Array sourceArray, Array destinationArray, int length)
    {
      if (sourceArray == null)
        throw new ArgumentNullException(nameof (sourceArray));
      if (destinationArray == null)
        throw new ArgumentNullException(nameof (destinationArray));
      Array.Copy(sourceArray, sourceArray.GetLowerBound(0), destinationArray, destinationArray.GetLowerBound(0), length, false);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
      Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length, false);
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal static extern void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length, bool reliable);

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [__DynamicallyInvokable]
    public static void ConstrainedCopy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
      Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length, true);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    public static void Copy(Array sourceArray, Array destinationArray, long length)
    {
      if (length > (long) int.MaxValue || length < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      Array.Copy(sourceArray, destinationArray, (int) length);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    public static void Copy(Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
    {
      if (sourceIndex > (long) int.MaxValue || sourceIndex < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (sourceIndex), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (destinationIndex > (long) int.MaxValue || destinationIndex < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (destinationIndex), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (length > (long) int.MaxValue || length < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (length), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      Array.Copy(sourceArray, (int) sourceIndex, destinationArray, (int) destinationIndex, (int) length);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void Clear(Array array, int index, int length);

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe object GetValue(params int[] indices)
    {
      if (indices == null)
        throw new ArgumentNullException(nameof (indices));
      if (this.Rank != indices.Length)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankIndices"));
      TypedReference typedReference = new TypedReference();
      fixed (int* pIndices = indices)
        this.InternalGetReference((void*) &typedReference, indices.Length, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe object GetValue(int index)
    {
      if (this.Rank != 1)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need1DArray"));
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 1, &index);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    [SecuritySafeCritical]
    public unsafe object GetValue(int index1, int index2)
    {
      if (this.Rank != 2)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need2DArray"));
      int* pIndices = stackalloc int[2];
      pIndices[0] = index1;
      *(int*) ((IntPtr) pIndices + 4) = index2;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 2, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    [SecuritySafeCritical]
    public unsafe object GetValue(int index1, int index2, int index3)
    {
      if (this.Rank != 3)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need3DArray"));
      int* pIndices = stackalloc int[3];
      pIndices[0] = index1;
      *(int*) ((IntPtr) pIndices + 4) = index2;
      pIndices[2] = index3;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 3, pIndices);
      return TypedReference.InternalToObject((void*) &typedReference);
    }

    [ComVisible(false)]
    public object GetValue(long index)
    {
      if (index > (long) int.MaxValue || index < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      return this.GetValue((int) index);
    }

    [ComVisible(false)]
    public object GetValue(long index1, long index2)
    {
      if (index1 > (long) int.MaxValue || index1 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index1), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index2), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      return this.GetValue((int) index1, (int) index2);
    }

    [ComVisible(false)]
    public object GetValue(long index1, long index2, long index3)
    {
      if (index1 > (long) int.MaxValue || index1 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index1), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index2), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index3 > (long) int.MaxValue || index3 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index3), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      return this.GetValue((int) index1, (int) index2, (int) index3);
    }

    [ComVisible(false)]
    public object GetValue(params long[] indices)
    {
      if (indices == null)
        throw new ArgumentNullException(nameof (indices));
      if (this.Rank != indices.Length)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankIndices"));
      int[] numArray = new int[indices.Length];
      for (int index1 = 0; index1 < indices.Length; ++index1)
      {
        long index2 = indices[index1];
        if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
          throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
        numArray[index1] = (int) index2;
      }
      return this.GetValue(numArray);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe void SetValue(object value, int index)
    {
      if (this.Rank != 1)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need1DArray"));
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 1, &index);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    [SecuritySafeCritical]
    public unsafe void SetValue(object value, int index1, int index2)
    {
      if (this.Rank != 2)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need2DArray"));
      int* pIndices = stackalloc int[2];
      pIndices[0] = index1;
      *(int*) ((IntPtr) pIndices + 4) = index2;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 2, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    [SecuritySafeCritical]
    public unsafe void SetValue(object value, int index1, int index2, int index3)
    {
      if (this.Rank != 3)
        throw new ArgumentException(Environment.GetResourceString("Arg_Need3DArray"));
      int* pIndices = stackalloc int[3];
      pIndices[0] = index1;
      *(int*) ((IntPtr) pIndices + 4) = index2;
      pIndices[2] = index3;
      TypedReference typedReference = new TypedReference();
      this.InternalGetReference((void*) &typedReference, 3, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    public unsafe void SetValue(object value, params int[] indices)
    {
      if (indices == null)
        throw new ArgumentNullException(nameof (indices));
      if (this.Rank != indices.Length)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankIndices"));
      TypedReference typedReference = new TypedReference();
      fixed (int* pIndices = indices)
        this.InternalGetReference((void*) &typedReference, indices.Length, pIndices);
      Array.InternalSetValue((void*) &typedReference, value);
    }

    [ComVisible(false)]
    public void SetValue(object value, long index)
    {
      if (index > (long) int.MaxValue || index < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      this.SetValue(value, (int) index);
    }

    [ComVisible(false)]
    public void SetValue(object value, long index1, long index2)
    {
      if (index1 > (long) int.MaxValue || index1 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index1), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index2), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      this.SetValue(value, (int) index1, (int) index2);
    }

    [ComVisible(false)]
    public void SetValue(object value, long index1, long index2, long index3)
    {
      if (index1 > (long) int.MaxValue || index1 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index1), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index2), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      if (index3 > (long) int.MaxValue || index3 < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index3), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      this.SetValue(value, (int) index1, (int) index2, (int) index3);
    }

    [ComVisible(false)]
    public void SetValue(object value, params long[] indices)
    {
      if (indices == null)
        throw new ArgumentNullException(nameof (indices));
      if (this.Rank != indices.Length)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankIndices"));
      int[] numArray = new int[indices.Length];
      for (int index1 = 0; index1 < indices.Length; ++index1)
      {
        long index2 = indices[index1];
        if (index2 > (long) int.MaxValue || index2 < (long) int.MinValue)
          throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
        numArray[index1] = (int) index2;
      }
      this.SetValue(value, numArray);
    }

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern unsafe void InternalGetReference(void* elemRef, int rank, int* pIndices);

    [SecurityCritical]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe void InternalSetValue(void* target, object value);

    [__DynamicallyInvokable]
    public extern int Length { [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    private static int GetMedian(int low, int hi)
    {
      return low + (hi - low >> 1);
    }

    [ComVisible(false)]
    public extern long LongLength { [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), MethodImpl(MethodImplOptions.InternalCall)] get; }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetLength(int dimension);

    [ComVisible(false)]
    public long GetLongLength(int dimension)
    {
      return (long) this.GetLength(dimension);
    }

    [__DynamicallyInvokable]
    public extern int Rank { [SecuritySafeCritical, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), __DynamicallyInvokable, MethodImpl(MethodImplOptions.InternalCall)] get; }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetUpperBound(int dimension);

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern int GetLowerBound(int dimension);

    [SecurityCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern int GetDataPtrOffsetInternal();

    [__DynamicallyInvokable]
    int ICollection.Count
    {
      [__DynamicallyInvokable] get
      {
        return this.Length;
      }
    }

    public object SyncRoot
    {
      get
      {
        return (object) this;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return false;
      }
    }

    public bool IsFixedSize
    {
      get
      {
        return true;
      }
    }

    public bool IsSynchronized
    {
      get
      {
        return false;
      }
    }

    [__DynamicallyInvokable]
    object IList.this[int index]
    {
      [__DynamicallyInvokable] get
      {
        return this.GetValue(index);
      }
      [__DynamicallyInvokable] set
      {
        this.SetValue(value, index);
      }
    }

    [__DynamicallyInvokable]
    int IList.Add(object value)
    {
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
    }

    [__DynamicallyInvokable]
    bool IList.Contains(object value)
    {
      return Array.IndexOf(this, value) >= this.GetLowerBound(0);
    }

    [__DynamicallyInvokable]
    void IList.Clear()
    {
      Array.Clear(this, this.GetLowerBound(0), this.Length);
    }

    [__DynamicallyInvokable]
    int IList.IndexOf(object value)
    {
      return Array.IndexOf(this, value);
    }

    [__DynamicallyInvokable]
    void IList.Insert(int index, object value)
    {
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
    }

    [__DynamicallyInvokable]
    void IList.Remove(object value)
    {
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
    }

    [__DynamicallyInvokable]
    void IList.RemoveAt(int index)
    {
      throw new NotSupportedException(Environment.GetResourceString("NotSupported_FixedSizeCollection"));
    }

    [__DynamicallyInvokable]
    public object Clone()
    {
      return this.MemberwiseClone();
    }

    [__DynamicallyInvokable]
    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (other == null)
        return 1;
      Array array = other as Array;
      if (array == null || this.Length != array.Length)
        throw new ArgumentException(Environment.GetResourceString("ArgumentException_OtherNotArrayOfCorrectLength"), nameof (other));
      int index = 0;
      int num;
      for (num = 0; index < array.Length && num == 0; ++index)
      {
        object x = this.GetValue(index);
        object y = array.GetValue(index);
        num = comparer.Compare(x, y);
      }
      return num;
    }

    [__DynamicallyInvokable]
    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      if (other == null)
        return false;
      if (this == other)
        return true;
      Array array = other as Array;
      if (array == null || array.Length != this.Length)
        return false;
      for (int index = 0; index < array.Length; ++index)
      {
        object x = this.GetValue(index);
        object y = array.GetValue(index);
        if (!comparer.Equals(x, y))
          return false;
      }
      return true;
    }

    internal static int CombineHashCodes(int h1, int h2)
    {
      return (h1 << 5) + h1 ^ h2;
    }

    [__DynamicallyInvokable]
    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      if (comparer == null)
        throw new ArgumentNullException(nameof (comparer));
      int h1 = 0;
      for (int index = this.Length >= 8 ? this.Length - 8 : 0; index < this.Length; ++index)
        h1 = Array.CombineHashCodes(h1, comparer.GetHashCode(this.GetValue(index)));
      return h1;
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch(Array array, object value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.BinarySearch(array, lowerBound, array.Length, value, (IComparer) null);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch(Array array, int index, int length, object value)
    {
      return Array.BinarySearch(array, index, length, value, (IComparer) null);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch(Array array, object value, IComparer comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.BinarySearch(array, lowerBound, array.Length, value, comparer);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch(Array array, int index, int length, object value, IComparer comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      if (index < lowerBound || length < 0)
        throw new ArgumentOutOfRangeException(index < lowerBound ? nameof (index) : nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - (index - lowerBound) < length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      if (array.Rank != 1)
        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
      if (comparer == null)
        comparer = (IComparer) Comparer.Default;
      int retVal;
      if (comparer == Comparer.Default && Array.TrySZBinarySearch(array, index, length, value, out retVal))
        return retVal;
      int low = index;
      int hi = index + length - 1;
      object[] objArray = array as object[];
      if (objArray != null)
      {
        while (low <= hi)
        {
          int median = Array.GetMedian(low, hi);
          int num;
          try
          {
            num = comparer.Compare(objArray[median], value);
          }
          catch (Exception ex)
          {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
          }
          if (num == 0)
            return median;
          if (num < 0)
            low = median + 1;
          else
            hi = median - 1;
        }
      }
      else
      {
        while (low <= hi)
        {
          int median = Array.GetMedian(low, hi);
          int num;
          try
          {
            num = comparer.Compare(array.GetValue(median), value);
          }
          catch (Exception ex)
          {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
          }
          if (num == 0)
            return median;
          if (num < 0)
            low = median + 1;
          else
            hi = median - 1;
        }
      }
      return ~low;
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool TrySZBinarySearch(Array sourceArray, int sourceIndex, int count, object value, out int retVal);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch<T>(T[] array, T value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.BinarySearch<T>(array, 0, array.Length, value, (IComparer<T>) null);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.BinarySearch<T>(array, 0, array.Length, value, comparer);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch<T>(T[] array, int index, int length, T value)
    {
      return Array.BinarySearch<T>(array, index, length, value, (IComparer<T>) null);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int BinarySearch<T>(T[] array, int index, int length, T value, IComparer<T> comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (index < 0 || length < 0)
        throw new ArgumentOutOfRangeException(index < 0 ? nameof (index) : nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - index < length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      return ArraySortHelper<T>.Default.BinarySearch(array, index, length, value, comparer);
    }

    public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (converter == null)
        throw new ArgumentNullException(nameof (converter));
      TOutput[] outputArray = new TOutput[array.Length];
      for (int index = 0; index < array.Length; ++index)
        outputArray[index] = converter(array[index]);
      return outputArray;
    }

    [__DynamicallyInvokable]
    public void CopyTo(Array array, int index)
    {
      if (array != null && array.Rank != 1)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
      Array.Copy(this, this.GetLowerBound(0), array, index, this.Length);
    }

    [ComVisible(false)]
    public void CopyTo(Array array, long index)
    {
      if (index > (long) int.MaxValue || index < (long) int.MinValue)
        throw new ArgumentOutOfRangeException(nameof (index), Environment.GetResourceString("ArgumentOutOfRange_HugeArrayNotSupported"));
      this.CopyTo(array, (int) index);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static T[] Empty<T>()
    {
      return EmptyArray<T>.Value;
    }

    [__DynamicallyInvokable]
    public static bool Exists<T>(T[] array, Predicate<T> match)
    {
      return Array.FindIndex<T>(array, match) != -1;
    }

    [__DynamicallyInvokable]
    public static T Find<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      for (int index = 0; index < array.Length; ++index)
      {
        if (match(array[index]))
          return array[index];
      }
      return default (T);
    }

    [__DynamicallyInvokable]
    public static T[] FindAll<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      List<T> objList = new List<T>();
      for (int index = 0; index < array.Length; ++index)
      {
        if (match(array[index]))
          objList.Add(array[index]);
      }
      return objList.ToArray();
    }

    [__DynamicallyInvokable]
    public static int FindIndex<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.FindIndex<T>(array, 0, array.Length, match);
    }

    [__DynamicallyInvokable]
    public static int FindIndex<T>(T[] array, int startIndex, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.FindIndex<T>(array, startIndex, array.Length - startIndex, match);
    }

    [__DynamicallyInvokable]
    public static int FindIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (startIndex < 0 || startIndex > array.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || startIndex > array.Length - count)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      int num = startIndex + count;
      for (int index = startIndex; index < num; ++index)
      {
        if (match(array[index]))
          return index;
      }
      return -1;
    }

    [__DynamicallyInvokable]
    public static T FindLast<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      for (int index = array.Length - 1; index >= 0; --index)
      {
        if (match(array[index]))
          return array[index];
      }
      return default (T);
    }

    [__DynamicallyInvokable]
    public static int FindLastIndex<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.FindLastIndex<T>(array, array.Length - 1, array.Length, match);
    }

    [__DynamicallyInvokable]
    public static int FindLastIndex<T>(T[] array, int startIndex, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.FindLastIndex<T>(array, startIndex, startIndex + 1, match);
    }

    [__DynamicallyInvokable]
    public static int FindLastIndex<T>(T[] array, int startIndex, int count, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      if (array.Length == 0)
      {
        if (startIndex != -1)
          throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      }
      else if (startIndex < 0 || startIndex >= array.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || startIndex - count + 1 < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      int num = startIndex - count;
      for (int index = startIndex; index > num; --index)
      {
        if (match(array[index]))
          return index;
      }
      return -1;
    }

    public static void ForEach<T>(T[] array, Action<T> action)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (action == null)
        throw new ArgumentNullException(nameof (action));
      for (int index = 0; index < array.Length; ++index)
        action(array[index]);
    }

    [__DynamicallyInvokable]
    public IEnumerator GetEnumerator()
    {
      int lowerBound = this.GetLowerBound(0);
      if (this.Rank == 1 && lowerBound == 0)
        return (IEnumerator) new Array.SZArrayEnumerator(this);
      return (IEnumerator) new Array.ArrayEnumerator(this, lowerBound, this.Length);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int IndexOf(Array array, object value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.IndexOf(array, value, lowerBound, array.Length);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int IndexOf(Array array, object value, int startIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.IndexOf(array, value, startIndex, array.Length - startIndex + lowerBound);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int IndexOf(Array array, object value, int startIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (array.Rank != 1)
        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
      int lowerBound = array.GetLowerBound(0);
      if (startIndex < lowerBound || startIndex > array.Length + lowerBound)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || count > array.Length - startIndex + lowerBound)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      int retVal;
      if (Array.TrySZIndexOf(array, startIndex, count, value, out retVal))
        return retVal;
      object[] objArray = array as object[];
      int num = startIndex + count;
      if (objArray != null)
      {
        if (value == null)
        {
          for (int index = startIndex; index < num; ++index)
          {
            if (objArray[index] == null)
              return index;
          }
        }
        else
        {
          for (int index = startIndex; index < num; ++index)
          {
            object obj = objArray[index];
            if (obj != null && obj.Equals(value))
              return index;
          }
        }
      }
      else
      {
        for (int index = startIndex; index < num; ++index)
        {
          object obj = array.GetValue(index);
          if (obj == null)
          {
            if (value == null)
              return index;
          }
          else if (obj.Equals(value))
            return index;
        }
      }
      return lowerBound - 1;
    }

    [__DynamicallyInvokable]
    public static int IndexOf<T>(T[] array, T value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.IndexOf<T>(array, value, 0, array.Length);
    }

    [__DynamicallyInvokable]
    public static int IndexOf<T>(T[] array, T value, int startIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.IndexOf<T>(array, value, startIndex, array.Length - startIndex);
    }

    [__DynamicallyInvokable]
    public static int IndexOf<T>(T[] array, T value, int startIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (startIndex < 0 || startIndex > array.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || count > array.Length - startIndex)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      return EqualityComparer<T>.Default.IndexOf(array, value, startIndex, count);
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool TrySZIndexOf(Array sourceArray, int sourceIndex, int count, object value, out int retVal);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int LastIndexOf(Array array, object value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.LastIndexOf(array, value, array.Length - 1 + lowerBound, array.Length);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int LastIndexOf(Array array, object value, int startIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      return Array.LastIndexOf(array, value, startIndex, startIndex + 1 - lowerBound);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static int LastIndexOf(Array array, object value, int startIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      int lowerBound = array.GetLowerBound(0);
      if (array.Length == 0)
        return lowerBound - 1;
      if (startIndex < lowerBound || startIndex >= array.Length + lowerBound)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      if (count > startIndex - lowerBound + 1)
        throw new ArgumentOutOfRangeException("endIndex", Environment.GetResourceString("ArgumentOutOfRange_EndIndexStartIndex"));
      if (array.Rank != 1)
        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
      int retVal;
      if (Array.TrySZLastIndexOf(array, startIndex, count, value, out retVal))
        return retVal;
      object[] objArray = array as object[];
      int num = startIndex - count + 1;
      if (objArray != null)
      {
        if (value == null)
        {
          for (int index = startIndex; index >= num; --index)
          {
            if (objArray[index] == null)
              return index;
          }
        }
        else
        {
          for (int index = startIndex; index >= num; --index)
          {
            object obj = objArray[index];
            if (obj != null && obj.Equals(value))
              return index;
          }
        }
      }
      else
      {
        for (int index = startIndex; index >= num; --index)
        {
          object obj = array.GetValue(index);
          if (obj == null)
          {
            if (value == null)
              return index;
          }
          else if (obj.Equals(value))
            return index;
        }
      }
      return lowerBound - 1;
    }

    [__DynamicallyInvokable]
    public static int LastIndexOf<T>(T[] array, T value)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.LastIndexOf<T>(array, value, array.Length - 1, array.Length);
    }

    [__DynamicallyInvokable]
    public static int LastIndexOf<T>(T[] array, T value, int startIndex)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      return Array.LastIndexOf<T>(array, value, startIndex, array.Length == 0 ? 0 : startIndex + 1);
    }

    [__DynamicallyInvokable]
    public static int LastIndexOf<T>(T[] array, T value, int startIndex, int count)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (array.Length == 0)
      {
        if (startIndex != -1 && startIndex != 0)
          throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
        if (count != 0)
          throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
        return -1;
      }
      if (startIndex < 0 || startIndex >= array.Length)
        throw new ArgumentOutOfRangeException(nameof (startIndex), Environment.GetResourceString("ArgumentOutOfRange_Index"));
      if (count < 0 || startIndex - count + 1 < 0)
        throw new ArgumentOutOfRangeException(nameof (count), Environment.GetResourceString("ArgumentOutOfRange_Count"));
      return EqualityComparer<T>.Default.LastIndexOf(array, value, startIndex, count);
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool TrySZLastIndexOf(Array sourceArray, int sourceIndex, int count, object value, out int retVal);

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Reverse(Array array)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      Array.Reverse(array, array.GetLowerBound(0), array.Length);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Reverse(Array array, int index, int length)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (index < array.GetLowerBound(0) || length < 0)
        throw new ArgumentOutOfRangeException(index < 0 ? nameof (index) : nameof (length), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - (index - array.GetLowerBound(0)) < length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      if (array.Rank != 1)
        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
      if (Array.TrySZReverse(array, index, length))
        return;
      int index1 = index;
      int index2 = index + length - 1;
      object[] objArray = array as object[];
      if (objArray != null)
      {
        for (; index1 < index2; --index2)
        {
          object obj = objArray[index1];
          objArray[index1] = objArray[index2];
          objArray[index2] = obj;
          ++index1;
        }
      }
      else
      {
        for (; index1 < index2; --index2)
        {
          object obj = array.GetValue(index1);
          array.SetValue(array.GetValue(index2), index1);
          array.SetValue(obj, index2);
          ++index1;
        }
      }
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool TrySZReverse(Array array, int index, int count);

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array array)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      Array.Sort(array, (Array) null, array.GetLowerBound(0), array.Length, (IComparer) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array keys, Array items)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      Array.Sort(keys, items, keys.GetLowerBound(0), keys.Length, (IComparer) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array array, int index, int length)
    {
      Array.Sort(array, (Array) null, index, length, (IComparer) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array keys, Array items, int index, int length)
    {
      Array.Sort(keys, items, index, length, (IComparer) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array array, IComparer comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      Array.Sort(array, (Array) null, array.GetLowerBound(0), array.Length, comparer);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array keys, Array items, IComparer comparer)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      Array.Sort(keys, items, keys.GetLowerBound(0), keys.Length, comparer);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array array, int index, int length, IComparer comparer)
    {
      Array.Sort(array, (Array) null, index, length, comparer);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort(Array keys, Array items, int index, int length, IComparer comparer)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      if (keys.Rank != 1 || items != null && items.Rank != 1)
        throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
      if (items != null && keys.GetLowerBound(0) != items.GetLowerBound(0))
        throw new ArgumentException(Environment.GetResourceString("Arg_LowerBoundsMustMatch"));
      if (index < keys.GetLowerBound(0) || length < 0)
        throw new ArgumentOutOfRangeException(length < 0 ? nameof (length) : nameof (index), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (keys.Length - (index - keys.GetLowerBound(0)) < length || items != null && index - items.GetLowerBound(0) > items.Length - length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      if (length <= 1 || (comparer == Comparer.Default || comparer == null) && Array.TrySZSort(keys, items, index, index + length - 1))
        return;
      object[] keys1 = keys as object[];
      object[] items1 = (object[]) null;
      if (keys1 != null)
        items1 = items as object[];
      if (keys1 != null && (items == null || items1 != null))
        new Array.SorterObjectArray(keys1, items1, comparer).Sort(index, length);
      else
        new Array.SorterGenericArray(keys, items, comparer).Sort(index, length);
    }

    [SecurityCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool TrySZSort(Array keys, Array items, int left, int right);

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<T>(T[] array)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      Array.Sort<T>(array, array.GetLowerBound(0), array.Length, (IComparer<T>) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      Array.Sort<TKey, TValue>(keys, items, 0, keys.Length, (IComparer<TKey>) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<T>(T[] array, int index, int length)
    {
      Array.Sort<T>(array, index, length, (IComparer<T>) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length)
    {
      Array.Sort<TKey, TValue>(keys, items, index, length, (IComparer<TKey>) null);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<T>(T[] array, IComparer<T> comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      Array.Sort<T>(array, 0, array.Length, comparer);
    }

    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, IComparer<TKey> comparer)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      Array.Sort<TKey, TValue>(keys, items, 0, keys.Length, comparer);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<T>(T[] array, int index, int length, IComparer<T> comparer)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (index < 0 || length < 0)
        throw new ArgumentOutOfRangeException(length < 0 ? nameof (length) : nameof (index), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - index < length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      if (length <= 1 || (comparer == null || comparer == Comparer<T>.Default) && Array.TrySZSort((Array) array, (Array) null, index, index + length - 1))
        return;
      ArraySortHelper<T>.Default.Sort(array, index, length, comparer);
    }

    [SecuritySafeCritical]
    [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
    [__DynamicallyInvokable]
    public static void Sort<TKey, TValue>(TKey[] keys, TValue[] items, int index, int length, IComparer<TKey> comparer)
    {
      if (keys == null)
        throw new ArgumentNullException(nameof (keys));
      if (index < 0 || length < 0)
        throw new ArgumentOutOfRangeException(length < 0 ? nameof (length) : nameof (index), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (keys.Length - index < length || items != null && index > items.Length - length)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      if (length <= 1 || (comparer == null || comparer == Comparer<TKey>.Default) && Array.TrySZSort((Array) keys, (Array) items, index, index + length - 1))
        return;
      if (items == null)
        Array.Sort<TKey>(keys, index, length, comparer);
      else
        ArraySortHelper<TKey, TValue>.Default.Sort(keys, items, index, length, comparer);
    }

    [__DynamicallyInvokable]
    public static void Sort<T>(T[] array, Comparison<T> comparison)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (comparison == null)
        throw new ArgumentNullException(nameof (comparison));
      IComparer<T> comparer = (IComparer<T>) new Array.FunctorComparer<T>(comparison);
      Array.Sort<T>(array, comparer);
    }

    [__DynamicallyInvokable]
    public static bool TrueForAll<T>(T[] array, Predicate<T> match)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (match == null)
        throw new ArgumentNullException(nameof (match));
      for (int index = 0; index < array.Length; ++index)
      {
        if (!match(array[index]))
          return false;
      }
      return true;
    }

    [SecuritySafeCritical]
    [__DynamicallyInvokable]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Initialize();

    internal sealed class FunctorComparer<T> : IComparer<T>
    {
      private Comparison<T> comparison;

      public FunctorComparer(Comparison<T> comparison)
      {
        this.comparison = comparison;
      }

      public int Compare(T x, T y)
      {
        return this.comparison(x, y);
      }
    }

    private struct SorterObjectArray
    {
      private object[] keys;
      private object[] items;
      private IComparer comparer;

      internal SorterObjectArray(object[] keys, object[] items, IComparer comparer)
      {
        if (comparer == null)
          comparer = (IComparer) Comparer.Default;
        this.keys = keys;
        this.items = items;
        this.comparer = comparer;
      }

      internal void SwapIfGreaterWithItems(int a, int b)
      {
        if (a == b || this.comparer.Compare(this.keys[a], this.keys[b]) <= 0)
          return;
        object key = this.keys[a];
        this.keys[a] = this.keys[b];
        this.keys[b] = key;
        if (this.items == null)
          return;
        object obj = this.items[a];
        this.items[a] = this.items[b];
        this.items[b] = obj;
      }

      private void Swap(int i, int j)
      {
        object key = this.keys[i];
        this.keys[i] = this.keys[j];
        this.keys[j] = key;
        if (this.items == null)
          return;
        object obj = this.items[i];
        this.items[i] = this.items[j];
        this.items[j] = obj;
      }

      internal void Sort(int left, int length)
      {
        if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
          this.IntrospectiveSort(left, length);
        else
          this.DepthLimitedQuickSort(left, length + left - 1, 32);
      }

      private void DepthLimitedQuickSort(int left, int right, int depthLimit)
      {
        while (depthLimit != 0)
        {
          int index1 = left;
          int index2 = right;
          int median = Array.GetMedian(index1, index2);
          try
          {
            this.SwapIfGreaterWithItems(index1, median);
            this.SwapIfGreaterWithItems(index1, index2);
            this.SwapIfGreaterWithItems(median, index2);
          }
          catch (Exception ex)
          {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
          }
          object key1 = this.keys[median];
          do
          {
            try
            {
              while (this.comparer.Compare(this.keys[index1], key1) < 0)
                ++index1;
              while (this.comparer.Compare(key1, this.keys[index2]) < 0)
                --index2;
            }
            catch (IndexOutOfRangeException ex)
            {
              throw new ArgumentException(Environment.GetResourceString("Arg_BogusIComparer", (object) this.comparer));
            }
            catch (Exception ex)
            {
              throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
            }
            if (index1 <= index2)
            {
              if (index1 < index2)
              {
                object key2 = this.keys[index1];
                this.keys[index1] = this.keys[index2];
                this.keys[index2] = key2;
                if (this.items != null)
                {
                  object obj = this.items[index1];
                  this.items[index1] = this.items[index2];
                  this.items[index2] = obj;
                }
              }
              ++index1;
              --index2;
            }
            else
              break;
          }
          while (index1 <= index2);
          --depthLimit;
          if (index2 - left <= right - index1)
          {
            if (left < index2)
              this.DepthLimitedQuickSort(left, index2, depthLimit);
            left = index1;
          }
          else
          {
            if (index1 < right)
              this.DepthLimitedQuickSort(index1, right, depthLimit);
            right = index2;
          }
          if (left >= right)
            return;
        }
        try
        {
          this.Heapsort(left, right);
        }
        catch (IndexOutOfRangeException ex)
        {
          throw new ArgumentException(Environment.GetResourceString("Arg_BogusIComparer", (object) this.comparer));
        }
        catch (Exception ex)
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
        }
      }

      private void IntrospectiveSort(int left, int length)
      {
        if (length < 2)
          return;
        try
        {
          this.IntroSort(left, length + left - 1, 2 * IntrospectiveSortUtilities.FloorLog2(this.keys.Length));
        }
        catch (IndexOutOfRangeException ex)
        {
          IntrospectiveSortUtilities.ThrowOrIgnoreBadComparer((object) this.comparer);
        }
        catch (Exception ex)
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
        }
      }

      private void IntroSort(int lo, int hi, int depthLimit)
      {
        int num1;
        for (; hi > lo; hi = num1 - 1)
        {
          int num2 = hi - lo + 1;
          if (num2 <= 16)
          {
            if (num2 == 1)
              break;
            if (num2 == 2)
            {
              this.SwapIfGreaterWithItems(lo, hi);
              break;
            }
            if (num2 == 3)
            {
              this.SwapIfGreaterWithItems(lo, hi - 1);
              this.SwapIfGreaterWithItems(lo, hi);
              this.SwapIfGreaterWithItems(hi - 1, hi);
              break;
            }
            this.InsertionSort(lo, hi);
            break;
          }
          if (depthLimit == 0)
          {
            this.Heapsort(lo, hi);
            break;
          }
          --depthLimit;
          num1 = this.PickPivotAndPartition(lo, hi);
          this.IntroSort(num1 + 1, hi, depthLimit);
        }
      }

      private int PickPivotAndPartition(int lo, int hi)
      {
        int index = lo + (hi - lo) / 2;
        this.SwapIfGreaterWithItems(lo, index);
        this.SwapIfGreaterWithItems(lo, hi);
        this.SwapIfGreaterWithItems(index, hi);
        object key = this.keys[index];
        this.Swap(index, hi - 1);
        int i = lo;
        int j = hi - 1;
        while (i < j)
        {
          do
            ;
          while (this.comparer.Compare(this.keys[++i], key) < 0);
          do
            ;
          while (this.comparer.Compare(key, this.keys[--j]) < 0);
          if (i < j)
            this.Swap(i, j);
          else
            break;
        }
        this.Swap(i, hi - 1);
        return i;
      }

      private void Heapsort(int lo, int hi)
      {
        int n = hi - lo + 1;
        for (int i = n / 2; i >= 1; --i)
          this.DownHeap(i, n, lo);
        for (int index = n; index > 1; --index)
        {
          this.Swap(lo, lo + index - 1);
          this.DownHeap(1, index - 1, lo);
        }
      }

      private void DownHeap(int i, int n, int lo)
      {
        object key = this.keys[lo + i - 1];
        object obj = this.items != null ? this.items[lo + i - 1] : (object) null;
        int num;
        for (; i <= n / 2; i = num)
        {
          num = 2 * i;
          if (num < n && this.comparer.Compare(this.keys[lo + num - 1], this.keys[lo + num]) < 0)
            ++num;
          if (this.comparer.Compare(key, this.keys[lo + num - 1]) < 0)
          {
            this.keys[lo + i - 1] = this.keys[lo + num - 1];
            if (this.items != null)
              this.items[lo + i - 1] = this.items[lo + num - 1];
          }
          else
            break;
        }
        this.keys[lo + i - 1] = key;
        if (this.items == null)
          return;
        this.items[lo + i - 1] = obj;
      }

      private void InsertionSort(int lo, int hi)
      {
        for (int index1 = lo; index1 < hi; ++index1)
        {
          int index2 = index1;
          object key = this.keys[index1 + 1];
          object obj = this.items != null ? this.items[index1 + 1] : (object) null;
          for (; index2 >= lo && this.comparer.Compare(key, this.keys[index2]) < 0; --index2)
          {
            this.keys[index2 + 1] = this.keys[index2];
            if (this.items != null)
              this.items[index2 + 1] = this.items[index2];
          }
          this.keys[index2 + 1] = key;
          if (this.items != null)
            this.items[index2 + 1] = obj;
        }
      }
    }

    private struct SorterGenericArray
    {
      private Array keys;
      private Array items;
      private IComparer comparer;

      internal SorterGenericArray(Array keys, Array items, IComparer comparer)
      {
        if (comparer == null)
          comparer = (IComparer) Comparer.Default;
        this.keys = keys;
        this.items = items;
        this.comparer = comparer;
      }

      internal void SwapIfGreaterWithItems(int a, int b)
      {
        if (a == b || this.comparer.Compare(this.keys.GetValue(a), this.keys.GetValue(b)) <= 0)
          return;
        object obj1 = this.keys.GetValue(a);
        this.keys.SetValue(this.keys.GetValue(b), a);
        this.keys.SetValue(obj1, b);
        if (this.items == null)
          return;
        object obj2 = this.items.GetValue(a);
        this.items.SetValue(this.items.GetValue(b), a);
        this.items.SetValue(obj2, b);
      }

      private void Swap(int i, int j)
      {
        object obj1 = this.keys.GetValue(i);
        this.keys.SetValue(this.keys.GetValue(j), i);
        this.keys.SetValue(obj1, j);
        if (this.items == null)
          return;
        object obj2 = this.items.GetValue(i);
        this.items.SetValue(this.items.GetValue(j), i);
        this.items.SetValue(obj2, j);
      }

      internal void Sort(int left, int length)
      {
        if (BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
          this.IntrospectiveSort(left, length);
        else
          this.DepthLimitedQuickSort(left, length + left - 1, 32);
      }

      private void DepthLimitedQuickSort(int left, int right, int depthLimit)
      {
        while (depthLimit != 0)
        {
          int num1 = left;
          int num2 = right;
          int median = Array.GetMedian(num1, num2);
          try
          {
            this.SwapIfGreaterWithItems(num1, median);
            this.SwapIfGreaterWithItems(num1, num2);
            this.SwapIfGreaterWithItems(median, num2);
          }
          catch (Exception ex)
          {
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
          }
          object obj1 = this.keys.GetValue(median);
          do
          {
            try
            {
              while (this.comparer.Compare(this.keys.GetValue(num1), obj1) < 0)
                ++num1;
              while (this.comparer.Compare(obj1, this.keys.GetValue(num2)) < 0)
                --num2;
            }
            catch (IndexOutOfRangeException ex)
            {
              throw new ArgumentException(Environment.GetResourceString("Arg_BogusIComparer", (object) this.comparer));
            }
            catch (Exception ex)
            {
              throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
            }
            if (num1 <= num2)
            {
              if (num1 < num2)
              {
                object obj2 = this.keys.GetValue(num1);
                this.keys.SetValue(this.keys.GetValue(num2), num1);
                this.keys.SetValue(obj2, num2);
                if (this.items != null)
                {
                  object obj3 = this.items.GetValue(num1);
                  this.items.SetValue(this.items.GetValue(num2), num1);
                  this.items.SetValue(obj3, num2);
                }
              }
              if (num1 != int.MaxValue)
                ++num1;
              if (num2 != int.MinValue)
                --num2;
            }
            else
              break;
          }
          while (num1 <= num2);
          --depthLimit;
          if (num2 - left <= right - num1)
          {
            if (left < num2)
              this.DepthLimitedQuickSort(left, num2, depthLimit);
            left = num1;
          }
          else
          {
            if (num1 < right)
              this.DepthLimitedQuickSort(num1, right, depthLimit);
            right = num2;
          }
          if (left >= right)
            return;
        }
        try
        {
          this.Heapsort(left, right);
        }
        catch (IndexOutOfRangeException ex)
        {
          throw new ArgumentException(Environment.GetResourceString("Arg_BogusIComparer", (object) this.comparer));
        }
        catch (Exception ex)
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
        }
      }

      private void IntrospectiveSort(int left, int length)
      {
        if (length < 2)
          return;
        try
        {
          this.IntroSort(left, length + left - 1, 2 * IntrospectiveSortUtilities.FloorLog2(this.keys.Length));
        }
        catch (IndexOutOfRangeException ex)
        {
          IntrospectiveSortUtilities.ThrowOrIgnoreBadComparer((object) this.comparer);
        }
        catch (Exception ex)
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_IComparerFailed"), ex);
        }
      }

      private void IntroSort(int lo, int hi, int depthLimit)
      {
        int num1;
        for (; hi > lo; hi = num1 - 1)
        {
          int num2 = hi - lo + 1;
          if (num2 <= 16)
          {
            if (num2 == 1)
              break;
            if (num2 == 2)
            {
              this.SwapIfGreaterWithItems(lo, hi);
              break;
            }
            if (num2 == 3)
            {
              this.SwapIfGreaterWithItems(lo, hi - 1);
              this.SwapIfGreaterWithItems(lo, hi);
              this.SwapIfGreaterWithItems(hi - 1, hi);
              break;
            }
            this.InsertionSort(lo, hi);
            break;
          }
          if (depthLimit == 0)
          {
            this.Heapsort(lo, hi);
            break;
          }
          --depthLimit;
          num1 = this.PickPivotAndPartition(lo, hi);
          this.IntroSort(num1 + 1, hi, depthLimit);
        }
      }

      private int PickPivotAndPartition(int lo, int hi)
      {
        int num = lo + (hi - lo) / 2;
        this.SwapIfGreaterWithItems(lo, num);
        this.SwapIfGreaterWithItems(lo, hi);
        this.SwapIfGreaterWithItems(num, hi);
        object obj = this.keys.GetValue(num);
        this.Swap(num, hi - 1);
        int i = lo;
        int j = hi - 1;
        while (i < j)
        {
          do
            ;
          while (this.comparer.Compare(this.keys.GetValue(++i), obj) < 0);
          do
            ;
          while (this.comparer.Compare(obj, this.keys.GetValue(--j)) < 0);
          if (i < j)
            this.Swap(i, j);
          else
            break;
        }
        this.Swap(i, hi - 1);
        return i;
      }

      private void Heapsort(int lo, int hi)
      {
        int n = hi - lo + 1;
        for (int i = n / 2; i >= 1; --i)
          this.DownHeap(i, n, lo);
        for (int index = n; index > 1; --index)
        {
          this.Swap(lo, lo + index - 1);
          this.DownHeap(1, index - 1, lo);
        }
      }

      private void DownHeap(int i, int n, int lo)
      {
        object x = this.keys.GetValue(lo + i - 1);
        object obj = this.items != null ? this.items.GetValue(lo + i - 1) : (object) null;
        int num;
        for (; i <= n / 2; i = num)
        {
          num = 2 * i;
          if (num < n && this.comparer.Compare(this.keys.GetValue(lo + num - 1), this.keys.GetValue(lo + num)) < 0)
            ++num;
          if (this.comparer.Compare(x, this.keys.GetValue(lo + num - 1)) < 0)
          {
            this.keys.SetValue(this.keys.GetValue(lo + num - 1), lo + i - 1);
            if (this.items != null)
              this.items.SetValue(this.items.GetValue(lo + num - 1), lo + i - 1);
          }
          else
            break;
        }
        this.keys.SetValue(x, lo + i - 1);
        if (this.items == null)
          return;
        this.items.SetValue(obj, lo + i - 1);
      }

      private void InsertionSort(int lo, int hi)
      {
        for (int index1 = lo; index1 < hi; ++index1)
        {
          int index2 = index1;
          object x = this.keys.GetValue(index1 + 1);
          object obj = this.items != null ? this.items.GetValue(index1 + 1) : (object) null;
          for (; index2 >= lo && this.comparer.Compare(x, this.keys.GetValue(index2)) < 0; --index2)
          {
            this.keys.SetValue(this.keys.GetValue(index2), index2 + 1);
            if (this.items != null)
              this.items.SetValue(this.items.GetValue(index2), index2 + 1);
          }
          this.keys.SetValue(x, index2 + 1);
          if (this.items != null)
            this.items.SetValue(obj, index2 + 1);
        }
      }
    }

    [Serializable]
    private sealed class SZArrayEnumerator : IEnumerator, ICloneable
    {
      private Array _array;
      private int _index;
      private int _endIndex;

      internal SZArrayEnumerator(Array array)
      {
        this._array = array;
        this._index = -1;
        this._endIndex = array.Length;
      }

      public object Clone()
      {
        return this.MemberwiseClone();
      }

      public bool MoveNext()
      {
        if (this._index >= this._endIndex)
          return false;
        ++this._index;
        return this._index < this._endIndex;
      }

      public object Current
      {
        get
        {
          if (this._index < 0)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
          if (this._index >= this._endIndex)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
          return this._array.GetValue(this._index);
        }
      }

      public void Reset()
      {
        this._index = -1;
      }
    }

    [Serializable]
    private sealed class ArrayEnumerator : IEnumerator, ICloneable
    {
      private Array array;
      private int index;
      private int endIndex;
      private int startIndex;
      private int[] _indices;
      private bool _complete;

      internal ArrayEnumerator(Array array, int index, int count)
      {
        this.array = array;
        this.index = index - 1;
        this.startIndex = index;
        this.endIndex = index + count;
        this._indices = new int[array.Rank];
        int num = 1;
        for (int dimension = 0; dimension < array.Rank; ++dimension)
        {
          this._indices[dimension] = array.GetLowerBound(dimension);
          num *= array.GetLength(dimension);
        }
        --this._indices[this._indices.Length - 1];
        this._complete = num == 0;
      }

      private void IncArray()
      {
        int rank = this.array.Rank;
        ++this._indices[rank - 1];
        for (int dimension1 = rank - 1; dimension1 >= 0; --dimension1)
        {
          if (this._indices[dimension1] > this.array.GetUpperBound(dimension1))
          {
            if (dimension1 == 0)
            {
              this._complete = true;
              break;
            }
            for (int dimension2 = dimension1; dimension2 < rank; ++dimension2)
              this._indices[dimension2] = this.array.GetLowerBound(dimension2);
            ++this._indices[dimension1 - 1];
          }
        }
      }

      public object Clone()
      {
        return this.MemberwiseClone();
      }

      public bool MoveNext()
      {
        if (this._complete)
        {
          this.index = this.endIndex;
          return false;
        }
        ++this.index;
        this.IncArray();
        return !this._complete;
      }

      public object Current
      {
        get
        {
          if (this.index < this.startIndex)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
          if (this._complete)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
          return this.array.GetValue(this._indices);
        }
      }

      public void Reset()
      {
        this.index = this.startIndex - 1;
        int num = 1;
        for (int dimension = 0; dimension < this.array.Rank; ++dimension)
        {
          this._indices[dimension] = this.array.GetLowerBound(dimension);
          num *= this.array.GetLength(dimension);
        }
        this._complete = num == 0;
        --this._indices[this._indices.Length - 1];
      }
    }
  }
}
