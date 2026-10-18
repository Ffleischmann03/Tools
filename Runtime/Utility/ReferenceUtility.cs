using UnityEngine;

public static class ReferenceUtility
{
    public static T Ensure<T>(T reference, Object context = null)
        where T : MonoBehaviour
    {
        if (reference == null)
            reference = Object.FindFirstObjectByType<T>();

        if (reference == null)
        {
            Debug.LogError(
                $"{typeof(T).Name} could not find a reference.",
                context
            );
        }

        return reference;
    }
}

