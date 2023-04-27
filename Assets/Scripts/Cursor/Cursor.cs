using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Sprites")]
    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite hand;

    [Header("Colliders")]
    [SerializeField] private Collider2D cursorColl;
    [SerializeField] private Collider2D handColl;

    public Controls controls;

    [Header("Camera Shake")]
    [SerializeField] private float intensity;
    [SerializeField] private float time;
    private Shake shake;
    private bool isAttacking;

    [Header("Sounds")]
    [SerializeField] private List<AudioClip> explosionClips;
    private AudioSource source;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    [HideInInspector] public Vector2 mousePosition;
    //private Vector2 direction;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        shake = FindObjectOfType<Shake>();

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        controls.Cursor.Drag.started += DragAndDrop.OnDragged;
        controls.Cursor.Drag.performed += DragAndDrop.OnReleased;

        controls.Cursor.Attack.started += _ => StartAttack();
        controls.Cursor.Attack.performed += _ => StopAttack();
    }

    private void Update()
    {
        mousePosition = controls.Cursor.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //direction = (mousePosition - (Vector2)transform.position).normalized;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(mousePosition);
    }

    void StartAttack()
    {
        isAttacking = true;
        spriteRenderer.sprite = hand;

        cursorColl.enabled = false;
        handColl.enabled = true;
    }

    void StopAttack()
    {
        isAttacking = false;
        spriteRenderer.sprite = cursor;

        cursorColl.enabled = true;
        handColl.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Explodable>() != null)
        {
            if (isAttacking)
            {
                source.clip = explosionClips[Random.Range(0, explosionClips.Count)];
                source.Play();

                collision.gameObject.GetComponent<Explodable>().explode();
                shake.ShakeCamera(intensity, time);
            }
        }
    }
}
