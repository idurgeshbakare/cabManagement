using CabManagement.Domain;
using CabManagement.Enums;
using CabManagement.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Services.Impl
{
    public class CabService : ICabService
    {
        private static readonly IDictionary<string, Cab> registeredCabs = new Dictionary<string, Cab>();

        /// <summary>
        /// Service Method to register the Cab
        /// </summary>
        /// <param name="cab"></param>
        public void RegisterCab(Cab cab)
        {
            if (!registeredCabs.ContainsKey(cab.CabId))
            {
                cab.LastBookingDate = DateTime.UtcNow.Ticks;
                registeredCabs.Add(cab.CabId, cab);
            }
            else
            {
                throw new CabAlreadyRegistered($"Can with Id '{cab.CabId}' is already registered");
            }
        }

        public Cab GetCab(string cabId)
        {
            ValidateCab(cabId);
            return registeredCabs[cabId];
        }

        public List<Cab> ListCabs(string state)
        {
            var allCabs = registeredCabs.Values;
            if (allCabs.Any())
            {
                var cabs = registeredCabs.Values.Where(cab => cab.State == state).ToList();
                return cabs;
            }

            return new List<Cab>();
        }

        public List<Cab> GetAllAvailableCabByLocation(string location)
        {
            var allAvailableCabs = ListCabs("IDLE");

            // get available cabs at location
            var cabsAvailableAtLocation = allAvailableCabs.Where(cab => cab.Location.Equals(location)).ToList();
            if (cabsAvailableAtLocation.Any())
            {
                return cabsAvailableAtLocation;
            }
            else
            {
                return new List<Cab>();
            }
        }

        public void UpdateCabLocation(string cabId, string location)
        {
            ValidateCab(cabId);
            registeredCabs[cabId].Location = location;
        }


        public void UpdateCabState(string cabId)
        {
            ValidateCab(cabId);
            var cab = GetCab(cabId);
            cab.TripState.ChangeState(cab);
        }

        private void ValidateCab(string cabId)
        {
            if (!registeredCabs.ContainsKey(cabId))
            {
                throw new CabDoesNotExist($"Cab with id '{cabId}' does not exist");
            }
        }
    }
}
