public class EnemyState : BaseState
{
    TurnSM sm;

    public EnemyState(TurnSM stateMachine) : base("EnemyState", stateMachine) => sm = stateMachine;

    bool isDone;

    public override void Enter()
    {
        isDone = false;
        sm.buttonGenerator.toggleKeyboardButton.enabled = false;
        sm.UpdateTurnText("COMPUTER IS THINKING");
    }

    public override void UpdateLogic()
    {
        EnemyTurn();

        if (GameManager.Instance.hasLost)
        {
            stateMachine.ChangeState(sm.loseState);
        }
        else if (GameManager.Instance.hasWon)
        {
            stateMachine.ChangeState(sm.winState);
        }
        else if (sm.enemy.hadTurn)
        {
            stateMachine.ChangeState(sm.playerState);
            sm.enemy.hadTurn = false;
        }

    }

    void EnemyTurn()
    {
        if (!isDone)
        {
            sm.enemy.Invoke("CheckRandomLetter", sm.enemy.enemyThinkingTime);
            isDone = true;
        }
    }
}
