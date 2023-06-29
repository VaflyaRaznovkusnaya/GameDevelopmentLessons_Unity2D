using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Пока!");
    }
    public void Continue()
    {
        GameManager.CanPlayerMove = true;
        GameManager.IsCrawlDoorOpen = false;
        GameManager.isInvisn = false;
        SceneManager.LoadScene("Level_1");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
