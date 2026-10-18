using System;
using UnityEngine;

namespace FoxTools.VariableObjects
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public float Value
        {
            get { return UseConstant ? ConstantValue : (Variable != null ? Variable.value : 0f); }
        }

        public void Set(float value)
        {
            if (UseConstant)
            {
                ConstantValue = value;
                return;
            }

            if (Variable == null)
            {
                Debug.LogError(
                    "Cannot set FloatReference: variable mode is enabled, " +
                    "but no FloatVariable is assigned.");
                return;
            }

            Variable.value = value;
        }

        public void Add(float value) => Set(Value + value);
        public void Subtract(float value) => Set(Value - value);
        public void Multiply(float value) => Set(Value * value);
        public void Divide(float value) => Set(Value / value);

        
    }
}