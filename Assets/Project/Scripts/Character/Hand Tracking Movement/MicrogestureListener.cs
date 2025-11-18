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
            LogMicrogestureEvent($"{g}");
        });
    }

    public void LogMicrogestureEvent(string microgestureName)
    {
            var message = $"Microgesture event received: {microgestureName}";
            // SpatialLogger.Instance.LogInfo(message);
            Debug.Log(microgestureName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
