# OpenKnife

# Bem-vindo ao Open Knife 👋
![Version](https://img.shields.io/badge/version-0.2.5-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-yes-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

<img align="right" src="https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/dioJMhfV3E.gif">

## 🔨 Recursos

✔️ Apenas uma cena para facilitar carregamento no celular.

✔️ Uso de 3 estados de jogo (Menu, InGame, GameOver)

✔️ _GameManager_ é um **singleton** com todos managers instanciados utilizando interface.
```csharp
GameStates[] internStates = GetComponents<GameStates>();
gameStates.AddRange(internStates);

```
✔️ _UnityEvents_ para uso fácil de designers no editor *Unity*.

✔️ Projeto com estrutura dividida com [definições de montagem](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html), ajudando em tempos de compilações menores,obrigando uso de [SOLID](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)) e divisão de testes.

✔️ Separação total da lógica do jogo com UI, nada depende da interface do usuário e sua lógica.

✔️ Utilizado [URP](https://github.com/Unity-Technologies/Graphics/tree/7.x.x/release/com.unity.render-pipelines.universal) com renderização rápida e fácil para plataforma mobile.

✔️ Simples animações de UI com uso de triggers.

✔️ Modo de chefe [Pull Request #1](https://github.com/ScriptsEngineer/OpenKnife/pull/7).

<img align="right" src="https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Tests.png">

✔️ Uso do [Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html) para testes de procedimentos.
    - Testes de runtime.
    - Testes de editor.




## Gerenciadores
Foi criado certos gerenciadores para utilizar lógica e dados de forma fácil e limpa.

🚨 _GameManager_: Um classe **singleton**. com estados do jogo, Importante notar aqui o uso de uma interface para todos componentes que queiram receber notificações de eventos dos estados do jogo.

🚨 _LevelManager_: Responsável obviamente pelos estágios e seus carregamentos.

🚨 _UIManager_: Além de ser pai de toda interface do usuário, armazena o _Canvas_ também.


## Atores

⛹️ Player com _Shooter_,_Scorer_

⛹️ Madeira com _Rotator_,_CurveRotator_

⛹️ Facas com _Knife_,_RigidBody2D_

⛹️ Frutas com _Rigidbody2D_

## Stages

✔️ _ScriptableObjects_ para separar dados das cenas.

✔️ _AnimationCurves_ para tempo de interpolação da velocidade da madeira.

✔️ _AngleObject_ é uma lista que mantém itens de objeto com um ângulo.


## 📈 Desafios

### Física ou Triggers?
Um dos maiores problemas vistos nessa produção foi a dúvida que se deveria usar física ou não. Problemas de utilizar física do Unity podem ser vistos aqui:

![Physic problem](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/GxxPtxn8Cu.gif)


### Aonde o estágio ❓

Para um designer é muito fácil apenas editar um arquivo, desta forma foi utilizado o [_ScriptableObject_](https://docs.unity3d.com/Manual/class-ScriptableObject.html).

![Stage Object](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Code_rDrUJHE2CC.png)

### 👨‍💻 Um designer não deveria usar um editor de código?

Obviamente um designer que deseja-se trocar um som de efeito ou escolher quando instanciar uma partícula na cena deveria criar de um forma fácil e rápida, assim foi utilizado extensivamente o 'UnityEvent'.

![UnityEvents](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Unity_tZZV1mtPlL.png)

## Uso de Assembly Definition

Uso de pacotes de montagem para cada namespace do projeto, divindo assim o uso de recursos ajudando no uso de testes.

## Tempo de produção
⏰ 12 horas

## Autor

👤 **Rafael Correa**
(Script)
* Twitter: [@ScriptsEngineer](https://twitter.com/ScriptsEngineer)
* Github: [@scriptsengineer](https://github.com/scriptsengineer)

## 🤝 Contribuindo

Contribuições, problemas and pedido de recursos são bem-vindos!

Veja aqui => [issues page](https://github.com/ExpressoBits/EBConsole/issues).

## Ajude

Dê uma ⭐️ se este projeto te ajudou!

## Assets utilizados

🎨 [FREE Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)

🎨 [20 Evolving Fantasy RPG Weapons](https://assetstore.unity.com/packages/2d/textures-materials/20-evolving-fantasy-rpg-weapons-61204)

🎨 [Free Pixel Font - Thaleah](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059)

🎨 [Free Pixel Food](https://assetstore.unity.com/packages/2d/environments/free-pixel-food-113523)


## 📝 Licença

Este projeto é licenciado pelo [MIT](MIT).

