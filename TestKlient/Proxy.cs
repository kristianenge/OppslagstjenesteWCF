using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using OppslagstjenesteWsdl.OppslagstjenesteV5;

namespace TestKlient
{
    public static class Proxy
    {
        public static oppslagstjeneste1602Client GetClient()
        {
            
            ServicePointManager.ServerCertificateValidationCallback += EasyCertCheck;
            
            var dnsIdentity = EndpointIdentity.CreateDnsIdentity("DIREKTORATET FOR FORVALTNING OG IKT");

            var address = new EndpointAddress(new Uri("https://kontaktinfo-ws-ver2.difi.no/kontaktinfo-external/ws-v5"),
                dnsIdentity);

            var myCustomBinding = CreateCustomBinding();
            var client = new oppslagstjeneste1602Client(myCustomBinding, address);

            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindByThumbprint,
                "8702F5E55217EC88CF2CCBADAC290BB4312594AC");
            client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(StoreLocation.CurrentUser,
                StoreName.TrustedPeople,
                X509FindType.FindByThumbprint,
                "a4 7d 57 ea f6 9b 62 77 10 fa 0d 06 ec 77 50 0b af 71 c4 32");

            return client;
        }

        private static bool EasyCertCheck(object sender, X509Certificate cert,
            X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }

        private static CustomBinding CreateCustomBinding()
        {
            
            var asbe =
                (AsymmetricSecurityBindingElement)
                    SecurityBindingElement.CreateMutualCertificateBindingElement(
                        MessageSecurityVersion
                            .WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10);

            asbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128Sha256;
            asbe.IncludeTimestamp = true;
            asbe.KeyEntropyMode = SecurityKeyEntropyMode.CombinedEntropy;
            asbe.SecurityHeaderLayout = SecurityHeaderLayout.Lax;
            asbe.RequireSignatureConfirmation = false;
            asbe.AllowSerializedSigningTokenOnReply= true;
            asbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature;
            
            var tmee = new TextMessageEncodingBindingElement();
            tmee.MaxReadPoolSize = 64;
            tmee.MaxWritePoolSize = 16;
            tmee.MessageVersion = MessageVersion.Soap12;
            tmee.WriteEncoding = Encoding.UTF8;
            tmee.ReaderQuotas.MaxDepth = 32;
            tmee.ReaderQuotas.MaxStringContentLength = 8192;
            tmee.ReaderQuotas.MaxArrayLength = 16384;
            tmee.ReaderQuotas.MaxBytesPerRead = 4096;
            tmee.ReaderQuotas.MaxNameTableCharCount = 16384;


            var htbe = new HttpsTransportBindingElement();
            htbe.RequireClientCertificate = true;
            htbe.MaxBufferPoolSize = 524288;
            htbe.MaxBufferSize =2147483647;
            htbe.MaxReceivedMessageSize = 2147483647;

            var binding = new CustomBinding();
            binding.Elements.Add(asbe);
            binding.Elements.Add(tmee);
            binding.Elements.Add(htbe);
            return new CustomBinding(binding);
        }
    }
}