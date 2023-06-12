using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new WordBank", menuName = "Yearsley/WordBank")]
public class WordBank : ScriptableObject
{
	[SerializeField]
	private List<string> words;

	public List<string> GetWords()
	{
		return words;
	}
	public void SetWords(List<string> words)
	{
		this.words = words;
	}
	public string GetRandomWord()
	{
		if (words.Count > 0)
		{
			return words[Random.Range(0, words.Count - 1)];
		}
		else return "pancake";
	}
}
