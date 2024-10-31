using System;
using System.Collections.Generic;

namespace Passwords;

public class CaseAlternatorTask
{
	public static List<string> AlternateCharCases(string lowercaseWord)
	{
		var result = new List<string>();
		AlternateCharCasesRecursive(lowercaseWord.ToCharArray(), 0, result);
		result.Sort((a, b) => string.CompareOrdinal(b, a));
		return result;
	}

	private static void AlternateCharCasesRecursive(char[] word, int index, List<string> result)
	{
		if (index == word.Length)
		{
			result.Add(new string(word));
			return;
		}

		foreach (var c in GetPossibleCases(word[index]))
		{
			word[index] = c;
			AlternateCharCasesRecursive(word, index + 1, result);
		}
	}
	
	private static IEnumerable<char> GetPossibleCases(char c)
	{
		if (!char.IsLetter(c))
		{
			yield return c;
			yield break;
		}

		var lower = char.ToLower(c);
		var upper = char.ToUpper(c);

		if (lower != upper)
		{
			yield return upper;
		}
		yield return lower;
	}
}