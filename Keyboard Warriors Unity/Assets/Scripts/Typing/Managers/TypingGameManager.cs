using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yearsley.Typing.Managers
{
	public class TypingGameManager : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text wordOutput = null;
		[SerializeField]
		private TMP_Text inputDisplay;
		[SerializeField]
		private WordBank wordBank;

		private string remainingWord = string.Empty;
		private string currentWord = string.Empty;

		// Start is called before the first frame update
		void Start()
		{
			SetCurrentWord();
		}

		private void SetCurrentWord()
		{
			currentWord = wordBank.GetRandomWord();
			SetRemainingWord(currentWord);
		}

		private void SetRemainingWord(string newString)
		{
			remainingWord = newString;
			wordOutput.text = remainingWord;
		}

		// Update is called once per frame
		void Update()
		{
			CheckInput();
		}

		private void CheckInput()
		{
			if (Input.anyKeyDown)
			{
				string keysPressed = Input.inputString;
				if (keysPressed.Length == 1)
					EnterLetter(keysPressed);
				inputDisplay.text += keysPressed;
			}
		}

		private void EnterLetter(string typedLetter)
		{
			if (isCorrectLetter(typedLetter))
			{
				RemoveLetter();

				if (isWordComplete())
					SetCurrentWord();
			}
		}

		private bool isCorrectLetter(string letter)
		{
			return remainingWord.IndexOf(letter) == 0;
		}

		private void RemoveLetter()
		{
			string newString = remainingWord.Remove(0, 1);
			SetRemainingWord(newString);
		}

		private bool isWordComplete()
		{
			return remainingWord.Length == 0;
		}
	}
}
