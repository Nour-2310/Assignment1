using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private HashSet<string> placedCubes = new HashSet<string>();
    public GameObject successMessage;
    public AudioSource winSound;
    public GameObject restartButton;

    void Awake()
    {
        Instance = this;
    }

    public void MarkCubePlaced(string color)
    {
        if (!placedCubes.Contains(color))
        {
            placedCubes.Add(color);
            if (placedCubes.Count == 3)
            {
                OnPuzzleCompleted();
            }
        }
    }

    void OnPuzzleCompleted()
    {
        successMessage?.SetActive(true);
        winSound?.Play();
        restartButton?.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
