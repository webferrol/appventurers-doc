using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TMP_LanguageFriendLySelector : MonoBehaviour
{
    public TMP_Dropdown DropdownLangComponent; // Asigna el TMP_Dropdown desde el inspector
    public List<Locale> supportedLocales; // Recuerda cargar en el inspector los locales
    [SerializeField] private Locale defaultLocale; // Esta opción por si queremos cargar un idioma por defecto
    void Start()
    {
       
        if (defaultLocale)
        {
            LocalizationSettings.SelectedLocale = defaultLocale;
        }

       
        var availableLocales = LocalizationSettings.AvailableLocales.Locales;

        if (supportedLocales.Count != 0)
        {

            LoadFriendlyLanguages();
            // Debug.Log(supportedLocales.Count);
        }
            
        else
        {
            // Debug.Log('h');
            LoadLanguages(availableLocales);
        }



        DropdownLangComponent.onValueChanged.AddListener(delegate { OnLanguageChanged(DropdownLangComponent); });

        // Establece el idioma inicial según la configuración actual
        int currentLocaleIndex = availableLocales.IndexOf(LocalizationSettings.SelectedLocale);
        DropdownLangComponent.value = currentLocaleIndex;
    }

    private void LoadFriendlyLanguages()
    {
        // Buscamos los locales diponibles

        DropdownLangComponent.options.Clear();

        foreach (var locale in supportedLocales)
        {
            Debug.Log(locale);
            LocalizedString localizedLanguageName = new LocalizedString { TableReference = "LanguageNames", TableEntryReference = locale.Identifier.Code };
            DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(localizedLanguageName.GetLocalizedString()));
            // Debug.Log(localizedLanguageName.GetLocalizedString());
            DropdownLangComponent.RefreshShownValue();

        }
    }

    private void LoadLanguages(List<Locale> availableLocales)
    {
        DropdownLangComponent.options.Clear();
        foreach (var locale in availableLocales)
        {
            // DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(locale.Identifier.Code));
            DropdownLangComponent.options.Add(new TMP_Dropdown.OptionData(locale.LocaleName));
        }
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
