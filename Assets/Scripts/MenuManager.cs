using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject InGame, EndGame;
    public static MenuManager ins;

    private void Awake()
    {
        ins = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GameOver()
    {
        InGame.SetActive(false);
        EndGame.SetActive(true);
    }
}
