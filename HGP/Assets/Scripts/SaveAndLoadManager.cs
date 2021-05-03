using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveAndLoadManager : MonoBehaviour
{
    private Image fadeImage;
    private bool loading;
    private float fadeSpeed = 0.01f;
    private Color alpha;
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        
    }

    void SavingdaGame()
    {
        PixelCrushers.SaveSystem.SaveToSlot(1);
    }

    public void LoadingdaGame()
    {
        loading = true;
    }

    public void ImmidiateLoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    //IEnumerator LoadingTime()
    //{
    //    yield return new WaitForSeconds(waitTime);

    //    loading = false;
    //}
}
