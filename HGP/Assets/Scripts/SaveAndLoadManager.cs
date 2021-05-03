using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveAndLoadManager : MonoBehaviour
{
    [SerializeField]
    private GameObject fadePanel;
    private Image fadeImage;
    private bool loading;
    private float fadeSpeed = 0.01f;
    private Color alpha;
    [SerializeField]
    private int waitTime = 4;
    [SerializeField]
    private Canvas mainMenuCanvas;
    void Awake()
    {
        fadeImage = fadePanel.GetComponent<Image>();
        alpha = fadeImage.color;
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        
        if (loading)
        {
            if (alpha.a < 1)
            {
                alpha.a += fadeSpeed;
            }
            else if (alpha.a >= 1)
            {
                alpha.a = 1;
                //StartCoroutine("LoadingTime");
                PixelCrushers.SaveSystem.LoadFromSlot(1);
            }
        }
        else
        {
            if (alpha.a > 0)
            {
                alpha.a -= fadeSpeed;
            }
            else if (alpha.a <= 0)
            {
                alpha.a = 0;
            }
        }
        fadeImage.color = alpha;
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
            mainMenuCanvas.gameObject.SetActive(true);
            var menu = mainMenuCanvas.transform.GetChild(1).GetComponent<MainMenuConroller>();
            menu.Return();
        }
    }

    //IEnumerator LoadingTime()
    //{
    //    yield return new WaitForSeconds(waitTime);

    //    loading = false;
    //}
}
