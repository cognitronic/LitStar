using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitStar.Infrastructure.Querying;

namespace LitStar.Couchbase
{
    public static class QueryTranslator
    {
        public static string BuildGetByQueryFrom(Query query)
        {
            string keys = "";
            if (query.Criteria != null)
            {
                foreach (var c in query.Criteria)
                {
                    if (!string.IsNullOrEmpty(keys) && keys.Length > 0)
                        keys += ",";
                    switch (c.CriteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            keys = c.Value.ToString();
                            break;
                        //case CriteriaOperator.LesserThanOrEqual:
                        //    criterion = Expression.Le(c.PropertyName, c.Value);
                        //    break;
                        //case CriteriaOperator.Between:
                        //    criterion = Expression.Between(c.PropertyName, c.Value.ToString().Split(',')[0], c.Value.ToString().Split(',')[1]);
                        //    break;
                        //case CriteriaOperator.Like:
                        //    criterion = Expression.Like(c.PropertyName, c.Value);
                        //    break;
                        //case CriteriaOperator.GreaterThanOrEqual:
                        //    criterion = Expression.Ge(c.PropertyName, c.Value);
                        //    break;
                        //default:
                        //    throw new ApplicationException("No operator defined");
                    }
                }
            }
            return keys;
        }
    }
}
