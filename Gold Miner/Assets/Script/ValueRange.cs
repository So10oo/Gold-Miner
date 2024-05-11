using System;

[Serializable]
public struct ValueRange<T> where T : IComparable
{
    public T min;
    public T max;

    public void OnValidate()
    {
        if (min.CompareTo(max) >= 0)
        {
            min = max;
        }
    }
}

