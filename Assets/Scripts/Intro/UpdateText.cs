using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    IntroDialogue dialogue;
    [SerializeField]
    private float timeBetweenTextUpdates;
    // the max amount of time that will either be added or removed from the timeBetweenTexUpdates value
    [SerializeField]
    private float timeBetweenTextUpdatesVariance;
    [SerializeField]
    private float minZRotation;
    [SerializeField]
    private float maxZRotation;
    [SerializeField]
    private Text text;
    private bool isPrintingLine;
    private Stack<string> remainingWordsToPrint;

    private string displayedString;

    private void Awake()
    {
        dialogue = new IntroDialogue();
        remainingWordsToPrint = new Stack<string>();
        StartPrintingNewLine(dialogue.GetNextLine());
    }

    /// <summary>
    /// Gets the next line from the dialog element and starts printing it.
    /// </summary>
    private void ShowNextLine()
    {
        if (isPrintingLine)
            return;
            
        string line = dialogue.GetNextLine();

        if (line != null)
        {
            StartPrintingNewLine(line);
        }
    }

    private void UpdateDisplayedString()
    {
        text.text = displayedString;
        // SetRandomZRotationOnTextElement();
    }

    /// <summary>
    /// Starts the process of printing the new line.
    /// </summary>
    /// <param name="line">The line that you want to be printed to the screen</param>
    private void StartPrintingNewLine(string line)
    {
        remainingWordsToPrint.Clear();
        var words = line.Split(' ');
        for (int i = words.Length - 1; i >= 0; i--)
        {
            remainingWordsToPrint.Push(words[i]);
        }
        
        isPrintingLine = true;
        displayedString = "";

        StartCoroutine(ExecuteAfterTime.Exectute(PrintNewLineSegment, getTimeBetweenUpdatesWithVariance()));
    }

    private float getTimeBetweenUpdatesWithVariance()
    {
        var timeVariance = Random.Range(0, timeBetweenTextUpdatesVariance);
        return timeBetweenTextUpdates + timeVariance;
    }

    private void SetRandomZRotationOnTextElement()
    {
        var transform = text.transform;
        var randomOffset = Random.Range(minZRotation, maxZRotation) * (Mathf.Sign(transform.rotation.z) * -1f);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, randomOffset);
    }

    /// <summary>
    /// Not to be directly called
    /// </summary>
    private void PrintNewLineSegment()
    {
        if (remainingWordsToPrint.Count > 0)
        {
            displayedString += $" {remainingWordsToPrint.Pop()}";
            UpdateDisplayedString();

            StartCoroutine(ExecuteAfterTime.Exectute(PrintNewLineSegment, getTimeBetweenUpdatesWithVariance()));
        } else
        {
            isPrintingLine = false;
        }
    }
}
