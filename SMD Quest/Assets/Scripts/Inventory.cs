using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton    
    public static Inventory instance;


    public void Awake()
    {
        if(instance != null)
            return;
            
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
     
    public List <Item> itemList = new List<Item>();
    public int space = 10;

    public bool Add(Item newItem)
    {
        if (itemList.Count >= space)
            return false;

        itemList.Add(newItem);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }


    public void Remove(Item item)
    {
        itemList.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

}

