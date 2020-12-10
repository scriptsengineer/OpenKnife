# OpenKnife

## Planejamento

Devido ser um jogo mobile simples, foi escolhido trabalhar apenas com uma cena juntamente com armazenamento de estados do jogo (Menu,InGame,GameOver)

## Criação

### Gerenciadores
Foi criado certos gerenciadores para utilizar lógica e dados de forma fácil e limpa.
#### GameManager 
Um classe singleton. com estados do jogo, Importante notar aqui o uso de uma interface para todos componentes que queiram receber notificações de eventos dos estados do jogo
#### LevelManager
Responsável obviamente pelos estágios e seus carregamentos.
#### UIManager
Além de ser pai de toda interface do usuário, armazena o Canvas também.


### Atores e suas lógicas

#### Knife
Knife pode ser do player ou não, ser do player significa que recebe eventos de colisão/triggers.
#### Mover
Um simples código para movimento rápido sem utilizar física.
#### Rotator
Usado pela madeira central para rotacionar com velocidades especificadas.
#### Random Rotator
Modifica o rotator com tempo e interpolação usando dados carregados dos estágios
#### Shooter
Armazena quantidades de tiros e chama no levelManager o evento de atirar.


## Stages

Neste quesito foi utilizado um Scriptable Objects para armazenar estágios de forma segura e independente da cena do Unity.

### Angle Object
Armazena um objeto e um ângulo para ser gerados assim que estágio começar.
### Speed Timer
Um tempo de interpolação e um float com velocidade que deve ser feita para começar a girar a madeira principal
