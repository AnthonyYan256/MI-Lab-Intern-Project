using UnityEngine;

[RequireComponent(typeof(OVRMicrogestureEventSource))]

public class MicrogestureListener : MonoBehaviour
{
    private OVRMicrogestureEventSource ovrMicrogestureEventSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ovrMicrogestureEventSource = GetComponent<OVRMicrogestureEventSource>();
        ovrMicrogestureEventSource.GestureRecognizedEvent.AddListener(g =>
        {
            var message = $"Microgesture event received: {g}";
            // SpatialLogger.Instance.LogInfo(message);
            Debug.Log(g);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
