using UnityEngine;

public enum states
{
    Prepare,
    Animation,
    Dice
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public GameEntity playerHand;
    public GameEntity pcHand;
    public GameObject cardPrefab;
    public states currentState;
    public bool CanPlayerMove => currentState == states.Prepare;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start()
    {
        DealInitialCards(4);
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
}
