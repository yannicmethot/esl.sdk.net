using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestFixture()]
    public class SigningRedirectForSignerExampleTest
    {
        /** 
        Will not be supported until later release.
        **/

        [Test()]
        public void VerifyResult()
        {
            SigningRedirectForSignerExample example = new SigningRedirectForSignerExample(Props.GetInstance());
            example.Run();

            Assert.IsNotNull(example.GeneratedLinkToSigningForSigner);

            string stringResponse = HttpRequestUtil.GetUrlContent(example.GeneratedLinkToSigningForSigner);
            StringAssert.Contains("Electronic Disclosures and Signatures Consent", stringResponse);
        }
    }
}

