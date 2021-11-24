public class SetupState : BaseState
{
    TurnSM sm;

    public SetupState(TurnSM stateMachine) : base("SetupState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        base.Enter();

        sm.wordGenerator.GenerateRandomWord();
        sm.wordUI.GeneratePlayerLetters();
        sm.wordUI.GenerateEnemyLetters();
        sm.buttonGenerator.GenerateButtons();

        stateMachine.ChangeState(sm.playerState);
    }
}
