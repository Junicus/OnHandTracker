using OnHandTracker.Domain;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class ItemName : Value<ItemName>
    {
        internal ItemName(string name) => Value = name;

        protected ItemName() { }

        public string Value { get; }

        public static ItemName FromString(string name) => new ItemName(name);

        public static implicit operator string(ItemName name) => name.Value;
    }
}