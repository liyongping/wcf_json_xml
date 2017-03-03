using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_json_xml
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    //[JSONPSupportBehaviorAttribute]
    public class Service2 : IService2
    {
        public Teacher GetTeacher(string id)
        {
            Teacher s = new Teacher(int.Parse(id), "Teacher:" + id);
            var xx = WebOperationContext.Current.OutgoingResponse.Format;
            return s;
        }
    }
}
