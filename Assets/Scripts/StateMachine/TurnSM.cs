using UnityEngine;
using TMPro;

public class TurnSM : StateMachine
{
    [HideInInspector] public SetupState setupState;
    [HideInInspector] public PlayerState playerState;
    [HideInInspector] public EnemyState enemyState;
    [HideInInspector] public WinState winState;
    [HideInInspector] public LoseState loseState;

    [Header("Scripts")]
    public Enemy enemy;
    public WordGenerator wordGenerator;
    public WordUI wordUI;
    public ButtonGenerator buttonGenerator;
    public Player player;
    public Results results;
    [Header("Setup")]
    [SerializeField] TextMeshProUGUI turnText;

    void Awake()
    {
        setupState = new SetupState(this);
        playerState = new PlayerState(this);
        enemyState = new EnemyState(this);
        winState = new WinState(this);
        loseState = new LoseState(this);
    }

    protected override BaseState GetInitialState() => setupState;

    public void UpdateTurnText(string turn) => turnText.text = turn;
}