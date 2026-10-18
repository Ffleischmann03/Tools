using UnityEngine;

public class TemporaryActivation : MonoBehaviour
{
    public void Activate(float seconds)
    {
        gameObject.SetActive(true);
        Invoke("Deactivate", seconds);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
