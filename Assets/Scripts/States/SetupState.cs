public class SetupState : BaseState
{
    TurnSM sm;

    public SetupState(TurnSM stateMachine) : base("SetupState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        sm.wordGenerator.GetRandomWordFromDictionary();

        sm.wordUI.GenerateLetters(sm.wordUI.playerPanel, sm.wordUI.playerLetters);
        sm.wordUI.GenerateLetters(sm.wordUI.enemyPanel, sm.wordUI.enemyLetters);

        sm.buttonGenerator.GenerateButtons();

        stateMachine.ChangeState(sm.playerState);
    }
}
