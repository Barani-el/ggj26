using System.Collections;
using TMPro;
using UnityEngine;

public enum TurnPhase
{
    Preparation,      
    DiceRoll,         
    ScoreCalculation, 
    PawnMovement,     
    Reactions,      
    CardDeal,         
    TurnEnd
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public GameEntity playerHand;
    public GameEntity pcHand;
    public GameObject cardPrefab;
    public TurnPhase currentPhase;

    [SerializeField] TextMeshProUGUI timerText;
    float prepTimer;
    private const float prepTime=30;
    private const float readyTime = 3;
    private bool playerReady;
    public bool CanPlayerMove => currentPhase == TurnPhase.Preparation;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start()
    {
        DealInitialCards(4);
    }

    private void Update()
    {
        HandlePreperationTime();
    }
    public void DealInitialCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            DrawCardFor(playerHand);
            DrawCardFor(pcHand);
        }
    }
    public void DrawCardFor(GameEntity targetEntity)
    {
        if (targetEntity == null) return;

        BaseCardSO card = CardDeck.instance.DrawCard();
        
        if (card != null)
        {
            Debug.Log("SEA BEN GELDÝM");

            GameObject cardObj = Instantiate(cardPrefab, targetEntity.cardPoses[targetEntity.inventory.Count ].position, Quaternion.Euler(90,0,0),targetEntity.transform); //üretim burada ama animasyon gelecek buraya

            CardController controller = cardObj.GetComponent<CardController>();
            controller.SetUp(card);
            targetEntity.AddCardToInventory(controller);

            /*if(targetEntity ==) Bu satýrda eðer kart oyuncuya veriliyorsa interactable layer'ý vericem */

         
         
        }
    }

    //               PHASE                //



    public void StartGame() => SetPhase(TurnPhase.Preparation);

    public void SetPhase(TurnPhase phase  )
    {
        currentPhase = phase;

        switch (phase)
        {
            case TurnPhase.Preparation:
                StartPrepare();
                break;
            case TurnPhase.DiceRoll:
                StartDiceRoll();
                break;
            case TurnPhase.ScoreCalculation:
                CalculateScore();
                break;
            case TurnPhase.PawnMovement:
                MovePawns();
                break;
            case TurnPhase.Reactions:
                PlayReactions();
                break;
            case TurnPhase.CardDeal:
                DealCards();
                break;
            case TurnPhase.TurnEnd:
                EndTurn();
                break;
        }
    }

    private void NextPhase() => SetPhase(currentPhase + 1);

    void StartPrepare()
    {
        prepTimer = prepTime;
        playerReady = false;
        EventManager.PreparationStart();
    }

    void HandlePreperationTime()
    {

        prepTimer -= Time.deltaTime;
        
        if (prepTime < 0)
        {
            EventManager.PreparationEnd();
            NextPhase();
        }
        else
        {
            timerText.text = prepTimer.ToString();
        }
    }

    public void PlayerReady()
    {
        if (!playerReady && currentPhase == TurnPhase.Preparation)
        {
            playerReady = true;
            prepTimer = Mathf.Min(prepTimer, readyTime);
        }
    }
    void StartDiceRoll()
    {
        EventManager.DiceRollStart();
    }

    void CalculateScore()
    {

    }

    void MovePawns()
    {

    }
    void PlayReactions()
    {

    }

    void DealCards()
    {

    }

    void EndTurn()
    {

    }
}
