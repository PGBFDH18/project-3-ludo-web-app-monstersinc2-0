namespace WebApp.Models.ApplicationModel
{
    public interface ILudoGameAPIProccessor
    {
        int CreateNewGame();

        string AddNewPalyer(int gameId, string name, string color);

        string StartGame(int gameId);

        int RollDiece(int gameId);

        Player GetCurrentPlayer(int gameId);

        string MovePiece(int gameId, int pieceId, int roll);

        string EndTurn(int gameId, int currentPlayeId);

        Player GetWinner(int gameId);

        Player[] GetAllPlayers(int gameId);

        LudoGame GameById(int gameId);

        string DeleteGame(int gameId);

    }
}
