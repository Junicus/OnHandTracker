using System;
using System.Collections.Generic;
using OnHandTracker.Modules.OnHand.Models;

namespace OnHandTracker.Modules.OnHand.Domain.Messages.Events
{
    public static class V1
    {
        public class OnHandCreated
        {
            public Guid Id { get; set; }
        }

        public class StationAddedToOnHand
        {
            public Guid StationId { get; set; }
            public Guid OnHandId { get; set; }
            public string StationName { get; set; }
        }

        internal class ItemAddedToStation
        {
            public Guid StationId { get; set; }
            public Guid ItemId { get; set; }
            public string ItemName { get; set; }
        }
    }
}