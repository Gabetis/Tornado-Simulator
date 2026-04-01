using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; } 
    public GameObject Visual;
    public GameObject HitBox;
    public GameObject Movement;
    public PlayerStats Stats { get; private set; } = new PlayerStats();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        if (Visual == null)
        {
            Visual = transform.Find("Visual").gameObject;
        }

        if (HitBox == null)
        {
            HitBox = transform.Find("HitBox").gameObject;
        }

        if(Movement == null)
        {
            Movement = transform.Find("Movement").gameObject;
        }
    }
}
