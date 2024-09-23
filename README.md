15 Puzzle Game (C# Console App)

A classic sliding puzzle game implemented as a C# console application.

Table of Contents
Introduction
How to Play
Features
Installation
Usage
Technologies Used
Contributing
License

Introduction
The 15 Puzzle Game is a classic sliding tile puzzle that consists of 15 numbered tiles on a 4x4 grid, with one empty space. The objective is to arrange the numbers in sequential order by sliding tiles into the empty space.

This project is a C# console application where users can play the game directly from the terminal, moving tiles using the arrow keys.

How to Play
The game starts with a randomized 4x4 grid, consisting of 15 numbered tiles and one empty space.
You can move tiles by using the arrow keys to slide them into the empty space.
The goal is to arrange the tiles in ascending order (from 1 to 15) with the empty space in the last position.
Solve the puzzle in as few moves as possible.
Features
Randomized Start: Each new game generates a shuffled puzzle.
Move Counter: Keeps track of the number of moves you've made.
Reset Game: Option to restart the game at any time.
Victory Check: Notifies you when the puzzle is solved.

Installation
To run the game locally, follow these steps:

Clone this repository:

bash
Copy code
[git clone https://github.com/yourusername/15-puzzle-game-csharp-console.git](https://github.com/SwizzleZticks/FifteenPuzzle.git)
Open the solution in your preferred IDE (such as Visual Studio or Visual Studio Code).

Build the project to restore any dependencies.

Run the application in the terminal/console:

For Visual Studio, press F5 or Ctrl + F5 to run the app.
You can also use dotnet run if you're using .NET CLI.
Usage
Once the application starts, the puzzle will appear in the console as a 4x4 grid.
Use the arrow keys on your keyboard to slide tiles around.
Up Arrow: Move the empty space up.
Down Arrow: Move the empty space down.
Left Arrow: Move the empty space left.
Right Arrow: Move the empty space right.
Continue moving the tiles until they are arranged in ascending order from 1 to 15, with the empty space in the bottom-right corner.

Technologies Used
C#: The core language used for developing the game.
.NET 8.0: The framework for building and running the console application.

License
This project is licensed under the MIT License.
