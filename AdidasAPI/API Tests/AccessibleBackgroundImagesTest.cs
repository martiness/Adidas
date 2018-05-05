using System;
using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace AdidasAPI
{
    public partial class APITests
    {
        /// <summary>
        /// Checks for empty images test.
        /// SLAs/requirements: Images should be accessible (no 404/401s)
        /// </summary>
        [Test]
        public static void API_CheckForEmptyMediaImagesTest()
        {
            Client client = new Client();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Constants.apiPublicAddress);
            string result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            QuickType.Welcome data = QuickType.Welcome.FromJson(result);


            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                {
                    foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                    {
                        QuickType.BackgroundMedia mediaItems = item.MediaItems;
                        
                        // Verification for Is Asset Type an Image 
                        if (!string.IsNullOrEmpty(mediaItems?.AssetType))
                        {
                            Validation.ValidateAssetTypeContent(mediaItems.AssetType);
                        }

                        //TODO: Check For Content-Type: image/jpeg 
                        //response.Result.Content.Headers.ContentType
                        //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;

                        // Verification for 
                        // Is Desktop Image has OK response
                        // Is Desktop Image extention JPG
                        if (!string.IsNullOrEmpty(mediaItems?.DesktopImage?.Url))
                        {
                            string desktopImageUrl = mediaItems.DesktopImage.Url;
                            Validation.ValidateResponseCode(desktopImageUrl);
                            Validation.ValidateUrlForJPGImageExtention(desktopImageUrl);
                        }

                        // Verification for 
                        // Is Mobile Image has OK response
                        // Is Mobile Image extention JPG
                        if (!string.IsNullOrEmpty(mediaItems?.MobileImage?.Url))
                        {
                            string mobileImageUrl = mediaItems.MobileImage.Url;
                            Validation.ValidateResponseCode(mobileImageUrl);
                            Validation.ValidateUrlForJPGImageExtention(mobileImageUrl);
                        }

                        // Verification for 
                        // Is Tablet Image has OK response
                        // Is Tablet Image extention JPG
                        if (!string.IsNullOrEmpty(mediaItems?.TabletImage?.Url))
                        {
                            string tabletImageUrl = mediaItems.TabletImage.Url;
                            Validation.ValidateResponseCode(tabletImageUrl);
                            Validation.ValidateUrlForJPGImageExtention(tabletImageUrl);
                        }

                    }

                }
            }
        }
    }
}
