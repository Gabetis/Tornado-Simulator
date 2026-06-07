using UnityEngine;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button button; 
    [SerializeField] private UpgradeSystem upgradeSystem;
    [SerializeField] private UpgradeType upgradeType;


    private void Awake()
    {
        if(button == null)
        {
            button = GetComponentInChildren<Button>();
        }
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        upgradeSystem.Upgrade(upgradeType);
        GameEvent.OnSoundRequest(SoundEvent.Upgrade);
    }
}
