# OpenKnife

# Welcome to Open Knife 👋
![Version](https://img.shields.io/badge/version-0.9.1-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-yes-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

## 🔨 Recursos

✔️ Apenas uma cena para facilitar carregamento no celular.
✔️ Uso de 3 estados de jogo (Menu, InGame, GameOver)
✔️ _GameManager_ com todos managers instanciados utilizando interface.
✔️ _UnityEvents_ para uso fácil de designers no editor *Unity*.


## Criação

### Gerenciadores
Foi criado certos gerenciadores para utilizar lógica e dados de forma fácil e limpa.
#### GameManager 
Um classe **singleton**. com estados do jogo, Importante notar aqui o uso de uma interface para todos componentes que queiram receber notificações de eventos dos estados do jogo
#### LevelManager
Responsável obviamente pelos estágios e seus carregamentos.
#### UIManager
Além de ser pai de toda interface do usuário, armazena o _Canvas_ também.


## Atores

🧝 Player com _Shooter_,_Scorer_
🧝 Madeira com _Rotator_,_CurveRotator_
🧝 Facas com _Knife_,_RigidBody2D_
🧝 Frutas com _Rigidbody2D_

## Stages

✔️ _ScriptableObjects_ para separar dados das cenas.
✔️ _AnimationCurves_ para tempo de interpolação da velocidade da madeira.
✔️ _AngleObject_ é uma lista que mantém itens de objeto com um ângulo.


## 📈 Desafios

### Física ou Triggers?
Um dos maiores problemas vistos nessa produção foi a dúvida que se deveria usar física ou não. Problemas de utilizar física do Unity podem ser vistos aqui:
![Physic problem](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/GxxPtxn8Cu.gif)


### Gerenciamento de estágio

Um fator que pode ser visto como design seria saber se estágios são randomicos ou não? Na minha abordagem o resultado foi utilizar velocidades com AnimationCurve, assim sei que velocidades e de que maneiras o estágio vai se comportar.
![Physic problem](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Code_rDrUJHE2CC.png)

### Código complexo para designers

Trabalhando nesse projeto, deparei com certos problemas que seriam meus, obviamente um designer que deseja-se trocar um som de efeito ou escolher quando instanciar uma partícula na cena deveria modelar de um forma rápido, assim utilizei extensivamente o 'UnityEvent'
![UnityEvents](https://github.com/ScriptsEngineer/OpenKnife/blob/main/Docs/Images/Unity_tZZV1mtPlL.png)

## Tempo de produção
⏰ 12 horas


## Autor

👤 **Rafael Correa**
(Script)
* Twitter: [@ScriptsEngineer](https://twitter.com/ScriptsEngineer)
* Github: [@scriptsengineer](https://github.com/scriptsengineer)


## 🤝 Contributing

Contribuições, problemas and pedido de recursos são bem-vindos!

Veja aqui => [issues page](https://github.com/ExpressoBits/EBConsole/issues).

## Show your support

Dê uma ⭐️ se este projeto te ajudou!


## 📝 Licença

Copyright © 2020 [Rafael Correa](https://github.com/scriptsengineer).

Este projeto é licenciado pelo [MIT](MIT).

