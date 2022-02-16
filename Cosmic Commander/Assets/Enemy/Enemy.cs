using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int moneyReward = 500;
    [SerializeField] int moneyPenalty = 1000;

    Bank bank;

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardMoney()
    {
        if (bank == null) { return; }
        bank.Deposit(moneyReward);
    }

    public void StealMoney()
    {
        if (bank == null) { return; }
        bank.Withdraw(moneyPenalty);
    }
}
