using System;

public interface IMover
{
    public event Action<int> ObjectMoved;
    public event Action<bool> ObjectJumped;

    private void MovedNotify(int value) { }
    private void JumpedNotify(bool value) { }
}