!!!IMPORTANT!!!: Add scenes to build settings:
MainMenu as scene 0
TicTacToeGame as scene 1

!!!IMPORTANT2!!!: When creating asset bundles, note that the assets are getting renamed so don't put 2 of the same
asset sprite (for example 2 X mark sprites) at the same folder.

This is a little readme to explain some of my design decisions and note things that I could’ve done differently.
At the end there are the names of the skins bundles available.


Board Design:
Usually it doesn’t seem like a good idea to give any one object most of the responsibility but since I am developing a board game, there isn’t really a way around it that makes more sense: The board is the “king” in this type of game, it is the only entity to set the rules and enforce them and if another object has to force a win or a loss it has to go through it.


But what is a king without subjects, that is why it has to hold a reference to the players playing the game.
I thought about making the board support an unlimited number of players from the get go, but it would have taken more development time, which I don’t have and is out of scope for this project.


I thought about making it a Singleton, which is a valid idea for this kind of game, but ultimately decided not to so that the design could support a version of the game with multiple boards.


I am trying to develop the game in a way that minimizes the things that are tightly coupled.
This is why I’m relying on the Observer pattern using events that are invoked from the Board.
Also, other features of the game such as the Undo, Hint and Timer have been extracted to different MonoBehaviours that are listening to the events of the board. This way I can add or remove features easily (something like a dependency injection).


In order to make things more organized as well as easily testable I extracted from most of my MonoBehaviours a native C# class that I could instantiate and unit test just the logic.


I built the board using the UI system and buttons but another way would’ve been using 2d Game Objects with 2D Colliders and raycasting to choose the Square on the board.


Player Design:
At first I created the player as an abstract class that needed to inherited and implemented for different types of players (the code for it is still inside the project under Scripts/UNUSED) but when I had to dynamically change players from the Main Menu I decided to extract a Player Controller out of the MonoBehaviour so it could be created easily. In turn this controller is abstract and we have to inherit and implement it to create differently controlled players. 


The BoardPlayerController kind of uses the Factory pattern: It has a static method to receive BoardPlayerControllers based on an enum that maps to different types so we could easily set and use them in the Inspector and throughout the code.








Skins available:
* moonactive
* handdrawn