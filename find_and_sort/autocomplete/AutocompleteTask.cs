using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete;

internal class AutocompleteTask
{
	public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
	{
		var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
		if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
			return phrases[index];
            
		return null;
	}
	
	public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
	{
		var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
		var result = new List<string>();

		int index = left + 1;
		while (index < phrases.Count && result.Count < count)
		{
			var currentPhrase = phrases[index];
			if (currentPhrase.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
			{
				result.Add(currentPhrase);
				index++;
			}
			else
			{
				break;
			}
		}

		return result.ToArray();
	}
	
	public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
	{
		var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count);
		var right = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count);

		var count = right - left - 1;
		return count;
	}
}

[TestFixture]
public class AutocompleteTests
{
	[Test]
	public void TopByPrefix_IsEmpty_WhenNoPhrases()
	{
		var phrases = new List<string>();
		var prefix = "abc";
		var count = 10;

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.IsEmpty(actualTopWords);
	}

	[Test]
	public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
	{
		var phrases = new List<string> { "apple", "banana", "cherry" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "xyz";
		var count = 5;

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.IsEmpty(actualTopWords);
	}

	[Test]
	public void TopByPrefix_ReturnsCorrectPhrases_WhenPrefixMatchesSomePhrases()
	{
		var phrases = new List<string> { "application", "appetite", "apple", "banana", "apricot" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "app";
		var count = 3;

		var expectedTopWords = new List<string> { "appetite", "apple", "application" };

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.AreEqual(expectedTopWords, actualTopWords);
	}
	
	[Test]
	public void TopByPrefix_ReturnsAllMatchingPhrases_WhenCountIsLargerThanMatches()
	{
		var phrases = new List<string> { "application", "appetite", "apple" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "app";
		var count = 10;

		var expectedTopWords = new List<string> { "appetite", "apple", "application" };

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.AreEqual(expectedTopWords, actualTopWords);
	}
	
	
	[Test]
	public void TopByPrefix_ReturnsEmptyArray_WhenCountIsZero()
	{
		var phrases = new List<string> { "apple", "application" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "app";
		var count = 0;

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.IsEmpty(actualTopWords);
	}
	
	[Test]
	public void TopByPrefix_IsCaseInsensitive()
	{
		var phrases = new List<string> { "Apple", "application", "APPetite", "banana", "Apricot" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "APP";
		var count = 3;

		var expectedTopWords = new List<string> { "APPetite", "Apple", "application" };

		var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

		CollectionAssert.AreEqual(expectedTopWords, actualTopWords);
	}
	
	[Test]
	public void CountByPrefix_IsCaseInsensitive()
	{
		var phrases = new List<string> { "Apple", "application", "APPetite", "banana", "Apricot" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "app";

		var expectedCount = 3;

		var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);

		Assert.AreEqual(expectedCount, actualCount);
	}
	
	[Test]
	public void CountByPrefix_IsZero_WhenNoMatchingPhrases()
	{
		var phrases = new List<string> { "apple", "banana", "cherry" };
		phrases.Sort(StringComparer.InvariantCultureIgnoreCase);
		var prefix = "xyz";

		var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);

		Assert.AreEqual(0, actualCount);
	}
}