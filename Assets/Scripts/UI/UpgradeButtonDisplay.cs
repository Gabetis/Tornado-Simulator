using UnityEngine;
using UnityEngine.UI;
public class UpgradeButtonDisplay : MonoBehaviour
{
    [SerializeField] private GameObject UpgradePanel;
    [SerializeField] private Button upgradeButton;

    private void Awake()
    {
        if (UpgradePanel == null)
        {
            UpgradePanel = transform.parent.Find("UpgradePanel").gameObject;
        }
        if (upgradeButton == null)
        {
            upgradeButton = GetComponentInChildren<Button>();
        }
    }

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    { 
        UpgradePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
