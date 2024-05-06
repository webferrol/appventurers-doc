using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using TMPro;

public class ScriptBehaviour : MonoBehaviour
{
    [SerializeField] private TextAsset SubtitlesTextFile;
    [SerializeField] private string voiceLinesFolderPath;
    [SerializeField] private Subtitle[] subtitles;

    [SerializeField] private int currentSubtitleIndex;

    private void OnValidate()
    {
        
        // UnassignedReferenceException Este error se da por no asignar el fichero en el inspector
        
        string[] subtitleLines = SubtitlesTextFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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

    private IEnumerator ShowSubtitles()
    {
        while (currentSubtitleIndex < subtitles.Length)
        {
            GetComponent<TextMeshProUGUI>().text = subtitles[currentSubtitleIndex].text;
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            currentSubtitleIndex++;
        }
    }

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(ShowSubtitles());
    }
}