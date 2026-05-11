using UnityEngine;

public class PullSystem : MonoBehaviour
{
    private float GetDistanceVector(Vector3 playerPos, Vector3 objectPos)
    {
        return (objectPos - playerPos).magnitude;
    }

    private float GetDrag(ObjectSO objectData)
    {
        return 1 + 0.3f * objectData.objectSize;
    }

    private float GetSuctionForce(PlayerManager playerStats, ObjectData objectData)
    {
        Debug.Log(playerStats.Stats.Suction * Mathf.Pow(playerStats.Stats.currentSize, 1.5f) / Mathf.Pow(GetDistanceVector(playerStats.transform.position, objectData.transform.position), 1.2f));
        return playerStats.Stats.Suction * Mathf.Pow(playerStats.Stats.currentSize, 1.5f) / Mathf.Pow(GetDistanceVector(playerStats.transform.position, objectData.transform.position), 1.2f);
    }

    private float GetResistance(ObjectSO objectSO)
    {
        return objectSO.objectMass * GetDrag(objectSO);
    }

    public bool GetResultSuction(PlayerManager playerManager, ObjectData objectData ,ObjectSO objectSO)
    {
        if (GetSuctionForce(playerManager, objectData) >= GetResistance(objectSO))
        {
            Debug.Log("Suction Force: " + GetSuctionForce(playerManager, objectData) + " | Resistance: " + GetResistance(objectSO));
            return true;
        }
        Debug.Log("Suction Force: " + GetSuctionForce(playerManager, objectData) + " | Resistance: " + GetResistance(objectSO));
        return false;
    }

    // Acceptable SRP violation - too simple to justify a separate class
    public int GetEXP(ObjectSO objectData, PlayerStats playerStats)
    {
        return (int)(objectData.baseEXP * Mathf.Pow(GetResistance(objectData) / playerStats.PlayerPower(), 0.7f));
    }
}
