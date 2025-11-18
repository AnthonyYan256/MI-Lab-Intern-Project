using UnityEngine;

public class CopyFingers : MonoBehaviour
{
    public Transform sourceHand; // The PoserAvatar's Hand
    public Transform targetHand; // The RigAvatar's Hand

    void LateUpdate()
    {
        if (sourceHand == null || targetHand == null) return;

        // Loop through all children (fingers) recursively
        CopyRotationRecursive(sourceHand, targetHand);
    }

    void CopyRotationRecursive(Transform source, Transform target)
    {
        // Copy the local rotation (the curl)
        target.localRotation = source.localRotation;

        // Iterate through children (finger joints)
        for (int i = 0; i < source.childCount; i++)
        {
            if (i < target.childCount)
            {
                CopyRotationRecursive(source.GetChild(i), target.GetChild(i));
            }
        }
    }
}