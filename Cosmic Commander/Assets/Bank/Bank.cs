using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 3000;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    MainGameUI moneyDisplay;

    void Awake()
    {
        currentBalance = startingBalance;
        moneyDisplay = FindObjectOfType<MainGameUI>();
        moneyDisplay.DisplayMoney();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        moneyDisplay.DisplayMoney();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if (currentBalance < 0)
        {
            currentBalance = 0;
        }
        moneyDisplay.DisplayMoney();
    }
}
