using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "Scriptable Objects/ObjectSO")]
public class ObjectSO : ScriptableObject
{
    public string nameObeject;
    public int objectMass;
    public int objectSize;
    public int baseEXP = 2; 
}
