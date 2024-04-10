namespace UM.SharedKernel.Abstractions
{
    public abstract class ValueObjectBase : IEquatable<ValueObjectBase>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObjectBase)obj;

            return ValuesAreEqual(other);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Aggregate(default(int), HashCode.Combine);
        }

        public bool Equals(ValueObjectBase? other)
        {
            return other != null && ValuesAreEqual(other);
        }

        private bool ValuesAreEqual(ValueObjectBase other)
        {
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public static bool operator ==(ValueObjectBase obj1, ValueObjectBase obj2)
        {
            return ValuesAreEqual(obj1, obj2);
        }

        public static bool operator !=(ValueObjectBase obj1, ValueObjectBase obj2)
        {
            return !ValuesAreEqual(obj1, obj2);
        }

        private static bool ValuesAreEqual(ValueObjectBase obj1, ValueObjectBase obj2)
        {
            return obj1.GetEqualityComponents().SequenceEqual(obj2.GetEqualityComponents());
        }
    }
}
