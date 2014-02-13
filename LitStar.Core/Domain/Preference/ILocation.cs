using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Domain;

namespace LitStar.Core.Domain.Preference
{
    public interface ILocation : ISystemObject
    {
        string Name { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}
