using System;

public class StartButton : ActionButton
{
    public event Action Clicked;
    
    protected override void Affect()
    {
        Clicked?.Invoke();
    }
}