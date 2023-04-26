using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public GameObject building;
    public int CashToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float UnlockRate = 10;
    public float UnlockAmount;
    public bool canUnlock;
    // Start is called before the first frame update
    void Start()
    {
        cashToUnlock.text = "Ksh. " + CashToUnlock.ToString();
        UnlockImage.fillAmount = UnlockAmount;
    }

    // Update is called once per frame
    void Update()
    {
        UnlockImage.fillAmount = Mathf.Lerp(UnlockImage.fillAmount,UnlockAmount,UnlockRate*Time.deltaTime)/100f;
        if(Input.GetKeyDown(KeyCode.M))
        {
            UnlockBuilding();
        }
    }

    public void UnlockBuilding()
    {
        UnlockAmount += 10;
    }
}
