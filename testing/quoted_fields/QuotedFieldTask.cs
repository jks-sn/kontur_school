using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
	[TestCase("''", 0, "", 2)] // Пустое поле
	[TestCase("'a'", 0, "a", 3)] // Поле с одним символом
	[TestCase("\"abc\"", 0, "abc", 5)] // Поле с несколькими символами
	[TestCase("\"abc def\"", 0, "abc def", 9)] // Поле с пробелами
	
	[TestCase("\"a 'b' c\"", 0, "a 'b' c", 9)] // Вложенные одинарные кавычки в двойных
	[TestCase("'a \"b\" c'", 0, "a \"b\" c", 9)] // Вложенные двойные кавычки в одинарных
	
	[TestCase("\"a \\\"b\\\" c\"", 0, "a \"b\" c", 11)] // Экранированные кавычки внутри
	[TestCase("\"a \\\\ b\"", 0, "a \\ b", 8)] // Экранированный слэш
	
	[TestCase("\"abc", 0, "abc", 4)] // Незакрытая кавычка до конца строки
	[TestCase("'def", 0, "def", 4)] // Незакрытая одинарная кавычка
	
	[TestCase("\"a'b\"", 0, "a'b", 5)] // Одинарные кавычки внутри двойных
	[TestCase("\"a'b\"c", 0, "a'b", 5)] // Поле в двойных кавычках, следующее поле простое
	public void Test(string line, int startIndex, string expectedValue, int expectedLength)
	{
		var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
		Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
	}

	// Добавьте свои тесты
}

class QuotedFieldTask
{
	static string str = "\"abc";
	enum State
	{
		Initial,
		InsideQuotes,
		EscapedCharacter,
		End
	}
	public static Token ReadQuotedField(string line, int startIndex)
	{
		char quoteOpenSymbol = line[startIndex];
		int currentIndex = startIndex + 1;
		var value = new System.Text.StringBuilder();
		var state = State.InsideQuotes; //гарантируется, что мы начинаем с открывающей кавычки

		while (currentIndex < line.Length && state != State.End)
		{
			char currentChar = line[currentIndex];

			switch (state)
			{
				case State.InsideQuotes:
					if (currentChar == '\\')
						state = State.EscapedCharacter;
					else if (currentChar == quoteOpenSymbol)
						state = State.End;
					else
						value.Append(currentChar);
					break;

				case State.EscapedCharacter:
					value.Append(currentChar);
					state = State.InsideQuotes;
					break;
			}

			currentIndex++;
		}

		int length = currentIndex - startIndex;
		return new Token(value.ToString(), startIndex, length);
	}
}