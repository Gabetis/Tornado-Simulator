using UnityEngine;
using UnityEngine.UI;
public class SellButton : MonoBehaviour
{
    private Button sellButton;
    [SerializeField] private PlayerManager playerManager;
    private void Awake()
    {
        if(sellButton == null)
        {
            sellButton = GetComponent<Button>();
        }

        if(playerManager == null)
        {
            playerManager = FindFirstObjectByType<PlayerManager>();
        }
    }

    private void Start()
    {
        sellButton.onClick.AddListener(OnSellButtonClicked);
    }

    private void OnSellButtonClicked()
    {
        playerManager.Stats.AddGold(playerManager.Stats.currentSizeStore);
        playerManager.transform.localScale = Vector3.one;
        GameEvent.UpdateGoldText(playerManager.Stats.Gold);
        GameEvent.ResetFill();
        GameEvent.ResetSizeText();
    }
}
