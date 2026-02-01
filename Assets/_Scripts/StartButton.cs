using UnityEngine;

public class StartButton : MonoBehaviour,IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (TurnManager.instance.currentPhase != TurnPhase.None) return;
        Debug.Log("OYUN BAÞLASIN!!!");
        TurnManager.instance.StartGame();
    }
}
