using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace SeanWelton.Stats
{
    [Serializable]
    public class Stat
    {
        public float BaseValue;
        protected float lastBaseValue = float.MinValue;
        protected bool isDirty = true;
        protected float value;
        public virtual float Value
        {
            get
            {
                if (isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    value = GetValue();
                    isDirty = false;
                }
                return value;
            }
        }

        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;



        public Stat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public Stat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        protected virtual float GetValue()
        {
            float finalValue = BaseValue;
            float percentAddSum = 0;
            statModifiers.Sort();

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];

                switch (mod.Type)
                {
                    case StatModifierType.Flat:
                        finalValue += mod.Value;
                        break;
                    case StatModifierType.PercentAdd:
                        percentAddSum += mod.Value;

                        if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModifierType.PercentAdd)
                        {
                            finalValue *= (1 + percentAddSum);
                            percentAddSum = 0;
                        }
                        break;
                    case StatModifierType.PercentMult:
                        finalValue *= (1 + mod.Value);
                        break;
                }
            }

            return finalValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveModifiersFromSource(object source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }

            return didRemove;
        }

    }

}