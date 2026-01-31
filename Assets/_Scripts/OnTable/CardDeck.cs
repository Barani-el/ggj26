using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct CardandAmount
{
    
    public BaseCardSO cardData;
    public int amount;
}

public class CardDeck : MonoBehaviour
{
    public static CardDeck instance;
    [SerializeField] List<CardandAmount> cardList = new List<CardandAmount>();
    [SerializeField] List<BaseCardSO> playDeck= new List<BaseCardSO>();

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

        PrepareDeck();
    }
    public void PrepareDeck()
    {
        foreach (var card in cardList)
        {
            for (int i = 0; i < card.amount; i++)
            {
                playDeck.Add(card.cardData);

            }
        }

        ShuffleDeck(playDeck);
    }

    private void ShuffleDeck(List<BaseCardSO> listToShuffle)
    {
        int n = listToShuffle.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            // Yer deðiþtirme (Swap) iþlemi
            BaseCardSO value = listToShuffle[k];
            listToShuffle[k] = listToShuffle[n];
            listToShuffle[n] = value;
        }
    }

    public BaseCardSO DrawCard()
    {
        if (playDeck.Count < 1)
        {
            return null;
        }

        BaseCardSO drawnCard = playDeck[0];
        playDeck.RemoveAt(0);
        return drawnCard;
    }
}
