public class EvHashtable : System.Collections.Hashtable
{
    public event System.EventHandler OnChange;

    public new void Add(object key, object value)
    {
        base.Add(key, value);
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

    public new void Remove(object key)
    {
        base.Remove(key);
        if (null != OnChange)
        {
            OnChange(this, null);
        }
    }
}