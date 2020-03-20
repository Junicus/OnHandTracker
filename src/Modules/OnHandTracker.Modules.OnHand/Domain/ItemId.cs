using System;
using OnHandTracker.Domain;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class ItemId : Value<ItemId>
    {
        public ItemId(Guid value) => Value = value;

        public Guid Value { get; }
    }
}