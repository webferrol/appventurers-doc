using System.Collections;
using UnityEngine;
using TMPro;
using System;


/**
 * Un formato de texto de ejemplo que tiene que haber en este GO TestMeshPro
 
    En un lugar de la mancha; 2
    de cuyo nombre no quiero acordarme; 3,5
    no hace mucho tiempo que vivía un hidalgo; 2
    su nombre era Xurxo; 2
    Profesor molón; 3,5
    donde los haya; 2

 */

public class SliderTextMeshPro : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI textMeshPro;
    public Subtitle[] subtitles;
    public int currentSubtitleIndex = 0;

    [SerializeField] private char separatorChar = ';'; // Por si queremos cambiar en el editor este caracter separador
    void GetSubtitles()
    {

        // Obtener el texto con formato del objeto TextMeshPro con el objetivo de obtener los saltos de línea \n
        string textoFormateado = textMeshPro.GetParsedText();


        // Obtenemos las líneas que haya en TextMeshPro que no sean en blanco (StringSplitOptions.RemoveEmptyEntries)
        string[] subtitleLines = textMeshPro.text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);


        // Generaremos un array que guarde objetos de tipo Subtitle con el nñymero de línea, texto y duración de cada línea
        subtitles = new Subtitle[subtitleLines.Length];
        for (int i = 0; i < subtitleLines.Length; i++)
        {
            string[] parts = subtitleLines[i].Split(separatorChar);

            if (parts.Length == 0) continue; //Evitamos posibles errores por si no carga una línea

            string text = parts[0].Trim();

            // Si no separa correctamente la línea metemos un segundo de duración
            float duration = parts.Length == 1 ? 1f : float.Parse(parts[1].Trim());

            subtitles[i] = new Subtitle
            {
                line = i,
                text = text,
                duration = duration
            };
        }
    }
    public void StartSubtitles()
    {
        StartCoroutine(ShowSubtitles());
    }

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        GetSubtitles();
        StartSubtitles();
    }


    // Funciones por si queremos pausar, resetear o continuar con el Slider de texto

    public void StopSubtitles()
    {
        StopAllCoroutines();
    }    

    public void ResetSubtitles()
    {
        StopAllCoroutines();
        currentSubtitleIndex = 0;
        StartSubtitles();
    }

    private IEnumerator ShowSubtitles()
    {

        while (currentSubtitleIndex < subtitles.Length)
        {
            textMeshPro.text = subtitles[currentSubtitleIndex].text;
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            currentSubtitleIndex++;
        }
    }
}


public class Subtitle
{
    public int line;
    public string text;
    public float duration;
}
