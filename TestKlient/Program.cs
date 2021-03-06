﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using OppslagstjenesteWsdl.OppslagstjenesteV5;
using ApiClientShared.Enums;
using System.ServiceModel.Security.Tokens;
using System.Diagnostics;

namespace TestKlient
{
    class Program
    {
        static void Main(string[] args)

        {
            configProxy();
            codeProxy();

        }

        public static void codeProxy()
        {

            var client = Proxy.GetClient();
            client.ChannelFactory.Endpoint.Behaviors.Add(new InspectorBehavior());
            try
            {
                var hentPersonRequest = HentPersonerRequest();
                var response = client.HentPersoner(hentPersonRequest);
            }
            catch (Exception exception)
            {

                if (exception.InnerException == null) Trace.WriteLine(exception.Message);
                else Trace.WriteLine(exception.InnerException);
            }
            
        }


        public static  void configProxy()
        {

            var proxyClient = new oppslagstjeneste1602Client("oppslagstjeneste_ver2_v6");
            proxyClient.Endpoint.Binding.CloseTimeout = proxyClient.Endpoint.Binding.OpenTimeout = proxyClient.Endpoint.Binding.ReceiveTimeout = proxyClient.Endpoint.Binding.SendTimeout = TimeSpan.FromMinutes(1);
            proxyClient.ChannelFactory.Endpoint.Behaviors.Add(new InspectorBehavior());
            
            
            try
            {
                var hentPersonRequest = HentPersonerRequest();
                var response =  proxyClient.HentPersoner(hentPersonRequest);
            }
            catch (Exception exception)
            {
                if (exception.InnerException == null) Trace.WriteLine(exception.Message);
                else Trace.WriteLine(exception.InnerException);
            }



        }

        private static HentPersonerRequest HentPersonerRequest()
        {
            var hentPersonForesp = new HentPersonerForespoersel();
            hentPersonForesp.informasjonsbehov = new[] {informasjonsbehov.Kontaktinfo};
            hentPersonForesp.personidentifikator = new[] {"31108446911"};
            var hentPersonRequest = new HentPersonerRequest(null, hentPersonForesp);
            return hentPersonRequest;
        }

        private static HentEndringerRequest HentEndringerRequest()
        {
            var endringForespoersel = HentEndringerForespoersel();
            var oppslagstjeneste = new Oppslagstjenesten();
            oppslagstjeneste.PaaVegneAv = "123";
            var hentEndringRequest = new HentEndringerRequest(null, endringForespoersel);
            return hentEndringRequest;
        }
        private static HentEndringerForespoersel HentEndringerForespoersel()
        {
            var endringForespoersel = new HentEndringerForespoersel
            {
                informasjonsbehov = new informasjonsbehov[(int) informasjonsbehov.Kontaktinfo],
                fraEndringsNummer = 8000
            };
            return endringForespoersel;
        }
    }
}
