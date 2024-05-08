using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SubtitleMultiLanguage : MonoBehaviour
{
    [Serializable]
    public class Subtitle
    {
        public int line;
        public string text;
        public float duration;
    }

    public enum Language
    {
        English,
        Spanish,
        NoSubtitles // Opción para no usar subtítulos
    }

    [SerializeField] private Language selectedLanguage;
    [SerializeField] private TextAsset subtitlesTextFileEnglish;
    [SerializeField] private TextAsset subtitlesTextFileSpanish;
    [SerializeField] private string voiceLinesFolderPath;
    [SerializeField] private Subtitle[] subtitles;
    [SerializeField] private int currentSubtitleIndex;

    private RectTransform  escenerio;

    private TextMeshProUGUI subtitleText;
    private TMP_Dropdown languageDropdown;
    private bool isVisible = false;

    private void OnValidate()
    {
        LoadSubtitles();
    }

    private void LoadSubtitles()
    {
        if (selectedLanguage == Language.NoSubtitles)
        {
            // Si no se seleccionan subtítulos, simplemente vacía la lista de subtítulos
            subtitles = new Subtitle[0];
            return;
        }

        TextAsset selectedSubtitlesTextFile = selectedLanguage == Language.English ? subtitlesTextFileEnglish : subtitlesTextFileSpanish;

        if (selectedSubtitlesTextFile == null)
        {
            Debug.LogError("No se ha asignado un archivo de subtítulos para el idioma seleccionado.");
            return;
        }

        string[] subtitleLines = selectedSubtitlesTextFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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
            subtitleText.text = subtitles[currentSubtitleIndex].text;
            yield return new WaitForSeconds(subtitles[currentSubtitleIndex].duration);
            currentSubtitleIndex++;
        }
    }

    // Método público para cambiar el idioma desde el Dropdown
    public void ChangeLanguage(int languageIndex)
    {
        selectedLanguage = (Language)languageIndex;
        LoadSubtitles();

        StopAllCoroutines(); // Detener todas las coroutines en caso de estar reproduciendo subtítulos
        if (selectedLanguage != Language.NoSubtitles) // Si se selecciona "No Subtitles", no se muestra ningún subtítulo
            StartCoroutine(ShowSubtitles());
    }

    // Start is called before the first frame update

    public void Show ()
    {
        isVisible = !isVisible;
        if(isVisible)
            escenerio.localScale = new Vector3(1, 1, 1);
        else
            escenerio.localScale = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        subtitleText = GetComponentInChildren<TextMeshProUGUI>();
        languageDropdown = GetComponentInChildren<TMP_Dropdown>();
        escenerio = GetComponent<RectTransform>();
        escenerio.localScale = new Vector3(0, 0, 0);
 
       


        // Asignar el método ChangeLanguage() al evento OnValueChanged del Dropdown
        languageDropdown.onValueChanged.AddListener(ChangeLanguage); // FALLO ---------------------------------------------------------------------------------------->

        // Establecer el valor inicial del Dropdown al idioma seleccionado
        languageDropdown.value = (int)selectedLanguage;

        // Cargar subtítulos al iniciar
        LoadSubtitles();
        if (selectedLanguage != Language.NoSubtitles) // Si se selecciona "No Subtitles", no se muestra ningún subtítulo
            StartCoroutine(ShowSubtitles());
    }
}
