using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Configuration;
using Newtonsoft;
using Enyim;

namespace LitStar.Couchbase
{
    public class SessionFactory
    {
        private static CouchbaseClient CouchbaseClient { get; set; }

        private static void Init()
        {
            var config = new CouchbaseClientConfiguration();
            config.Bucket = "RAM_Data";
            config.BucketPassword = "";
            config.Urls.Add(new Uri("http://127.0.0.1:8091/pools"));
            //config.DesignDocumentNameTransformer = new ProductionModeNameTransformer();
            CouchbaseClient = new CouchbaseClient(config);
        }

        public static CouchbaseClient GetCurrentSession()
        {
            if (CouchbaseClient == null)
                Init();
            return CouchbaseClient;
        }
    }
}
