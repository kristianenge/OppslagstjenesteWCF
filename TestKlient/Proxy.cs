using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using OppslagstjenesteWsdl.OppslagstjenesteV5;

namespace TestKlient
{
    public static class Proxy
    {
        public static oppslagstjeneste1602Client GetClient()
        {
            var i = 0;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection serverCert = store.Certificates.Find(X509FindType.FindByThumbprint, "b0 cb 92 22 14 d1 1e 8c e9 93 83 8d b4 c6 d0 4c 0c 09 70 b8", false);
            store.Close();
            

            EndpointAddress address = new EndpointAddress(new Uri("https://kontaktinfo-ws-ver2.difi.no/kontaktinfo-external/ws-v5"),
                                                                         EndpointIdentity.CreateX509CertificateIdentity(serverCert[0]));
            
            CustomBinding myCustomBinding = CreateCustomBinding(address);
            oppslagstjeneste1602Client client = new oppslagstjeneste1602Client(myCustomBinding, address);

            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser,
                                                                     StoreName.My,
                                                                     X509FindType.FindByThumbprint,
                                                                     "8702F5E55217EC88CF2CCBADAC290BB4312594AC");
            
            return client;
        }

        private static CustomBinding CreateCustomBinding(EndpointAddress address)
        {
            CustomBinding binding = new CustomBinding();
            SymmetricSecurityBindingElement ssbe =
                SecurityBindingElement.CreateSslNegotiationBindingElement(true);
            
            ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128Sha256Rsa15;
            ssbe.IncludeTimestamp = true;
            ssbe.KeyEntropyMode = SecurityKeyEntropyMode.ServerEntropy;
            ssbe.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12;
            ssbe.SecurityHeaderLayout = SecurityHeaderLayout.LaxTimestampLast;

            X509SecurityTokenParameters endpointSupportingTokenParametersTokenParams = new X509SecurityTokenParameters();
            endpointSupportingTokenParametersTokenParams.InclusionMode = SecurityTokenInclusionMode.AlwaysToRecipient;
            endpointSupportingTokenParametersTokenParams.ReferenceStyle = SecurityTokenReferenceStyle.Internal;
            endpointSupportingTokenParametersTokenParams.RequireDerivedKeys = false;
            endpointSupportingTokenParametersTokenParams.X509ReferenceStyle = X509KeyIdentifierClauseType.Any;

            ssbe.EndpointSupportingTokenParameters.Signed.Add(endpointSupportingTokenParametersTokenParams);
            ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
            ssbe.RequireSignatureConfirmation = false;
            

            X509SecurityTokenParameters ProtectionTokenParametersTokenParams = new X509SecurityTokenParameters();
            ProtectionTokenParametersTokenParams.InclusionMode = SecurityTokenInclusionMode.Never;
            ProtectionTokenParametersTokenParams.ReferenceStyle = SecurityTokenReferenceStyle.Internal;
            ProtectionTokenParametersTokenParams.RequireDerivedKeys = false;
            ProtectionTokenParametersTokenParams.X509ReferenceStyle = X509KeyIdentifierClauseType.Thumbprint;
            ssbe.ProtectionTokenParameters = ProtectionTokenParametersTokenParams;
            

            TextMessageEncodingBindingElement tmee = new TextMessageEncodingBindingElement();
            tmee.MaxReadPoolSize = 64;
            tmee.MaxWritePoolSize = 16;
            tmee.MessageVersion = MessageVersion.Soap12;
            tmee.WriteEncoding = Encoding.UTF8;
            tmee.ReaderQuotas.MaxDepth = 32;
            tmee.ReaderQuotas.MaxStringContentLength = 8192;
            tmee.ReaderQuotas.MaxArrayLength = 16384;
            tmee.ReaderQuotas.MaxBytesPerRead = 4096;
            tmee.ReaderQuotas.MaxNameTableCharCount = 16384;
            
            

            HttpsTransportBindingElement htbe = new HttpsTransportBindingElement();
            htbe.ManualAddressing = false;
            htbe.MaxBufferPoolSize = 524288;
            htbe.MaxReceivedMessageSize = 65536;
            htbe.AllowCookies = false;
            htbe.AuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            htbe.BypassProxyOnLocal = false;
            htbe.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            htbe.KeepAliveEnabled = true;
            htbe.MaxBufferSize = 65536;
            htbe.ProxyAuthenticationScheme = System.Net.AuthenticationSchemes.Anonymous;
            htbe.Realm = "";
            htbe.TransferMode = TransferMode.Buffered;
            htbe.UnsafeConnectionNtlmAuthentication = false;
            htbe.UseDefaultWebProxy = true;
            

            binding.Elements.Add(ssbe);
            binding.Elements.Add(tmee);
            binding.Elements.Add(htbe);
            return new CustomBinding(binding);
        }
    }
}
