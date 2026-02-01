using System.Collections.Generic;
using UnityEngine;



public class GameEntity : MonoBehaviour
{
    public Transform[] cardPoses;
    public List<CardController> inventory = new List<CardController>();

    public int healthPoint = 3;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        healthPoint--;
    }

    public void AddCardToInventory(CardController targetCard)
    {
        inventory.Add(targetCard);
    }

   
  
}
