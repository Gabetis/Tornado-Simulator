using UnityEngine;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeSO upgradeData;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private int maxSizeLevel = 0;
    [SerializeField] private int goldMultiplierLevel = 0;
    [SerializeField] private int moveSpeedLevel = 0;

    public void Upgrade(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.MaxSize:
                int maxSizeCost = upgradeData.GetMaxSizeCost(maxSizeLevel);
                if (playerManager.Stats.Gold >= maxSizeCost)
                {
                    playerManager.Stats.SpendGold(maxSizeCost);
                    maxSizeLevel++;

                    int value = upgradeData.GetMaxSizeValue(maxSizeLevel);
                    playerManager.Stats.SetMaxSize(value);

                    GameEvent.UpdateGoldText(playerManager.Stats.Gold);
                    GameEvent.UpdateMaxSizeText(playerManager.Stats.maxSize);
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
                if (playerManager.Stats.Gold >= moveSpeedCost)
                {
                    playerManager.Stats.SpendGold(moveSpeedCost);
                    moveSpeedLevel++;

                    float value = upgradeData.GetMoveSpeedValue(moveSpeedLevel);
                    playerManager.Stats.SetMoveSpeed(value);

                    GameEvent.UpdateGoldText(playerManager.Stats.Gold);
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
                if (playerManager.Stats.Gold >= goldMultiplierCost)
                {
                    playerManager.Stats.SpendGold(goldMultiplierCost);
                    goldMultiplierLevel++;

                    int value = Mathf.RoundToInt(upgradeData.GetGoldMultiplierValue(goldMultiplierLevel));
                    playerManager.Stats.SetGoldMultiplier(value);

                    GameEvent.UpdateGoldText(playerManager.Stats.Gold);
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
