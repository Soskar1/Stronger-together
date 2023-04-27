using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Transform cursor;
    [SerializeField] private float dragDistance;

    [SerializeField] private float forceAmount;
    [SerializeField] private float groundCheckSize;

    [Header("Scaling")]
    [SerializeField] private float maxScaleX;
    [SerializeField] private float minScaleX;
    [SerializeField] private float sizeChangeSpeed;

    private Rigidbody2D rb2d;

    private DragAndDrop dragAndDrop;

    [HideInInspector] public bool isDragging;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dragAndDrop = GetComponent<DragAndDrop>();

        cursor = FindObjectOfType<Cursor>().transform;
    }

    private void Update()
    {
        if (GroundCheck() && !isDragging)
        {
            //Меняем его объём
            if (transform.localScale.x < maxScaleX)
            {
                Vector2 newScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y);
                transform.localScale = newScale;
            }
            else
            {
                transform.localScale = new Vector2(maxScaleX, transform.localScale.y);
            }
        }
        else if (!GroundCheck() && !isDragging)
        {
            //Меняем его объём
            if (transform.localScale.x > minScaleX)
            {
                Vector2 newScale = new Vector2(transform.localScale.x - Time.deltaTime * sizeChangeSpeed, transform.localScale.y);
                transform.localScale = newScale;
            }
            else
            {
                transform.localScale = new Vector2(minScaleX, transform.localScale.y);
            }
        }
        else if (!GroundCheck() && isDragging)
        {
            //Меняем его объём
            if (transform.localScale.x < maxScaleX)
            {
                Vector2 newScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y);
                transform.localScale = newScale;
            }
            else
            {
                transform.localScale = new Vector2(maxScaleX, transform.localScale.y);
            }
        }

        if (isDragging)
        {
            if (Vector2.Distance(cursor.position, transform.position) > dragDistance)
            {
                isDragging = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            rb2d.velocity = (dragAndDrop.cursor.mousePosition - (Vector2)transform.position) *
                forceAmount * Time.fixedDeltaTime;
        }
    }

    private bool GroundCheck()
    {
        Vector2 scale = new Vector2(transform.localScale.x + groundCheckSize, transform.localScale.y + groundCheckSize);

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, scale, 0);

        foreach(Collider2D collider in colliders)
        {
            if (collider != null && collider.GetComponent<Cube>() == null)
            {
                return true;
            }
        }

        return false;
    }
}
