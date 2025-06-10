using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private HashSet<string> placedCubes = new HashSet<string>();

    public GameObject successMessage;
    public GameObject restartButton;

    public AudioSource audioSource;   // Shared audio source
    public AudioClip winClip;         // Specific win sound to play

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
        restartButton?.SetActive(true);

        if (audioSource && winClip)
        {
            audioSource.clip = winClip;
            audioSource.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
