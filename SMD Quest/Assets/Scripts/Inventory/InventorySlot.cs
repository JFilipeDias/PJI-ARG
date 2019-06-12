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
                case "Chave Audiovisual":
                    goalTarget = GameObject.Find("Target Bau Audiovisual");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;

                case "Chave Design":
                    goalTarget = GameObject.Find("Target Bau Design");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Chave Jogos":
                    goalTarget = GameObject.Find("Target Bau Design");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Chave Sistemas":
                    goalTarget = GameObject.Find("Target Bau Design");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        item.Use();
                    break;
                    
                case "Chave Falsa":
                        item.Use();
                    break;
                    
            }
          
            
        }
    }
}
