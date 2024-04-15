namespace UM.SharedKernel.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Aggregate(default(int), HashCode.Combine);
        }

        public static bool operator ==(ValueObject x, ValueObject y)
        {
            if (x is null && y is null)
                return true;

            if (x is null || y is null)
                return false;

            return x.Equals(y);
        }

        public static bool operator !=(ValueObject x, ValueObject y)
        {
            return !(x == y);
        }
    }
}
