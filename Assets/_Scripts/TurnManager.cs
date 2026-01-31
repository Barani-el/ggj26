using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameEntity playerHand;
    public GameEntity pcHand;
    public GameObject cardPrefab;

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

            GameObject cardObj = Instantiate(cardPrefab, targetEntity.cardPoses[targetEntity.inventory.Count ].position, Quaternion.Euler(90,0,0)); //üretim burada ama animasyon gelecek buraya

            CardController controller = cardObj.GetComponent<CardController>();
            controller.SetUp(card);
            targetEntity.AddCardToInventory(controller);

          /*  if (!targetEntity.cardPoses[targetEntity.inventory.Count + 1])  //Bir þeyi check ediom ama ne olduðunu unttum
            {
               
            }*/
         
        }
    }
}
