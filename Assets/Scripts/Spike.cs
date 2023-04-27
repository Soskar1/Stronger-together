using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private List<AudioClip> hitClips;
    private AudioSource source;

    private Game game;
    private Shake shake;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
        shake = FindObjectOfType<Shake>();

        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Cube>() != null
            || collision.GetComponent<Cursor>() != null)
        {
            GameOver(collision);
        }
    }

    void GameOver(Collider2D collision)
    {
        if (collision.GetComponentInChildren<ParticleSystem>() != null)
        {
            collision.GetComponentInChildren<ParticleSystem>().Play();
        }

        source.clip = hitClips[Random.Range(0, hitClips.Count)];
        source.Play();

        shake.ShakeCamera(5f, 0.1f);

        game.RestartOrMoveToTheNextLevel(false);
    }
}
