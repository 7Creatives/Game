using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    public int Amount = 0;
    public TMP_Text CashAmount;

    // Start is called before the first frame update
    void Start()
    {
        CashAmount.text = "Ksh. " + Amount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // update the cash ui
        CashAmount.text = "Ksh. " + Amount.ToString();
    }

    public void IncreaseCash(int CashToIncrease)
    {
        Amount = Amount + CashToIncrease;
    }

    public void DecreaseCash(int CashToDecrease)
    {
        Amount = Amount - CashToDecrease;
        if(Amount <=0)
        {
            Amount = 0;
            return;
        }
    }
}
