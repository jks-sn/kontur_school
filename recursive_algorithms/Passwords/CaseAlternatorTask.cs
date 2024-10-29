namespace Passwords;

public class CaseAlternatorTask
{
	public static List<string> AlternateCharCases(string lowercaseWord)
	{
		var result = new List<string>();
		AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
		result.Sort((a, b) => string.CompareOrdinal(b, a));
		return result;
	}

	static void AlternateCharCases(char[] word, int startIndex, List<string> result)
	{
		if (startIndex == word.Length)
		{
			result.Add(new string(word));
			return;
		}

		var c = word[startIndex];
		if (char.IsLetter(c))
		{
			var lower = char.ToLower(c);
			var upper = char.ToUpper(c);

			if (lower == upper)
			{
				word[startIndex] = lower;
				AlternateCharCases(word, startIndex + 1, result);
			}
			else
			{
				word[startIndex] = upper;
				AlternateCharCases(word, startIndex + 1, result);
				
				word[startIndex] = lower;
				AlternateCharCases(word, startIndex + 1, result);
			}
		}
		else
		{
			AlternateCharCases(word, startIndex + 1, result);
		}
	}
}