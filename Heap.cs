using System.Collections.Generic;
using System;

namespace DataStructures.Collections.Heaps;

public class Heap<T> where T : IComparable<T>
{
    private List<T> _items;

    public Heap()
    {
        this._items = new List<T>();
    }

    public int Count
    {
        get { return this._items.Count; }
    }

    public void Add(T item)
    {
        this._items.Add(item);
        int currentIndex = this._items.Count - 1;

        // todo finish
    }
}