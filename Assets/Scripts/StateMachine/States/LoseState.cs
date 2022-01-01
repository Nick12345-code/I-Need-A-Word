using UnityEngine;

public class LoseState : BaseState
{
    TurnSM sm;

    public LoseState(TurnSM stateMachine) : base("LoseState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        sm.results.ShowResults(sm.results.loseSentence, sm.wordGenerator.randomWord);
        GameManager.Instance.IncreaseCorrectLetters();
    }
}
