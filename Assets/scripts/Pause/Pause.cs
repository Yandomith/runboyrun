using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject Pause_menu;

   public void PauseButton()
   {
        Pause_menu.SetActive(true);
        Time.timeScale= 0f;

   } 
   public void Resume()
   {
        Pause_menu.SetActive(false);
        Time.timeScale= 1f;
   }

   public void Menu()
   {
        SceneManager.LoadScene(0);
        Time.timeScale= 1f;
   }
}
