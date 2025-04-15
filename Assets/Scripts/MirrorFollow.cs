using UnityEngine;

public class MirrorFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    void Update()
    {
        Vector3 updatedZVector = transform.position;
        updatedZVector.z = playerTransform.position.z;
        transform.position = updatedZVector;
    }
}
