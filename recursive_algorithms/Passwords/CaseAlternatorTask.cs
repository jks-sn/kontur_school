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

		var possibleChars = GetPossibleCases(word[index]);

		foreach (var c in possibleChars)
		{
			word[index] = c;
			AlternateCharCasesRecursive(word, index + 1, result);
		}
	}

	private static List<char> GetPossibleCases(char c)
	{
		var cases = new List<char>();

		if (char.IsLetter(c))
		{
			var lower = char.ToLower(c);
			var upper = char.ToUpper(c);

			if (lower != upper)
			{
				cases.Add(upper);
			}
			cases.Add(lower);
		}
		else
		{
			cases.Add(c);
		}
		return cases;
	}
}