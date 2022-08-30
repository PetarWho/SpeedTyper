using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class Word
{

	public string word;
	private int typeIndex;

	WordDisplay display;

	public bool isGolden;
	private int rnd;
	private Color goldColor;
	private Color normalColor;
	public static int randomNumberStart;
	public static int randomNumberEnd;
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
