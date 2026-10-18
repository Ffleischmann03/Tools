using UnityEngine;

namespace FoxTools.Components
{
    public class GizmoIcon : MonoBehaviour
    {
        public string iconName = "crosshair";
        public Color tint = Color.white;
        public bool allowScaling = false;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, iconName, allowScaling, tint);
    }

#endif
    }
}