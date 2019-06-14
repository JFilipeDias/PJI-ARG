using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{
    public void PlayChestAnimation()
    {
        Animator chestAnimator = GetComponentInParent<Animator>();
        chestAnimator.SetTrigger("Opening");
    }
}
