using UnityEngine;

public static class CanvasGroupUtility
{
    public static void SetActive(CanvasGroup group, bool active, bool IgnoreParentOverride = false)
    {
        group.alpha = active ? 1f : 0f;
        group.interactable = active;
        group.blocksRaycasts = active;
        group.ignoreParentGroups = IgnoreParentOverride;
    }

    public static void SetActive(CanvasGroup group, float alpha, bool interactable, bool blocksRaycasts, bool ignoreParentGroups = false)
    {
        group.alpha = alpha;
        group.interactable = interactable;
        group.blocksRaycasts = blocksRaycasts;
        group.ignoreParentGroups = ignoreParentGroups;
    }
}
