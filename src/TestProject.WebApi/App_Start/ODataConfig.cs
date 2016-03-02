using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace TestProject.WebApi
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("ODataRoute", "api", CreateEdmModel());
        }

        private static IEdmModel CreateEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            SetKeys(builder);
            BuildActions(builder);
            BuildFunctions(builder);

            return builder.GetEdmModel();
        }

        private static void BuildFunctions(ODataModelBuilder builder)
        {
            throw new NotImplementedException();
        }

        private static void BuildActions(ODataModelBuilder builder)
        {
            throw new NotImplementedException();
        }

        private static void SetKeys(ODataModelBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}