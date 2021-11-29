using UnityEngine;

public class PlayerState : BaseState
{
    TurnSM sm;

    public PlayerState(TurnSM stateMachine) : base("PlayerState", stateMachine) => sm = stateMachine;  

    public override void Enter()
    {
        sm.buttonGenerator.keyboardButton.enabled = true;
    }

    public override void UpdateLogic()
    {
        if (GameManager.Instance.hasWon)
        {
            stateMachine.ChangeState(sm.winState);
        }
        else if (GameManager.Instance.hasLost)
        {
            stateMachine.ChangeState(sm.loseState);
        }
        else if (sm.player.hadTurn)
        {
            stateMachine.ChangeState(sm.enemyState);
            sm.player.hadTurn = false;
        }
    }
}
