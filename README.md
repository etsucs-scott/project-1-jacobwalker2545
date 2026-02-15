[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/2QC0Bpz-)
# CSCI 1260 — Project

# Adventure Game

This Adventure game is a game, where you are in a maze, you are the player that has to either pickup weapons or attack monsters, and find your way to the exit, you can pickup potions, items, also you can take damage, and inflict damage on others.

---

## Building and Running

from the beginning you start with with a "dotnet build"

### Run the Game

dotnet run, making sure you're in the AdventureConsole directory 

## Movement  Controls and Display Format 

W- Move player up
S -Move player down
A -Move player left
D -Move player right

The player moves around the maze when you hit the keys WASD, direction keys, or arrows.

## Display Format 

The map is displayed in a 10x10 grid
#-represents a wall in the maze
@-represents player
M-represents monster
W=represents weapon
E-exit
.-Empty space
P-Potion

## Win and Lose Conditions

### Win Conition
 Either the player reaches the exit
 The player defeats all the enemies

## Lose condition 
Player dies in battle, health to 0

## Battle 
When the player moves onto a monster tile, it starts a battle, they attack each other, it shows the attacks
the battle either ends when the player or monster reaches the health of 0, all the monsters have lower health then you. 

These are seperated by classes, between the player and monster, and also just game logic. 

## UML Diagram

The UML that is included in this repository: AdventureGame_UML.png

This covers relationships between the classes, the structure of each class, and how they work.
Also how the game works, how the map is structured, and responsibnilites of each method

Overall showing how these classes interact with eachother and how they work together for the final product on the game.

## Git Usage

Cloning the project commands

    git clone<>
    
Navigating to (change directory)

    cd AdventureGame 

Build, (also to see where the build errors, I used to troubleshoot)
    dotnet build
Run the game:
    dotnet run

---

## Author
Jacob Walker 
