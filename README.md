# OpenKnife

# Welcome to Open Knife 👋
![Version](https://img.shields.io/badge/version-0.2.5-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-yes-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

<img align="right" src="https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/dioJMhfV3E.gif">

## 🔨 Features

✔️ Just a scene to make it easier to loading on your phone.

✔️ Use of 3 game states (Menu, InGame, GameOver)

✔️ _GameManager_ is a **singleton** with all managers instantiated using interface.
```csharp
GameStates[] internStates = GetComponents<GameStates>();
gameStates.AddRange(internStates);

```
✔️ _UnityEvents_ for easy use of designers in the editor *Unity*.

✔️ Design with split structure with [Assembly Definitions](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html), helping in times of smaller compilations, obliging the use of [SOLID](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design)) and split of tests.

✔️ Full separation of game logic with UI, nothing depends on the user interface and its logic.

✔️ Use [URP](https://github.com/Unity-Technologies/Graphics/tree/7.x.x/release/com.unity.render-pipelines.universal) with quick and easy rendering for mobile platform.

✔️ Simple UI animations using triggers.

✔️ Boss mode [Pull Request #7](https://github.com/ScriptsEngineer/OpenKnife/pull/7).

<img align="right" src="https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Tests.png">

✔️ Use of [Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html) for procedure testing.
    - Runtime tests.
    - Editor tests.




## Managers
Certain managers have been created to use logic and data easily and cleanly.

🚨 _GameManager_: A class **singleton**. with game states, It is important to note here the use of an interface for all components that want to receive event notifications from the game states.

🚨 _LevelManager_: Obviously responsible for the stages and their shipments.

🚨 _UIManager_: In addition to being the parent of the entire User Interface, it stores _Canvas_ as well.


## Actors

⛹️ Player with _Shooter_,_Scorer_

⛹️ Wood with _Rotator_,_CurveRotator_

⛹️ Knife with _Knife_,_RigidBody2D_

⛹️ Fruit with _Rigidbody2D_

## Stages

✔️ _ScriptableObjects_ to separate data from scenes.

✔️ _AnimationCurves_ for time interpolation of wood speed.

✔️ _AngleObject_ is a list that keeps object items with an angle.


## 📈 Challenges

### Physics or Triggers?
One of the biggest problems seen in this production was the doubt that one should use physics or not. Problems using Unity physics can be seen here:

![Physic problem](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/GxxPtxn8Cu.gif)


### Where the stage ❓

For a designer it is very easy to just edit a file, in this way it was used the
[_ScriptableObject_](https://docs.unity3d.com/Manual/class-ScriptableObject.html).

!Stage Object](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Code_rDrUJHE2CC.png)

### 👨‍💻 Shouldn't a designer use a code editor ?

Obviously a designer who wants to exchange an effect sound or choose when to instantiate a particle in the scene should create easily and quickly, so 'UnityEvent' was used extensively.

![UnityEvents](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Unity_tZZV1mtPlL.png)

## Assembly Definition Use

Use of assembly packages for each namespace of the project, thus dividing the use of resources helping in the use of tests.

## Production time
⏰ 12 hours

## Author

👤 **Rafael Correa**
(Script)
* Twitter: [@ScriptsEngineer](https://twitter.com/ScriptsEngineer)
* Github: [@scriptsengineer](https://github.com/scriptsengineer)

## 🤝 Contributing

Contributions, issues and feature requests are welcome!

Feel free to check [issues page](https://github.com/ExpressoBits/EBConsole/issues).

## Show your support

Give a ⭐️ if this project helped you!

## Assets used

🎨 [FREE Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)

🎨 [20 Evolving Fantasy RPG Weapons](https://assetstore.unity.com/packages/2d/textures-materials/20-evolving-fantasy-rpg-weapons-61204)

🎨 [Free Pixel Font - Thaleah](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059)

🎨 [Free Pixel Food](https://assetstore.unity.com/packages/2d/environments/free-pixel-food-113523)


## 📝 License

This project is [MIT](MIT) licensed.

