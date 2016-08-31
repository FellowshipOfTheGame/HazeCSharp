namespace Pong_Tutorial
{
    //List of all game objects in the game
    public class GameObjects
    {
        public Paddle PlayerPaddle { get; set; }
        public Paddle CPUPaddle { get; set; }
        public Ball Ball { get; set; }
        public Score Score { get; set; }
    }
}