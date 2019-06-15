using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject inventoryCanvas;

    public void StartGame()
    {
        this.gameObject.SetActive(false);
        inventoryCanvas.SetActive(true);
    }
}
