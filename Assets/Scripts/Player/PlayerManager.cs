using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject Movement;
    public GameObject VFX;
    public GameObject Tornado;
    public PlayerStats Stats { get; private set; } = new PlayerStats();

    private void Awake()
    {
        if (HitBox == null)
        {
            HitBox = transform.Find("SuctionZone").gameObject;
        }

        if (Movement == null)
        {
            Movement = transform.Find("Movement").gameObject;
        }

        if (VFX == null)
        {
            VFX = transform.Find("VFX").gameObject;
        }

        if (Tornado == null)
        {
            Tornado = VFX.transform .Find("Tornado").gameObject;
        }

        Stats.LoadFromPrefs();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameEvent.UpdateGoldText((int)Stats.Gold);
        GameEvent.UpdateSizeText((int)Stats.currentSizeStore, Stats.maxSize);
    }
}
