using System;
using System.Threading;

class Input
{
    public static InputResult LastInput
    {
        get;
        protected set;
    }

    protected Thread inputThread;
    public void StartInput()
    {
        inputThread = new Thread(InputThreadSheduler);
        inputThread.IsBackground = true;

        inputThread.Start();
    }
      
    public void StopInput()
    {
        inputThread.Abort();
    }

    public void ClearInput()
    {
        LastInput = InputResult.None;
    }


    protected InputResult GetInputDirection()
    {
        var keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                return InputResult.MoveLeft;

            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                return InputResult.MoveUp;

            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                return InputResult.MoveRight;

            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                return InputResult.MoveDown;

            case ConsoleKey.Escape:
                return InputResult.Exit;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                return InputResult.Shoot;
        }
        return InputResult.None;
    }

    protected void InputThreadSheduler()
    {
        while (true)
        {
            LastInput = GetInputDirection();
        }
    }
}