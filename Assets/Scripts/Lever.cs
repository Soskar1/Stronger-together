using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public enum TechFunction
    {
        GoUpThenDown,
        GoDownThenUp,
        ObjectDisappearing,
        GoLeftThenRight,
        GoRightThenLeft
    }

    public TechFunction function;

    [SerializeField] private float maxDegree;
    [SerializeField] private float minDegree;

    [SerializeField] private float force;
    [SerializeField] private TechActivation tech;

    [HideInInspector] public bool isDragging;
    public bool disabled;

    private DragAndDrop dragAndDrop;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float levelRotation = Mathf.Rad2Deg * transform.rotation.z * 2;

        if (isDragging)
        {
            float rotationZ = Vector2.SignedAngle(dragAndDrop.cursor.transform.position, transform.position);

            if (levelRotation > -45f && levelRotation < maxDegree)
            {
                rb2d.MoveRotation(rotationZ * force);
            }
        }

        if (levelRotation < minDegree)
        {
            disabled = true;
            transform.rotation = Quaternion.Euler(0, 0, minDegree);
        }

        if (levelRotation > maxDegree)
        {
            disabled = false;
            transform.rotation = Quaternion.Euler(0, 0, maxDegree);
        }

        if (!disabled) //¬ À
        {
            if (function == TechFunction.GoUpThenDown)
            {
                tech.ActivateTech(ref tech.doorGoUp, true);
            }

            if (function == TechFunction.GoDownThenUp)
            {
                tech.ActivateTech(ref tech.doorGoDown, true);
            }

            if (function == TechFunction.ObjectDisappearing)
            {
                tech.gameObject.SetActive(false);
            }

            if (function == TechFunction.GoLeftThenRight)
            {
                tech.ActivateTech(ref tech.doorGoLeft, true);
            }

            if (function == TechFunction.GoRightThenLeft)
            {
                tech.ActivateTech(ref tech.doorGoRight, true);
            }
        }
        else //¬€ À
        {
            if (function == TechFunction.GoUpThenDown)
            {
                tech.ActivateTech(ref tech.doorGoUp, false);
            }

            if (function == TechFunction.GoDownThenUp)
            {
                tech.ActivateTech(ref tech.doorGoDown, false);
            }

            if (function == TechFunction.ObjectDisappearing)
            {
                tech.gameObject.SetActive(true);
            }

            if (function == TechFunction.GoLeftThenRight)
            {
                tech.ActivateTech(ref tech.doorGoLeft, false);
            }

            if (function == TechFunction.GoRightThenLeft)
            {
                tech.ActivateTech(ref tech.doorGoRight, false);
            }
        }
    }
}
