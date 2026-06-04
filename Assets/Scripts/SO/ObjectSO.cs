using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSO", menuName = "Scriptable Objects/ObjectSO")]
public class ObjectSO : ScriptableObject
{
    public string nameObeject;
    public float objectMass;
    public float objectSize;
    public int baseEXP = 2; 
}
