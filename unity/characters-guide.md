
># UNITY - GUÍA DE IMPORTACIÓN DE PERSONAXES


1) Accedemos á carpeta dos personaxes da compartida:

```
compartida/PERSONAJES
```

2) Movemos o/s personaxe/s á carpeta do noso proxecto, en local:

```
proxecto-unity/Assets/Characters/
(De non existir a carpeta 'Characters' creámola)
```

3) Unha vez importado/s o/s personaxe/s, seleccionamos 'Fix Now' na ventá de 'NormalMap Settings'

```
NormalMap Settings -> Fix Now
```

4) Arrastramos o arquivo 'personaxe.fbx' dende o explorador de ficheiros de Unity á xerarquía da escena

```
persoaxe.fbx -> arrastrar á xerarquía da escena 
```

5) Axustamos o pelo da personaxe e prememos en 'Build materials' 

```
Reallusion -> Import Characters

Cambiar 'Two Pass Hair' a 'MSAA coverage hair' -> build materials
```

6) Agregamoslle 'Animator' ó personaxe:

```
Nas propiedades do personaxe:

Add Component -> Animator
```

7) Asignámoslle animación ó personaxe:

```
Desplegamos o arquivo personaxe.fbx no explorador de ficheiros de unity

Arrastramos o 'Animation Clip' pertinente ó Animator 
```
