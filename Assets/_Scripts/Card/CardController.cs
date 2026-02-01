using System;
using UnityEngine;

public enum cardState
{
    selected,
    normal
}

public class CardController : MonoBehaviour,IInteractable
{
    public BaseCardSO currentData;
    cardState state;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    public void SetUp(BaseCardSO data)
    {
        currentData = data;
        state = cardState.normal;
    }

    public void Interact()
    {
        if (state == cardState.normal)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }

    public void Select()
    {
        // Animler
        Debug.Log("Select");
        state = cardState.selected;
        transform.localScale = new Vector3(1,0.07f,1.55f)* 1.5f;
    }

    public void Deselect()
    {
        //Animler
        state = cardState.normal;
        Debug.Log("DeSelect");
        transform.localScale = new Vector3(1, 0.07f, 1.55f);
    }
}
