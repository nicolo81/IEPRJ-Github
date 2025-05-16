using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MoveToBattle ()
    {
        SceneManager.LoadSceneAsync("TestLevel");
    }

    public void MoveToMinigame1 ()
    {
        SceneManager.LoadSceneAsync("Minigame1");
    }

    public void MoveToMenu ()
    {
        SceneManager.LoadSceneAsync("IdolMenu");
    }

    public void MoveToMinigame2 ()
    {
        SceneManager.LoadSceneAsync("Minigame2");
    }
}
