using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yearsley.Typing.Managers
{
	public class TypingGameManager : MonoBehaviour
	{

		#region Singleton

		public static TypingGameManager instance { get; private set; }

		private void InitializeSingleton()
		{
			instance = this;
		}

		#endregion
		[SerializeField]
		private TMP_Text wordOutput = null;
		[SerializeField]
		private WordBank wordBank;

		private string remainingWord = string.Empty;
		private string currentWord = string.Empty;

		private void Awake()
		{
			InitializeSingleton();
		}
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
			}
		}

		private void EnterLetter(string typedLetter)
		{
			if (IsCorrectLetter(typedLetter))
			{
				RemoveLetter();

				if (isWordComplete())
					SetCurrentWord();
			}
		}

		private bool IsCorrectLetter(string letter)
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
