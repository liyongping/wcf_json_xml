using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AutomaticFormat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract,
        WebInvoke(UriTemplate = "student/{id}",
            BodyStyle = WebMessageBodyStyle.Bare,
               Method = "GET")]
        Student GetStudent(string id);

        [OperationContract,
        WebInvoke(UriTemplate = "add/student",
            BodyStyle = WebMessageBodyStyle.Bare,
               Method = "POST")]
        Student AddStudent(Student student);
    }

    [DataContract]
    public class Student
    {
        string name = "student";
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

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
