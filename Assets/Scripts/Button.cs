using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips;
    private AudioSource source;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite activatedButtonSprite;
    [SerializeField] private Sprite defaultSprite;

    [SerializeField] private float offset;

    [SerializeField] private TechActivation tech;
    public Lever.TechFunction function;
    private bool buttonPressed;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (buttonPressed) //¬ À
        {
            if (function == Lever.TechFunction.GoUpThenDown)
            {
                tech.ActivateTech(ref tech.doorGoUp, true);
            }

            if (function == Lever.TechFunction.ObjectDisappearing)
            {
                tech.gameObject.SetActive(false);
            }
        }
        else //¬€ À
        {
            if (function == Lever.TechFunction.GoUpThenDown)
            {
                tech.ActivateTech(ref tech.doorGoUp, false);
            }

            if (function == Lever.TechFunction.ObjectDisappearing)
            {
                tech.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Cube>() != null)
        {
            if (collision.transform.position.y >= transform.position.y + offset)
            {
                source.clip = clips[Random.Range(0, clips.Count)];
                source.Play();

                spriteRenderer.sprite = activatedButtonSprite;
                buttonPressed = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Cube>() != null)
        {
            spriteRenderer.sprite = defaultSprite;
            buttonPressed = false;
        }
    }
}
