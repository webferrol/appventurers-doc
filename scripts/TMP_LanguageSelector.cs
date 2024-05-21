using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;

public class TMP_LanguageSelector : MonoBehaviour
{
    public TMP_Dropdown languageDropdown; // Asigna el TMP_Dropdown desde el inspector
    [SerializeField] private Locale defaultLocale;
    void Start()
    {
        if (defaultLocale)
        {
            LocalizationSettings.SelectedLocale = defaultLocale;
        }
        // Rellena el TMP_Dropdown con los idiomas disponibles
        var availableLocales = LocalizationSettings.AvailableLocales.Locales;
        languageDropdown.options.Clear();
        foreach (var locale in availableLocales)
        {
            // languageDropdown.options.Add(new TMP_Dropdown.OptionData(locale.Identifier.Code));
            languageDropdown.options.Add(new TMP_Dropdown.OptionData(locale.LocaleName));
        }

        languageDropdown.onValueChanged.AddListener(delegate { OnLanguageChanged(languageDropdown); });

        // Establece el idioma inicial según la configuración actual
        int currentLocaleIndex = availableLocales.IndexOf(LocalizationSettings.SelectedLocale);
        languageDropdown.value = currentLocaleIndex;
    }

    public void OnLanguageChanged(TMP_Dropdown change)
    {
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales[change.value];
        StartCoroutine(SetLocale(selectedLocale));
    }

    IEnumerator SetLocale(Locale locale)
    {
        yield return LocalizationSettings.InitializationOperation; // Espera a que la localización se inicialice
        LocalizationSettings.SelectedLocale = locale; // Cambia el idioma
    }
}
