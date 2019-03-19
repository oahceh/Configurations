// Decompiled with JetBrains decompiler
// Type: System.Collections.Stack
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: C3E4200C-CDA7-4037-B5FC-8C34C9135930
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

namespace System.Collections
{
  [DebuggerTypeProxy(typeof (Stack.StackDebugView))]
  [DebuggerDisplay("Count = {Count}")]
  [ComVisible(true)]
  [Serializable]
  public class Stack : ICollection, IEnumerable, ICloneable
  {
    private object[] _array;
    private int _size;
    private int _version;
    [NonSerialized]
    private object _syncRoot;
    private const int _defaultCapacity = 10;

    public Stack()
    {
      this._array = new object[10];
      this._size = 0;
      this._version = 0;
    }

    public Stack(int initialCapacity)
    {
      if (initialCapacity < 0)
        throw new ArgumentOutOfRangeException(nameof (initialCapacity), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (initialCapacity < 10)
        initialCapacity = 10;
      this._array = new object[initialCapacity];
      this._size = 0;
      this._version = 0;
    }

    public Stack(ICollection col)
      : this(col == null ? 32 : col.Count)
    {
      if (col == null)
        throw new ArgumentNullException(nameof (col));
      foreach (object obj in (IEnumerable) col)
        this.Push(obj);
    }

    public virtual int Count
    {
      get
      {
        return this._size;
      }
    }

    public virtual bool IsSynchronized
    {
      get
      {
        return false;
      }
    }

    public virtual object SyncRoot
    {
      get
      {
        if (this._syncRoot == null)
          Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), (object) null);
        return this._syncRoot;
      }
    }

    public virtual void Clear()
    {
      Array.Clear((Array) this._array, 0, this._size);
      this._size = 0;
      ++this._version;
    }

    public virtual object Clone()
    {
      Stack stack = new Stack(this._size);
      stack._size = this._size;
      Array.Copy((Array) this._array, 0, (Array) stack._array, 0, this._size);
      stack._version = this._version;
      return (object) stack;
    }

    public virtual bool Contains(object obj)
    {
      int size = this._size;
      while (size-- > 0)
      {
        if (obj == null)
        {
          if (this._array[size] == null)
            return true;
        }
        else if (this._array[size] != null && this._array[size].Equals(obj))
          return true;
      }
      return false;
    }

    public virtual void CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException(nameof (array));
      if (array.Rank != 1)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof (index), Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - index < this._size)
        throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
      int num = 0;
      if (array is object[])
      {
        object[] objArray = (object[]) array;
        for (; num < this._size; ++num)
          objArray[num + index] = this._array[this._size - num - 1];
      }
      else
      {
        for (; num < this._size; ++num)
          array.SetValue(this._array[this._size - num - 1], num + index);
      }
    }

    public virtual IEnumerator GetEnumerator()
    {
      return (IEnumerator) new Stack.StackEnumerator(this);
    }

    public virtual object Peek()
    {
      if (this._size == 0)
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
      return this._array[this._size - 1];
    }

    public virtual object Pop()
    {
      if (this._size == 0)
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
      ++this._version;
      object obj = this._array[--this._size];
      this._array[this._size] = (object) null;
      return obj;
    }

    public virtual void Push(object obj)
    {
      if (this._size == this._array.Length)
      {
        object[] objArray = new object[2 * this._array.Length];
        Array.Copy((Array) this._array, 0, (Array) objArray, 0, this._size);
        this._array = objArray;
      }
      this._array[this._size++] = obj;
      ++this._version;
    }

    [HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
    public static Stack Synchronized(Stack stack)
    {
      if (stack == null)
        throw new ArgumentNullException(nameof (stack));
      return (Stack) new Stack.SyncStack(stack);
    }

    public virtual object[] ToArray()
    {
      object[] objArray = new object[this._size];
      for (int index = 0; index < this._size; ++index)
        objArray[index] = this._array[this._size - index - 1];
      return objArray;
    }

    [Serializable]
    private class SyncStack : Stack
    {
      private Stack _s;
      private object _root;

      internal SyncStack(Stack stack)
      {
        this._s = stack;
        this._root = stack.SyncRoot;
      }

      public override bool IsSynchronized
      {
        get
        {
          return true;
        }
      }

      public override object SyncRoot
      {
        get
        {
          return this._root;
        }
      }

      public override int Count
      {
        get
        {
          lock (this._root)
            return this._s.Count;
        }
      }

      public override bool Contains(object obj)
      {
        lock (this._root)
          return this._s.Contains(obj);
      }

      public override object Clone()
      {
        lock (this._root)
          return (object) new Stack.SyncStack((Stack) this._s.Clone());
      }

      public override void Clear()
      {
        lock (this._root)
          this._s.Clear();
      }

      public override void CopyTo(Array array, int arrayIndex)
      {
        lock (this._root)
          this._s.CopyTo(array, arrayIndex);
      }

      public override void Push(object value)
      {
        lock (this._root)
          this._s.Push(value);
      }

      public override object Pop()
      {
        lock (this._root)
          return this._s.Pop();
      }

      public override IEnumerator GetEnumerator()
      {
        lock (this._root)
          return this._s.GetEnumerator();
      }

      public override object Peek()
      {
        lock (this._root)
          return this._s.Peek();
      }

      public override object[] ToArray()
      {
        lock (this._root)
          return this._s.ToArray();
      }
    }

    [Serializable]
    private class StackEnumerator : IEnumerator, ICloneable
    {
      private Stack _stack;
      private int _index;
      private int _version;
      private object currentElement;

      internal StackEnumerator(Stack stack)
      {
        this._stack = stack;
        this._version = this._stack._version;
        this._index = -2;
        this.currentElement = (object) null;
      }

      public object Clone()
      {
        return this.MemberwiseClone();
      }

      public virtual bool MoveNext()
      {
        if (this._version != this._stack._version)
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
        if (this._index == -2)
        {
          this._index = this._stack._size - 1;
          bool flag = this._index >= 0;
          if (flag)
            this.currentElement = this._stack._array[this._index];
          return flag;
        }
        if (this._index == -1)
          return false;
        bool flag1 = --this._index >= 0;
        this.currentElement = !flag1 ? (object) null : this._stack._array[this._index];
        return flag1;
      }

      public virtual object Current
      {
        get
        {
          if (this._index == -2)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
          if (this._index == -1)
            throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
          return this.currentElement;
        }
      }

      public virtual void Reset()
      {
        if (this._version != this._stack._version)
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumFailedVersion"));
        this._index = -2;
        this.currentElement = (object) null;
      }
    }

    internal class StackDebugView
    {
      private Stack stack;

      public StackDebugView(Stack stack)
      {
        if (stack == null)
          throw new ArgumentNullException(nameof (stack));
        this.stack = stack;
      }

      [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
      public object[] Items
      {
        get
        {
          return this.stack.ToArray();
        }
      }
    }
  }
}
