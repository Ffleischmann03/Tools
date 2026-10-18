using UnityEngine;

namespace FoxTools.VariableObjects
{
    [CreateAssetMenu(menuName = "Variable Objects/Int Variable", fileName = "New Int Variable")]
    public class IntVariable : ScriptableObject
    {
        public int value;
    }
}