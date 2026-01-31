using System;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public BaseCardSO card;
    public event Action CardChanged;

    public void AddCard(CardController cardData)
    {
        card = cardData.currentData;
        cardData.transform.position = this.transform.position;
        Debug.Log(card + " eklendi");
        CardChanged?.Invoke();
    }

    public void ClearSlot()
    {
        card = null;
        Debug.Log("Slot Temizlendi");
        CardChanged?.Invoke();
    }
}
