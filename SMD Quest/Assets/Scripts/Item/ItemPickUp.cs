using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;


    public void PickUp()
    {
        if (item.name == "Key Fake")
        {
            int FakeKeyIconRandomizer = Random.Range(1, 4);

            if (FakeKeyIconRandomizer == 1)
                item.icon =  item.FakeKeyIcon[0];
            else if (FakeKeyIconRandomizer == 2)
                item.icon = item.FakeKeyIcon[1];
            else if (FakeKeyIconRandomizer == 3)
                item.icon = item.FakeKeyIcon[2];
            else if (FakeKeyIconRandomizer == 4)
                item.icon = item.FakeKeyIcon[3];
        }

        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(this.gameObject);
    }   
}
