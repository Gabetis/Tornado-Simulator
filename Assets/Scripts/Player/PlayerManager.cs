using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Visual;
    public GameObject HitBox;
    public GameObject Movement;
    public PlayerStats Stats { get; private set; } = new PlayerStats();

    private void OnEnable()
    {
        GameEvent.OnUpdateRealScale += UpdateRealScale;
    }
    private void Awake()
    {
        if (Visual == null)
        {
            Visual = transform.Find("Visual").gameObject;
        }

        if (HitBox == null)
        {
            HitBox = transform.Find("SuctionZone").gameObject;
        }

        if(Movement == null)
        {
            Movement = transform.Find("Movement").gameObject;
        }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameEvent.UpdateGoldText(Stats.Gold);
        GameEvent.UpdateSizeText(Stats.currentSizeStore, Stats.maxSize);
    }    

    public void UpdateRealScale()
    {
        transform.localScale = Vector3.one * (1 + Stats.sizeMultiplier * Stats.currentSize); 
    }
}
