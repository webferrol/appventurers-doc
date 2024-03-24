# Comandos Git [🔙](/)

## Video tutorial

[![Alt text](./images/midudev-git-tutorial.webp)](https://www.youtube.com/watch?v=niPExbK8lSw&t=2265s)

## Clonar

### Clonar ramas a una profundidad

A veces no hace falta clonar totalmente todo el histórico o commits de un repositorio puede con el tiempo ocupar bastante. Una opción es clonar hasta un commit o "profundidad" que desemos. Por ejemplo, clonamos un repositiorio hasta el último commit:

```sh
git clone --depth 1   https://github.com/webferrol/my-github-repo.git
```

## Branch

### Listar todas las ramas

```sh
git branch
```

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

