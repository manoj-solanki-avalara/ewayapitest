using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExcelloneWayApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
			byte[] key = Encoding.UTF8.GetBytes("fade3390ab9d49c88f2e0e69ed6e40af");
			System.Security.Cryptography.RSACryptoServiceProvider RSACryp = null;
			RSACryp = GetPublicKey();
			byte[] bytesEncrypted = RSACryp.Encrypt(key, false);
			var str = Convert.ToBase64String(bytesEncrypted);

		
		}

		

		private static RSACryptoServiceProvider GetPublicKey()
		{
			var publicKeyStr = "-----BEGIN CERTIFICATE-----\n" + "MIIDBjCCAe4CCQD4s8To3ff4XTANBgkqhkiG9w0BAQUFADBFMQswCQYDVQQGEwJBVTETMBEGA1UECBMKU29tZS1TdGF0ZTEhMB8GA1UEChMYSW50ZXJuZXQgV2lkZ2l0cyBQdHkgTHRkMB4XDTE3MDMxNzA2NDYwNVoXDTI3MDMxNTA2NDYwNVowRTELMAkGA1UEBhMCQVUxEzARBgNVBAgTClNvbWUtU3RhdGUxITAfBgNVBAoTGEludGVybmV0IFdpZGdpdHMgUHR5IEx0ZDCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANCk1xx5Te1zgS69DJKM/CdK+qywtRYjYYcT8vGUXmkTrJ5M/qRpkc0gI50yyIMmJsQjxW0H5DTbMHHZGobtrwlFlyyU73V4U5mgUf/fw/H1S4XihTWNhpMADmCuT79FAsGrnuTD52XsLRihtUk2kOl8NhW8jemMwfzUks73dPCLclH4NlWYHsGJB98xw/oSKlTXJJk7TsgoWQQ1HIu0govgLTlB2nWRl+p5kGrJ9uEPyHRkXDZC3fVep+6n7T1woRXtYaOMldzcTEIc+/jcpeKS6/F5N0MKcpzxL5IggCP1LpdwAQn7ErmKKDEbngxO8Mp4r+hKgmktg2vOiPlzHsUCAwEAATANBgkqhkiG9w0BAQUFAAOCAQEArqUL2ZZhQ4h5htvjDYuGmZiN7sJLz/5ipSxQATx6kdvuvBcl1b30Qwald5F9PJkDCoaJqmdr/gwW+l0RLHQXwn0fEjNQRHc6WQCisr3B1CHuxlnc2rs2Xlv/b3foZpkuqCePr6T1UklDMfeWSezcXWQ6hKSWx0F47OSWLnLbzFKJQRFRbzmr0rYcvAFVSrb4yCWypvcwnIiYf7jkqwXf8yZ00ZpMlHLn11gB24SVgU08OpoqeyuggJ8BWas8W1VB+FF6EuKzELcyOwbA7BV4ArajP/Hcb31Ao1H5JshiY0PJTl31AKEozQa9BAOzDnsS0gUbxYUnFEJ92I/cVAa3mA==" + "\n-----END CERTIFICATE-----";
			using (System.IO.TextReader reader = new System.IO.StringReader(publicKeyStr))
			{
				var pemReader = new Org.BouncyCastle.OpenSsl.PemReader(reader);
				var bouncyRsaParameters = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)pemReader.ReadObject();
				var rsaParameters = Org.BouncyCastle.Security.DotNetUtilities.ToRSAParameters(bouncyRsaParameters);
				var publicKey = new RSACryptoServiceProvider();
				publicKey.ImportParameters(rsaParameters);
				return publicKey;
			}
		}
	}
}
