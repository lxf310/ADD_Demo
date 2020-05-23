using System;
using System.Security.Cryptography.X509Certificates;

namespace NativeApp
{
    public static class Helper
    {
        public static X509Certificate2 GetCertificateBySubject(string subject = "SubjectName")
        {
            if (string.IsNullOrEmpty(subject)) return null;

            using (var store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                store.Open(OpenFlags.ReadOnly);

                var certificates = store.Certificates.Find(X509FindType.FindBySubjectName, subject, false);

                if (certificates.Count != 1)
                {
                    throw new Exception($"Failed to retrieve certificate of {subject}.");
                }

                return certificates[0];
            }
        }
    }
}
