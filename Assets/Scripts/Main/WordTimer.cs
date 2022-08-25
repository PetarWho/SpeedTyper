using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

	public WordManager wordManager;

	public static float wordFallSpeed;
	public float wordDelay;
	private float nextWordTime = 0f;
	public static long scoreToWin = long.MaxValue;
	private void Start()
	{
		switch (LevelLoader.staticDifficulty)
		{
			case "Easy":
				wordFallSpeed = 1.2f;
				wordDelay = 2f;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = 51;
				scoreToWin = 200;
				break;
			case "Normal":
				wordFallSpeed = 1.4f;
				wordDelay = 1.5f;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = 31;
				scoreToWin = 300;
				break;
			case "Hard":
				wordFallSpeed = 1.65f;
				wordDelay = 1.4f;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = 23;
				scoreToWin = 400;
				break;
			case "Insane":
				wordFallSpeed = 1.8f;
				wordDelay = 1.3f;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = 16;
				scoreToWin = 500;
				break;
			case "Endless":
				wordFallSpeed = 1.25f;
				wordDelay = 1.45f;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = 26;
				break;
			case "Custom":
				wordFallSpeed = GetCustomSettings.CustomSpeed;
				wordDelay = GetCustomSettings.CustomDelay;
				scoreToWin = GetCustomSettings.CustomScore;
				Word.randomNumberStart = 1;
				Word.randomNumberEnd = -1;
				break;
		}
		
	}

	private void Update()
	{
		if (Time.time >= nextWordTime)
		{
			wordManager.AddWord();
			nextWordTime = Time.time + wordDelay;
		}
	}

}
