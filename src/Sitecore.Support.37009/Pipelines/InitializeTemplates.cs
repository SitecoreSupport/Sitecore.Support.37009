using Sitecore.Commerce.Connect.CommerceServer.Catalog;
using Sitecore.Configuration;
using Sitecore.Data.DataProviders;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Commerce.Connect.CommerceServer.Pipelines
{
    public class InitializeTemplates
    {
        public void Process(PipelineArgs args)
        {
            var database = Factory.GetDatabase("master",false);
            if (database != null)
            {
                var dataProviders = database.GetDataProviders();

                foreach (var provider in dataProviders)
                {
                    if (provider is CatalogDataProvider)
                    {
                        typeof(CatalogDataProvider).GetMethod("InitializeTemplates", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(provider, new object[] { provider.Database });
                        break;
                    }
                }
            }
            database = Factory.GetDatabase("web",false);
            if (database != null)
            {
                var dataProviders = database.GetDataProviders();

                foreach (var provider in dataProviders)
                {
                    if (provider is CatalogDataProvider)
                    {
                        typeof(CatalogDataProvider).GetMethod("InitializeTemplates", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(provider, new object[] { provider.Database });
                        break;
                    }
                }
            }
        }

    }
}
