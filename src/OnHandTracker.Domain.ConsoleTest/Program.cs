using System;
using System.Linq;
using OnHandTracker.Modules.OnHand.Domain.OnHands;

namespace OnHandTracker.Domain.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create OnHand");

            var onHand = OnHand.Create(OnHandId.FromGuid(Guid.NewGuid()));
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            Console.WriteLine();

            Console.WriteLine("Add Station");
            onHand.AddStation("TestStation");
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            Console.WriteLine();

            Console.WriteLine("Add Station");
            onHand.AddStation("TestStation2");
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            onHand.Stations.ToList().ForEach(e => e.Items.ToList().ForEach(i => Console.WriteLine($"Item: {i}")));

            Console.WriteLine();

            var station = onHand.Stations.First();

            Console.WriteLine("Add Item");
            onHand.AddItemToStation(station.Id.Value, Guid.NewGuid(), "Test Item");
            Console.WriteLine($"OnHand: {onHand.State}");
            onHand.Stations.ToList().ForEach(e => Console.WriteLine($"{e.Id} - {e.StationName}"));
            onHand.Stations.ToList().ForEach(e => e.Items.ToList().ForEach(i => Console.WriteLine($"Item: {i.Id} - {i.ItemName}")));

            Console.WriteLine();
            var events = onHand.GetChanges();

            foreach (var e in events)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}
