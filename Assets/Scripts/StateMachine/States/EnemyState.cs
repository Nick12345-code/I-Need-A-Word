public class EnemyState : BaseState
{
    TurnSM sm;

    public EnemyState(TurnSM stateMachine) : base("EnemyState", stateMachine) => sm = stateMachine;

    bool isDone;

    public override void Enter()
    {
        isDone = false;
        sm.buttonGenerator.keyboardButton.enabled = false;
    }

    public override void UpdateLogic()
    {
        EnemyTurn();

        if (GameManager.hasLost)
        {
            stateMachine.ChangeState(sm.loseState);
        }
        else if (GameManager.hasWon)
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
