using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePicker : MonoBehaviour
{
    public enum HouseSelector
    {
        Shop,
        Apartment_1,
        Apartment_2,
        Apartment_3,
        Apartment_4,
        Apartment_5,
        Apartment_6,
        Apartment_7,
        Apartment_8,
        Apartment_9,
    }
    public HouseSelector HouseSelector_;
    public List<GameObject> Houses = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(HouseSelector_)
        {
            case HouseSelector.Shop:
            Houses[0].SetActive(true);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_1:
            Houses[0].SetActive(false);
            Houses[1].SetActive(true);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_2:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(true);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_3:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(true);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_4:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(true);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_5:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(true);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_6:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(true);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_7:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(true);
            Houses[8].SetActive(false);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_8:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(true);
            Houses[9].SetActive(false);
            break;
            case HouseSelector.Apartment_9:
            Houses[0].SetActive(false);
            Houses[1].SetActive(false);
            Houses[2].SetActive(false);
            Houses[3].SetActive(false);
            Houses[4].SetActive(false);
            Houses[5].SetActive(false);
            Houses[6].SetActive(false);
            Houses[7].SetActive(false);
            Houses[8].SetActive(false);
            Houses[9].SetActive(true);
            break;

        }
    }
}
