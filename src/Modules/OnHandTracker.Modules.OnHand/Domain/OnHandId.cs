using System;
using OnHandTracker.Domain;

namespace OnHandTracker.Modules.OnHand.Domain.OnHands
{
    public class OnHandId : AggregateId<OnHand>
    {
        protected OnHandId(Guid value) : base(value)
        {
        }

        public static OnHandId FromGuid(Guid value) => new OnHandId(value);
    }
}