using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    private Transform itemTrasnform;
    private int itemMask;

    private void Awake()
    {
        itemMask = LayerMask.GetMask("ItemMask");
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            CheckTouch();
        }
    }


    private void CheckTouch()
    {
        Touch playerTouch = Input.GetTouch(0);
        Ray camRay = Camera.main.ScreenPointToRay(playerTouch.position);
        RaycastHit rayHit;

        if (Physics.Raycast(camRay, out rayHit, Mathf.Infinity, itemMask))
        {
            itemTrasnform = rayHit.transform;
            itemTrasnform.GetComponent<ItemPickUp>().PickUp();
        }
    }


    public void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(itemTrasnform.GetComponent<ItemPickUp>().item);

        if (wasPickedUp)
            Destroy(this.gameObject);
    }   
}
