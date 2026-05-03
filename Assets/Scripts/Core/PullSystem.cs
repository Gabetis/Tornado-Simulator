using UnityEngine;

public class PullSystem : MonoBehaviour
{
    private float GetDistanceVector(Vector3 playerPos, Vector3 objectPos)
    {
        Debug.Log("Distance: " + (objectPos - playerPos).magnitude);
        return (objectPos - playerPos).magnitude;
    }

    private float GetDrag(ObjectSO objectData)
    {
        Debug.Log("Dtag: " + (1 + 0.3f * objectData.objectSize));
        return 1 + 0.3f * objectData.objectSize;
    }

    private float GetSuctionForce(PlayerManager playerStats)
    {
        return playerStats.Stats.Suction * Mathf.Pow(playerStats.Stats.currentSize, 1.5f) / Mathf.Pow(GetDistanceVector(playerStats.transform.position, transform.position), 1.2f);
    }

    private float GetResistance(ObjectSO objectData)
    {
        return objectData.objectMass * objectData.objectSize * GetDrag(objectData);
    }

    public bool ResultSuction(PlayerManager playerManager, ObjectSO objectData)
    {
        if (GetSuctionForce(playerManager) >= GetResistance(objectData))
            return true;
        return false;
    }
}
