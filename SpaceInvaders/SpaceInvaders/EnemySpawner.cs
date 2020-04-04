using System;

class EnemySpawner : GameBehaviourBase
{
    protected readonly Level level;

    public EnemySpawner(Level level)
    {
        this.level = level;
    }

    public override void OnUpdate()
    {
        var r = new Random();

        if (r.NextDouble() < 0.1f)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        var r = new Random();

        var x = r.Next(level.Width - 7, level.Width - 1);
        var y = r.Next(1, level.Height - 4);

        SpawnEnemy(x, y);
    }

    public void SpawnEnemy(int x, int y)
    {
        var enemy = new Enemy(level);
        enemy.MoveTo(x, y);
        enemy.Move(Direction.Left);
        Game.Instance.RegisterBehaviour(enemy);
    }

    public override void Clear() { }

    public override void Draw() { }
}