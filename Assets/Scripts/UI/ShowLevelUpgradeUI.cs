using UnityEngine;
using TMPro;
public class ShowLevelUpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private UpgradeSystem upgradeSystem;
    private void Awake()
    {
        if(text == null)
        {
            text = transform.Find("NumberLevelText").GetComponent<TextMeshProUGUI>(); 
        }
    }

    private void Start()
    {
        ShowUI(upgradeType);
    }

    private void OnEnable()
    {
        GameEvent.OnUpdateUpgradeLevelUI += ShowUI;
    }

    public void ShowUI(UpgradeType typeFromEvent)
    {
        if (upgradeType != typeFromEvent)
            return;
        text.text = upgradeSystem.GetLevel(typeFromEvent).ToString();
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateUpgradeLevelUI -= ShowUI;
    }
}
