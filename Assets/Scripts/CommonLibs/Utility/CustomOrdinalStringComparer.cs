using System;
using System.Collections.Generic;

public class CustomOrdinalStringComparer : IEqualityComparer<string>
{
    private static CustomOrdinalStringComparer m_comparer = new CustomOrdinalStringComparer();
    
    public static CustomOrdinalStringComparer GetComparer()
    {
        return m_comparer;
    }
    
    public int GetHashCode(string obj)
    {
        return obj.GetHashCode();
    }

    public bool Equals(string x, string y)
    {
        if (x.Length != y.Length) return false;
        int i = 0;
        while (i < x.Length)
        {
            if (x[i] != y[i]) return false;
            i++;
        }

        return true;
    }
}