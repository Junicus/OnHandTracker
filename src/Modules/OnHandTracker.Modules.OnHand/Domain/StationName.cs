using OnHandTracker.Domain;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class StationName : Value<StationName>
    {
        internal StationName(string name) => Value = name;

        protected StationName() { }

        public string Value { get; }

        public static StationName FromString(string name) => new StationName(name);

        public static implicit operator string(StationName name) => name.Value;
    }
}