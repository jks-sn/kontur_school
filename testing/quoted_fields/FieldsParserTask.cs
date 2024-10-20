using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
	[TestCase("text", new[] {"text"})]
	[TestCase("hello world", new[] {"hello", "world"})]

	[TestCase("  a   b  c ", new[] {"a", "b", "c"})]
	[TestCase("'a b c'", new[] {"a b c"})]
			
	[TestCase("\"abc", new[] {"abc"})]
	[TestCase("\"a b c\"", new[] {"a b c"})]
	[TestCase("\"a 'b' c\"", new[] {"a 'b' c"})]
	[TestCase("'abc", new[] {"abc"})]
	[TestCase("\"\"", new[] {""})]

	[TestCase("''", new[] {""})]		

	[TestCase("'a\\'b\\' c'", new[] {"a'b' c"})]
	[TestCase("'a \"b\" c'", new[] {"a \"b\" c"})]
	[TestCase("\"a\\\"b\\\" c\"", new[] {"a\"b\" c"})]
	[TestCase("\"a\\\"b\\\"c\" d", new[] {"a\"b\"c", "d"})]
	[TestCase("\"a\\\"b\\\"\"", new[] {"a\"b\""})]
	[TestCase("a\\ b", new[] {"a\\", "b"})]
	[TestCase("\"abc'def\"ghi", new[] {"abc'def", "ghi"})]
	[TestCase("\"abc\\\\\"", new[] {"abc\\"})]
	[TestCase("\"a'b'c\"", new[] {"a'b'c"})]
	[TestCase("\"a\\\\\\\"b\"", new[] {"a\\\"b"})]
	[TestCase("\"a\"\"b\"\"c\"", new[] {"a", "b", "c"})]
	[TestCase("\"\"\"\"", new[] { "", "" })]
	[TestCase("''''", new[] {"", ""})]
	[TestCase("\"a\\'b\\\"c\"", new[] {"a'b\"c"})]
	[TestCase("\"a\\\\b\\\\c\"", new[] {"a\\b\\c"})]
	[TestCase("\"a\\\\\\\"b\"", new[] {"a\\\"b"})]
	[TestCase("a\"b c\"", new[] {"a", "b c"})]
	[TestCase("", new string[] { })]                    
	[TestCase("   ", new string[] { })]                 
	[TestCase("      ", new string[] { })]
			
	[TestCase("\"abc def ", new[] { "abc def " })]
	[TestCase("'abc def ", new[] { "abc def " })]
	[TestCase("\"abc def ghi jkl", new[] { "abc def ghi jkl" })]
	[TestCase("'abc def ghi jkl", new[] { "abc def ghi jkl" })]
	
	public static void Test(string input, string[] expectedResult)
	{
		var actualResult = FieldsParserTask.ParseLine(input);
		Assert.AreEqual(expectedResult.Length, actualResult.Count);
		for (int i = 0; i < expectedResult.Length; ++i)
		{
			Assert.AreEqual(expectedResult[i], actualResult[i].Value);
		}
	}

	// Скопируйте сюда метод с тестами из предыдущей задачи.
}

public class FieldsParserTask
{
	// При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
	// Подумайте как можно использовать ReadQuotedField и Token в этой задаче.
	public static List<Token> ParseLine(string line)
	{
		var tokens = new List<Token>();
		int currentIndex = 0;

		while (currentIndex < line.Length)
		{
			currentIndex = SkipSpaces(line, currentIndex);
			if (currentIndex >= line.Length)
			{
				break;
			}

			Token token;
			if (IsQuoteCharacter(line[currentIndex]))
			{
				token = ReadQuotedField(line, currentIndex);
			}
			else
			{
				token = ReadField(line, currentIndex);
			}

			tokens.Add(token);
			currentIndex = token.GetIndexNextToToken();
		}

		return tokens;
	}
	
	private static bool IsQuoteCharacter(char c)
	{
		return (c == '"' || c == '\'');
	}
	
	private static Token ReadField(string line, int startIndex)
	{
		int currentIndex = startIndex;
		while (currentIndex < line.Length && !char.IsWhiteSpace(line[currentIndex]) && !IsQuoteCharacter(line[currentIndex]))
		{
			currentIndex++;
		}
		return new Token(line.Substring(startIndex, currentIndex - startIndex), startIndex, currentIndex - startIndex);
	}

	private static int SkipSpaces(string line, int index)
	{
		while (index < line.Length && char.IsWhiteSpace(line[index]))
		{
			index++;
		}
		return index;
	}

	public static Token ReadQuotedField(string line, int startIndex)
	{
		return QuotedFieldTask.ReadQuotedField(line, startIndex);
	}
}