class Program
{
    static void Main(string[] args)
    {
        Game.Instance.Init(new GameSettings
        {
            levelWidth = 20,
            levelHeight = 10,

            playerSpawnX = 1,
            playerSpawnY = 1,

            timeStep = 100
        });
        Game.Instance.Start();
    }
}