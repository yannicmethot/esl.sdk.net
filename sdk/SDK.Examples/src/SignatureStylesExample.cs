using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignatureStylesExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new SignatureStylesExample(Props.GetInstance()).Run();
        }

        private string email1;
        private Stream fileStream1;

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly int FULL_NAME_SIGNATURE_PAGE = 0;
        public readonly int FULL_NAME_SIGNATURE_POSITION_X = 500;
        public readonly int FULL_NAME_SIGNATURE_POSITION_Y = 100;
        public readonly int INITIAL_SIGNATURE_PAGE = 0;
        public readonly int INITIAL_SIGNATURE_POSITION_X = 500;
        public readonly int INITIAL_SIGNATURE_POSITION_Y = 300;
        public readonly int HAND_DRAWN_SIGNATURE_PAGE = 0;
        public readonly int HAND_DRAWN_SIGNATURE_POSITION_X = 500;
        public readonly int HAND_DRAWN_SIGNATURE_POSITION_Y = 500;

        public SignatureStylesExample(Props props) : this(props.Get("api.key"), props.Get("api.url"), props.Get("1.email"))
        {
        }

        public SignatureStylesExample(string apiKey, string apiUrl, string email1) : base(apiKey, apiUrl)
        {
            this.email1 = email1;
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf").FullName);
        }

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed("SignatureStylesExample: " + DateTime.Now)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("John")
                            .WithLastName("Smith"))
                .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                .FromStream(fileStream1, DocumentType.PDF)
                                .WithSignature(SignatureBuilder.SignatureFor(email1)
                                    .OnPage(FULL_NAME_SIGNATURE_PAGE)
                                    .AtPosition(FULL_NAME_SIGNATURE_POSITION_X, FULL_NAME_SIGNATURE_POSITION_Y)) 
                                .WithSignature(SignatureBuilder.InitialsFor(email1)
                                    .OnPage(INITIAL_SIGNATURE_PAGE)
                                    .AtPosition(INITIAL_SIGNATURE_POSITION_X, INITIAL_SIGNATURE_POSITION_Y))
                                .WithSignature(SignatureBuilder.CaptureFor(email1)
                                    .OnPage(HAND_DRAWN_SIGNATURE_PAGE)
                                    .AtPosition(HAND_DRAWN_SIGNATURE_POSITION_X, HAND_DRAWN_SIGNATURE_POSITION_Y)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

