using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotIcon;
    private Item item;
    public Button useItemButton;
    private InventoryUI inventoryCanvas;
    private GameObject goalTarget;
    public GameObject totemAudiovisual;
    public GameObject totemDesign;
    public GameObject totemGames;
    public GameObject totemSystems;


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

                case "Totem Audiovisual":
                case "Totem Design":
                case "Totem Games":
                case "Totem Systems":
                    goalTarget = GameObject.Find("Target Island");
                    if (goalTarget.GetComponent<GoalTargetDetection>().isTracked)
                        Use();
                    break;
            }
        }
    }


    public void Use()
    {
        string deletedItem = item.name;
        inventoryCanvas.Close();
        Inventory.instance.Remove(item);

        if (deletedItem == "Key Audiovisual" ||
            deletedItem == "Key Design" ||
            deletedItem == "Key Games" ||
            deletedItem == "Key Systems") 
            UseKey();
        else if (deletedItem == "Totem Audiovisual" ||
            deletedItem == "Totem Design" ||
            deletedItem == "Totem Games" ||
            deletedItem == "Totem Systems")
            UseTotem(deletedItem);
    }


    public void UseKey()
    {
        Transform spawnPosition = goalTarget.transform.GetChild(0).GetChild(3);
        Instantiate(Resources.Load("Prefabs/3D/KeyAnimated", typeof(GameObject)), spawnPosition);
    }


    public void UseTotem(string deletedItem)
    {
        if (deletedItem == "Totem Audiovisual")
            totemAudiovisual.SetActive(true);
        else if (deletedItem == "Totem Design")
            totemDesign.SetActive(true);
        else if (deletedItem == "Totem Games")
            totemGames.SetActive(true);
        else if (deletedItem == "Totem Systems")
            totemSystems.SetActive(true);
    }
}
