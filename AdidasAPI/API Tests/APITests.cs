using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AdidasAPI.API_Client;

namespace AdidasAPI
{
    public class APITests
    {

        /// <summary>
        /// Checks for reponse time test.
        /// SLAs/requirements: Response time should be bellow 1s
        /// </summary>
        [Test]
        public static void API_CheckForReponseTimeTest()
        {
            Client client = new Client();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Keywords.apiPublicAddress);
            stopwatch.Stop();

            bool isLessThanSec = Validation.IsLessThanASecond(stopwatch.ElapsedMilliseconds);
            Assert.IsTrue(isLessThanSec, "Expected API request response to be bellow 1 second, but it isn't");
        }



        /// <summary>
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public static void API_CheckForEmptyImagesTest()
        {
            Client client = new Client();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Keywords.apiPublicAddress);
            string result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            QuickType.Welcome data = QuickType.Welcome.FromJson(result);

            

            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null
                    && componentPresentation.Component.ContentFields?.Items != null
                )
                {
                    foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                    {
                        QuickType.BackgroundMedia backgroundMediaItems = item.BackgroundMedia;

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.AssetType))
                        {
                            Validation.ValidateAssetType(backgroundMediaItems.AssetType, "Expected 'Asset Type' to be 'Image'");
                        }

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.DesktopImage?.Url))
                        {
                            string desktopImageUrl = backgroundMediaItems.DesktopImage.Url;
                            Validation.ValidateResponse(desktopImageUrl, "Expected Desкtop Images to be accessible!");

                            //TODO: Check For Content-Type: image/jpeg 
                            //response.Result.Content.Headers.ContentType
                            //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;
                        }

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.MobileImage?.Url))
                        {
                            string mobileImageUrl = backgroundMediaItems.MobileImage.Url;
                            Validation.ValidateResponse(mobileImageUrl, "Expected Mobile Images to be accessible!");
                        }


                        if (!string.IsNullOrEmpty(backgroundMediaItems?.TabletImage?.Url))
                        {
                            string tabletImageUrl = backgroundMediaItems.TabletImage.Url;
                            Validation.ValidateResponse(tabletImageUrl, "Expected Responce Images to be accessible!");
                        }



                        QuickType.BackgroundMedia mediaItems = item.MediaItems;

                        if (!string.IsNullOrEmpty(mediaItems?.AssetType))
                        {
                            Validation.ValidateAssetType(mediaItems.AssetType, "Expected 'Asset Type' to be 'Image'");
                        }

                        if (!string.IsNullOrEmpty(mediaItems?.DesktopImage?.Url))
                        {
                            string desktopImageUrl = mediaItems.DesktopImage.Url;
                            Validation.ValidateResponse(desktopImageUrl, "Expected Desкtop Images to be accessible!");

                            //TODO: Check For Content-Type: image/jpeg 
                            //response.Result.Content.Headers.ContentType
                            //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;
                        }

                        if (!string.IsNullOrEmpty(mediaItems?.MobileImage?.Url))
                        {
                            string mobileImageUrl = mediaItems.MobileImage.Url;
                            Validation.ValidateResponse(mobileImageUrl, "Expected Mobile Images to be accessible!");
                        }


                        if (!string.IsNullOrEmpty(mediaItems?.TabletImage?.Url))
                        {
                            string tabletImageUrl = mediaItems.TabletImage.Url;
                            Validation.ValidateResponse(tabletImageUrl, "Expected Responce Images to be accessible!");
                        }

                    }

                }
            }
        }

        
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
                if (
                    componentPresentation.Component?.ContentFields != null
                    && componentPresentation.Component.ContentFields?.Items != null
                )
                {
                    foreach (var item in componentPresentation.Component.ContentFields.Items)
                    {
                        var suportingFields = item.SupportingFields;
                        if (suportingFields != null)
                        {
                            if (suportingFields.SupportingFields != null)
                            {
                                if (suportingFields.SupportingFields.StandardMetadata != null)
                                {
                                    if (suportingFields.SupportingFields.StandardMetadata.AnalyticsName != null)
                                    {
                                        bool hasAnaliticsName = (!string.IsNullOrEmpty(suportingFields.SupportingFields.StandardMetadata.AnalyticsName));
                                        Assert.IsTrue(hasAnaliticsName,
                                            "Expected component to have “analytics_name” in it, but it haven't!");
                                        System.Diagnostics.Debug.WriteLine(hasAnaliticsName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Checks for valid response, different from 401 and 404
        /// </summary>
        /// <param name="address"> Image address </param>
        /// <returns></returns>
        #region Helpers


        #endregion Helpers
    }
}
