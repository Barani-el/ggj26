using UnityEngine;

public class CardController : MonoBehaviour
{
    public BaseCardSO currentData;
    public void SetUp(BaseCardSO data)
    {
        currentData = data;
    }
}
