// Decompiled with JetBrains decompiler
// Type: System.Linq.Enumerable
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 548CE49A-FA67-4B90-A074-9067AEBB2C19
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Core.dll

using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.Linq
{
  [__DynamicallyInvokable]
  public static class Enumerable
  {
    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      if (source is Enumerable.Iterator<TSource>)
        return ((Enumerable.Iterator<TSource>) source).Where(predicate);
      if (source is TSource[])
        return (IEnumerable<TSource>) new Enumerable.WhereArrayIterator<TSource>((TSource[]) source, predicate);
      if (source is List<TSource>)
        return (IEnumerable<TSource>) new Enumerable.WhereListIterator<TSource>((List<TSource>) source, predicate);
      return (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(source, predicate);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      return Enumerable.WhereIterator<TSource>(source, predicate);
    }

    private static IEnumerable<TSource> WhereIterator<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        if (predicate(source1, index))
          yield return source1;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (selector == null)
        throw Error.ArgumentNull(nameof (selector));
      if (source is Enumerable.Iterator<TSource>)
        return ((Enumerable.Iterator<TSource>) source).Select<TResult>(selector);
      if (source is TSource[])
        return (IEnumerable<TResult>) new Enumerable.WhereSelectArrayIterator<TSource, TResult>((TSource[]) source, (Func<TSource, bool>) null, selector);
      if (source is List<TSource>)
        return (IEnumerable<TResult>) new Enumerable.WhereSelectListIterator<TSource, TResult>((List<TSource>) source, (Func<TSource, bool>) null, selector);
      return (IEnumerable<TResult>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(source, (Func<TSource, bool>) null, selector);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (selector == null)
        throw Error.ArgumentNull(nameof (selector));
      return Enumerable.SelectIterator<TSource, TResult>(source, selector);
    }

    private static IEnumerable<TResult> SelectIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        yield return selector(source1, index);
      }
    }

    private static Func<TSource, bool> CombinePredicates<TSource>(Func<TSource, bool> predicate1, Func<TSource, bool> predicate2)
    {
      return (Func<TSource, bool>) (x =>
      {
        if (predicate1(x))
          return predicate2(x);
        return false;
      });
    }

    private static Func<TSource, TResult> CombineSelectors<TSource, TMiddle, TResult>(Func<TSource, TMiddle> selector1, Func<TMiddle, TResult> selector2)
    {
      return (Func<TSource, TResult>) (x => selector2(selector1(x)));
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (selector == null)
        throw Error.ArgumentNull(nameof (selector));
      return Enumerable.SelectManyIterator<TSource, TResult>(source, selector);
    }

    private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
    {
      foreach (TSource source1 in source)
      {
        foreach (TResult result in selector(source1))
          yield return result;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (selector == null)
        throw Error.ArgumentNull(nameof (selector));
      return Enumerable.SelectManyIterator<TSource, TResult>(source, selector);
    }

    private static IEnumerable<TResult> SelectManyIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        foreach (TResult result in selector(source1, index))
          yield return result;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (collectionSelector == null)
        throw Error.ArgumentNull(nameof (collectionSelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        TSource element = source1;
        checked { ++index; }
        foreach (TCollection collection in collectionSelector(element, index))
          yield return resultSelector(element, collection);
        element = default (TSource);
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (collectionSelector == null)
        throw Error.ArgumentNull(nameof (collectionSelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.SelectManyIterator<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
    }

    private static IEnumerable<TResult> SelectManyIterator<TSource, TCollection, TResult>(IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
    {
      foreach (TSource source1 in source)
      {
        TSource element = source1;
        foreach (TCollection collection in collectionSelector(element))
          yield return resultSelector(element, collection);
        element = default (TSource);
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.TakeIterator<TSource>(source, count);
    }

    private static IEnumerable<TSource> TakeIterator<TSource>(IEnumerable<TSource> source, int count)
    {
      if (count > 0)
      {
        foreach (TSource source1 in source)
        {
          yield return source1;
          if (--count == 0)
            break;
        }
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      return Enumerable.TakeWhileIterator<TSource>(source, predicate);
    }

    private static IEnumerable<TSource> TakeWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          yield return source1;
        else
          break;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      return Enumerable.TakeWhileIterator<TSource>(source, predicate);
    }

    private static IEnumerable<TSource> TakeWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      int index = -1;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        if (predicate(source1, index))
          yield return source1;
        else
          break;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.SkipIterator<TSource>(source, count);
    }

    private static IEnumerable<TSource> SkipIterator<TSource>(IEnumerable<TSource> source, int count)
    {
      using (IEnumerator<TSource> e = source.GetEnumerator())
      {
        while (count > 0 && e.MoveNext())
          --count;
        if (count <= 0)
        {
          while (e.MoveNext())
            yield return e.Current;
        }
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      return Enumerable.SkipWhileIterator<TSource>(source, predicate);
    }

    private static IEnumerable<TSource> SkipWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      bool yielding = false;
      foreach (TSource source1 in source)
      {
        if (!yielding && !predicate(source1))
          yielding = true;
        if (yielding)
          yield return source1;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      return Enumerable.SkipWhileIterator<TSource>(source, predicate);
    }

    private static IEnumerable<TSource> SkipWhileIterator<TSource>(IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
    {
      int index = -1;
      bool yielding = false;
      foreach (TSource source1 in source)
      {
        checked { ++index; }
        if (!yielding && !predicate(source1, index))
          yielding = true;
        if (yielding)
          yield return source1;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
    {
      if (outer == null)
        throw Error.ArgumentNull(nameof (outer));
      if (inner == null)
        throw Error.ArgumentNull(nameof (inner));
      if (outerKeySelector == null)
        throw Error.ArgumentNull(nameof (outerKeySelector));
      if (innerKeySelector == null)
        throw Error.ArgumentNull(nameof (innerKeySelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.JoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      if (outer == null)
        throw Error.ArgumentNull(nameof (outer));
      if (inner == null)
        throw Error.ArgumentNull(nameof (inner));
      if (outerKeySelector == null)
        throw Error.ArgumentNull(nameof (outerKeySelector));
      if (innerKeySelector == null)
        throw Error.ArgumentNull(nameof (innerKeySelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.JoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    private static IEnumerable<TResult> JoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
      foreach (TOuter outer1 in outer)
      {
        TOuter item = outer1;
        Lookup<TKey, TInner>.Grouping g = lookup.GetGrouping(outerKeySelector(item), false);
        if (g != null)
        {
          for (int i = 0; i < g.count; ++i)
            yield return resultSelector(item, g.elements[i]);
        }
        g = (Lookup<TKey, TInner>.Grouping) null;
        item = default (TOuter);
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
    {
      if (outer == null)
        throw Error.ArgumentNull(nameof (outer));
      if (inner == null)
        throw Error.ArgumentNull(nameof (inner));
      if (outerKeySelector == null)
        throw Error.ArgumentNull(nameof (outerKeySelector));
      if (innerKeySelector == null)
        throw Error.ArgumentNull(nameof (innerKeySelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.GroupJoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      if (outer == null)
        throw Error.ArgumentNull(nameof (outer));
      if (inner == null)
        throw Error.ArgumentNull(nameof (inner));
      if (outerKeySelector == null)
        throw Error.ArgumentNull(nameof (outerKeySelector));
      if (innerKeySelector == null)
        throw Error.ArgumentNull(nameof (innerKeySelector));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.GroupJoinIterator<TOuter, TInner, TKey, TResult>(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
    }

    private static IEnumerable<TResult> GroupJoinIterator<TOuter, TInner, TKey, TResult>(IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
      foreach (TOuter outer1 in outer)
        yield return resultSelector(outer1, lookup[outerKeySelector(outer1)]);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, (IComparer<TKey>) null, false);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, false);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, (IComparer<TKey>) null, true);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      return (IOrderedEnumerable<TSource>) new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, true);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return source.CreateOrderedEnumerable<TKey>(keySelector, (IComparer<TKey>) null, false);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return source.CreateOrderedEnumerable<TKey>(keySelector, comparer, false);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return source.CreateOrderedEnumerable<TKey>(keySelector, (IComparer<TKey>) null, true);
    }

    [__DynamicallyInvokable]
    public static IOrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IOrderedEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return source.CreateOrderedEnumerable<TKey>(keySelector, comparer, true);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return (IEnumerable<IGrouping<TKey, TSource>>) new GroupedEnumerable<TSource, TKey, TSource>(source, keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      return (IEnumerable<IGrouping<TKey, TSource>>) new GroupedEnumerable<TSource, TKey, TSource>(source, keySelector, IdentityFunction<TSource>.Instance, comparer);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      return (IEnumerable<IGrouping<TKey, TElement>>) new GroupedEnumerable<TSource, TKey, TElement>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      return (IEnumerable<IGrouping<TKey, TElement>>) new GroupedEnumerable<TSource, TKey, TElement>(source, keySelector, elementSelector, comparer);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
    {
      return (IEnumerable<TResult>) new GroupedEnumerable<TSource, TKey, TSource, TResult>(source, keySelector, IdentityFunction<TSource>.Instance, resultSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
    {
      return (IEnumerable<TResult>) new GroupedEnumerable<TSource, TKey, TElement, TResult>(source, keySelector, elementSelector, resultSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      return (IEnumerable<TResult>) new GroupedEnumerable<TSource, TKey, TSource, TResult>(source, keySelector, IdentityFunction<TSource>.Instance, resultSelector, comparer);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
    {
      return (IEnumerable<TResult>) new GroupedEnumerable<TSource, TKey, TElement, TResult>(source, keySelector, elementSelector, resultSelector, comparer);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.ConcatIterator<TSource>(first, second);
    }

    private static IEnumerable<TSource> ConcatIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      foreach (TSource source in first)
        yield return source;
      foreach (TSource source in second)
        yield return source;
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      return Enumerable.ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector);
    }

    private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
    {
      using (IEnumerator<TFirst> e1 = first.GetEnumerator())
      {
        using (IEnumerator<TSecond> e2 = second.GetEnumerator())
        {
          while (e1.MoveNext() && e2.MoveNext())
            yield return resultSelector(e1.Current, e2.Current);
        }
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.DistinctIterator<TSource>(source, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.DistinctIterator<TSource>(source, comparer);
    }

    private static IEnumerable<TSource> DistinctIterator<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      foreach (TSource source1 in source)
      {
        if (set.Add(source1))
          yield return source1;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.UnionIterator<TSource>(first, second, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.UnionIterator<TSource>(first, second, comparer);
    }

    private static IEnumerable<TSource> UnionIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      foreach (TSource source in first)
      {
        if (set.Add(source))
          yield return source;
      }
      foreach (TSource source in second)
      {
        if (set.Add(source))
          yield return source;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.IntersectIterator<TSource>(first, second, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.IntersectIterator<TSource>(first, second, comparer);
    }

    private static IEnumerable<TSource> IntersectIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      foreach (TSource source in second)
        set.Add(source);
      foreach (TSource source in first)
      {
        if (set.Remove(source))
          yield return source;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.ExceptIterator<TSource>(first, second, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      return Enumerable.ExceptIterator<TSource>(first, second, comparer);
    }

    private static IEnumerable<TSource> ExceptIterator<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      Set<TSource> set = new Set<TSource>(comparer);
      foreach (TSource source in second)
        set.Add(source);
      foreach (TSource source in first)
      {
        if (set.Add(source))
          yield return source;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.ReverseIterator<TSource>(source);
    }

    private static IEnumerable<TSource> ReverseIterator<TSource>(IEnumerable<TSource> source)
    {
      Buffer<TSource> buffer = new Buffer<TSource>(source);
      for (int i = buffer.count - 1; i >= 0; --i)
        yield return buffer.items[i];
    }

    [__DynamicallyInvokable]
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
    {
      return first.SequenceEqual<TSource>(second, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
    {
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      if (first == null)
        throw Error.ArgumentNull(nameof (first));
      if (second == null)
        throw Error.ArgumentNull(nameof (second));
      using (IEnumerator<TSource> enumerator1 = first.GetEnumerator())
      {
        using (IEnumerator<TSource> enumerator2 = second.GetEnumerator())
        {
          while (enumerator1.MoveNext())
          {
            if (!enumerator2.MoveNext() || !comparer.Equals(enumerator1.Current, enumerator2.Current))
              return false;
          }
          if (enumerator2.MoveNext())
            return false;
        }
      }
      return true;
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
    {
      return source;
    }

    [__DynamicallyInvokable]
    public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return new Buffer<TSource>(source).ToArray();
    }

    [__DynamicallyInvokable]
    public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return new List<TSource>(source);
    }

    [__DynamicallyInvokable]
    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return source.ToDictionary<TSource, TKey, TSource>(keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      return source.ToDictionary<TSource, TKey, TSource>(keySelector, IdentityFunction<TSource>.Instance, comparer);
    }

    [__DynamicallyInvokable]
    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      return source.ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (keySelector == null)
        throw Error.ArgumentNull(nameof (keySelector));
      if (elementSelector == null)
        throw Error.ArgumentNull(nameof (elementSelector));
      Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(comparer);
      foreach (TSource source1 in source)
        dictionary.Add(keySelector(source1), elementSelector(source1));
      return dictionary;
    }

    [__DynamicallyInvokable]
    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
      return (ILookup<TKey, TSource>) Lookup<TKey, TSource>.Create<TSource>(source, keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
    {
      return (ILookup<TKey, TSource>) Lookup<TKey, TSource>.Create<TSource>(source, keySelector, IdentityFunction<TSource>.Instance, comparer);
    }

    [__DynamicallyInvokable]
    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
    {
      return (ILookup<TKey, TElement>) Lookup<TKey, TElement>.Create<TSource>(source, keySelector, elementSelector, (IEqualityComparer<TKey>) null);
    }

    [__DynamicallyInvokable]
    public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
    {
      return (ILookup<TKey, TElement>) Lookup<TKey, TElement>.Create<TSource>(source, keySelector, elementSelector, comparer);
    }

    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
    {
      return source.ToHashSet<TSource>((IEqualityComparer<TSource>) null);
    }

    public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return new HashSet<TSource>(source, comparer);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
    {
      return source.DefaultIfEmpty<TSource>(default (TSource));
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.DefaultIfEmptyIterator<TSource>(source, defaultValue);
    }

    private static IEnumerable<TSource> DefaultIfEmptyIterator<TSource>(IEnumerable<TSource> source, TSource defaultValue)
    {
      using (IEnumerator<TSource> e = source.GetEnumerator())
      {
        if (e.MoveNext())
        {
          do
          {
            yield return e.Current;
          }
          while (e.MoveNext());
        }
        else
          yield return defaultValue;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.OfTypeIterator<TResult>(source);
    }

    private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source)
    {
      foreach (object obj in source)
      {
        if (obj is TResult)
          yield return (TResult) obj;
      }
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
    {
      IEnumerable<TResult> results = source as IEnumerable<TResult>;
      if (results != null)
        return results;
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      return Enumerable.CastIterator<TResult>(source);
    }

    private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source)
    {
      foreach (TResult result in source)
        yield return result;
    }

    [__DynamicallyInvokable]
    public static TSource First<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        if (sourceList.Count > 0)
          return sourceList[0];
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
            return enumerator.Current;
        }
      }
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return source1;
      }
      throw Error.NoMatch();
    }

    [__DynamicallyInvokable]
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        if (sourceList.Count > 0)
          return sourceList[0];
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
            return enumerator.Current;
        }
      }
      return default (TSource);
    }

    [__DynamicallyInvokable]
    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return source1;
      }
      return default (TSource);
    }

    [__DynamicallyInvokable]
    public static TSource Last<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        int count = sourceList.Count;
        if (count > 0)
          return sourceList[count - 1];
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            TSource current;
            do
            {
              current = enumerator.Current;
            }
            while (enumerator.MoveNext());
            return current;
          }
        }
      }
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static TSource Last<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      TSource source1 = default (TSource);
      bool flag = false;
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
        {
          source1 = source2;
          flag = true;
        }
      }
      if (flag)
        return source1;
      throw Error.NoMatch();
    }

    [__DynamicallyInvokable]
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        int count = sourceList.Count;
        if (count > 0)
          return sourceList[count - 1];
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            TSource current;
            do
            {
              current = enumerator.Current;
            }
            while (enumerator.MoveNext());
            return current;
          }
        }
      }
      return default (TSource);
    }

    [__DynamicallyInvokable]
    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      TSource source1 = default (TSource);
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
          source1 = source2;
      }
      return source1;
    }

    [__DynamicallyInvokable]
    public static TSource Single<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        switch (sourceList.Count)
        {
          case 0:
            throw Error.NoElements();
          case 1:
            return sourceList[0];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            throw Error.NoElements();
          TSource current = enumerator.Current;
          if (!enumerator.MoveNext())
            return current;
        }
      }
      throw Error.MoreThanOneElement();
    }

    [__DynamicallyInvokable]
    public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      TSource source1 = default (TSource);
      long num = 0;
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
        {
          source1 = source2;
          checked { ++num; }
        }
      }
      if (num == 0L)
        throw Error.NoMatch();
      if (num == 1L)
        return source1;
      throw Error.MoreThanOneMatch();
    }

    [__DynamicallyInvokable]
    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
      {
        switch (sourceList.Count)
        {
          case 0:
            return default (TSource);
          case 1:
            return sourceList[0];
        }
      }
      else
      {
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
          if (!enumerator.MoveNext())
            return default (TSource);
          TSource current = enumerator.Current;
          if (!enumerator.MoveNext())
            return current;
        }
      }
      throw Error.MoreThanOneElement();
    }

    [__DynamicallyInvokable]
    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      TSource source1 = default (TSource);
      long num = 0;
      foreach (TSource source2 in source)
      {
        if (predicate(source2))
        {
          source1 = source2;
          checked { ++num; }
        }
      }
      if (num == 0L)
        return default (TSource);
      if (num == 1L)
        return source1;
      throw Error.MoreThanOneMatch();
    }

    [__DynamicallyInvokable]
    public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      IList<TSource> sourceList = source as IList<TSource>;
      if (sourceList != null)
        return sourceList[index];
      if (index < 0)
        throw Error.ArgumentOutOfRange(nameof (index));
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          if (index == 0)
            return enumerator.Current;
          --index;
        }
        throw Error.ArgumentOutOfRange(nameof (index));
      }
    }

    [__DynamicallyInvokable]
    public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (index >= 0)
      {
        IList<TSource> sourceList = source as IList<TSource>;
        if (sourceList != null)
        {
          if (index < sourceList.Count)
            return sourceList[index];
        }
        else
        {
          foreach (TSource source1 in source)
          {
            if (index == 0)
              return source1;
            --index;
          }
        }
      }
      return default (TSource);
    }

    [__DynamicallyInvokable]
    public static IEnumerable<int> Range(int start, int count)
    {
      long num = (long) start + (long) count - 1L;
      if (count < 0 || num > (long) int.MaxValue)
        throw Error.ArgumentOutOfRange(nameof (count));
      return Enumerable.RangeIterator(start, count);
    }

    private static IEnumerable<int> RangeIterator(int start, int count)
    {
      for (int i = 0; i < count; ++i)
        yield return start + i;
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
    {
      if (count < 0)
        throw Error.ArgumentOutOfRange(nameof (count));
      return Enumerable.RepeatIterator<TResult>(element, count);
    }

    private static IEnumerable<TResult> RepeatIterator<TResult>(TResult element, int count)
    {
      for (int i = 0; i < count; ++i)
        yield return element;
    }

    [__DynamicallyInvokable]
    public static IEnumerable<TResult> Empty<TResult>()
    {
      return (IEnumerable<TResult>) EmptyEnumerable<TResult>.Instance;
    }

    [__DynamicallyInvokable]
    public static bool Any<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (enumerator.MoveNext())
          return true;
      }
      return false;
    }

    [__DynamicallyInvokable]
    public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          return true;
      }
      return false;
    }

    [__DynamicallyInvokable]
    public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      foreach (TSource source1 in source)
      {
        if (!predicate(source1))
          return false;
      }
      return true;
    }

    [__DynamicallyInvokable]
    public static int Count<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      ICollection<TSource> sources = source as ICollection<TSource>;
      if (sources != null)
        return sources.Count;
      ICollection collection = source as ICollection;
      if (collection != null)
        return collection.Count;
      int num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          checked { ++num; }
      }
      return num;
    }

    [__DynamicallyInvokable]
    public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      int num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          checked { ++num; }
      }
      return num;
    }

    [__DynamicallyInvokable]
    public static long LongCount<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num = 0;
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        while (enumerator.MoveNext())
          checked { ++num; }
      }
      return num;
    }

    [__DynamicallyInvokable]
    public static long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (predicate == null)
        throw Error.ArgumentNull(nameof (predicate));
      long num = 0;
      foreach (TSource source1 in source)
      {
        if (predicate(source1))
          checked { ++num; }
      }
      return num;
    }

    [__DynamicallyInvokable]
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
    {
      ICollection<TSource> sources = source as ICollection<TSource>;
      if (sources != null)
        return sources.Contains(value);
      return source.Contains<TSource>(value, (IEqualityComparer<TSource>) null);
    }

    [__DynamicallyInvokable]
    public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
    {
      if (comparer == null)
        comparer = (IEqualityComparer<TSource>) EqualityComparer<TSource>.Default;
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      foreach (TSource x in source)
      {
        if (comparer.Equals(x, value))
          return true;
      }
      return false;
    }

    [__DynamicallyInvokable]
    public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (func == null)
        throw Error.ArgumentNull(nameof (func));
      using (IEnumerator<TSource> enumerator = source.GetEnumerator())
      {
        if (!enumerator.MoveNext())
          throw Error.NoElements();
        TSource source1 = enumerator.Current;
        while (enumerator.MoveNext())
          source1 = func(source1, enumerator.Current);
        return source1;
      }
    }

    [__DynamicallyInvokable]
    public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (func == null)
        throw Error.ArgumentNull(nameof (func));
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return accumulate;
    }

    [__DynamicallyInvokable]
    public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      if (func == null)
        throw Error.ArgumentNull(nameof (func));
      if (resultSelector == null)
        throw Error.ArgumentNull(nameof (resultSelector));
      TAccumulate accumulate = seed;
      foreach (TSource source1 in source)
        accumulate = func(accumulate, source1);
      return resultSelector(accumulate);
    }

    [__DynamicallyInvokable]
    public static int Sum(this IEnumerable<int> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int num1 = 0;
      foreach (int num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    [__DynamicallyInvokable]
    public static int? Sum(this IEnumerable<int?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int num = 0;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new int?(num);
    }

    [__DynamicallyInvokable]
    public static long Sum(this IEnumerable<long> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      foreach (long num2 in source)
        checked { num1 += num2; }
      return num1;
    }

    [__DynamicallyInvokable]
    public static long? Sum(this IEnumerable<long?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num = 0;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
          checked { num += nullable.GetValueOrDefault(); }
      }
      return new long?(num);
    }

    [__DynamicallyInvokable]
    public static float Sum(this IEnumerable<float> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      foreach (float num2 in source)
        num1 += (double) num2;
      return (float) num1;
    }

    [__DynamicallyInvokable]
    public static float? Sum(this IEnumerable<float?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num = 0.0;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
          num += (double) nullable.GetValueOrDefault();
      }
      return new float?((float) num);
    }

    [__DynamicallyInvokable]
    public static double Sum(this IEnumerable<double> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      foreach (double num2 in source)
        num1 += num2;
      return num1;
    }

    [__DynamicallyInvokable]
    public static double? Sum(this IEnumerable<double?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num = 0.0;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new double?(num);
    }

    [__DynamicallyInvokable]
    public static Decimal Sum(this IEnumerable<Decimal> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num1 = new Decimal();
      foreach (Decimal num2 in source)
        num1 += num2;
      return num1;
    }

    [__DynamicallyInvokable]
    public static Decimal? Sum(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num = new Decimal();
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
          num += nullable.GetValueOrDefault();
      }
      return new Decimal?(num);
    }

    [__DynamicallyInvokable]
    public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      return source.Select<TSource, int>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static int? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      return source.Select<TSource, int?>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static long Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      return source.Select<TSource, long>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static long? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
    {
      return source.Select<TSource, long?>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static float Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
    {
      return source.Select<TSource, float>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static float? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
    {
      return source.Select<TSource, float?>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static double Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
    {
      return source.Select<TSource, double>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static double? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
    {
      return source.Select<TSource, double?>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static Decimal Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal> selector)
    {
      return source.Select<TSource, Decimal>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static Decimal? Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal?> selector)
    {
      return source.Select<TSource, Decimal?>(selector).Sum();
    }

    [__DynamicallyInvokable]
    public static int Min(this IEnumerable<int> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int num1 = 0;
      bool flag = false;
      foreach (int num2 in source)
      {
        if (flag)
        {
          if (num2 < num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static int? Min(this IEnumerable<int?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int? nullable1 = new int?();
      foreach (int? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          int? nullable3 = nullable2;
          int? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() < nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static long Min(this IEnumerable<long> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      bool flag = false;
      foreach (long num2 in source)
      {
        if (flag)
        {
          if (num2 < num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static long? Min(this IEnumerable<long?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long? nullable1 = new long?();
      foreach (long? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          long? nullable3 = nullable2;
          long? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() < nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static float Min(this IEnumerable<float> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      float num = 0.0f;
      bool flag = false;
      foreach (float f in source)
      {
        if (flag)
        {
          if ((double) f < (double) num || float.IsNaN(f))
            num = f;
        }
        else
        {
          num = f;
          flag = true;
        }
      }
      if (flag)
        return num;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static float? Min(this IEnumerable<float?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      float? nullable1 = new float?();
      foreach (float? nullable2 in source)
      {
        if (nullable2.HasValue)
        {
          if (nullable1.HasValue)
          {
            float? nullable3 = nullable2;
            float? nullable4 = nullable1;
            if (((double) nullable3.GetValueOrDefault() < (double) nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0 && !float.IsNaN(nullable2.Value))
              continue;
          }
          nullable1 = nullable2;
        }
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static double Min(this IEnumerable<double> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num = 0.0;
      bool flag = false;
      foreach (double d in source)
      {
        if (flag)
        {
          if (d < num || double.IsNaN(d))
            num = d;
        }
        else
        {
          num = d;
          flag = true;
        }
      }
      if (flag)
        return num;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static double? Min(this IEnumerable<double?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double? nullable1 = new double?();
      foreach (double? nullable2 in source)
      {
        if (nullable2.HasValue)
        {
          if (nullable1.HasValue)
          {
            double? nullable3 = nullable2;
            double? nullable4 = nullable1;
            if ((nullable3.GetValueOrDefault() < nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0 && !double.IsNaN(nullable2.Value))
              continue;
          }
          nullable1 = nullable2;
        }
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static Decimal Min(this IEnumerable<Decimal> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num1 = new Decimal();
      bool flag = false;
      foreach (Decimal num2 in source)
      {
        if (flag)
        {
          if (num2 < num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static Decimal? Min(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal? nullable1 = new Decimal?();
      foreach (Decimal? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          Decimal? nullable3 = nullable2;
          Decimal? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() < nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static TSource Min<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) y == null)
      {
        foreach (TSource x in source)
        {
          if ((object) x != null && ((object) y == null || comparer.Compare(x, y) < 0))
            y = x;
        }
        return y;
      }
      bool flag = false;
      foreach (TSource x in source)
      {
        if (flag)
        {
          if (comparer.Compare(x, y) < 0)
            y = x;
        }
        else
        {
          y = x;
          flag = true;
        }
      }
      if (flag)
        return y;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      return source.Select<TSource, int>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      return source.Select<TSource, int?>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      return source.Select<TSource, long>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static long? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
    {
      return source.Select<TSource, long?>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static float Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
    {
      return source.Select<TSource, float>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static float? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
    {
      return source.Select<TSource, float?>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static double Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
    {
      return source.Select<TSource, double>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static double? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
    {
      return source.Select<TSource, double?>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static Decimal Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal> selector)
    {
      return source.Select<TSource, Decimal>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static Decimal? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal?> selector)
    {
      return source.Select<TSource, Decimal?>(selector).Min();
    }

    [__DynamicallyInvokable]
    public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
      return source.Select<TSource, TResult>(selector).Min<TResult>();
    }

    [__DynamicallyInvokable]
    public static int Max(this IEnumerable<int> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int num1 = 0;
      bool flag = false;
      foreach (int num2 in source)
      {
        if (flag)
        {
          if (num2 > num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static int? Max(this IEnumerable<int?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      int? nullable1 = new int?();
      foreach (int? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          int? nullable3 = nullable2;
          int? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() > nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static long Max(this IEnumerable<long> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      bool flag = false;
      foreach (long num2 in source)
      {
        if (flag)
        {
          if (num2 > num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static long? Max(this IEnumerable<long?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long? nullable1 = new long?();
      foreach (long? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          long? nullable3 = nullable2;
          long? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() > nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static double Max(this IEnumerable<double> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double d = 0.0;
      bool flag = false;
      foreach (double num in source)
      {
        if (flag)
        {
          if (num > d || double.IsNaN(d))
            d = num;
        }
        else
        {
          d = num;
          flag = true;
        }
      }
      if (flag)
        return d;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static double? Max(this IEnumerable<double?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double? nullable1 = new double?();
      foreach (double? nullable2 in source)
      {
        if (nullable2.HasValue)
        {
          if (nullable1.HasValue)
          {
            double? nullable3 = nullable2;
            double? nullable4 = nullable1;
            if ((nullable3.GetValueOrDefault() > nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0 && !double.IsNaN(nullable1.Value))
              continue;
          }
          nullable1 = nullable2;
        }
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static float Max(this IEnumerable<float> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      float num1 = 0.0f;
      bool flag = false;
      foreach (float num2 in source)
      {
        if (flag)
        {
          if ((double) num2 > (double) num1 || double.IsNaN((double) num1))
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static float? Max(this IEnumerable<float?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      float? nullable1 = new float?();
      foreach (float? nullable2 in source)
      {
        if (nullable2.HasValue)
        {
          if (nullable1.HasValue)
          {
            float? nullable3 = nullable2;
            float? nullable4 = nullable1;
            if (((double) nullable3.GetValueOrDefault() > (double) nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0 && !float.IsNaN(nullable1.Value))
              continue;
          }
          nullable1 = nullable2;
        }
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static Decimal Max(this IEnumerable<Decimal> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num1 = new Decimal();
      bool flag = false;
      foreach (Decimal num2 in source)
      {
        if (flag)
        {
          if (num2 > num1)
            num1 = num2;
        }
        else
        {
          num1 = num2;
          flag = true;
        }
      }
      if (flag)
        return num1;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static Decimal? Max(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal? nullable1 = new Decimal?();
      foreach (Decimal? nullable2 in source)
      {
        if (nullable1.HasValue)
        {
          Decimal? nullable3 = nullable2;
          Decimal? nullable4 = nullable1;
          if ((nullable3.GetValueOrDefault() > nullable4.GetValueOrDefault() ? (nullable3.HasValue & nullable4.HasValue ? 1 : 0) : 0) == 0)
            continue;
        }
        nullable1 = nullable2;
      }
      return nullable1;
    }

    [__DynamicallyInvokable]
    public static TSource Max<TSource>(this IEnumerable<TSource> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Comparer<TSource> comparer = Comparer<TSource>.Default;
      TSource y = default (TSource);
      if ((object) y == null)
      {
        foreach (TSource x in source)
        {
          if ((object) x != null && ((object) y == null || comparer.Compare(x, y) > 0))
            y = x;
        }
        return y;
      }
      bool flag = false;
      foreach (TSource x in source)
      {
        if (flag)
        {
          if (comparer.Compare(x, y) > 0)
            y = x;
        }
        else
        {
          y = x;
          flag = true;
        }
      }
      if (flag)
        return y;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      return source.Select<TSource, int>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      return source.Select<TSource, int?>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      return source.Select<TSource, long>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static long? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
    {
      return source.Select<TSource, long?>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
    {
      return source.Select<TSource, float>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static float? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
    {
      return source.Select<TSource, float?>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static double Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
    {
      return source.Select<TSource, double>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static double? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
    {
      return source.Select<TSource, double?>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static Decimal Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal> selector)
    {
      return source.Select<TSource, Decimal>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static Decimal? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal?> selector)
    {
      return source.Select<TSource, Decimal?>(selector).Max();
    }

    [__DynamicallyInvokable]
    public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
      return source.Select<TSource, TResult>(selector).Max<TResult>();
    }

    [__DynamicallyInvokable]
    public static double Average(this IEnumerable<int> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      long num2 = 0;
      foreach (int num3 in source)
      {
        checked { num1 += (long) num3; }
        checked { ++num2; }
      }
      if (num2 > 0L)
        return (double) num1 / (double) num2;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static double? Average(this IEnumerable<int?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      long num2 = 0;
      foreach (int? nullable in source)
      {
        if (nullable.HasValue)
        {
          checked { num1 += (long) nullable.GetValueOrDefault(); }
          checked { ++num2; }
        }
      }
      if (num2 > 0L)
        return new double?((double) num1 / (double) num2);
      return new double?();
    }

    [__DynamicallyInvokable]
    public static double Average(this IEnumerable<long> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      long num2 = 0;
      foreach (long num3 in source)
      {
        checked { num1 += num3; }
        checked { ++num2; }
      }
      if (num2 > 0L)
        return (double) num1 / (double) num2;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static double? Average(this IEnumerable<long?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      long num1 = 0;
      long num2 = 0;
      foreach (long? nullable in source)
      {
        if (nullable.HasValue)
        {
          checked { num1 += nullable.GetValueOrDefault(); }
          checked { ++num2; }
        }
      }
      if (num2 > 0L)
        return new double?((double) num1 / (double) num2);
      return new double?();
    }

    [__DynamicallyInvokable]
    public static float Average(this IEnumerable<float> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      long num2 = 0;
      foreach (float num3 in source)
      {
        num1 += (double) num3;
        checked { ++num2; }
      }
      if (num2 > 0L)
        return (float) num1 / (float) num2;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static float? Average(this IEnumerable<float?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      long num2 = 0;
      foreach (float? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += (double) nullable.GetValueOrDefault();
          checked { ++num2; }
        }
      }
      if (num2 > 0L)
        return new float?((float) num1 / (float) num2);
      return new float?();
    }

    [__DynamicallyInvokable]
    public static double Average(this IEnumerable<double> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      long num2 = 0;
      foreach (double num3 in source)
      {
        num1 += num3;
        checked { ++num2; }
      }
      if (num2 > 0L)
        return num1 / (double) num2;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static double? Average(this IEnumerable<double?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      double num1 = 0.0;
      long num2 = 0;
      foreach (double? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += nullable.GetValueOrDefault();
          checked { ++num2; }
        }
      }
      if (num2 > 0L)
        return new double?(num1 / (double) num2);
      return new double?();
    }

    [__DynamicallyInvokable]
    public static Decimal Average(this IEnumerable<Decimal> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num1 = new Decimal();
      long num2 = 0;
      foreach (Decimal num3 in source)
      {
        num1 += num3;
        checked { ++num2; }
      }
      if (num2 > 0L)
        return num1 / (Decimal) num2;
      throw Error.NoElements();
    }

    [__DynamicallyInvokable]
    public static Decimal? Average(this IEnumerable<Decimal?> source)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Decimal num1 = new Decimal();
      long num2 = 0;
      foreach (Decimal? nullable in source)
      {
        if (nullable.HasValue)
        {
          num1 += nullable.GetValueOrDefault();
          checked { ++num2; }
        }
      }
      if (num2 > 0L)
        return new Decimal?(num1 / (Decimal) num2);
      return new Decimal?();
    }

    [__DynamicallyInvokable]
    public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
    {
      return source.Select<TSource, int>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
    {
      return source.Select<TSource, int?>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
    {
      return source.Select<TSource, long>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
    {
      return source.Select<TSource, long?>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static float Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
    {
      return source.Select<TSource, float>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static float? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
    {
      return source.Select<TSource, float?>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
    {
      return source.Select<TSource, double>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
    {
      return source.Select<TSource, double?>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static Decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal> selector)
    {
      return source.Select<TSource, Decimal>(selector).Average();
    }

    [__DynamicallyInvokable]
    public static Decimal? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Decimal?> selector)
    {
      return source.Select<TSource, Decimal?>(selector).Average();
    }

    public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Enumerable.AppendPrependIterator<TSource> appendPrependIterator = source as Enumerable.AppendPrependIterator<TSource>;
      if (appendPrependIterator != null)
        return (IEnumerable<TSource>) appendPrependIterator.Append(element);
      return (IEnumerable<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(source, element, true);
    }

    public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource element)
    {
      if (source == null)
        throw Error.ArgumentNull(nameof (source));
      Enumerable.AppendPrependIterator<TSource> appendPrependIterator = source as Enumerable.AppendPrependIterator<TSource>;
      if (appendPrependIterator != null)
        return (IEnumerable<TSource>) appendPrependIterator.Prepend(element);
      return (IEnumerable<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(source, element, false);
    }

    private abstract class Iterator<TSource> : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IDisposable, IEnumerator
    {
      private int threadId;
      internal int state;
      internal TSource current;

      public Iterator()
      {
        this.threadId = Thread.CurrentThread.ManagedThreadId;
      }

      public TSource Current
      {
        get
        {
          return this.current;
        }
      }

      public abstract Enumerable.Iterator<TSource> Clone();

      public virtual void Dispose()
      {
        this.current = default (TSource);
        this.state = -1;
      }

      public IEnumerator<TSource> GetEnumerator()
      {
        if (this.threadId == Thread.CurrentThread.ManagedThreadId && this.state == 0)
        {
          this.state = 1;
          return (IEnumerator<TSource>) this;
        }
        Enumerable.Iterator<TSource> iterator = this.Clone();
        iterator.state = 1;
        return (IEnumerator<TSource>) iterator;
      }

      public abstract bool MoveNext();

      public abstract IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector);

      public abstract IEnumerable<TSource> Where(Func<TSource, bool> predicate);

      object IEnumerator.Current
      {
        get
        {
          return (object) this.Current;
        }
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) this.GetEnumerator();
      }

      void IEnumerator.Reset()
      {
        throw new NotImplementedException();
      }
    }

    private class WhereEnumerableIterator<TSource> : Enumerable.Iterator<TSource>
    {
      private IEnumerable<TSource> source;
      private Func<TSource, bool> predicate;
      private IEnumerator<TSource> enumerator;

      public WhereEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate)
      {
        this.source = source;
        this.predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone()
      {
        return (Enumerable.Iterator<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(this.source, this.predicate);
      }

      public override void Dispose()
      {
        if (this.enumerator != null)
          this.enumerator.Dispose();
        this.enumerator = (IEnumerator<TSource>) null;
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this.enumerator = this.source.GetEnumerator();
            this.state = 2;
            goto case 2;
          case 2:
            while (this.enumerator.MoveNext())
            {
              TSource current = this.enumerator.Current;
              if (this.predicate(current))
              {
                this.current = current;
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(this.source, this.predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
      {
        return (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>(this.source, Enumerable.CombinePredicates<TSource>(this.predicate, predicate));
      }
    }

    private class WhereArrayIterator<TSource> : Enumerable.Iterator<TSource>
    {
      private TSource[] source;
      private Func<TSource, bool> predicate;
      private int index;

      public WhereArrayIterator(TSource[] source, Func<TSource, bool> predicate)
      {
        this.source = source;
        this.predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone()
      {
        return (Enumerable.Iterator<TSource>) new Enumerable.WhereArrayIterator<TSource>(this.source, this.predicate);
      }

      public override bool MoveNext()
      {
        if (this.state == 1)
        {
          while (this.index < this.source.Length)
          {
            TSource source = this.source[this.index];
            ++this.index;
            if (this.predicate(source))
            {
              this.current = source;
              return true;
            }
          }
          this.Dispose();
        }
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectArrayIterator<TSource, TResult>(this.source, this.predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
      {
        return (IEnumerable<TSource>) new Enumerable.WhereArrayIterator<TSource>(this.source, Enumerable.CombinePredicates<TSource>(this.predicate, predicate));
      }
    }

    private class WhereListIterator<TSource> : Enumerable.Iterator<TSource>
    {
      private List<TSource> source;
      private Func<TSource, bool> predicate;
      private List<TSource>.Enumerator enumerator;

      public WhereListIterator(List<TSource> source, Func<TSource, bool> predicate)
      {
        this.source = source;
        this.predicate = predicate;
      }

      public override Enumerable.Iterator<TSource> Clone()
      {
        return (Enumerable.Iterator<TSource>) new Enumerable.WhereListIterator<TSource>(this.source, this.predicate);
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this.enumerator = this.source.GetEnumerator();
            this.state = 2;
            goto case 2;
          case 2:
            while (this.enumerator.MoveNext())
            {
              TSource current = this.enumerator.Current;
              if (this.predicate(current))
              {
                this.current = current;
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereSelectListIterator<TSource, TResult>(this.source, this.predicate, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
      {
        return (IEnumerable<TSource>) new Enumerable.WhereListIterator<TSource>(this.source, Enumerable.CombinePredicates<TSource>(this.predicate, predicate));
      }
    }

    private class SelectEnumerableIterator<TSource, TResult> : Enumerable.Iterator<TResult>, IIListProvider<TResult>, IEnumerable<TResult>, IEnumerable
    {
      private readonly IEnumerable<TSource> _source;
      private readonly Func<TSource, TResult> _selector;
      private IEnumerator<TSource> _enumerator;

      public SelectEnumerableIterator(IEnumerable<TSource> source, Func<TSource, TResult> selector)
      {
        this._source = source;
        this._selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone()
      {
        return (Enumerable.Iterator<TResult>) new Enumerable.SelectEnumerableIterator<TSource, TResult>(this._source, this._selector);
      }

      public override void Dispose()
      {
        if (this._enumerator != null)
        {
          this._enumerator.Dispose();
          this._enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this._enumerator = this._source.GetEnumerator();
            this.state = 2;
            goto case 2;
          case 2:
            if (this._enumerator.MoveNext())
            {
              this.current = this._selector(this._enumerator.Current);
              return true;
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.SelectEnumerableIterator<TSource, TResult2>(this._source, Enumerable.CombineSelectors<TSource, TResult, TResult2>(this._selector, selector));
      }

      public override IEnumerable<TResult> Where(Func<TResult, bool> predicate)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereEnumerableIterator<TResult>((IEnumerable<TResult>) this, predicate);
      }

      public TResult[] ToArray()
      {
        LargeArrayBuilder<TResult> largeArrayBuilder = new LargeArrayBuilder<TResult>(true);
        foreach (TSource source in this._source)
          largeArrayBuilder.Add(this._selector(source));
        return largeArrayBuilder.ToArray();
      }

      public List<TResult> ToList()
      {
        List<TResult> resultList = new List<TResult>();
        foreach (TSource source in this._source)
          resultList.Add(this._selector(source));
        return resultList;
      }

      public int GetCount(bool onlyIfCheap)
      {
        if (onlyIfCheap)
          return -1;
        int num = 0;
        foreach (TSource source in this._source)
        {
          TResult result = this._selector(source);
          checked { ++num; }
        }
        return num;
      }
    }

    private class WhereSelectEnumerableIterator<TSource, TResult> : Enumerable.Iterator<TResult>
    {
      private IEnumerable<TSource> source;
      private Func<TSource, bool> predicate;
      private Func<TSource, TResult> selector;
      private IEnumerator<TSource> enumerator;

      public WhereSelectEnumerableIterator(IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
      {
        this.source = source;
        this.predicate = predicate;
        this.selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone()
      {
        return (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult>(this.source, this.predicate, this.selector);
      }

      public override void Dispose()
      {
        if (this.enumerator != null)
          this.enumerator.Dispose();
        this.enumerator = (IEnumerator<TSource>) null;
        base.Dispose();
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this.enumerator = this.source.GetEnumerator();
            this.state = 2;
            goto case 2;
          case 2:
            while (this.enumerator.MoveNext())
            {
              TSource current = this.enumerator.Current;
              if (this.predicate == null || this.predicate(current))
              {
                this.current = this.selector(current);
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectEnumerableIterator<TSource, TResult2>(this.source, this.predicate, Enumerable.CombineSelectors<TSource, TResult, TResult2>(this.selector, selector));
      }

      public override IEnumerable<TResult> Where(Func<TResult, bool> predicate)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereEnumerableIterator<TResult>((IEnumerable<TResult>) this, predicate);
      }
    }

    private class WhereSelectArrayIterator<TSource, TResult> : Enumerable.Iterator<TResult>
    {
      private TSource[] source;
      private Func<TSource, bool> predicate;
      private Func<TSource, TResult> selector;
      private int index;

      public WhereSelectArrayIterator(TSource[] source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
      {
        this.source = source;
        this.predicate = predicate;
        this.selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone()
      {
        return (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectArrayIterator<TSource, TResult>(this.source, this.predicate, this.selector);
      }

      public override bool MoveNext()
      {
        if (this.state == 1)
        {
          while (this.index < this.source.Length)
          {
            TSource source = this.source[this.index];
            ++this.index;
            if (this.predicate == null || this.predicate(source))
            {
              this.current = this.selector(source);
              return true;
            }
          }
          this.Dispose();
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectArrayIterator<TSource, TResult2>(this.source, this.predicate, Enumerable.CombineSelectors<TSource, TResult, TResult2>(this.selector, selector));
      }

      public override IEnumerable<TResult> Where(Func<TResult, bool> predicate)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereEnumerableIterator<TResult>((IEnumerable<TResult>) this, predicate);
      }
    }

    private class WhereSelectListIterator<TSource, TResult> : Enumerable.Iterator<TResult>
    {
      private List<TSource> source;
      private Func<TSource, bool> predicate;
      private Func<TSource, TResult> selector;
      private List<TSource>.Enumerator enumerator;

      public WhereSelectListIterator(List<TSource> source, Func<TSource, bool> predicate, Func<TSource, TResult> selector)
      {
        this.source = source;
        this.predicate = predicate;
        this.selector = selector;
      }

      public override Enumerable.Iterator<TResult> Clone()
      {
        return (Enumerable.Iterator<TResult>) new Enumerable.WhereSelectListIterator<TSource, TResult>(this.source, this.predicate, this.selector);
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this.enumerator = this.source.GetEnumerator();
            this.state = 2;
            goto case 2;
          case 2:
            while (this.enumerator.MoveNext())
            {
              TSource current = this.enumerator.Current;
              if (this.predicate == null || this.predicate(current))
              {
                this.current = this.selector(current);
                return true;
              }
            }
            this.Dispose();
            break;
        }
        return false;
      }

      public override IEnumerable<TResult2> Select<TResult2>(Func<TResult, TResult2> selector)
      {
        return (IEnumerable<TResult2>) new Enumerable.WhereSelectListIterator<TSource, TResult2>(this.source, this.predicate, Enumerable.CombineSelectors<TSource, TResult, TResult2>(this.selector, selector));
      }

      public override IEnumerable<TResult> Where(Func<TResult, bool> predicate)
      {
        return (IEnumerable<TResult>) new Enumerable.WhereEnumerableIterator<TResult>((IEnumerable<TResult>) this, predicate);
      }
    }

    private abstract class AppendPrependIterator<TSource> : Enumerable.Iterator<TSource>, IIListProvider<TSource>, IEnumerable<TSource>, IEnumerable
    {
      protected readonly IEnumerable<TSource> _source;
      protected IEnumerator<TSource> enumerator;

      protected AppendPrependIterator(IEnumerable<TSource> source)
      {
        this._source = source;
      }

      protected void GetSourceEnumerator()
      {
        this.enumerator = this._source.GetEnumerator();
      }

      public abstract Enumerable.AppendPrependIterator<TSource> Append(TSource item);

      public abstract Enumerable.AppendPrependIterator<TSource> Prepend(TSource item);

      protected bool LoadFromEnumerator()
      {
        if (this.enumerator.MoveNext())
        {
          this.current = this.enumerator.Current;
          return true;
        }
        this.Dispose();
        return false;
      }

      public override void Dispose()
      {
        if (this.enumerator != null)
        {
          this.enumerator.Dispose();
          this.enumerator = (IEnumerator<TSource>) null;
        }
        base.Dispose();
      }

      public override IEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector)
      {
        return (IEnumerable<TResult>) new Enumerable.SelectEnumerableIterator<TSource, TResult>((IEnumerable<TSource>) this, selector);
      }

      public override IEnumerable<TSource> Where(Func<TSource, bool> predicate)
      {
        return (IEnumerable<TSource>) new Enumerable.WhereEnumerableIterator<TSource>((IEnumerable<TSource>) this, predicate);
      }

      public abstract TSource[] ToArray();

      public abstract List<TSource> ToList();

      public abstract int GetCount(bool onlyIfCheap);
    }

    private class AppendPrepend1Iterator<TSource> : Enumerable.AppendPrependIterator<TSource>
    {
      private readonly TSource _item;
      private readonly bool _appending;

      public AppendPrepend1Iterator(IEnumerable<TSource> source, TSource item, bool appending)
        : base(source)
      {
        this._item = item;
        this._appending = appending;
      }

      public override Enumerable.Iterator<TSource> Clone()
      {
        return (Enumerable.Iterator<TSource>) new Enumerable.AppendPrepend1Iterator<TSource>(this._source, this._item, this._appending);
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this.state = 2;
            if (!this._appending)
            {
              this.current = this._item;
              return true;
            }
            goto case 2;
          case 2:
            this.GetSourceEnumerator();
            this.state = 3;
            goto case 3;
          case 3:
            if (this.LoadFromEnumerator())
              return true;
            if (this._appending)
            {
              this.current = this._item;
              return true;
            }
            break;
        }
        this.Dispose();
        return false;
      }

      public override Enumerable.AppendPrependIterator<TSource> Append(TSource item)
      {
        if (this._appending)
          return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, (SingleLinkedNode<TSource>) null, new SingleLinkedNode<TSource>(this._item).Add(item), 0, 2);
        return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(this._item), new SingleLinkedNode<TSource>(item), 1, 1);
      }

      public override Enumerable.AppendPrependIterator<TSource> Prepend(TSource item)
      {
        if (this._appending)
          return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(item), new SingleLinkedNode<TSource>(this._item), 1, 1);
        return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, new SingleLinkedNode<TSource>(this._item).Add(item), (SingleLinkedNode<TSource>) null, 2, 0);
      }

      private TSource[] LazyToArray()
      {
        LargeArrayBuilder<TSource> largeArrayBuilder = new LargeArrayBuilder<TSource>(true);
        if (!this._appending)
          largeArrayBuilder.SlowAdd(this._item);
        largeArrayBuilder.AddRange(this._source);
        if (this._appending)
          largeArrayBuilder.SlowAdd(this._item);
        return largeArrayBuilder.ToArray();
      }

      public override TSource[] ToArray()
      {
        int count = this.GetCount(true);
        if (count == -1)
          return this.LazyToArray();
        TSource[] array = new TSource[count];
        int arrayIndex;
        if (this._appending)
        {
          arrayIndex = 0;
        }
        else
        {
          array[0] = this._item;
          arrayIndex = 1;
        }
        EnumerableHelpers.Copy<TSource>(this._source, array, arrayIndex, count - 1);
        if (this._appending)
          array[array.Length - 1] = this._item;
        return array;
      }

      public override List<TSource> ToList()
      {
        int count = this.GetCount(true);
        List<TSource> sourceList = count == -1 ? new List<TSource>() : new List<TSource>(count);
        if (!this._appending)
          sourceList.Add(this._item);
        sourceList.AddRange(this._source);
        if (this._appending)
          sourceList.Add(this._item);
        return sourceList;
      }

      public override int GetCount(bool onlyIfCheap)
      {
        IIListProvider<TSource> source = this._source as IIListProvider<TSource>;
        if (source != null)
        {
          int count = source.GetCount(onlyIfCheap);
          if (count != -1)
            return count + 1;
          return -1;
        }
        if (onlyIfCheap && !(this._source is ICollection<TSource>))
          return -1;
        return this._source.Count<TSource>() + 1;
      }
    }

    private class AppendPrependN<TSource> : Enumerable.AppendPrependIterator<TSource>
    {
      private readonly SingleLinkedNode<TSource> _prepended;
      private readonly SingleLinkedNode<TSource> _appended;
      private readonly int _prependCount;
      private readonly int _appendCount;
      private SingleLinkedNode<TSource> _node;

      public AppendPrependN(IEnumerable<TSource> source, SingleLinkedNode<TSource> prepended, SingleLinkedNode<TSource> appended, int prependCount, int appendCount)
        : base(source)
      {
        this._prepended = prepended;
        this._appended = appended;
        this._prependCount = prependCount;
        this._appendCount = appendCount;
      }

      public override Enumerable.Iterator<TSource> Clone()
      {
        return (Enumerable.Iterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended, this._appended, this._prependCount, this._appendCount);
      }

      public override bool MoveNext()
      {
        switch (this.state)
        {
          case 1:
            this._node = this._prepended;
            this.state = 2;
            goto case 2;
          case 2:
            if (this._node != null)
            {
              this.current = this._node.Item;
              this._node = this._node.Linked;
              return true;
            }
            this.GetSourceEnumerator();
            this.state = 3;
            goto case 3;
          case 3:
            if (this.LoadFromEnumerator())
              return true;
            if (this._appended == null)
              return false;
            this.enumerator = this._appended.GetEnumerator(this._appendCount);
            this.state = 4;
            goto case 4;
          case 4:
            return this.LoadFromEnumerator();
          default:
            this.Dispose();
            return false;
        }
      }

      public override Enumerable.AppendPrependIterator<TSource> Append(TSource item)
      {
        return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended, this._appended != null ? this._appended.Add(item) : new SingleLinkedNode<TSource>(item), this._prependCount, this._appendCount + 1);
      }

      public override Enumerable.AppendPrependIterator<TSource> Prepend(TSource item)
      {
        return (Enumerable.AppendPrependIterator<TSource>) new Enumerable.AppendPrependN<TSource>(this._source, this._prepended != null ? this._prepended.Add(item) : new SingleLinkedNode<TSource>(item), this._appended, this._prependCount + 1, this._appendCount);
      }

      private TSource[] LazyToArray()
      {
        SparseArrayBuilder<TSource> sparseArrayBuilder = new SparseArrayBuilder<TSource>(true);
        if (this._prepended != null)
          sparseArrayBuilder.Reserve(this._prependCount);
        sparseArrayBuilder.AddRange(this._source);
        if (this._appended != null)
          sparseArrayBuilder.Reserve(this._appendCount);
        TSource[] array = sparseArrayBuilder.ToArray();
        int num1 = 0;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          array[num1++] = singleLinkedNode.Item;
        int num2 = array.Length - 1;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._appended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          array[num2--] = singleLinkedNode.Item;
        return array;
      }

      public override TSource[] ToArray()
      {
        int count = this.GetCount(true);
        if (count == -1)
          return this.LazyToArray();
        TSource[] array = new TSource[count];
        int arrayIndex = 0;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
        {
          array[arrayIndex] = singleLinkedNode.Item;
          ++arrayIndex;
        }
        ICollection<TSource> source1 = this._source as ICollection<TSource>;
        if (source1 != null)
        {
          source1.CopyTo(array, arrayIndex);
        }
        else
        {
          foreach (TSource source2 in this._source)
          {
            array[arrayIndex] = source2;
            ++arrayIndex;
          }
        }
        int length = array.Length;
        for (SingleLinkedNode<TSource> singleLinkedNode = this._appended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
        {
          --length;
          array[length] = singleLinkedNode.Item;
        }
        return array;
      }

      public override List<TSource> ToList()
      {
        int count = this.GetCount(true);
        List<TSource> sourceList = count == -1 ? new List<TSource>() : new List<TSource>(count);
        for (SingleLinkedNode<TSource> singleLinkedNode = this._prepended; singleLinkedNode != null; singleLinkedNode = singleLinkedNode.Linked)
          sourceList.Add(singleLinkedNode.Item);
        sourceList.AddRange(this._source);
        if (this._appended != null)
        {
          IEnumerator<TSource> enumerator = this._appended.GetEnumerator(this._appendCount);
          while (enumerator.MoveNext())
            sourceList.Add(enumerator.Current);
        }
        return sourceList;
      }

      public override int GetCount(bool onlyIfCheap)
      {
        IIListProvider<TSource> source = this._source as IIListProvider<TSource>;
        if (source != null)
        {
          int count = source.GetCount(onlyIfCheap);
          if (count != -1)
            return count + this._appendCount + this._prependCount;
          return -1;
        }
        if (onlyIfCheap && !(this._source is ICollection<TSource>))
          return -1;
        return this._source.Count<TSource>() + this._appendCount + this._prependCount;
      }
    }
  }
}
