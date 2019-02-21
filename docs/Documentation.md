### WebAPP Visual Design

We started off by making a new ASP.NET Core Web Application MVC project. After that we went to bootswatch.com and grabbed a free bootstrap theme to make the app look more professional and non-standard. Then the work began...

#### Play Ludo

When you enter the Play Ludo section of the WebAPP, you will be able to step into an already started game. A visitor can enter any game, since no time has been deliberately put on security which of course we would have done in a "real" project. If no game is active, there's is a link to create a new game which will take you to a new page where you can enter the players names and also what color they prefer to have.

##### The game

To create the visual game, we had a look at the provided example files containing a HTML and some CSS files that, put together, resulted in a fancy LudoBoard. To actually play the game and make things happen in this HTML document, we discussed several technical approaches such as JavaScript, jQuery, SIgnalR, but due to lack of time and our choices of focus points, we decided to go with a full feathered bootstrap clothed Razor page.

When a game opens (new or already started) a model with the needed data will be provided to the Razor page. This page will be painted depending on what data it gets from the model. When a move or roll is done in the game, the controllers action will call the API and reload the page with the new data, returned from the API.

#### Stats

When a winner is announced, a POST call will automatically be made to the API to add a winner to the stats section. This call also have a GET version, which is called when you enter the Stats section of the WebAPP. If the call returns any former winners, it will be represented here in a stylish bootstrap table ranking them by the number of games won.

#### Manual

This page is just informing the visitors how to play the game.