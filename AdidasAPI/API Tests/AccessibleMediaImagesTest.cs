﻿using System.Diagnostics;
using System.Net.Http;
using NUnit.Framework;
using AdidasAPI.API_Client;

namespace AdidasAPI.API_Tests
{
    public partial class APITests
    {
        [Test]
        public static void API_CheckForEmptyBackgroundImagesTest()
        {
            Client client = new Client();
            System.Threading.Tasks.Task<HttpResponseMessage> response = client.GetAsync(Keywords.apiPublicAddress);
            string result = response.Result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            QuickType.Welcome data = QuickType.Welcome.FromJson(result);


            foreach (var componentPresentation in data.ComponentPresentations)
            {
                if (componentPresentation.Component?.ContentFields != null && componentPresentation.Component.ContentFields?.Items != null)
                {
                    foreach (QuickType.Item item in componentPresentation.Component.ContentFields.Items)
                    {
                        QuickType.BackgroundMedia backgroundMediaItems = item.BackgroundMedia;

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.AssetType))
                        {
                            Validation.ValidateAssetTypeContent(backgroundMediaItems.AssetType);
                        }

                        //TODO: Check For Content-Type: image/jpeg 
                        //response.Result.Content.Headers.ContentType
                        //var url = client.GetAsync(desktopImageUrl).Result.Content.Headers.ContentType;

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.DesktopImage?.Url))
                        {
                            string desktopImageUrl = backgroundMediaItems.DesktopImage.Url;
                            Validation.ValidateResponseCode(desktopImageUrl, "Expected Desкtop Images to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(desktopImageUrl);
                        }

                        if (!string.IsNullOrEmpty(backgroundMediaItems?.MobileImage?.Url))
                        {
                            string mobileImageUrl = backgroundMediaItems.MobileImage.Url;
                            Validation.ValidateResponseCode(mobileImageUrl, "Expected Mobile Images to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(mobileImageUrl);
                        }


                        if (!string.IsNullOrEmpty(backgroundMediaItems?.TabletImage?.Url))
                        {
                            string tabletImageUrl = backgroundMediaItems.TabletImage.Url;
                            Validation.ValidateResponseCode(tabletImageUrl, "Expected Responce Images to be accessible!");
                            Validation.ValidateUrlForJPGImageExtention(tabletImageUrl);
                        }
                    }
                }
            }
        }
    }
}
