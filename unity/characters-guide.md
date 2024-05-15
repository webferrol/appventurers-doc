
># UNITY - GUÍA DE IMPORTACIÓN DE PERSONAXES


1) Accedemos á carpeta dos personaxes da compartida:

```
compartida/PERSONAJES
```

2) Movemos o/s personaxe/s á nosa xerarquía local:

```
proxecto-unity/Assets/Characters/
(De non existir a carpeta 'Characters' creámola)
```

3) Unha vez importado/s o/s personaxe/s, seleccionamos 'Fix Now' na ventá de 'NormalMap Settings'

```
NormalMap Settings -> Fix Now
```

4) Axustamos o pelo da personaxe e prememos en 'Build materials' 

```
Reallusion -> Import Characters

Cambiar 'Two Pass Hair' a 'MSAA coverage hair' -> build materials
```

5) Agregamoslle 'Animator' ó personaxe:

```
Nas propiedades do personaxe:

Add Component -> Animator
```

6) Asignámoslle animación ó personaxe:

```
Desplegamos o arquivo personaxe.fbx no explorador de ficheiros de unity

Arrastramos o 'Animation Clip' pertinente ó Animator 
```

7) Asignámoslle audio ós personaxes:

```
Arrastrar audio ó obxeto do personaxe da xerarquia da Scene
```
