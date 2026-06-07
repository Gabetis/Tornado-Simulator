using UnityEngine;
using UnityEngine.UI;
public class UpgradeButtonDisplay : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Button upgradeButton;

    private void Awake()
    {
        if (upgradePanel == null)
        {
            upgradePanel = transform.parent.Find("Upgrade Panel").gameObject;
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
        upgradePanel.SetActive(true);
        this.gameObject.SetActive(false);
        GameEvent.OnSoundRequest(SoundEvent.Click);
    }
}
