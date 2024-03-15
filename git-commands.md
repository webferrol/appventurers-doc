# Comandos Git

## Branch

### Cambiar de rama

```sh
git switch nombre_de_tu_rama
```

### Crear y cambiar a una nueva rama

```sh
git switch -c nombre_de_tu_rama
```

### Fusionar ramas

```sh
git merge nombre_de_tu_rama
```

>⚠️ Si hay conflictos entre las dos ramas, Git te pedirá que resuelvas esos conflictos antes de completar la fusión.

### Eliminar ramas

```sh
git branch -d nombre_de_tu_rama
```

Si lo que deseas es eliminar una **rama remota**:

```sh
git push origen --delete nombre_de_tu_rama
```

