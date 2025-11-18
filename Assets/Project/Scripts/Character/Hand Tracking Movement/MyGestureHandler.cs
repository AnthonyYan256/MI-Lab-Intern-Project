using UnityEngine;
// This namespace is required to access OVRHand and MicrogestureType
using Oculus.Interaction.Input; 

[RequireComponent(typeof(OVRMicrogestureEventSource))]
public class MyGestureHandler : MonoBehaviour
{
    private OVRMicrogestureEventSource _eventSource;

    void Start()
    {
        // Get the event source component that Unity added
        _eventSource = GetComponent<OVRMicrogestureEventSource>();

        // Subscribe our custom function to the event
        _eventSource.GestureRecognizedEvent.AddListener(OnGestureRecognized);

        Debug.Log("Gesture Handler is set up and listening.");
    }

    // This function will be called every time a gesture is detected
    private void OnGestureRecognized(OVRHand.MicrogestureType gesture)
    {
        // Use a switch statement to handle the different gestures
        switch (gesture)
        {
            case OVRHand.MicrogestureType.SwipeLeft:
                Debug.Log("GESTURE: Swipe Left");
                // Add your "turn left" code here
                break;

            case OVRHand.MicrogestureType.SwipeRight:
                Debug.Log("GESTURE: Swipe Right");
                // Add your "turn right" code here
                break;

            case OVRHand.MicrogestureType.ThumbTap:
                Debug.Log("GESTURE: Thumb Tap");
                // Add your "teleport" or "select" code here
                break;

            case OVRHand.MicrogestureType.SwipeForward:
                Debug.Log("GESTURE: Swipe Forward");
                // Add your "move forward" code here
                break;

            case OVRHand.MicrogestureType.SwipeBackward:
                Debug.Log("GESTURE: Swipe Backward");
                // Add your "move backward" code here
                break;
        }

    }

    // It's good practice to clean up listeners when the object is destroyed
    void OnDestroy()
    {
        if (_eventSource != null)
        {
            _eventSource.GestureRecognizedEvent.RemoveListener(OnGestureRecognized);
        }
    }
}