using UnityEngine;
using UnityEngine.UI;

public class SizeStoreBar : MonoBehaviour
{
    [SerializeField] private Image sizeBarFill;
    [SerializeField] private PlayerManager playerManager;

    private void OnEnable()
    {
        GameEvent.OnUpdateFill += GetCurrentFill;
        GameEvent.OnResetFill += ResetFill;
    }

    private void Start()
    {
        if(sizeBarFill == null)
        {
            sizeBarFill = transform.Find("BG/Fill").GetComponent<Image>();
        }
    }

    private void GetCurrentFill()
    {
        float fillAmount = (float)playerManager.Stats.currentSizeStore / (float)playerManager.Stats.maxSize;
        sizeBarFill.fillAmount = fillAmount;
    }

    public void ResetFill()
    {
        sizeBarFill.fillAmount = 0f;
        playerManager.Stats.ResetCurrentSizeStore();
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateFill -= GetCurrentFill;
    }
}
