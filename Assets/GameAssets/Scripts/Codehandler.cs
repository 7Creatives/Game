using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Codehandler : MonoBehaviour
{
    public Loader loader_;
    public string sceneToLoad_;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        loader_.sceneToLoad = sceneToLoad_;
        loader_.Load();
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
