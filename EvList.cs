public class EvList<T> : System.Collections.Generic.List<T>
{
    public event System.EventHandler OnChange;

    public new void Add(T item)
    {
        base.Add(item);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void AddRange(System.Collections.Generic.IEnumerable<T> collection)
    {
        base.AddRange(collection);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Clear()
    {
        base.Clear();
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Insert(int index, T item)
    {
        base.Insert(index, item);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void InsertRange(int index, System.Collections.Generic.IEnumerable<T> collection)
    {
        base.InsertRange(index, collection);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }    

    public new void Remove(T item)
    {
        base.Remove(item);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void RemoveAll(System.Predicate<T> match)
    {
        base.RemoveAll(match);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void RemoveAt(int index)
    {
        base.RemoveAt(index);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void RemoveRange(int index, int count)
    {
        base.RemoveRange(index, count);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Reverse()
    {
        base.Reverse();
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Reverse(int index, int count)
    {
        base.Reverse(index, count);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Sort()
    {
        base.Sort();
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Sort(System.Collections.Generic.IComparer<T> comparer)
    {
        base.Sort(comparer);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Sort(System.Comparison<T> comparison)
    {
        base.Sort(comparison);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }

    public new void Sort(int index, int count, System.Collections.Generic.IComparer<T> comparer)
    {
        base.Sort(index, count, comparer);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }
}