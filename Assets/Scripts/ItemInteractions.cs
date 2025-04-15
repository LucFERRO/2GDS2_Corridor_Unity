using TMPro;
using UnityEngine;

public class ItemInteractions : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    public bool isInRange;
    [SerializeField]
    float interactionRange = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnMouseOver()
    {
        isInRange = Vector3.Distance(transform.position, playerTransform.position) <= interactionRange;
    }    
    private void OnMouseExit()
    {
        isInRange = false;
    }
}
