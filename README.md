# Klarb-Procreation-Rift

<img src="/docs/Klarb.PNG" alt="game" width="400px"> <img src="/docs/space.png" alt="space" width="40px"> <img src="/docs/Klarb2.PNG" alt="game" width="400px">

Several friends and I decided to enter the August 2014 Ludum Dare. The chosen theme was Connected Worlds. We decided to make a game where the population of an alien race was divided in two distant worlds, and the only way they can met is through an unstable rift in space.
The player must control both aliens at the same time and navigate both aliens to the end at the same time. As you move around, each tile you step on starts to crumble, and disintegrates after a few seconds. All levels are randomly generated. Each new level is harder than the one before, with false paths and gaps that you have to jump over.

# Live Game
Click below to play the game live and try it out: 
https://viktordd.github.io/Klarb-Procreation-Rift-LudumDare30-/

# Technical Architecture
The game consists of several Scenes in Unity. Most are small simple scenes dedicated to displaying the title screen, story slides, victory, and game over screens. The Main scene uses a level generator to get a layout of the current level. The level difficulty is determined by the level number. Each time the player gets to the end we increment the level and reload the main scene. We keep track of the current level using the PlayerPrefs API. The api is usually used to store player preferences between game sessions.

All animations are created as sprites with each individual frame drawn separately. We used unity’s animation engine to create player walking, jumping, and falling animations.

<img src="/Assets/Sprites/FemaleWalk1.png" alt="game" width="400px">
<img src="/Assets/Sprites/FemaleAlienFall1.png" alt="game" width="400px">

# How to Setup this Project Locally 
You would need to download the free version of Unity to run the game locally. https://unity3d.com/
To Run the game locally clone the source code, then open it with Unity.

<img src="/docs/UnityOpen.PNG" alt="open" width="400px">

Open the TitleScreen scene under Assets, then hit the play button.

<img src="/docs/KlarbTitleScene.PNG" alt="scene" width="400px"> <img src="/docs/KlarbPlay.PNG" alt="scene" width="400px">


# LudumDare30
Ludum Dare is a game jam competition that is held 3 times a year. The competition challenges people to create a game in a short amount of time, 48 to 72 hours. All games should follow a theme that is announced at the start of the competition. After the competition ends. people can play and rate the games to determine the winner.

Original Ludum Dare 30 submission:
http://www.ludumdare.com/compo/ludum-dare-30/?action=preview&uid=42368
