using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void UpdateUI()
    {

    }
}
