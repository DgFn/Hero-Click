using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Loading Scene")]
    int SceneID;
    int thisScene;
    [Header("All")]
    public Image loadingImg;

    public void LoadScene(int ID)
    {
        StartCoroutine(AsyncLoad(ID));
    }

    IEnumerator AsyncLoad(int ID)
    {
        SceneID = ID;
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            yield return null;
        }
    }   
    public void QuitGame()
    {
        Application.Quit();
    }

}
