using UnityEngine;

public class PullSystem : MonoBehaviour
{
    [SerializeField] private float coefficientA = 1.5f;
    [SerializeField] private float coefficientB = 0.7f;
    [SerializeField] private float coefficientEXP = 1f;

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
        return playerStats.Stats.Suction * Mathf.Pow(playerStats.Stats.currentSize, coefficientA) / Mathf.Pow(GetDistanceVector(playerStats.transform.position, objectData.transform.position), coefficientB);
    }

    private float GetResistance(ObjectSO objectSO)
    {
        return objectSO.objectMass * GetDrag(objectSO);
    }

    public bool GetResultSuction(PlayerManager playerManager, ObjectData objectData ,ObjectSO objectSO)
    {
        Debug.Log("Suction Force: " + GetSuctionForce(playerManager, objectData) + " | Resistance: " + GetResistance(objectSO));
        if (GetSuctionForce(playerManager, objectData) >= GetResistance(objectSO))
        {
            return true;
        }
        return false;
    }

    // Acceptable SRP violation - too simple to justify a separate class
    public float GetEXP(ObjectSO objectData, PlayerStats playerStats)
    {
        return objectData.baseEXP * Mathf.Pow(GetResistance(objectData) / playerStats.PlayerPower(), coefficientEXP);
    }
}
