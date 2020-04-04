using System;

abstract class RenderBase 
{
    protected ConsoleColor color;

    public abstract void Clear();
    public abstract void Draw();
}