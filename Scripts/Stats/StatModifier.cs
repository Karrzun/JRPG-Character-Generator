using System;


namespace SeanWelton.Stats
{
	
	public class StatModifier : IComparable<StatModifier>
	{
		public readonly float Value;
		public readonly StatModifierType Type;
		public readonly int Order;
		public readonly object Source;



		public StatModifier (float value, StatModifierType type, int order, object source)
		{
			Value = value;
			Type = type;
			Order = order;
			Source = source;
		}

		public StatModifier (float value, StatModifierType type) : this (value, type, (int)type, null) {}
		public StatModifier (float value, StatModifierType type, int order) : this (value, type, order, null) {}
		public StatModifier (float value, StatModifierType type, object source) : this (value, type, (int)type, source) {}



		public int CompareTo (StatModifier other)
		{
			if (other == null)
				return 1;

			return Order.CompareTo (other.Order);
		}
	}

}