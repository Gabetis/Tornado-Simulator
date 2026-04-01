using UnityEngine;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeSO upgradeData;

    [SerializeField] private int maxSizeLevel = 0;
    [SerializeField] private int goldMultiplierLevel = 0;
    [SerializeField] private int moveSpeedLevel = 0;

    public void Upgrade(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSize:
                int maxSizeCost = upgradeData.GetMaxSizeCost(maxSizeLevel);
                if (PlayerManager.Instance.Stats.Gold >= maxSizeCost)
                {
                    PlayerManager.Instance.Stats.SpendGold(maxSizeCost);
                    maxSizeLevel++;

                    int value = upgradeData.GetMaxSizeValue(maxSizeLevel);
                    PlayerManager.Instance.Stats.SetMaxSize(value);

                    GameEvent.UpdateGoldText(PlayerManager.Instance.Stats.Gold);
                    GameEvent.UpdateMaxSizeText(PlayerManager.Instance.Stats.maxSize);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                }
                else
                {
                    Debug.Log("Not enough gold to upgrade Max Size.");
                }
                break;
            case UpgradeType.MoveSpeed:
                int moveSpeedCost = upgradeData.GetMoveSpeedCost(moveSpeedLevel);
                if (PlayerManager.Instance.Stats.Gold >= moveSpeedCost)
                {
                    PlayerManager.Instance.Stats.SpendGold(moveSpeedCost);
                    moveSpeedLevel++;

                    float value = upgradeData.GetMoveSpeedValue(moveSpeedLevel);
                    PlayerManager.Instance.Stats.SetMoveSpeed(value);

                    GameEvent.UpdateGoldText(PlayerManager.Instance.Stats.Gold);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                    Debug.Log("Move Speed upgraded to level " + moveSpeedLevel + " with value " + value);
                }
                else
                {
                    Debug.Log("Not enough gold to upgrade Move Speed.");
                }
                GameEvent.UpdateUpgradeLevelUI(upgradeType);
                break;
            case UpgradeType.GoldMultiplier:
                int goldMultiplierCost = upgradeData.GetGoldMultiplierCost(goldMultiplierLevel);
                if (    PlayerManager.Instance.Stats.Gold >= goldMultiplierCost)
                {
                    PlayerManager.Instance.Stats.SpendGold(goldMultiplierCost);
                    goldMultiplierLevel++;

                    int value = Mathf.RoundToInt(upgradeData.GetGoldMultiplierValue(goldMultiplierLevel));
                        PlayerManager.Instance.Stats.SetGoldMultiplier(value);

                    GameEvent.UpdateGoldText(PlayerManager.Instance.Stats.Gold);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                    Debug.Log("Gold Multiplier upgraded to level " + goldMultiplierLevel + " with value " + value);
                }
                else
                {
                    Debug.Log("Not enough gold to upgrade Gold Multiplier.");
                }
                break;
        }
    }

    public int GetLevel(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSize:
                return maxSizeLevel;
            case UpgradeType.GoldMultiplier:
                return goldMultiplierLevel;
            case UpgradeType.MoveSpeed:
                return moveSpeedLevel;
            default:
                Debug.Log("Missing UpgradeType or something");
                return 0;
        }
    }

    public int GetUpgradeCost(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSize:
                return upgradeData.GetMaxSizeCost(maxSizeLevel);
            case UpgradeType.GoldMultiplier:
                return upgradeData.GetGoldMultiplierCost(goldMultiplierLevel);
            case UpgradeType.MoveSpeed:
                return upgradeData.GetMoveSpeedCost(moveSpeedLevel);
            default:
                Debug.Log("Missing UpgradeType or something");
                return 0;
        }
    }
}
