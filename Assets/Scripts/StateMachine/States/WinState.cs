using UnityEngine;

public class WinState : BaseState
{
    TurnSM sm;

    public WinState(TurnSM stateMachine) : base("WinState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        sm.results.ShowResults(sm.results.winSentence);

        sm.wordUI.GameOverEffect();
    }
}
