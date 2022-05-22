using UnityEngine;

public class ElementsInventory : MonoBehaviour
{
    [SerializeField] private Elements[] elements;
    private int currentElementIndex;
    private int maxElements;
    private GameObject player;
    private PlayerHUD hud;
    

    public void Start()
    {
        InitVariables();
    }

    public void AddElement(Elements newItem)
    {

        if (currentElementIndex < maxElements )
        {
            elements[currentElementIndex] = newItem;
            hud.UpdateElementUI(currentElementIndex, elements[currentElementIndex]);
            currentElementIndex++;
        }
    }

    public void RemoveElement()
    {
        if(currentElementIndex > 0)
        {
            currentElementIndex--;
            Debug.Log(currentElementIndex);
            hud.deleteElementUI(currentElementIndex, elements[currentElementIndex]);
            hud.UpdateMessage("Tu as jeté" + elements[currentElementIndex].description + " sur le sol");
            Instantiate(this.GetElement(currentElementIndex).prefab, player.transform.position + player.transform.forward, this.GetElement(currentElementIndex).prefab.transform.rotation);
            elements[currentElementIndex] = null;
        }
        
    }

    public Elements GetElement(int index)
    {
        return elements[index];
    }

    private void InitVariables()
    {
        player = PlayerController.instance;
        currentElementIndex = 0;
        maxElements = 4;
        hud = GetComponent<PlayerHUD>();
        elements = new Elements[maxElements];
    }
}
