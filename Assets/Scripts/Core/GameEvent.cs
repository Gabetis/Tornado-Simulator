using UnityEngine;
using System;
public static class GameEvent 
{
    public static Action OnUpdateFill;
    public static void UpdateFill() => OnUpdateFill?.Invoke();
    public static Action<int, int> OnUpdateSizeText;
    public static void UpdateSizeText(int currentSizeStore, int maxSize) => OnUpdateSizeText?.Invoke(currentSizeStore, maxSize);
}
