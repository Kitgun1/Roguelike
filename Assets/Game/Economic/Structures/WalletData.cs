using NaughtyAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public struct WalletData
{
    public string Prefix;
    [MinValue(0)] public int BalanceValue;

    [Header("Links")] public List<TMP_Text> Balances;
}