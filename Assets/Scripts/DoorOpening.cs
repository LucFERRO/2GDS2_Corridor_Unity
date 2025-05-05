using TMPro;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float doorRange = 2f;
    [SerializeField]
    float doorSpeed;
    [SerializeField]
    float snapAngle;
    [SerializeField]
    bool isOpening;
    [SerializeField]
    TMP_Text uiText;

    void Update()
    {
        HandleDoorMovement();
    }

    private void HandleDoorMovement()
    {
        float currentY = transform.localEulerAngles.y;
        float targetAngle = isOpening ? 90f : 0f;
        float newY = Mathf.LerpAngle(currentY, targetAngle, Time.deltaTime * doorSpeed);

        if (Mathf.Abs(Mathf.DeltaAngle(currentY, targetAngle)) < snapAngle)
        {
            newY = targetAngle;
        }

        Vector3 newAngle = new Vector3(transform.localEulerAngles.x, newY, transform.localEulerAngles.z);
        transform.localEulerAngles = newAngle;
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= doorRange)
        {
            uiText.enabled = true;
            if (Input.GetButtonDown("Interact") && Vector3.Distance(transform.position, playerTransform.position) <= doorRange)
            {
                isOpening = !isOpening;
            }
        } else
        {

            uiText.enabled = false;
        }
    }

    private void OnMouseExit()
    {

        uiText.enabled = false;
    }
}
