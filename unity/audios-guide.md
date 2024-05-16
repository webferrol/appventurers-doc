
> # UNITY: GUÍA AUDIOS PERSONAXES


Para reproducir un audio cando enfocamos un Image Target:

1) Arrastrar arquivo de audio á 'Image Target' na xerarquía
2) Desmarcar casilla de 'Play on Awake' nas propiedades 'Audio Source' da 'Image Target'
3) O script para reproducir / pausar o audio en canto se enfoca a 'Image Target':

```
    // 1. Na función asignada ó 'On Target Found':


    GetComponent<AudioSource>().Play();
```
```
    // 2. Na función asignada ó 'On Target Lost'


    GetComponent<AudioSource>().Stop();
```
