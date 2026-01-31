using UnityEngine;

public class GameEntity : MonoBehaviour
{
    [SerializeField] Transform[] cardPoses;
    public BaseCardSO[] inventory;

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

  
}
