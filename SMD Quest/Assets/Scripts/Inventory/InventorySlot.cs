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
                    if (GameObject.Find("Target Chest Audiovisual").GetComponent<GoalTargetDetection>().isTracked ||
                        GameObject.Find("Target Chest Design").GetComponent<GoalTargetDetection>().isTracked ||
                        GameObject.Find("Target Chest Games").GetComponent<GoalTargetDetection>().isTracked ||
                        GameObject.Find("Target Chest Systems").GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;
            }
        }
    }


    public void Use()
    {
        string deletedItem = item.name;
        Inventory.instance.Remove(item);
        ClearSlot();
        inventoryCanvas.Close();

        Debug.Log("Removeu o item do iventário");

        if (deletedItem == "Key Audiovisual" ||
            deletedItem == "Key Design" ||
            deletedItem == "Key Games" ||
            deletedItem == "Key Systems")
        {
            UseKey();
        }
        else if (deletedItem == "Totem Audiovisual" ||
            deletedItem == "Totem Design" ||
            deletedItem == "Totem Games" ||
            deletedItem == "Totem Systems")
            UseTotem();
    }


    public void UseKey()
    {
        Transform spawnPosition = goalTarget.transform.GetChild(0).GetChild(3);
        Instantiate(Resources.Load("Prefabs/3D/KeyAnimated", typeof(GameObject)), spawnPosition);
    }


    public void UseTotem()
    {

    }
}
