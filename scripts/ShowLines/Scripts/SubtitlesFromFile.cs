using System;
using System.Collections;
using UnityEngine;
using TMPro;
using System.ComponentModel;
public class SubtitlesFromFile : MonoBehaviour
{
    [SerializeField] private TextAsset TextFile;
    public Subtitle[] subtitles;
    public int currentSubtitleIndex = 0;

    private void OnValidate()
    {

        // UnassignedReferenceException Este error se da por no asignar el fichero en el inspector

        string[] subtitleLines = TextFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        subtitles = new Subtitle[subtitleLines.Length];

        for (int i = 0; i < subtitleLines.Length; i++)
        {
            string[] parts = subtitleLines[i].Split(';');

            string text = parts[0].Trim();
            float duration = float.Parse(parts[1].Trim());

            subtitles[i] = new Subtitle
            {
                line = i,
                text = text,
                duration = duration
            };
        }
    }
}
