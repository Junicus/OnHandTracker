using System;
using System.Collections.Generic;
using System.Linq;
using OnHandTracker.Modules.OnHand.Domain;
using OnHandTracker.Modules.OnHand.Domain.OnHands;
using OnHandTracker.Modules.OnHand.Models;

namespace OnHandTracker.Domain.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create OnHand");

            var items = new List<PosItem>();
            items.Add(new PosItem { Id = 1, Name = "Test" });

            var onHand = OnHand.Create(OnHandId.FromGuid(Guid.NewGuid()));
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            Console.WriteLine();

            Console.WriteLine("Add Station");
            onHand.AddStation("TestStation", items);
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            Console.WriteLine();

            Console.WriteLine("Add Station");
            onHand.AddStation("TestStation2", items);
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            Console.WriteLine();

            var events = onHand.GetChanges();

            foreach (var e in events)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
