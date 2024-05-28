```
# # # # # # # # # # # # # # # # # # # # # # # # # 
 __  __     __   __     __     ______   __  __    
/\ \/\ \   /\ "-.\ \   /\ \   /\__  _\ /\ \_\ \   
\ \ \_\ \  \ \ \-.  \  \ \ \  \/_/\ \/ \ \____ \  
 \ \_____\  \ \_\\"\_\  \ \_\    \ \_\  \/\_____\ 
  \/_____/   \/_/ \/_/   \/_/     \/_/   \/_____/ 
                                                  
# # # # # # # # # # # # # # # # # # # # # # # # # 
```


1. Crear proxecto de Unity:

```
Unity HUB -> New Project -> 3d Core (Built-In Render Pipeline)
```


2. Implementar soporte para iconos SVG y Localization:
   
```
Window -> Package Manager -> add package by name: "com.unity.vectorgraphics"
```

```
Window -> Package Manager -> add package by name: "com.unity.localization"
```


3. [OPCIONAL] Instalar Reallusion:

```
Window -> Package Manager -> add package from disk: cc_unity_tools_3D/package.json

(Localizado en: /compartida/APPVENTURERS/unity/Doc/Packages/)
```


4. Instalar 3D Tools:

```
assets -> import package -> custom package: /packages/RL_ShaderPackage_3D.unitypackage

(Localizado en: /compartida/APPVENTURERS/unity/Doc/Packages/cc_unity_tools_3D/Packages/)
```

5. [OPCIONAL] Importar Vuforia:
   
```
Doble click en: [add-vuforia-package-10-22-5.unitypackage]

(Localizado en: /compartida/APPVENTURERS/unity/Doc/Packages/)
```

```

6. Cambiar Build Settings para Android:

```
File -> Build Settings -> Android -> Switch Platform 

(Se vamos a usar varias escenas, agregalas a 'Scenes in Build' arrastrándoas dende o explorador de Unity.)
```

7. Copiar os Assets da carpeta compartida aos Assets en Local:

```
(Localizado en: Window -> Package Manager -> add package from disk: cc_unity_tools_3D/package.json

([Localizado en]: (https://github.com/webferrol/appventurers-doc/tree/main/demo/Assets))


--------------------------------

IMPORTANTE:
* INTENTAR COPIAR TODO A LOCAL ANTES DE TOCALO!
* NON TRABALLAR CON ARQUIVOS DIRECTAMENTE DENDE A COMPARTIDA!
  
