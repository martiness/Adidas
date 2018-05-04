using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AdidasAPI.API_Client;

namespace AdidasAPI.API_Tests
{
    public partial class APITests
    {
        /// <summary>
        /// Checks for analytics data.
        /// SLAs/requirements: Every component has at least analytics data “analytics_name” in it 
        /// </summary>
        [Test]
        public static void API_CheckForAnalyticsData()
        {
            //string apiAddress = apiAddress = @"api/pages/landing?path=/";

            var client = new Client();
            var response = client.GetAsync(Keywords.apiPublicAddress);
            var result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var data = QuickType.Welcome.FromJson(result);

            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                {
                    foreach (var item in componentPresentation.Component.ContentFields.Items)
                    {
                        var suportingFields = item.SupportingFields;

                        if (suportingFields?.SupportingFields?.StandardMetadata?.AnalyticsName != null)
                        {
                            string analyticsName = suportingFields.SupportingFields.StandardMetadata.AnalyticsName;

                            Validation.ValidateAnalyticsNameExist(analyticsName, "Expected component to have 'Analytics Name' in it!");
                        }

                    }
                }
            }
        }
    }
}
