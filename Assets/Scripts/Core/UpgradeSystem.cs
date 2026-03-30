using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private UpgradeData upgradeData;
    [SerializeField] private PlayerManager playerManager;

    [SerializeField] private int maxSizeLevel = 0;
    [SerializeField] private int goldMultiplierLevel = 0;
    [SerializeField] private int moveSpeedLevel = 0;

    public void UpgradeMaxSize()
    {
        int cost = upgradeData.GetMaxSizeCost(maxSizeLevel);
        if (playerManager.Stats.Gold >= cost)
        {
            playerManager.Stats.SpendGold(cost);
            maxSizeLevel++;

            int value = upgradeData.GetMaxSizeValue(maxSizeLevel);
            playerManager.Stats.SetMaxSize(value);

            GameEvent.UpdateGoldText(playerManager.Stats.Gold);
            //GameEvent.UpdateUpgradeUI();
            Debug.Log($"Max Size upgraded to level {maxSizeLevel}. New Max Size: {value}");
            Debug.Log("Level" + maxSizeLevel);
        }
        else
        {
            Debug.Log("Not enough gold to upgrade Max Size.");
        }
    }
}
