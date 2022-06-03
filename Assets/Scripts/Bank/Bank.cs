using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startingBalance = 150;

    private int _currentBalance;

    public int CurrentBalance { get { return _currentBalance; } }

    public event UnityAction<int> BalanceUpdated;

    private void Awake()
    {
        _currentBalance = _startingBalance;
        BalanceUpdated?.Invoke(_currentBalance);
    } 

    public void Deposit(int amount)
    {
        _currentBalance += Mathf.Abs(amount);
        BalanceUpdated?.Invoke(_currentBalance);
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= Mathf.Abs(amount);
        BalanceUpdated?.Invoke(_currentBalance);

        if (_currentBalance < 0)
            ReloadScene();

    }

    private void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
