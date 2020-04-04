using System;
using System.Collections.Generic;
using System.Threading;

class Game
{
    static Game instance;
    public static Game Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new Game();
            }
            return instance;
        }
    }

    public bool IsFinished
    {
        get;
        protected set;
    }

    protected GameSettings settings;

    protected Level level;
    protected Input input;
    protected EnemySpawner enemySpawner;
    protected List<GameBehaviourBase> gameBehaviours;

    protected Thread gameThread;

    public void Init(GameSettings settings)
    {        
        Console.CursorVisible = false;
        this.settings = settings;

        level = new Level(settings.levelWidth, settings.levelHeight);
        input = new Input();

        gameBehaviours = new List<GameBehaviourBase>();
        var player = new Player(level);
        player.MoveTo(settings.playerSpawnX, settings.playerSpawnY);
        RegisterBehaviour(player);

        enemySpawner = new EnemySpawner(level);
        RegisterBehaviour(enemySpawner);
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

    public void RegisterBehaviour<TBehaviour>(TBehaviour behaviour) where TBehaviour : GameBehaviourBase
    {
        gameBehaviours.Add(behaviour);
    }

    public void UnRegisterBehaviour<TBehaviour>(TBehaviour behaviour) where TBehaviour : GameBehaviourBase
    {
        gameBehaviours.Remove(behaviour);
    }


    protected void GameThreadSheduler()
    {
        while (!IsFinished)
        {
            ClearFrame();
            CalculateFrame();
            DrawFrame();

            DrawDebug();

            input.ClearInput();
            Thread.Sleep(settings.timeStep);
        }
    }

    protected void CalculateFrame()
    {
        switch (Input.LastInput)
        {
            case InputResult.Exit:
                IsFinished = true;
                return;
        }

        // Do every object logic
        for (int i = 0; i < gameBehaviours.Count; i++)
        {
            gameBehaviours[i].OnUpdate();
        }
    }

    protected void ClearFrame()
    { 
        for (int i = 0; i < gameBehaviours.Count; i++)
        {
            gameBehaviours[i].Clear();
        }
    }

    protected void DrawFrame()
    {
        for (int i = 0; i < gameBehaviours.Count; i++)
        {
            gameBehaviours[i].Draw();
        }
    }

    void DrawDebug()
    {
        Console.SetCursorPosition(0, level.Height);
        Console.Write($"gameBehaviours: {gameBehaviours.Count}");
    }
}