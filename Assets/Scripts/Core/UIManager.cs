using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIManager Instance { get; private set; }
    public SizeStoreBar sizeStoreBar;
    public SellButton sellButton;
    public GoldDisplay goldDisplay;
    public UpgradeButtonDisplay upgradeButtonDisplay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
