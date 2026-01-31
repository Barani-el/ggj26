using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public static PlayerInputHandler instance;
    public GameObject selectedCard;
    public LayerMask interactable;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        if (TurnManager.instance.CanPlayerMove && Input.GetMouseButtonDown(0))
        {
            HandleRaycast();
        }
    }

    void HandleRaycast()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, interactable))
        {

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null )
            {   
                interactable.Interact();
                if (selectedCard != null)
                {
                    IInteractable selecetedInteractable = selectedCard.GetComponent<IInteractable>();
                    selecetedInteractable.Interact();
                   

                }
                selectedCard = hit.transform.gameObject;
            }
        }
    }
}
