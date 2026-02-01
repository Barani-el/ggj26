using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    public static event Action OnPrepareStart;
    public static event Action OnPrepareEnd;
    public static event Action OnDiceRollStart;
    public static event Action<int[]> OnDiceRollComplete; // zar sonuçlarý
    public static event Action<int> OnScoreCalculated;    // toplam skor
    public static event Action<int> OnPawnMove;           // kaç adým
    public static event Action<bool> OnReaction;          // true=mutlu, false=sinirli
    public static event Action OnCardDealStart;
    public static event Action OnTurnEnd;

    public static void PreparationStart() => OnPrepareStart?.Invoke();
    public static void PreparationEnd() => OnPrepareEnd?.Invoke();
    public static void DiceRollStart() => OnDiceRollStart?.Invoke();
    public static void DiceRollComplete(int[] results) => OnDiceRollComplete?.Invoke(results);
    public static void ScoreCalculated(int total) => OnScoreCalculated?.Invoke(total);
    public static void PawnMove(int stepAmount) => OnPawnMove?.Invoke(stepAmount);

    public static void Reaction(bool result) => OnReaction?.Invoke(result);
    public static void CardDealStart() => OnCardDealStart?.Invoke();
    public static void TurnEnd() => OnTurnEnd?.Invoke();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        
    }

    void Update()
    {
        
    }
}
