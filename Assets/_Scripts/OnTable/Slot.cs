using System;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour,IInteractable
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
    public void Interact()
    {
        CardController _card = PlayerInputHandler.instance.selectedCard.GetComponent<CardController>();
        if (_card != null)
        {
            card = _card.currentData;
            PlayerInputHandler.instance.selectedCard.transform.position = transform.position;
            PlayerInputHandler.instance.selectedCard.transform.rotation = transform.rotation;
        }
    }
}
