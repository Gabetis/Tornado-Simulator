using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Visual;
    public GameObject HitBox;
    public GameObject Movement;
    public PlayerStats Stats { get; private set; } = new PlayerStats();
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
