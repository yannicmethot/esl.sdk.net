using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageFromTemplateWithAttachmentExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageFromTemplateWithAttachmentExample example = new CreatePackageFromTemplateWithAttachmentExample(Props.GetInstance());
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            foreach (Signer signer in documentPackage.Signers.Values) {
                foreach (AttachmentRequirement attachmentRequirement in signer.Attachments.Values) {
                    Assert.IsNotNull(attachmentRequirement);
                }
            }
        }
    }
}

