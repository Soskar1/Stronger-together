using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechActivation : MonoBehaviour
{
    [SerializeField] private Lever.TechFunction function;

    [Header("GoUpThenDown, GoDownThenUp")]
    [SerializeField] private float speed;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform originPosition;

    [HideInInspector] public bool doorGoUp;
    [HideInInspector] public bool doorGoDown;
    [HideInInspector] public bool doorGoRight;
    [HideInInspector] public bool doorGoLeft;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        if (rb2d != null)
        {
            if (function == Lever.TechFunction.GoUpThenDown)
            {
                if (doorGoUp)
                {
                    DoorGoUp();
                }
                else
                {
                    DoorGoDownFromTheEnd();
                }
            }

            if (function == Lever.TechFunction.GoDownThenUp)
            {
                if (doorGoDown)
                {
                    DoorGoDown();
                }
                else
                {
                    DoorGoUpFromTheEnd();
                }
            }

            if (function == Lever.TechFunction.GoLeftThenRight)
            {
                if (doorGoLeft)
                {
                    DoorGoLeft();
                }
                else
                {
                    DoorGoRightFromTheEnd();
                }
            }

            if (function == Lever.TechFunction.GoRightThenLeft)
            {
                if (doorGoRight)
                {
                    DoorGoRight();
                }
                else
                {
                    DoorGoLeftFromTheEnd();
                }
            }
        }
    }

    public void ActivateTech(ref bool tech, bool statement)
    {
        tech = statement;
    }

    private void DoorGoUp()
    {
        if (endPosition.localPosition.y > transform.localPosition.y)
        {
            rb2d.velocity = Vector2.up * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoDownFromTheEnd()
    {
        if (transform.localPosition.y > originPosition.localPosition.y)
        {
            rb2d.velocity = Vector2.down * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoDown()
    {
        if (endPosition.localPosition.y < transform.localPosition.y)
        {
            rb2d.velocity = Vector2.down * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoUpFromTheEnd()
    {
        if (transform.localPosition.y < originPosition.localPosition.y)
        {
            rb2d.velocity = Vector2.up * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoRight()
    {
        if (endPosition.localPosition.x > transform.localPosition.x)
        {
            rb2d.velocity = Vector2.right * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoLeftFromTheEnd()
    {
        if (transform.localPosition.x > originPosition.localPosition.x)
        {
            rb2d.velocity = Vector2.left * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoLeft()
    {
        if (endPosition.localPosition.x < transform.localPosition.x)
        {
            rb2d.velocity = Vector2.left * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void DoorGoRightFromTheEnd()
    {
        if (transform.localPosition.x < originPosition.localPosition.x)
        {
            rb2d.velocity = Vector2.right * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
