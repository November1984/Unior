public class ToPlayerTalkStateTransition : Transition
{
    private readonly Player _player;

    public ToPlayerTalkStateTransition(State nextState, Player player) : base(nextState)
    {
        _player = player;
    }

    protected override bool CanTransit()
    {
        return _player.IsTalking;
    }
}