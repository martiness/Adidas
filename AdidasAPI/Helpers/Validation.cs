using NUnit.Framework;
using System;
using System.Net.Http;

namespace AdidasAPI.API_Client
{
    class Validation
    {
        public static bool IsLessThanASecond(long elapsedTicks)
        {
            var elapsedTime = new TimeSpan(elapsedTicks);
            var isLessThanSec = elapsedTime < TimeSpan.FromSeconds(1);
            return isLessThanSec;
        }

        public static void ValidateResponse(string address, string errorMessage)
        {
            HttpResponseMessage message = new Client(address).GetAsync("").GetAwaiter().GetResult();

            bool isSuccessfulResponse = (int)message.StatusCode != 401 
                                     && (int)message.StatusCode != 404;

            Assert.IsTrue(isSuccessfulResponse, errorMessage);
        }

        public static void ValidateAssetTypeContent(string assetType, string errorMessage)
        {
            bool isAssetType = false;

            if (assetType == "Image")
            {
                isAssetType = true;
            }

            Assert.IsTrue(isAssetType, errorMessage);
        }

        public static void ValidateAnalyticsNameExist(string analyticsName, string errorMessage)
        {
            bool hasAnaliticsName = (!string.IsNullOrEmpty(analyticsName));

            Assert.IsTrue(hasAnaliticsName, errorMessage);
        }

    }
}
