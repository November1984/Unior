using System;

public class RestartButton : ActionButton
{
    public event Action Clicked;
    
    protected override void Affect()
    {
        Clicked?.Invoke();
    }
}