using System;
using UnityEditor;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public Slot[] slots;
    public int totalValue;

    public event Action SlotChanged;

    private void Awake()
    {
        foreach (var slot in slots)
        {
            slot.CardChanged += SlotChange;     //Slotlarýn Deðiþim eventine abone
        }
    }
    private void OnEnable()
    {
        SlotChanged += TakeSlotsValue;  
    }

   public void TakeSlotsValue()
    {/*
        totalValue = 0;
        for (int i = 0; i < slots.Length; i++)
        {   
            int _cardValue;
            PointCard card = slots[i].GetComponent<PointCard>();
            if (card !=null)
            {
                _cardValue = card.cardValue;
                totalValue += _cardValue;   // Total deðer
            }
        }
        Debug.Log($"Total Value = {totalValue}");*/
    }

    public void SlotChange()
    {
        SlotChanged?.Invoke();
    }
}
