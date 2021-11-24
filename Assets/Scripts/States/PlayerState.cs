public class PlayerState : BaseState
{
    TurnSM sm;

    public PlayerState(TurnSM stateMachine) : base("PlayerState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        base.Enter();

        sm.buttonGenerator.UpdateButtons(true);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (sm.player.playerWon)
        {
            stateMachine.ChangeState(sm.winState);
        }
        else if (sm.player.hadTurn)
        {
            stateMachine.ChangeState(sm.enemyState);
            sm.player.hadTurn = false;
        }
    }
}
