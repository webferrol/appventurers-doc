using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TMP_LanguageFriendlySelector : MonoBehaviour
{
    public TMP_Dropdown DropdownLangComponent; // Asigna el TMP_Dropdown desde el inspector
    public List<Locale> supportedLocales; // Recuerda cargar en el inspector los locales
    [SerializeField] private Locale defaultLocale; // Esta opción por si queremos cargar un idioma por defecto
    private const string LocaleKey = "SelectedLocale"; // Clave para almacenar el idioma seleccionado en PlayerPrefs

    void Start()
    {
        if (defaultLocale && !PlayerPrefs.HasKey(LocaleKey))
        {
            LocalizationSettings.SelectedLocale = defaultLocale;
            PlayerPrefs.SetString(LocaleKey, defaultLocale.Identifier.Code);
            PlayerPrefs.Save();
        }

        var availableLocales = LocalizationSettings.AvailableLocales.Locales;

        if (supportedLocales.Count != 0)
        {
            LoadFriendlyLanguages();
        }
        else
        {
            LoadLanguages(availableLocales);
        }

        DropdownLangComponent.onValueChanged.AddListener(delegate { OnLanguageChanged(DropdownLangComponent); });

        // Establece el idioma inicial según la configuración actual
        int currentLocaleIndex = availableLocales.IndexOf(LocalizationSettings.SelectedLocale);
        DropdownLangComponent.value = currentLocaleIndex;
    }

    private void LoadFriendlyLanguages()
    {
        // Buscamos los locales disponibles
        DropdownLangComponent.options.Clear();

        foreach (var locale in supportedLocales)
        {
            LocalizedString localizedLanguageName = new LocalizedString { TableReference = "LanguageNames", TableEntryReference = locale.Identifier.Code };
            DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(localizedLanguageName.GetLocalizedString()));
        }

        DropdownLangComponent.RefreshShownValue();
    }

    private void LoadLanguages(List<Locale> availableLocales)
    {
        DropdownLangComponent.options.Clear();

        foreach (var locale in availableLocales)
        {
            DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(locale.LocaleName));
        }

        DropdownLangComponent.RefreshShownValue();
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

        // Actualiza los nombres de los idiomas en el Dropdown
        UpdateDropdownOptions();
    }

    private void UpdateDropdownOptions()
    {
        var availableLocales = LocalizationSettings.AvailableLocales.Locales;

        if (supportedLocales.Count != 0)
        {
            LoadFriendlyLanguages();
        }
        else
        {
            LoadLanguages(availableLocales);
        }

        // Actualiza el valor seleccionado del Dropdown
        int currentLocaleIndex = availableLocales.IndexOf(LocalizationSettings.SelectedLocale);
        DropdownLangComponent.value = currentLocaleIndex;
    }
}
