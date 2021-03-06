using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerOrderingExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerOrderingExample example = new SignerOrderingExample( Props.GetInstance() );
            example.Run();

            // Initial signing order
            DocumentPackage beforeReorder = example.savedPackage;
            Assert.AreEqual(beforeReorder.Signers[example.email1].SigningOrder, 1);
            Assert.AreEqual(beforeReorder.Signers[example.email2].SigningOrder, 2);

            // After reordering signers
            DocumentPackage afterReorder = example.afterReorder;
            Assert.AreEqual(afterReorder.Signers[example.email1].SigningOrder, 2);
            Assert.AreEqual(afterReorder.Signers[example.email2].SigningOrder, 1);
        }
    }
}

