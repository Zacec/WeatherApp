using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Linq;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Cors;

namespace WeatherApp.API.Controllers
{
    public class AllowCorsAttribute : Attribute, ICorsPolicyProvider
    {
        private const string keyCorsAllowOrigin = "cors:allowOrigins";

        private CorsPolicy _policy;

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_policy == null)
            {
                var retval = new CorsPolicy();
                retval.AllowAnyHeader = true;
                retval.AllowAnyMethod = true;
                retval.AllowAnyOrigin = false;

                var value = ConfigurationManager.AppSettings[keyCorsAllowOrigin];

                if (!string.IsNullOrEmpty(value))
                {
                    foreach (var one in from v in value.Split(';')
                                        where !string.IsNullOrEmpty(v)
                                        select v)
                    {
                        retval.Origins.Add(one);
                    }
                }

                _policy = retval;
            }

            return Task.FromResult(_policy);
        }
    }
}