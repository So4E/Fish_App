using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{

    TextMeshProUGUI moneyCount;
    int score = 0;
    bool addedFiveToCount;
    bool addedTenToCount;
    bool addedTwentyToCount;
    bool addedFiftyToCount;
    bool addedHundredToCount;
    // Start is called before the first frame update
    void Start()
    {
        moneyCount = GameObject.FindGameObjectWithTag("MoneyCount").GetComponent<TextMeshProUGUI>();
    }

    public void setMoneyCount(int scannedBillValue)
    {
        int amountToAdd = 0;
        switch (scannedBillValue)
        {
            case 5:
                if (!addedFiftyToCount)
                {
                    amountToAdd = 5;
                    addedFiftyToCount = true;
                }
                break;
            case 10:
                if (!addedTenToCount)
                {
                    amountToAdd = 10;
                    addedTenToCount = true;
                }
                break;
            case 20:
                if(!addedTwentyToCount)
                {
                    amountToAdd = 20;
                    addedTwentyToCount = true;
                }
                break;
            case 50:
                if(!addedFiftyToCount)
                {
                    amountToAdd = 50;
                    addedFiftyToCount = true;
                }
                break;
            case 100:
                if (!addedHundredToCount)
                {
                    amountToAdd = 100;
                    addedHundredToCount = true;
                }
                break;
        }
        this.score = this.score + amountToAdd;
        moneyCount.text = " MONEY COUNT " + this.score + " €";
    }
}
