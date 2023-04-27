using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Animator restartPanelAnimator;
    [SerializeField] private GameObject pauseMenu;

    public Controls controls;

    private void OnEnable() => controls.Enable();

    private void Awake()
    {
        controls = new Controls();
        FindObjectOfType<Cursor>().controls = controls;
    }

    private void Start()
    {
        //Курсор и куб
        Physics2D.IgnoreLayerCollision(2, 7);

        //Передвигаемые предметы и препятствие для курсора
        Physics2D.IgnoreLayerCollision(7, 8);

        //Курсор и препятствия для куба
        Physics2D.IgnoreLayerCollision(2, 9);

        if (restartPanelAnimator != null)
        {
            controls.Cursor.RestartLevel.performed += _ => RestartOrMoveToTheNextLevel();
        }

        if (pauseMenu != null)
        {
            controls.Cursor.Pause.performed += _ => PauseTheGame();
        }
    }

    private void OnDisable() => controls.Disable();

    public void RestartOrMoveToTheNextLevel(bool moveToTheNextLevel = false)
    {
        StartCoroutine(RestartingOrLoadingNewLevel(moveToTheNextLevel));
    }

    private IEnumerator RestartingOrLoadingNewLevel(bool moveToTheNextLevel)
    {
        restartPanelAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        if (!moveToTheNextLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            int level = SceneManager.GetActiveScene().buildIndex + 1;
            string key = level.ToString() + " Level";
            PlayerPrefs.SetInt(key, 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void PauseTheGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
