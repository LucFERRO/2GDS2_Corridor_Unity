using UnityEngine;

public class LightDetector : MonoBehaviour
{
    bool movementDetected;
    bool MovementDetected
    {
        get { return movementDetected; }
        set
        {
            movementDetected = value;
            ToggleLights(movementDetected);
        }
    }
    public int maxTimer;
    public int detectionThreshold;
    [SerializeField]  float currentTimer;
    [SerializeField] Light[] linkedLights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTimer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementDetected)
        {
            currentTimer -= Time.deltaTime;
        }

        if (currentTimer <= 0)
        {
            Debug.Log("OFF");
            MovementDetected = false;
            currentTimer = maxTimer;

        }
    }

    void ToggleLights(bool movementDetected)
    {
        foreach (Light light in linkedLights)
        {
            light.enabled = movementDetected;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (other.GetComponent<Rigidbody>().linearVelocity.magnitude >= detectionThreshold)
        {
            Debug.Log("DETECTED");
            currentTimer = maxTimer;
            MovementDetected = true;
        }
    }
}
