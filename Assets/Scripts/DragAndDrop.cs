using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [HideInInspector] public Cursor cursor;

    public static Action<InputAction.CallbackContext> OnDragged;
    public static Action<InputAction.CallbackContext> OnReleased;

    private void Awake()
    {
        OnDragged += Dragging;
        OnReleased += Releasing;
    }

    public void Dragging(InputAction.CallbackContext callbackContext)
    {
        cursor = FindObjectOfType<Cursor>();
        RaycastHit2D hitInfo = Physics2D.Raycast(cursor.transform.position, Vector2.zero);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.GetComponent<Cube>() != null)
            {
                hitInfo.collider.GetComponent<Cube>().isDragging = true;
            }
            else if (hitInfo.collider.GetComponent<Lever>() != null)
            {
                hitInfo.collider.GetComponent<Lever>().isDragging = true;
            }
        }
    }

    public void Releasing(InputAction.CallbackContext callbackContext)
    {
        DragAndDrop[] dragAndDrops = FindObjectsOfType<DragAndDrop>();
        foreach(DragAndDrop dragAndDrop in dragAndDrops)
        {
            if (dragAndDrop.GetComponent<Cube>() != null)
            {
                dragAndDrop.GetComponent<Cube>().isDragging = false;
            }

            if (dragAndDrop.GetComponent<Lever>() != null)
            {
                dragAndDrop.GetComponent<Lever>().isDragging = false;
            }
        }
    }
}
