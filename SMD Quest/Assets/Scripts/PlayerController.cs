using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
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

        if (Physics.Raycast(camRay, out rayHit, Mathf.Infinity, LayerMask.GetMask("ItemMask")))
        {
            rayHit.transform.GetComponent<ItemPickUp>().PickUp();
        }
    }
}
