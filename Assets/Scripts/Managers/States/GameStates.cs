namespace OpenKnife.Managers
{
    public interface GameStates
    {
        void MainMenu(GameState newState, GameState oldState);
        void StartGame(GameState newState, GameState oldState);
        void GameOver(GameState newState, GameState oldState);
    }
}

