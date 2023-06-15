using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject Menu;
    public GameObject loadingScreen;
    public string sceneToLoad;
    public CanvasGroup canvasGroup;
    AsyncOperation loadingOperation;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Load()
    {
        StartCoroutine(StartLoad());
    }
    IEnumerator StartLoad()
    {
        if(Menu == null)
        {

        }
        else
        {
            Menu.SetActive(false);
        }
        
        yield return new WaitForSeconds(1);

        loadingScreen.SetActive(true);
        yield return StartCoroutine(FadeLoadingScreen(1, 1));
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!loadingOperation.isDone)
        {
            yield return null;
        }
        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        loadingScreen.SetActive(false);
    }
    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;
    }
}
