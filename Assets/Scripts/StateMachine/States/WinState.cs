using UnityEngine;
using System.Collections;

public class WinState : BaseState
{
    TurnSM sm;

    public WinState(TurnSM stateMachine) : base("WinState", stateMachine) => sm = stateMachine;

    public override void Enter()
    {
        sm.results.StartWinSequence();
        GameManager.Instance.IncreaseCorrectWords();
        GameManager.Instance.IncreaseCorrectLetters();
    }
}
