using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    public Animator playerTurnIndicator, enemyTurnIndicator;

    public void UpdateTurnIndicatorAnimation(Animator animator, bool value)
    {
        //animator.enabled = value;
    }
}
