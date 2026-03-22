using UnityEngine;
using TMPro;

public class BarValueText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentSizeStoreText;
    [SerializeField] private TextMeshProUGUI MaxSizeText;
    private void OnEnable()
    {
        GameEvent.OnUpdateSizeText += UpdateSizeText;
        GameEvent.OnResetSizeText += ResetSizeText;
    }

    private void Awake()
    {
        if (currentSizeStoreText == null)
        {
            currentSizeStoreText = transform.Find("CurrentSizeStore").GetComponent<TextMeshProUGUI>();
        }

        if (MaxSizeText == null)
        {
            MaxSizeText = transform.Find("MaxSize").GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateSizeText(int currentSizeStore, int maxSize)
    {
        currentSizeStoreText.text = currentSizeStore.ToString();
        MaxSizeText.text = maxSize.ToString();
    }

    public void ResetSizeText()
    {
        currentSizeStoreText.text = "0";
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateSizeText -= UpdateSizeText;
        GameEvent.OnResetSizeText -= ResetSizeText;
    }
}
