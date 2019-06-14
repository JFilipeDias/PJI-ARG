using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotIcon;
    private Item item;
    public Button useItemButton;
    private InventoryUI inventoryCanvas;
    private GameObject goalTarget;


    private void Start()
    {
        inventoryCanvas = GameObject.Find("Canvas").GetComponent<InventoryUI>();
    }


    public void AddItem(Item newItem)
    {
        item = newItem;
        slotIcon.sprite = item.icon;
        slotIcon.enabled = true;
        useItemButton.interactable = true;
    }


    public void ClearSlot()
    {
        item = null;
        slotIcon.sprite = null;
        slotIcon.enabled = false;
        useItemButton.interactable = false;
    }


    public void OnUseItemButton()
    {
        

        if (item != null){
            switch (item.name)
            {
                case "Key Audiovisual":
                    goalTarget = GameObject.Find("Target Chest Audiovisual");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;

                case "Key Design":
                    goalTarget = GameObject.Find("Target Chest Design");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;
                    
                case "Key Games":
                    goalTarget = GameObject.Find("Target Chest Games");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;
                    
                case "Key Systems":
                    goalTarget = GameObject.Find("Target Chest Systems");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;
                    
                case "Key Fake":
                        Use();
                    break;
            }
        }
    }


    public void Use()
    {
        Inventory.instance.Remove(item);
        ClearSlot();
        inventoryCanvas.Close();


        if (item.name == "Key Audiovisual" ||
            item.name == "Key Design" ||
            item.name == "Key Games" ||
            item.name == "Key Systems")
            UseKey();
        else if (item.name == "Totem Audiovisual" ||
            item.name == "Totem Design" ||
            item.name == "Totem Games" ||
            item.name == "Totem Systems")
            UseTotem();
    }


    public void UseKey()
    {
        Transform spawnPosition = goalTarget.transform.GetChild(0).GetChild(3);
        Debug.Log("Spawn position: " + spawnPosition.name);
        GameObject keyAnimated = Instantiate(Resources.Load("Prefabs/3D/KeyAnimated"), spawnPosition) as GameObject;
        keyAnimated.GetComponent<Animator>().SetTrigger("Opening");
    }


    public void UseTotem()
    {

    }
}
