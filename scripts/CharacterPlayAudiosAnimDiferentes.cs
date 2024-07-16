using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class CharacterPlay : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public GameObject myCharacter;

    public AudioClip audioEspañol;
    public AudioClip audioGallego;
    public AudioClip audioIngles;
    public AudioClip audioFrances;

    public RuntimeAnimatorController animacionEspañol;
    public RuntimeAnimatorController animacionGallego;
    public RuntimeAnimatorController animacionIngles;
    public RuntimeAnimatorController animacionFrances;


    void Start()
    {
        animator = myCharacter.GetComponent<Animator>();
        audioSource = myCharacter.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = myCharacter.AddComponent<AudioSource>();
        }
    }

    public void TargetFound()
    {
        string selectedLocale = LocalizationSettings.SelectedLocale.Identifier.Code;

        switch (selectedLocale)
        {
            case "es":
                audioSource.clip = audioEspañol;
                animator.runtimeAnimatorController = animacionEspañol;
                break;
            case "gl-ES":
                audioSource.clip = audioGallego;
                animator.runtimeAnimatorController = animacionGallego;
                break;
            case "en":
                audioSource.clip = audioIngles;
                animator.runtimeAnimatorController = animacionIngles;
                break;
            case "fr":
                audioSource.clip = audioFrances;
                animator.runtimeAnimatorController = animacionFrances;
                break;
            default:
                audioSource.clip = null; // Opcional: manejar un caso por defecto
                break;
        }

        if (audioSource.clip != null)
        {
            audioSource.Play();
        }

        animator.Play(0, 0, 0f);
    }

    public void TargetLost()
    {
        audioSource.Stop();
    }
}
