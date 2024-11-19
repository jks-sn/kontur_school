using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete;

public class RightBorderTask
{
	public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
	{
		left = Math.Max(left, 0);
		right = Math.Min(right, phrases.Count);
		while (left < right)
		{
			int mid = left + (right - left) / 2;
			var midPhrase = phrases[mid];
			
			if (!midPhrase.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase) &&
			    string.Compare(midPhrase, prefix, StringComparison.InvariantCultureIgnoreCase) > 0)
			{
				right = mid;
			}
			else
			{
				left = mid + 1;
			}
		}
		return left;
	}
}