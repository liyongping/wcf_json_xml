using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace URL.json
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Student GetStudent(string id)
        {
            // 查找?format=json参数
            string formatQueryStringValue = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            if (!string.IsNullOrEmpty(formatQueryStringValue))
            {
                if (formatQueryStringValue.Equals("xml", System.StringComparison.OrdinalIgnoreCase))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Xml;
                }
                else if (formatQueryStringValue.Equals("json", System.StringComparison.OrdinalIgnoreCase))
                {
                    WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
                }
                else
                {
                    throw new WebFaultException<string>(string.Format("Unsupported format '{0}'", formatQueryStringValue), HttpStatusCode.BadRequest);
                }
            }
            Student s = new Student(int.Parse(id), "student:" + id);
            return s;
        }
    }
}
