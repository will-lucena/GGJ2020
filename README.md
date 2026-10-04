# Chaos Manager

RTS para celular feito na **Global Game Jam 2020** pela Baladeira e a Sekuela Games. Usa o [A* Pathfinding Project](https://arongranberg.com/astar/) (versão gratuita) para a navegação no mapa da cidade.

![Menu do jogo](https://will-lucena.com.br/img/jogos/ggj2020.jpg)

## Como rodar

Atualizado para **Unity 6 (6000.6.2f1)** em outubro de 2026. Abra a pasta no Unity Hub com essa versão, ou gere o build pela linha de comando:

```sh
# WebGL (precisa do módulo "Web Build Support")
Unity.exe -batchmode -quit -projectPath . -buildTarget WebGL -executeMethod WebGLBuild.Build
# Windows
Unity.exe -batchmode -quit -projectPath . -buildTarget Win64 -executeMethod WebGLBuild.BuildWindows
```

O build sai em `Builds/`. O script fica em `Assets/Editor/WebGLBuild.cs`.
