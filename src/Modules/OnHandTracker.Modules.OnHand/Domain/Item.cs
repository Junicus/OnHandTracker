using System;
using OnHandTracker.Domain;
using OnHandTracker.Modules.OnHand.Domain.Messages.Events;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class Item : Entity<ItemId>
    {
        public Item(Action<object> applier) : base(applier)
        {
        }

        private StationId ParentStationId { get; set; }
        public ItemName ItemName { get; private set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case V1.ItemAddedToStation e:
                    Id = new ItemId(e.ItemId);
                    ParentStationId = new StationId(e.StationId);
                    ItemName = ItemName.FromString(e.ItemName);
                    break;
            }
        }
    }
}