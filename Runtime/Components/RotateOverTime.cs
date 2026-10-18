using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
    }
}
