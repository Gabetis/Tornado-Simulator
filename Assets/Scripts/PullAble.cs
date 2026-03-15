using UnityEngine;

public class PullAble : MonoBehaviour
{
    public void PullTowards(Vector3 Player, int Suction)
    {
        transform.position = Vector3.MoveTowards(transform.position, Player, Suction * Time.deltaTime);
    }    
}
