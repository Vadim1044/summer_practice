using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace task03;

public class CustomCollection<T> : IEnumerable<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<T> GetReverseEnumerator()
    {
        for (int item = _items.Count()-1; item>=0; item = item-1)
        {
            yield return _items[item];
        }
    }

    public static IEnumerable<int> GenerateSequence(int start, int count)
    {
        return from i in Enumerable.Range(0, count) select start + i;
    }

    public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
    {
        return from item in _items where predicate(item) orderby keySelector(item) select item;
    }
}
