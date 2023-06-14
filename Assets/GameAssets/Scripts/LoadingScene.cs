using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Image fader;
    public string sceneToLoad; 
    AsyncOperation loadingOperation;
    public TMP_Text PercentLoaded;

    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        PercentLoaded.text = Mathf.Round(progressValue * 100) + "%";
    }

}
