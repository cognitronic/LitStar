using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Infrastructure.Domain
{
    public interface ISystemObject
    {
        int ID { get; set; }
        Guid SystemID { get; set; }
        string Type { get; set; }
    }
}
