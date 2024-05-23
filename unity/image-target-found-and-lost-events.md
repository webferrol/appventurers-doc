# ASIGNAR ANIMACIÓN E AUDIO A PERSONAXES:
1) Seguimos os pasos de importación de persoaxe incluídos no [readme](https://github.com/webferrol/appventurers-doc/blob/main/unity/characters-guide.md)
2) Movemos o personaxe dentro da xerarquía do proxecto a: ImageTarget -> PanelAnclaxe -> o_noso_personaxe
3) Copiamos o script 'CharacterPlay.cs' ó noso proxecto e asignámosllo á ImageTarget
4) Nas propiedades da Image Target, asignámoslle as funcións 'TargetFound' e 'TargetLost' (contidos no script CharacterPlay.cs) ós eventos "On Target Found ()" e "On Target Lost ()" respectivamente
5) Creamos obxecto AudioSource na xerarquía (click dereito -> Audio -> Audio Source) e asignámoslle o audio do personaxe (ao mesmo nivel xerárquico que o PanelAnclaxe)
6) Dentro das propiedades de ImageTarget Asignamos este AudioSource a 'My Audio' e o obxeto personaxe a 'My Character'
7) Asignamos Animator e animación ó personaxe
   
----
```
NOTAS:
- O 'Audio Source' das propiedades dos personaxes debe estar en 'None'
- Cada audio ten que estar asignado a un obxeto AudioSource distinto
- Para unha correcta visualización dos modelos no móbil, débese cambiar, na Image Target, a opción 'Consider target visible (...)' dentro de 'Default Observer Event Handler (Script)' a 'Tracked'
- No punto 4), para asignar correctamente o script CharacterPlay.cs enlazado á ImageTarget, debemos arrastrar o obxeto ImageTarget dende a xerarquía do proxecto, non o script.
```
Exemplo: <br>
![CapturaTARGETS](https://github.com/webferrol/appventurers-doc/assets/148337654/d9e0caaa-5963-4223-a426-0f5174ce8815)
