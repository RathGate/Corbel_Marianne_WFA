# WFA Pico-8 Celeste
![enter image description here](https://i.ibb.co/pyRcfFf/Capture-d-cran-2023-09-25-145145.png)

This project is being realised by Marianne Corbel as part of the "C# Introduction" cours from Ynov Aix. This project aims at providing an approximate Windows Form (WFA) version of [Celeste Pico-8](https://www.lexaloffle.com/bbs/?tid=2145) made by [Maddy Thorson](https://twitter.com/mattthorson) and [Noel Berry](https://twitter.com/noelfb).

**DISCLAIMER**: I do not own any of the assets used in the program, which won't be used for anything else than educational purposes.

![enter image description here](https://i.ibb.co/x2JDRcQ/Capture-d-cran-2023-09-28-085758.png)


## Specifications and how to use

 This program is a Windows Form Application, written entirely in C#.

As it is, the program **has not been compiled**. If you want to use it, you'll either have to compile it yourself or run a `dotnet run` command in the folder where `Program.cs` is located.


# Development Logs

***Wednesday, Sept. 20***
- Getting used to the IDE, testing things out (collisions, movements, classes, etc.)

***Thursday, Sept. 21***
- Defined Celeste Pico-8 as the theme of the game !
- Made first level without textures (tile positioning only).
- Implemented base player controls (walk, jump).
- Implemented collectibles and gravity.
![That was ugly though.](https://i.ibb.co/GvtDrMp/Capture-d-cran-2023-09-20-164812.png)

***Friday, Sept. 22***
- Added sprites and tile textures, made the background images out of scratch.
- Tried to implement game rooms as UserControls to display the full game in one window, but after some consideration and since I might not have the time to do it correctly, decided to stick to multi-window display.
![enter image description here](https://i.ibb.co/rwv3L4c/Capture-d-cran-2023-09-23-171854.png)


***Saturday, Sept. 23***
- Almost took a whole year to make jump animation smoother.
- My computer crashed and VS basically corrupted the project with restaured files.
![enter image description here](https://i.ibb.co/Byc2Rrw/Capture-d-cran-2023-09-28-084339.png)

***Sunday, Sept. 24***
- Implemented basic sprite animations for Madeline (walk, wall grab, look upward/downward, turn-around).
- Implemented wall jump when Madeline is midair, against a wall and holding the wall's direction.
- Implemented death event.
- Realised the structure is messy and not viable, rework to come.

***Monday, Sept. 25***
- Started working on the new structure (classes, methods of PictureBox derived classes like Player, PlayerInputs, etc).
- Fixed window boundaries (upper boundary = player has won the level; side boundaries = player stopped).
- Created the structure of the second level.
![enter image description here](https://i.ibb.co/0scBFRd/Capture-d-cran-2023-09-23-185254.png)

***Tuesday, Sept. 26***
- Finally pushed reworked version, though issues are still to be fixed with some methods that could not work if they were Player's method and not Form method.
- Fixed double-jump issues.
- Created new structures (Inputs, Player...).
- Fixed Madeline animation.

***Wednesday, Sept. 27***
- Added in-game timer based on the number of ticks of the main game timer.
- Added intro screen with its animations.
- Added pause menu with death and collectible counts.
- Did some fixes and workaround to be able to "finish" the game for the presentation. These additions will need to be correctly implemented later as right now, the code is shameful as hell.
![enter image description here](https://i.ibb.co/9VXBbJM/Capture-d-cran-2023-09-27-150317.png)
![enter image description here](https://i.ibb.co/tPJbVCk/Capture-d-cran-2023-09-28-090836.png)

## What's next ? 
- As the base levels are not doable without a dash, I need to either implement it or change the structure of the levels
- Implement at least three to four screens before winning !
- Clean-up the code
- Put options in the menu (close menu, reset Pico-8)
- Winning screen and possibility to restart the game when finished
- Snow balls as moving enemies to kill the player 
- Animations
