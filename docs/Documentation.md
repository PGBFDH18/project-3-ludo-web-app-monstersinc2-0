### WebAPP Visual Design

We started off by making a new ASP.NET Core Web Application MVC project. After that we went to bootswatch.com and grabbed a free bootstrap theme to make the app look more professional and non-standard. Then the work began...

#### Play Ludo

When you enter the Play Ludo section of the WebAPP, you will be able to step into an already started game. A visitor can enter any game, since no time has been deliberately put on security which of course we would have done in a "real" project. If no game is active, there's is a link to create a new game which will take you to a new page where you can enter the players names and also what color they prefer to have.

##### The game

To create the visual game, we first decided to go with the teachers example files that included a HTML-page and some CSS-files. Our first approach was to get the game working by writing JavaScript code, but pretty soon we realized that we didn't have the skills for it or time to learn a whole new language, and since this course is for ***back-end*** web development, we abandoned this and decided to go with a Razor page, combining HTML and C#. Unfortunately, this approach forced the page to reload every time we made a move, but again, this is back-end so we went with it anyway.

After hours and hours of trying to make things work visually, we abandoned this approach as well and finally we settled with some bootstrap-styled "cards" for the players, including statistics for each game piece. We also threw in an extra card presenting current player, the ability to roll the die, latest roll and also it will present the winner, when there is one.

#### Stats

When a winner is announced, a POST call will automatically be made to the API to add a winner to the stats section. This call also have a GET version, which is called when you enter the Stats section of the WebAPP. If the call returns any former winners, it will be represented here in a stylish bootstrap table ranking them by the number of games won.

#### Manual

This page is just informing the visitors how to play the game.