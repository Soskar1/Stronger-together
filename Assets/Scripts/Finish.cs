using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private List<AudioClip> completedClips;
    [SerializeField] private AudioSource completedSource;

    [SerializeField] private List<AudioClip> newLevelClips;
    [SerializeField] private AudioSource newLevelSource;

    private Game game;

    private bool cubeCompletedTheLevel;
    private bool cursorCompletedTheLevel;

    [SerializeField] private GameObject cubeNotCompleted;
    [SerializeField] private GameObject cursorNotCompleted;

    [SerializeField] private GameObject cubeCompleted;
    [SerializeField] private GameObject cursorCompleted;

    private void Awake() => game = FindObjectOfType<Game>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Cube>() != null)
        {
            ChangeStatement(ref cubeCompletedTheLevel, true);
        }

        if (collision.GetComponentInParent<Cursor>() != null)
        {
            ChangeStatement(ref cursorCompletedTheLevel, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Cube>() != null)
        {
            ChangeStatement(ref cubeCompletedTheLevel, false);
        }

        if (collision.GetComponentInParent<Cursor>() != null)
        {
            ChangeStatement(ref cursorCompletedTheLevel, false);
        }
    }

    void ChangeStatement(ref bool boolean, bool statement)
    {
        boolean = statement;

        if (cubeCompletedTheLevel)
        {
            completedSource.clip = completedClips[Random.Range(0, completedClips.Count)];
            completedSource.Play();

            cubeCompleted.SetActive(true);
            cubeNotCompleted.SetActive(false);
        }
        else
        {
            cubeCompleted.SetActive(false);
            cubeNotCompleted.SetActive(true);
        }

        if (cursorCompletedTheLevel)
        {
            completedSource.clip = completedClips[Random.Range(0, completedClips.Count)];
            completedSource.Play();

            cursorCompleted.SetActive(true);
            cursorNotCompleted.SetActive(false);
        }
        else
        {
            cursorCompleted.SetActive(false);
            cursorNotCompleted.SetActive(true);
        }

        if (cubeCompletedTheLevel && cursorCompletedTheLevel)
        {
            newLevelSource.clip = newLevelClips[Random.Range(0, newLevelClips.Count)];
            newLevelSource.Play();

            game.RestartOrMoveToTheNextLevel(true);
        }
    }
}
