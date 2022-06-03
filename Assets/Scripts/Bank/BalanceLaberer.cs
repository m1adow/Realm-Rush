using UnityEngine;
using TMPro;

public class BalanceLaberer : MonoBehaviour
{
    private Bank _bank;
    private TextMeshPro _balance;

    private void Awake()
    {
        _balance = GetComponent<TextMeshPro>();
        _bank = GetComponentInParent<Bank>();
    }

    private void OnEnable() => _bank.BalanceUpdated += OnBalanceUpdated;
   
    private void OnBalanceUpdated(int balance) => _balance.text = $"Balance: {balance}";
}
