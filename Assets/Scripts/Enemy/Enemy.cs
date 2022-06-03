using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _reward = 25;
    [SerializeField] private int _penalty = 25;

    private Bank _bank;

    private void Start() => _bank = FindObjectOfType<Bank>();

    public void Reward()
    {
        if (_bank is null) return;
        _bank.Deposit(_reward);
    }

    public void Steal()
    {
        if (_bank is null) return;
        _bank.Withdraw(_penalty);
    }
}
