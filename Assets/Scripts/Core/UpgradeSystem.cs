using UnityEngine;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeSO upgradeData;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private int maxSizeLevel = 0;
    [SerializeField] private int goldMultiplierLevel = 0;
    [SerializeField] private int moveSpeedLevel = 0;

    private void Start()
    {
        maxSizeLevel = PlayerPrefs.GetInt("MaxSizeLevel", 0);
        goldMultiplierLevel = PlayerPrefs.GetInt("GoldMultiplierLevel", 0);
        moveSpeedLevel = PlayerPrefs.GetInt("MoveSpeedLevel", 0);
        // Apply saved upgrades
        playerManager.Stats.SetMaxSize(upgradeData.GetMaxSizeValue(maxSizeLevel));
        playerManager.Stats.SetGoldMultiplier(upgradeData.GetGoldMultiplierValue(goldMultiplierLevel));
        playerManager.Stats.SetMoveSpeed(upgradeData.GetMoveSpeedValue(moveSpeedLevel));
        GameEvent.UpdateUpgradeLevelUI(UpgradeType.MaxSize);
        GameEvent.UpdateUpgradeLevelUI(UpgradeType.GoldMultiplier);
        GameEvent.UpdateUpgradeLevelUI(UpgradeType.MoveSpeed);
    }

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

                    GameEvent.UpdateGoldText((int)playerManager.Stats.Gold);
                    GameEvent.UpdateMaxSizeText(playerManager.Stats.maxSize);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                    GameEvent.UpdateMaxScale();
                    GameEvent.UpdateFill();
                    PlayerPrefs.SetInt("MaxSizeLevel", maxSizeLevel);
                    PlayerPrefs.SetInt("MaxSizeCost", maxSizeCost);
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

                    GameEvent.UpdateGoldText((int)playerManager.Stats.Gold);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                    Debug.Log("Move Speed upgraded to level " + moveSpeedLevel + " with value " + value);
                    PlayerPrefs.SetInt("MoveSpeedLevel", moveSpeedLevel);
                    PlayerPrefs.SetInt("MoveSpeedCost", moveSpeedCost);
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

                    float value = upgradeData.GetGoldMultiplierValue(goldMultiplierLevel);
                    playerManager.Stats.SetGoldMultiplier(value);

                    GameEvent.UpdateGoldText((int)playerManager.Stats.Gold);
                    GameEvent.UpdateUpgradeLevelUI(upgradeType);
                    GameEvent.UpdateUpgradeCostUI(upgradeType);
                    Debug.Log("Gold Multiplier upgraded to level " + goldMultiplierLevel + " with value " + value);
                    PlayerPrefs.SetInt("GoldMultiplierLevel", goldMultiplierLevel);
                    PlayerPrefs.SetInt("GoldltiplierCost", goldMultiplierCost);
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
