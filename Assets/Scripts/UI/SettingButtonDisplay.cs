using UnityEngine;
using UnityEngine.UI;
public class SettingButtonDisplay : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Button settingButton;

    private void Awake()
    {
        if (settingPanel == null)
        {
            settingPanel = transform.parent.Find("Setting Panel").gameObject;
        }
        if (settingButton == null)
        {
            settingButton = GetComponentInChildren<Button>();
        }
    }

    private void Start()
    {
        settingButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    { 
        settingPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
