using UnityEngine;
using TMPro;

public class ShowUpgradeCostUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private UpgradeSystem upgradeSystem;
    [SerializeField] private UpgradeType upgradeType;

    private void OnEnable()
    {
        GameEvent.OnUpdateUpgradeCostUI += UpdateUpgradeCostText;
    }
    private void Awake()
    {
        if (upgradeCostText == null)
        {
            upgradeCostText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        UpdateUpgradeCostText(upgradeType);
    }

    public void UpdateUpgradeCostText(UpgradeType type)
    {
        if(type != upgradeType) 
            return;
        upgradeCostText.text = upgradeSystem.GetUpgradeCost(upgradeType).ToString();
    }
    private void OnDisable()
    {
        GameEvent.OnUpdateUpgradeCostUI -= UpdateUpgradeCostText;
    }
}
