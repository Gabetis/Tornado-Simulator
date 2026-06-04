using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private int timeToRespawn = 1;
    private Dictionary<GameObject, (Vector3, Quaternion)> originalTransforms = new();

    private void Start()
    {
        foreach (Transform child in this.transform) 
        {
            GameObject obj = child.gameObject;
            originalTransforms[obj] = (obj.transform.position, obj.transform.rotation);
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        StartCoroutine(RespawnObject(obj, timeToRespawn));
    }

    private IEnumerator RespawnObject(GameObject obj, int delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        var (pos, rot) = originalTransforms[obj];
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
    }
}
