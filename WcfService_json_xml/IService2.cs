﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_json_xml
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "teacher/{id}")]
        Teacher GetTeacher(string id);
    }

    public class MyBehaviorExtensionElement : BehaviorExtensionElement
    {
        public MyBehaviorExtensionElement() { }
        public override Type BehaviorType
        {
            get { return typeof(JSONPSupportBehaviorAttribute); }
        }

        protected override object CreateBehavior()
        {
            return new JSONPSupportBehaviorAttribute();
        }
    }
    
    [DataContract]
    public class Teacher
    {
        string name = "Teacher";
        int id = 0;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
