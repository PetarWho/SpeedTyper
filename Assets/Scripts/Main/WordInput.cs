using UnityEngine;

public class WordInput : MonoBehaviour {

	public WordManager wordManager;

	void Update () {
		foreach (char letter in Input.inputString)
		{
			wordManager.TypeLetter(letter);
		}
	}

}
