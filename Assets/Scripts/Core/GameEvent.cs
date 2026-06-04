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
    public static Action<UpgradeType> OnUpdateUpgradeLevelUI;
    public static void UpdateUpgradeLevelUI(UpgradeType upgradeType) => OnUpdateUpgradeLevelUI?.Invoke(upgradeType);
    public static Action<int> OnUpdateMaxSizeText;
    public static void UpdateMaxSizeText(int maxSize) => OnUpdateMaxSizeText?.Invoke(maxSize);
    public static Action<UpgradeType> OnUpdateUpgradeCostUI;
    public static void UpdateUpgradeCostUI(UpgradeType type) => OnUpdateUpgradeCostUI?.Invoke(type);

    public static Action OnUpdateRealScale;
    public static void UpdateRealScale() => OnUpdateRealScale?.Invoke();

    public static Action OnUpdateMaxScale;
    public static void UpdateMaxScale() => OnUpdateMaxScale?.Invoke();

    public static Action<SoundEvent> OnSoundRequest;
    public static void RequestSound(SoundEvent sound) => OnSoundRequest?.Invoke(sound);
}

public enum SoundEvent
{
    Click,
    Sell,
    Upgrade,
    Suction,
    BackgroundMusic
}