using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Word
{
	/// <summary>
	/// The word to type
	/// </summary>
	public string word;

	/// <summary>
	/// Index of the next letter to be typed
	/// </summary>
	private int typeIndex;

	/// <summary>
	/// Indicates if the word is golden (gives coins)
	/// </summary>
	public bool isGolden;

	/// <summary>
	/// Golden word start number. Used as starting value for golden word roll. It's best idea to keep it at 1.
	/// </summary>
	public static int randomNumberStart;

	/// <summary>
	/// Golden word end numer. Used as last value (exclusive) for golden word roll. Random number roll between randomNumberStart and randomNumberEnd and if the rolled number is equal to 2, the word will be golden.
	/// </summary>
	public static int randomNumberEnd;

	private int rnd;
	private Color goldColor;
	private Color normalColor;
	WordDisplay display;
	public Word (string _word, WordDisplay _display)
	{
		ColorUtility.TryParseHtmlString("#FDBD25", out goldColor);
		ColorUtility.TryParseHtmlString("#FFB9B6", out normalColor);
		word = _word;
		typeIndex = 0;
		rnd = Random.Range(randomNumberStart, randomNumberEnd);
		this.isGolden = rnd == 2;
		display = _display;
		display.SetWord(word, isGolden ? goldColor : normalColor);
	}

	
	public char GetNextLetter ()
	{
		return word[typeIndex];
	}

	public void TypeLetter ()
	{
		typeIndex++;
		display.RemoveLetter();
	}
	public bool WordTyped ()
	{
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped)
		{
			ScoreSystem.score += word.Length;
			display.RemoveWord();
			if(LevelLoader.staticDifficulty == "Endless")
				WordTimer.wordFallSpeed *= 1.0001f;
			else
				WordTimer.wordFallSpeed *= 1.001f;

		}
		return wordTyped;
	}
}
