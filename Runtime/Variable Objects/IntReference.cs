using System;
using UnityEngine;

namespace FoxTools.VariableObjects
{
    [Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        public int ConstantValue;
        public IntVariable Variable;

        public int Value
        {
            get { return UseConstant ? ConstantValue : (Variable != null ? Variable.value : 0); }
        }

        public void Set(int value)
        {
            if (UseConstant)
            {
                ConstantValue = value;
                return;
            }

            if (Variable == null)
            {
                Debug.LogError(
                    "Cannot set IntReference: variable mode is enabled, " +
                    "but no IntVariable is assigned.");
                return;
            }

            Variable.value = value;
        }

        public void Add(int value) => Set(Value + value);
        public void Subtract(int value) => Set(Value - value);
        public void Multiply(int value) => Set(Value * value);
        public void Divide(int value) => Set(Value / value);


    }
}