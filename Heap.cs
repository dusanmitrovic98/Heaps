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
}