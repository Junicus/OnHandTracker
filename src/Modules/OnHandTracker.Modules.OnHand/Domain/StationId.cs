using System;
using OnHandTracker.Domain;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class StationId : Value<StationId>
    {
        public StationId(Guid value) => Value = value;

        public Guid Value { get; }
    }
}