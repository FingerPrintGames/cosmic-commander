using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    Bank bank;

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void DisplayMoney()
    {

        moneyText.text = "$:" + bank.CurrentBalance.ToString("0000000");
    }
}
