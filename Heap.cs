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

        while (currentIndex > 0 && this._items[currentIndex].CompareTo(this._items[ParentIndex(currentIndex)]) < 0)
        {
            Swap(currentIndex, ParentIndex(currentIndex));
            currentIndex = ParentIndex(currentIndex);
        }
    }

    public T RemoveMin()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        T min = this._items[0];
        this._items[0] = this._items[Count - 1];
        this._items.RemoveAt(Count - 1);

        int currentIndex = 0;
        while (HasLeftChild(currentIndex))
        {
            int smallerChildIndex = LeftChildIndex(currentIndex);
            if (HasRightChild(currentIndex) && this._items[RightChildIndex(currentIndex)].CompareTo(this._items[smallerChildIndex]) < 0)
            {
                smallerChildIndex = RightChildIndex(currentIndex);
            }

            if (this._items[currentIndex].CompareTo(this._items[smallerChildIndex]) < 0)
            {
                break;
            }

            Swap(currentIndex, smallerChildIndex);
            currentIndex = smallerChildIndex;
        }

        return min;
    }

    private void Swap(int indexA, int indexB)
    {
        T temp = this._items[indexA];
        this._items[indexA] = this._items[indexB];
        this._items[indexB] = temp;
    }

    private int ParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private int LeftChildIndex(int index)
    {
        return 2 * index + 1;
    }

    private int RightChildIndex(int index)
    {
        return 2 * index + 2;
    }

    private bool HasLeftChild(int index)
    {
        return LeftChildIndex(index) < Count;
    }

    private bool HasRightChild(int index)
    {
        return RightChildIndex(index) < Count;
    }
}