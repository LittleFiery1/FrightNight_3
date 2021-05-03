using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

//Controls the main menu. I think someone else made this, don't remember, maybe not.

public class MainMenuConroller : MonoBehaviour
{
    public GameObject CreditsMenuUI;
    public GameObject MainMenuUI;
    //public DatabaseManager letMeSpeakToYourManager;

    /// <summary>
    /// Sets credits panel to active and Main Menu panel inactive
    /// </summary>
    public void Awake()
    {
        //Turns off credits and turns on the menu.
        if (!ReloadMenu.Reloaded)
        {
            CreditsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }
        else
        {
            CreditsMenuUI.SetActive(true);
            MainMenuUI.SetActive(false);
        }
    }

    public void PlayGame ()
    {
        //Loads the next scene
        ReloadMenu.Reloaded = true;
        DialogueManager.ResetDatabase();
        PixelCrushers.SaveSystem.ClearSavedGameData();
        this.gameObject.transform.parent.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void Credits()
    {
        //Turns off the menu to show the credits
        MainMenuUI.SetActive(false);
        CreditsMenuUI.SetActive(true);
    }

    public void Quit()
    {
        //Closes the application
        Application.Quit();
        //Debug.Log("Application is closed");
    }

    public void Return()
    {
        //Turns off credits to return to the main menu.
        CreditsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}

