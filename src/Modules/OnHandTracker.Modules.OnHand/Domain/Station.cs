using System;
using System.Collections.Generic;
using OnHandTracker.Domain;
using OnHandTracker.Modules.OnHand.Domain.Messages.Events;
using OnHandTracker.Modules.OnHand.Domain.OnHands;

namespace OnHandTracker.Modules.OnHand.Domain
{
    public class Station : Entity<StationId>
    {
        public Station(Action<object> applier) : base(applier)
        {
        }

        private List<Item> _items;

        private OnHandId ParentId { get; set; }
        public StationName StationName { get; private set; }
        public IEnumerable<Item> Items => _items;

        protected override void When(object @event)
        {
            switch (@event)
            {
                case V1.StationAddedToOnHand e:
                    Id = new StationId(e.StationId);
                    ParentId = OnHandId.FromGuid(e.OnHandId);
                    StationName = StationName.FromString(e.StationName);
                    _items = new List<Item>();
                    break;
                case V1.ItemAddedToStation e:
                    {
                        var item = new Item(Apply);
                        item.Handle(e);
                        _items.Add(item);
                    }
                    break;
            }
        }
    }
}