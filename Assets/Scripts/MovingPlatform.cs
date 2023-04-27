using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;

    [Tooltip("Всегда должен находится слева")]
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform originPosition;

    [SerializeField] private bool goToTheEnd = true;

    private Rigidbody2D rb2d;

    private void Awake() => rb2d = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if (goToTheEnd)
        {
            if (endPosition.position.x < transform.position.x)
            {
                rb2d.velocity = Vector2.left * speed * Time.fixedDeltaTime;
            }
            else
            {
                goToTheEnd = false;
            }
        }
        else
        {
            if (transform.position.x < originPosition.position.x)
            {
                rb2d.velocity = Vector2.right * speed * Time.fixedDeltaTime;
            }
            else
            {
                goToTheEnd = true;
            }
        }
    }
}
