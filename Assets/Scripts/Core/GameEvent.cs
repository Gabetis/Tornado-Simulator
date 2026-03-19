using UnityEngine;
using System;
public static class GameEvent 
{
    public static Action OnUpdateFill;
    public static void UpdateFill() => OnUpdateFill?.Invoke();
}
