using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource AS;
    public GameObject Soundon;
    public GameObject Soundoff;
    public bool isSoundOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activatesound()
    {
        Soundoff.SetActive(false);
        Soundon.SetActive(true);
        isSoundOn = true;
        AS.volume = 1;
        AS.Play();
       
    }

    public void DeactivateSound()
    {
        Soundon.SetActive(false);
        Soundoff.SetActive(true);
        isSoundOn = false;
        AS.volume = 0;
        AS.Stop();
    }
}
