using UnityEngine;
using UnityEngine.UI;

public class SizeStoreBar : MonoBehaviour
{
    [SerializeField] private Image sizeBarFill;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        if(playerManager == null)
        {

        }

        if(sizeBarFill == null)
        {
            sizeBarFill = transform.Find("BG/Fill").GetComponent<Image>();
        }

        GameEvent.OnUpdateFill += GetCurrentFill;
    }

    private void GetCurrentFill()
    {
        float fillAmount = (float)playerManager.Stats.currentSizeStore / (float)playerManager.Stats.maxSize;
        sizeBarFill.fillAmount = fillAmount;
    }

    private void OnDisable()
    {
        GameEvent.OnUpdateFill -= GetCurrentFill;
    }
}
