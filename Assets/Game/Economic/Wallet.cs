using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour, IWallet
{
    private WalletData _wallet;

    public event UnityAction<int> OnWalletEmpty;

    public int GetBalance() => _wallet.BalanceValue;

    public void SetBalance(int value)
    {
        _wallet.BalanceValue = value;
        DisplayBalance();

        if (value != 0) return;

        OnWalletEmpty?.Invoke(value);
    }

    public void BalanceTransfer(int value)
    {
        if (0 < _wallet.BalanceValue + value)
        {
            _wallet.BalanceValue += value;
        }
        else
        {
            OnWalletEmpty?.Invoke(_wallet.BalanceValue);
            _wallet.BalanceValue = 0;
        }
        DisplayBalance();
    }

    public void DisplayBalance()
    {
        foreach (var text in _wallet.Balances)
        {
            text.text = $"{_wallet.BalanceValue} {_wallet.Prefix}";
        }
    }
}