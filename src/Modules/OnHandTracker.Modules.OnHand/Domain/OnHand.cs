using System;
using System.Collections.Generic;
using OnHandTracker.Domain;
using OnHandTracker.Modules.OnHand.Domain.Messages.Events;
using OnHandTracker.Modules.OnHand.Models;

namespace OnHandTracker.Modules.OnHand.Domain.OnHands
{
    public class OnHand : AggregateRoot
    {
        public enum OnHandState { New, Ready }

        private List<Station> _stations;

        public static OnHand Create(OnHandId id)
        {
            var onHand = new OnHand();
            onHand.Apply(new V1.OnHandCreated
            {
                Id = id,
            });
            return onHand;
        }

        public void AddStation(string stationName) => Apply(new V1.StationAddedToOnHand
        {
            OnHandId = Id,
            StationId = Guid.NewGuid(),
            StationName = stationName,
        });

        public OnHandState State { get; private set; }
        public IEnumerable<Station> Stations => _stations;

        protected override void When(object @event)
        {
            switch (@event)
            {
                case V1.OnHandCreated e:
                    Id = e.Id;
                    State = OnHandState.New;
                    _stations = new List<Station>();
                    break;
                case V1.StationAddedToOnHand e:
                    {
                        var station = new Station(Apply);
                        ApplyToEntity(station, e);
                        _stations.Add(station);
                        break;
                    }
                case V1.ItemAddedToStation e:
                    {
                        var station = _stations.Find(s => s.Id == new StationId(e.StationId));
                        ApplyToEntity(station, e);
                        break;
                    }
            }
        }

        protected override void EnsureValidState()
        {
            var valid = (State switch
            {
                OnHandState.Ready => _stations.Count > 0,
                _ => true
            });

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(
                    this, $"Post-checks failed in state {State}");
        }
    }
}