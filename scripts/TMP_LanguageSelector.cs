using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;

public class TMP_LanguageSelector : MonoBehaviour
{
    public TMP_Dropdown DropdownLangComponent; // Asigna el TMP_Dropdown desde el inspector
    [SerializeField] private Locale defaultLocale;
    void Start()
    {
        if (defaultLocale)
        {
            LocalizationSettings.SelectedLocale = defaultLocale;
        }
        // Rellena el TMP_Dropdown con los idiomas disponibles
        var availableLocales = LocalizationSettings.AvailableLocales.Locales;
        DropdownLangComponent.options.Clear();
        foreach (var locale in availableLocales)
        {
            // DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(locale.Identifier.Code));
            DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(locale.LocaleName));
        }

        DropdownLangComponent.onValueChanged.AddListener(delegate { OnLanguageChanged(DropdownLangComponent); });

        // Establece el idioma inicial según la configuración actual
        int currentLocaleIndex = availableLocales.IndexOf(LocalizationSettings.SelectedLocale);
        DropdownLangComponent.value = currentLocaleIndex;
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
