using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitStar.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NumberOfResultsPerPage { get; }
        string JanrainApiKey { get; }
        string JanrainURL { get; }
        string SmtpHost { get; }
        string SmtpUsername { get; }
        string SmtpPassword { get; }
        string PersistenceStrategy { get; }
    }
}
