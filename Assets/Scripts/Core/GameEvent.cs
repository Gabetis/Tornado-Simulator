using UnityEngine;
using System;
public static class GameEvent 
{
    public static Action<int> OnAddMoney;
    public static void AddMoney(int amount) => OnAddMoney?.Invoke(amount);
}
