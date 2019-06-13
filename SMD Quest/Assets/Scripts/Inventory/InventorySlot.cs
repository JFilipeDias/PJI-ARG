using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotIcon;
    private Item item;
    public Button useItemButton;
    private GameObject goalTarget;

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
        Inventory.instance.Remove(item);

        if (item != null){
            switch (item.name)
            {
                case "Key Audiovisual":
                    goalTarget = GameObject.Find("Target Chest Audiovisual");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;

                case "Key Design":
                    goalTarget = GameObject.Find("Target Chest Design");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Key Games":
                    goalTarget = GameObject.Find("Target Chest Games");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Key Systems":
                    goalTarget = GameObject.Find("Target Chest Systems");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Key Fake":
                        item.Use();
                    break;
                    
            }
          
            
        }
    }
}
