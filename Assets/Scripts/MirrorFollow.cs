using UnityEngine;

public class MirrorFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    void Update()
    {
        //Vector3 updatedZVector = transform.position;
        //updatedZVector.z = playerTransform.position.z;
        //transform.position = updatedZVector;
        //Vector3 cameraAngle = transform.eulerAngles;
        float clampedX = Mathf.Clamp(transform.eulerAngles.x, -112, -67);
        //cameraAngle.x = clampedX;
        transform.rotation = Quaternion.Euler(new Vector3(clampedX, -90, 90));
    }
}
