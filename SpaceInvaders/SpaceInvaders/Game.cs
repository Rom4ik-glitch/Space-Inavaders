using System;
using System.Threading;

class Game
{
    public bool IsFinished
    {
        get;
        protected set;
    }

    protected readonly GameSettings settings;

    protected Level level;
    protected Player player;
    protected Input input;

    protected Thread gameThread;
    protected InputResult result;

    public Game(GameSettings settings)
    {
        this.settings = settings;

        level = new Level(settings.levelWidth, settings.levelHeight);

        player = new Player(level);
        player.MoveTo(settings.playerSpawnX, settings.playerSpawnY);

        input = new Input();
    }

    public void Start()
    {
        level.DrawField();

        input.StartInput();

        gameThread = new Thread(GameThreadSheduler);
        gameThread.Start();
    }

    public void StopInput()
    {
        gameThread.Abort();
    }


    protected void GameThreadSheduler()
    {
        while (!IsFinished)
        {
            var playerDirection = Direction.None;
            switch (input.LastInput)
            {
                case InputResult.Exit:
                    IsFinished = true;
                    return;

                case InputResult.MoveLeft:
                    playerDirection = Direction.Left;
                    break;

                case InputResult.MoveRight:
                    playerDirection = Direction.Right;
                    break;

                case InputResult.MoveUp:
                    playerDirection = Direction.Up;
                    break;

                case InputResult.MoveDown:
                    playerDirection = Direction.Down;
                    break;
            }

            // Do every object logic
            player.Move(playerDirection);

            // Clear frame
            player.Clear();

            // Render frame
            player.Draw();

            Thread.Sleep(settings.timeStep);
        }
    }
}