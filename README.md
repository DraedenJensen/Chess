## General Info

**Author and Copyright:** 

Draeden Jensen, October 2023.
This work may not be copied without attribution.

**Date:** 

The program was started on June 15, 2023, and completed on October 15, 2023.
The model was worked on throughout June 2023. The GUI was worked on throughout October 2023.

## Description

This project was developed in C# using Windows Forms development in Visual Studio 2022, running .NET 4.8.

This solution contains a Windows Forms chess app. Running the program starts a GUI from which the user can play multiplayer games
on a single system or single-player games against a computer. The program itself is pretty self-explanatory; as long as if you know 
how to play chess you can jump right in.

## Solution Contents:

The overall solution is built from 3 projects:

- ChessClientGUI, the project containing the GUI programs:
	- ChessClient -- the main menu.
	- ChessGame -- the game window.
	- GameOverPopup and PromotionPopup -- popup windows to get user input at their respective events.
	- Plus all the C++ source code and documentation for the Stockfish engine.

- ChessModels, the project containing the backing model programs:
	- Chessboard -- the main chess game model.
	- ChessPiece -- a smaller class used by the Chessboard class.
	- StockfishInterface -- a helper class for running and communicating with Stockfish.

- ChessModelsText, a unit test program for the Chessboard class.

## Credits

All code for the game logic and GUI was written by me (Draeden Jensen). Open online sources were used for images, and the
Stockfish chess engine was used for the single-player AI.

Chess icon downloads: 
	https://greenchess.net/info.php?item=downloads

Stockfish download: 
	https://stockfishchess.org/download/

Wood and marble texture sources:
	https://wallpapers.com/background/light-tan-background-qr7iaq7l6ts1w6hb.html#google_vignette
	https://pngtree.com/freebackground/brown-wood-texture-background_1314885.html
	https://www.abposters.com/marketplace/white-marble-texture-v90401?size=128&material=vlies
	https://rmsmarble.com/marble-tiles/nordic-grey-marble/

This was my first time developing with Windows Forms so naturally I consulted a whole lot of official Microsoft documentation:
	https://learn.microsoft.com/en-us/docs/

I used Wikipedia just to refresh myself on how chess notation works:
	https://en.wikipedia.org/wiki/Algebraic_notation_(chess)

And this very useful Stack Exchange post helped me get started with using a C# process to run Stockfish inside my app:
	https://chess.stackexchange.com/questions/17685/how-to-send-uci-messages-from-c-app-to-stockfish-on-android