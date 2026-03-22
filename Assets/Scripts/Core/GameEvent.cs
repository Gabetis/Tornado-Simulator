using UnityEngine;
using System;
public static class GameEvent 
{
    public static Action OnUpdateFill;
    public static void UpdateFill() => OnUpdateFill?.Invoke();
    public static Action OnResetFill;
    public static void ResetFill() => OnResetFill?.Invoke();
    public static Action<int, int> OnUpdateSizeText;
    public static void UpdateSizeText(int currentSizeStore, int maxSize) => OnUpdateSizeText?.Invoke(currentSizeStore, maxSize);
    public static Action OnResetSizeText;
    public static void ResetSizeText() => OnResetSizeText?.Invoke();
    public static Action<int> OnUpdateGoldText;
    public static void UpdateGoldText(int goldAmount) => OnUpdateGoldText?.Invoke(goldAmount);
}
