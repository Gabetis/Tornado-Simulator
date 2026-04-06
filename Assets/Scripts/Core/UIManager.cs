using UnityEngine;

public class UIManager : MonoBehaviour
{
    public SizeStoreBar sizeStoreBar;
    public SellButton sellButton;
    public GoldDisplay goldDisplay;
    public UpgradeButtonDisplay upgradeButtonDisplay;

    private void Awake()
    {
        if (sizeStoreBar == null)
        {
            sizeStoreBar = transform.Find("Size Store Bar").GetComponent<SizeStoreBar>(); 
        }
        if (sellButton == null)
        {
            sellButton = transform.Find("Sell Button").GetComponent<SellButton>();
        }
        if (goldDisplay == null)
        {
            goldDisplay = transform.Find("Gold Display").GetComponent<GoldDisplay>();
        }
        if (upgradeButtonDisplay == null)
        {
            upgradeButtonDisplay = transform.Find("Upgrade Button").GetComponent<UpgradeButtonDisplay>();
        }
    }
}
