using System;
using System.Collections.Generic;

namespace Autocomplete;

public class LeftBorderTask
{
    
    public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
    {
        if (right - left <= 1)
        {
            return left;
        }
        
        var mid = left + (right - left) / 2;
        var comparison = string.Compare(phrases[mid], prefix, StringComparison.InvariantCultureIgnoreCase);

        if (comparison < 0 && !phrases[mid].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
        {
            return GetLeftBorderIndex(phrases, prefix, mid, right);
        }
        else
        {
            return GetLeftBorderIndex(phrases, prefix, left, mid);
        }
    }

}