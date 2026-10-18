using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupStartSettings : MonoBehaviour
{
    public bool interactable = false;
    public bool blocksRaycast = false;
    [Range(0f, 1f)] public float alpha = 0f;
    public CanvasGroup group;

    private void Start()
    {
        if(group == null) group = GetComponent<CanvasGroup>();

        if(group == null) return;

        group.interactable = interactable;
        group.blocksRaycasts = blocksRaycast;
        group.alpha = alpha;
    }

    private void OnValidate()
    {
        if (group == null) group = GetComponent<CanvasGroup>();
    }
}
