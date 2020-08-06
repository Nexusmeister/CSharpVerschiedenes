using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace SOAPTest3
{
    class Funktion
    {
        public Funktion()
        {

        }

        public bool CallWebService()
        {
            //TODO INSERT URL
            var _url = string.Empty;
            var _action = "http://xxxxxxxx/Service1.asmx?op=HelloWorld";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            FuegeSoapEnvelopeInEineWebRequest(soapEnvelopeXml, webRequest);

            // Async WebRequest
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }

            return true;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            var soapEnv = new XmlDocument();
            soapEnv.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://uri.seeburger.com/bisas/schema/WebServiceMFT"">
                                           <soapenv:Header/>
                                           <soapenv:Body>
                                              <web:FilesElement>
                                                 <!--1 or more repetitions:-->
                                                 <web:filename>?</web:filename>
                                              </web:FilesElement>
                                              <web:FtpParams>
                                                 <web:URL>?</web:URL>
                                                 <web:Port>?</web:Port>
                                                 <web:Type>?</web:Type>
                                                 <web:User>?</web:User>
                                                 <web:Password>?</web:Password>
                                                 <web:Path>?</web:Path>
                                              </web:FtpParams>
                                            </soapenv:Body>
                                            </soapenv:Envelope>");
            return soapEnv;
        }

        private static void FuegeSoapEnvelopeInEineWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        /// <summary>
        /// Sends a custom sync SOAP request to given URL and receive a request
        /// </summary>
        /// <param name="url">The WebService endpoint URL</param>
        /// <param name="action">The WebService action name</param>
        /// <param name="parameters">A dictionary containing the parameters in a key-value fashion</param>
        /// <param name="soapAction">The SOAPAction value, as specified in the Web Service's WSDL (or NULL to use the url parameter)</param>
        /// <param name="useSOAP12">Set this to TRUE to use the SOAP v1.2 protocol, FALSE to use the SOAP v1.1 (default)</param>
        ///// <returns>A string containing the raw Web Service response</returns>
        //public static string SendSOAPRequest(string url, string action, Dictionary<string, string> parameters, string soapAction = null)
        //{
        //    // Create the SOAP envelope
        //    XmlDocument soapEnvelopeXml = new XmlDocument();
        //    var xmlStr =
             
        //        @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://uri.seeburger.com/bisas/schema/WebServiceMFT"">
        //                                   <soapenv:Header/>
        //                                   <soapenv:Body>
        //                                      <web:FilesElement>
        //                                         <!--1 or more repetitions:-->
        //                                         <web:filename>?</web:filename>
        //                                      </web:FilesElement>
        //                                      <web:FtpParams>
        //                                         <web:URL>?</web:URL>
        //                                         <web:Port>?</web:Port>
        //                                         <web:Type>?</web:Type>
        //                                         <web:User>?</web:User>
        //                                         <web:Password>?</web:Password>
        //                                         <web:Path>?</web:Path>
        //                                      </web:FtpParams>
        //                                    </soapenv:Body>
        //                                    </soapenv:Envelope>";


        //    string parms = string.Join(string.Empty, parameters.Select(kv => String.Format("<{0}>{1}</{0}>", kv.Key, kv.Value)).ToArray());
        //    var s = String.Format(xmlStr, action, new Uri(url).GetLeftPart(UriPartial.Authority) + "/", parms);
        //    soapEnvelopeXml.LoadXml(s);

        //    // Create the web request
        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
        //    webRequest.Headers.Add("SOAPAction", soapAction ?? url);
        //    bool useSOAP12 = false;
        //    webRequest.ContentType = (useSOAP12) ? "application/soap+xml;charset=\"utf-8\"" : "text/xml;charset=\"utf-8\"";
        //    webRequest.Accept = (useSOAP12) ? "application/soap+xml" : "text/xml";
        //    webRequest.Method = "POST";

        //    // Insert SOAP envelope
        //    using (Stream stream = webRequest.GetRequestStream())
        //    {
        //        soapEnvelopeXml.Save(stream);
        //    }

        //    // Send request and retrieve result
        //    string result;
        //    using (WebResponse response = webRequest.GetResponse())
        //    {
        //        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
        //        {
        //            result = rd.ReadToEnd();
        //        }
        //    }
        //    return result;
        //}

    }
}
