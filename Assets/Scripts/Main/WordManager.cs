using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordManager : MonoBehaviour {

	public List<Word> words;

	public WordSpawner wordSpawner;
	public Animator goldAnim;

	private bool hasActiveWord;
	private Word activeWord;
	public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		words.Add(word);
	}

	public void TypeLetter (char letter)
	{
		if (!PauseMenu.GameIsPaused)
		{
			if (hasActiveWord)
			{
				if (activeWord.GetNextLetter() == letter)
				{
					activeWord.TypeLetter();
				}
				else
				{
					if (ScoreSystem.score > 0)
					{
						ScoreSystem.score -= 1;
						
					}
				}
			}
			else
			{
				foreach (Word word in words)
				{
					Word currentWord = words.First();
					if (word.GetNextLetter() == letter && currentWord==word)
					{
						activeWord = word;
						hasActiveWord = true;
						word.TypeLetter();
						break;
					}
				}
			}

			if (hasActiveWord && activeWord.WordTyped())
			{
				hasActiveWord = false;
				if (activeWord.isGolden)
				{
					CoinScript.coins += activeWord.word.Length;
					goldAnim.SetBool("Typed",true);
					StartCoroutine(WaitAndStop());
				}
				words.Remove(activeWord);
			}
			
		}
	}
	IEnumerator WaitAndStop()
	{
		yield return new WaitForSeconds(1);
		goldAnim.SetBool("Typed",false);
	}
}
