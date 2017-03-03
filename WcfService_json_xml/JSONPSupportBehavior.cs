using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace WcfService_json_xml
{
    class JSONPSupportInspector : IDispatchMessageInspector
    {
        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            if (request.Properties.ContainsKey("UriTemplateMatchResults"))
            {
                HttpRequestMessageProperty httpmsg = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
                UriTemplateMatch match = (UriTemplateMatch)request.Properties["UriTemplateMatchResults"];

                string format = match.QueryParameters["format"];
                if ("json".Equals(format, StringComparison.InvariantCultureIgnoreCase))
                {
                    match.QueryParameters.Remove("$format");

                    // replace the Accept header so that the Data Services runtime 
                    // assumes the client asked for a JSON representation
                    httpmsg.Headers["Accept"] = "application/json, text/plain;q=0.5";
                    httpmsg.Headers["Accept-Charset"] = "utf-8";
                }
                else
                {   
                    // default
                    httpmsg.Headers["Accept"] = "application/xml, text/plain;q=0.5";
                    httpmsg.Headers["Accept-Charset"] = "utf-8";
                }
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {

        }
        #endregion
    }

    // Simply apply this attribute to a DataService-derived class to get
    // JSONP support in that service
    //[AttributeUsage(AttributeTargets.Class)]
    [AttributeUsage(AttributeTargets.All)]
    public class JSONPSupportBehaviorAttribute : Attribute, IServiceBehavior
    {
        #region IServiceBehavior Members

        void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cd in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher ed in cd.Endpoints)
                {
                    ed.DispatchRuntime.MessageInspectors.Add(new JSONPSupportInspector());
                }
            }
        }

        void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }

}