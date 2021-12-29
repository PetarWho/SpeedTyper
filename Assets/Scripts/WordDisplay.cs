using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordDisplay : MonoBehaviour {

	public TextMeshProUGUI text;

	public void SetWord (string word)
	{
		text.SetText(word);
	}

	public void RemoveLetter ()
	{
		text.text = text.text.Remove(0, 1);
		text.color = Color.red;
	}

	public void RemoveWord ()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.Translate(0f, -WordTimer.wordFallSpeed * Time.deltaTime, 0f);
	}

}
