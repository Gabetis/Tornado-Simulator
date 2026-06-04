using UnityEngine;
using TMPro;
public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void OnEnable()
    {
        GameEvent.OnUpdateGoldText += UpdateText;
    }

    private void Awake()
    {
        if (goldText == null)
        {
            goldText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    private void UpdateText(int goldAmount)
    {
        goldText.text = goldAmount.ToString();
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateGoldText -= UpdateText;
    }
}
