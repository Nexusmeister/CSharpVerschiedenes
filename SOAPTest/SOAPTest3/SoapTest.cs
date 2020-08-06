using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using SOAPTest3.SeeburgerService;

namespace SOAPTest3
{
    //Hier sind alle Methoden aus dem SeeburgerInterface -> Was kann man mit den anfangen...?
    class SoapTest : MFTWebServiceMFTPortTypeChannel
    {
        public WebServiceToFtpResponse WebServiceToFtp(WebServiceToFtpRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<WebServiceToFtpResponse> WebServiceToFtpAsync(WebServiceToFtpRequest request)
        {
            throw new NotImplementedException();
        }

        public WebServiceToMailResponse WebServiceToMail(WebServiceToMailRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<WebServiceToMailResponse> WebServiceToMailAsync(WebServiceToMailRequest request)
        {
            throw new NotImplementedException();
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Close(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndClose(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Open(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndOpen(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public CommunicationState State { get; }
        public event EventHandler Closed;
        public event EventHandler Closing;
        public event EventHandler Faulted;
        public event EventHandler Opened;
        public event EventHandler Opening;
        public T GetProperty<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IExtensionCollection<IContextChannel> Extensions { get; }
        public bool AllowOutputBatching { get; set; }
        public IInputSession InputSession { get; }
        public EndpointAddress LocalAddress { get; }
        public TimeSpan OperationTimeout { get; set; }
        public IOutputSession OutputSession { get; }
        public EndpointAddress RemoteAddress { get; }
        public string SessionId { get; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DisplayInitializationUI()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginDisplayInitializationUI(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void EndDisplayInitializationUI(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginWebServiceToFtp(WebServiceToFtpRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public WebServiceToFtpResponse EndWebServiceToFtp(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginWebServiceToMail(WebServiceToMailRequest request, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public WebServiceToMailResponse EndWebServiceToMail(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public bool AllowInitializationUI { get; set; }
        public bool DidInteractiveInitialization { get; }
        public Uri Via { get; }
        public event EventHandler<UnknownMessageReceivedEventArgs> UnknownMessageReceived;
    }
}
