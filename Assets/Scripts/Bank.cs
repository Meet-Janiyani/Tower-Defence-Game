using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance=150;
    [SerializeField] int currentBalnce = 0;
    [SerializeField] TMP_Text GoldText;
    public int CurrentBalnce { get => currentBalnce; }

    void Start()
    {
        currentBalnce = startingBalance;
        UpdateGold();
    }

    private void UpdateGold()
    {
        GoldText.text = "Gold:- " + currentBalnce.ToString();
    }

    public void Deposit(int amount)
    {
        currentBalnce += amount;
        UpdateGold();
    }

    public void Witdraw(int amount)
    {
        currentBalnce -= amount;
        UpdateGold();
    }    
}
