using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class WordListGenerator : EditorWindow
{
    private string filePath;
    [SerializeField]
    private WordBank wordBank;

    [MenuItem("Tools/Generate Word List")]
    public static void ShowWindow()
    {
        GetWindow(typeof(WordListGenerator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Word List Generator", EditorStyles.boldLabel);
        GUILayout.Space(10);

        filePath = EditorGUILayout.TextField("Text File Path: ", filePath);
        wordBank = EditorGUILayout.ObjectField("Word Bank", wordBank, typeof(WordBank), false) as WordBank;
        if (GUILayout.Button("Generate Word List"))
        {
            GenerateList();
        }
    }

    private void GenerateList()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found!");
            return;
        }

        List<string> wordList = new List<string>();

        string text = File.ReadAllText(filePath);
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (!wordList.Contains(word))
            {
                wordList.Add(word);
            }
        }

        SaveWordList(wordList);
        Debug.Log("Word list generated successfully!");
    }

    private void SaveWordList(List<string> words)
    {
        if (wordBank != null)
		{
            wordBank.SetWords(words);
            Debug.Log("word list saved");
		} else
		{
            Debug.LogError("No Word List object set in editor window");
		}
    }
}