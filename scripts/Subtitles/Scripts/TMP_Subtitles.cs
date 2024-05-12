using System.Collections;
using TMPro;
using UnityEngine;

public class TMP_Subtitles : MonoBehaviour

{
    public SubtitlesFromFile data;
    public TMP_Text componente;
    
    private IEnumerator ShowSubtitles()
    {

        while (data.currentSubtitleIndex < data.subtitles.Length)
        {
            componente.text = data.subtitles[data.currentSubtitleIndex].text;
            yield return new WaitForSeconds(data.subtitles[data.currentSubtitleIndex].duration);
            data.currentSubtitleIndex++;
        }
    }

    public void StopSubtitles()
    {
        StopAllCoroutines();
    }

    public void StartSubtitles()
    {
        StartCoroutine(ShowSubtitles());
    }

    public void ResetSubtitles()
    {
        StopAllCoroutines();
        data.currentSubtitleIndex = 0;
        StartSubtitles();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        componente = GetComponent<TMP_Text>();
        StartSubtitles();
    }


}
