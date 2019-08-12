# Salad-Chef
Details of the Project:
GitHub Link: https://github.com/msadityakumar/Salad-Chef
Unity Version: 2018.3.6f1 (Personal Edition) 
Required Packages:
- Cinemahine (v2.2.8)
- TextMeshPro (v1.3.0)

Few Important Notes about the project:
- The project uses Cinemachine feature for Controlling the Camera.
- Tile map feature is used to Setup the Environment.
- All Interactables in the game use the IInteractable interface.
- The GameModel Object in GameController Script is the main Data storage class for the Game.
- The Player inventory is used to store and update Data of player. This has been implemented using the Queue Data Structure.
- All the assets used in the game are taken from OpenGameArt.org

Controls:
Player1:
Pickup: "Q"
Drop: "E"
Movement: W, A, S, D

Player2:
PickUp: "."(period)
Drop: "/"(Slash)
Movement: Up, Down, Left, Right(Arrows) 

Missed things:
- PowerUps
- Show previous top 10 scores.

Bugs:
- Some times the players don't interact with the object. Need to reposition the player to move outside the interactable and again enter the interactable.
