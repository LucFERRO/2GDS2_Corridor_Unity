using UnityEngine;

public class UiHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    ItemInteractions[] itemInteractions;

    // Update is called once per frame
    void Update()
    {
        foreach (ItemInteractions item in itemInteractions)
        {
            if (item.isInRange)
            {
            }
        }
    }
}
