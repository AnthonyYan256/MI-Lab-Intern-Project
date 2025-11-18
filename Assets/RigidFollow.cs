using UnityEngine;

public class RigidFollow : MonoBehaviour
{
    [Header("Sources")]
    public Transform targetBone; // Assign PoserAvatar's HIPS bone
    
    [Header("Settings")]
    public float turnSmoothness = 10f;
    public Vector3 rotationOffset; // Tweak if avatar faces wrong way (e.g. 0, 180, 0)

    void LateUpdate()
    {
        if (targetBone == null) return;

        // 1. POSITION: Snap to the target hips exactly
        transform.position = targetBone.position;

        // 2. ROTATION: only follow the "Forward" direction (Y-axis)
        // Project the hip's forward vector onto the flat ground plane
        Vector3 projectedForward = Vector3.ProjectOnPlane(targetBone.forward, Vector3.up).normalized;

        if (projectedForward != Vector3.zero)
        {
            // Create a rotation that looks in that flat direction
            Quaternion targetRotation = Quaternion.LookRotation(projectedForward, Vector3.up);
            
            // Apply offset (in case your model was imported backwards)
            targetRotation *= Quaternion.Euler(rotationOffset);

            // Smoothly rotate the rig to face that way
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSmoothness);
        }
    }
}