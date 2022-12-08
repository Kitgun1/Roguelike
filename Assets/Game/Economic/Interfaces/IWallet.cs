using UnityEngine.Events;

public interface IWallet
{
    public event UnityAction<int> OnWalletEmpty;
    public int GetBalance();
    public void SetBalance(int value);
    public void BalanceTransfer(int value);
    public void DisplayBalance();
}