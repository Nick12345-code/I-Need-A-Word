using UnityEngine;

public class PlayerState : BaseState
{
    TurnSM sm;

    public PlayerState(TurnSM stateMachine) : base("PlayerState", stateMachine) => sm = stateMachine;  

    public override void Enter()
    {
        sm.buttonGenerator.keyboardButton.enabled = true;

        sm.turnIndicator.UpdateTurnIndicatorAnimation(sm.turnIndicator.playerTurnIndicator, true);
        sm.turnIndicator.UpdateTurnIndicatorAnimation(sm.turnIndicator.enemyTurnIndicator, false);
    }

    public override void UpdateLogic()
    {
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
