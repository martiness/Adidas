using NUnit.Framework;
using System;
using System.Net.Http;

namespace AdidasAPI
{
    public class Validation
    {
        public static bool IsLessThanASecond(long elapsedTicks)
        {
            var elapsedTime = new TimeSpan(elapsedTicks);
            var isLessThanSec = elapsedTime < TimeSpan.FromSeconds(1);
            return isLessThanSec;
        }

        public static void ValidateResponseCode(string address)
        {
            HttpResponseMessage message = new Client(address).GetAsync("").GetAwaiter().GetResult();

            bool isSuccessfulResponse = (int)message.StatusCode != ErrorMessages.errorMessageUnautorized
                                     && (int)message.StatusCode != ErrorMessages.errorMessageNotFound;

            Assert.IsTrue(isSuccessfulResponse, ErrorMessages.apiImageResponseFailedMessage);
        }

        public static void ValidateAssetTypeContent(string assetType)
        {
            bool isAssetType = false;

            if (assetType == Constants.apiImageTypeText)
            {
                isAssetType = true;
            }

            Assert.IsTrue(isAssetType, ErrorMessages.apiAssetTypeFailedMessage);
        }

        public static void ValidateUrlForJPGImageExtention(string url)
        {
            bool isJpgImage = url.Contains(Constants.apiImageExtentionType);
            Assert.IsTrue(isJpgImage, ErrorMessages.apiImageJpgExtentionFailedMessage);
        }

        public static void ValidateAnalyticsNameExist(string analyticsName)
        {
            bool hasAnaliticsName = (!string.IsNullOrEmpty(analyticsName));
            Assert.IsTrue(hasAnaliticsName, ErrorMessages.apiAnalyticsNameFailedMessage);
        }

    }
}
