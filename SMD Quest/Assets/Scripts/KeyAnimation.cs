using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public void PlayChestAnimation()
    {
        Animator chestAnimator = transform.parent.GetComponentInParent<Animator>();
        Debug.Log("Chest Animator: " + chestAnimator.name);
        chestAnimator.SetTrigger("Opening");
        chestAnimator.transform.GetChild(4).gameObject.AddComponent<BoxCollider>();
    }
}
