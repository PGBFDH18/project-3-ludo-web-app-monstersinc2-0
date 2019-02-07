namespace WebApp.Models.ApplicationModel
{
    public interface ILudoGameAPIProccessor
    {
        string CreateNewGame();

        string AddNewPalyer(int gameId, string name, string color);

        string StartGame(int gameId);

        string RollDiece(int gameId);

        Player GetCurrentPlayer(int gameId);

        string MovePiece(int gameId, int pieceId, int roll);


        string EndTurn(int gameId, int currentPlayeId);


        Player GetWinner(int gameId);


        int NumberOfPlayersAdded(int gameId);

        LudoGame GameById(int gameId);

        string DeleteGame(int gameId);

    }
}
