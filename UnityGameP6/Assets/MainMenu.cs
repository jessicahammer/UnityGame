using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("level1");

    }
    public void PlayGameHeavy()
    {
        SceneManager.LoadScene("level2");

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");

    }
    public void LoadBonus()
    {
        SceneManager.LoadScene("levelbonus");

    }

}
