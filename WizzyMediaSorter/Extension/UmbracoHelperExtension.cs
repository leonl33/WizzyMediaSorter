using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace WizzyMediaSorter.Extension
{
    public static class UmbracoHelperExtension
    {
        public static T ContentFromUmbraco<T>(this UmbracoHelper umbracoHelper, string appSettingsKey)
        {
            var nodeKey = ConfigurationManager.AppSettings[appSettingsKey];

            if (!Guid.TryParse(nodeKey, out Guid nodeKeyParse))
                return default;

            var node = umbracoHelper.Content(nodeKeyParse);
            return (T)node;
        }
    }



}