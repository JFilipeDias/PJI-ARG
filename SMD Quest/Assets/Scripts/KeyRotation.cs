using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{
    private Quaternion originalRotation;
    private float startAngle = 0;
    private int keyMask;

    public void Start()
    {
        keyMask = LayerMask.GetMask("KeyMask");
        originalRotation = this.transform.rotation;
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            HandleTouch();
            //Debug.Log("Tocou");
        }
    }


    private void HandleTouch()
    {
        Touch playerTouch = Input.GetTouch(0);

        Vector2 keyScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 vector = Input.GetTouch(0).position - keyScreenPosition;

        if (playerTouch.phase == TouchPhase.Began)
        {
            originalRotation = this.transform.rotation;
            startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        }

        if (playerTouch.phase == TouchPhase.Moved)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, this.transform.forward);
            newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
            this.transform.rotation = originalRotation * newRotation;
        }
    }
}
