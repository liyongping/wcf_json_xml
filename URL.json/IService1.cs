using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace URL.json
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract,
        WebInvoke(UriTemplate = "student/{id}",
               Method = "GET")]
        Student GetStudent(string id);
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
