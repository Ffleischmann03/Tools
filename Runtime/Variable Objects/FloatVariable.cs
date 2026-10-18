using UnityEngine;

namespace FoxTools.VariableObjects
{
    [CreateAssetMenu(menuName = "Variable Objects/Float Variable", fileName = "New Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        public float value;
    }
}