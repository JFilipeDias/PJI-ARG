using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemsParent;
    private InventorySlot[] slots;
    public GameObject inventoryUI;
    public GameObject inventoryOpenButton;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemList.Count)
                slots[i].AddItem(inventory.itemList[i]);
            else
                slots[i].ClearSlot();
        }
    }


    public void Open()
    {
        inventoryUI.SetActive(true);
        inventoryOpenButton.SetActive(false);

    }


    public void Close()
    {
        inventoryUI.SetActive(false);
        inventoryOpenButton.SetActive(true);
    }
}
