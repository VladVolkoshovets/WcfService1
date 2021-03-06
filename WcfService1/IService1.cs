﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.DataContracts;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    //[ServiceContract(CallbackContract = typeof(IServiceCallback), Name = "IServiceWCallback")]
    //public interface IService2
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void SendMesage(Message message);
    //}
    [ServiceContract(Name = "IService", CallbackContract = typeof(IServiceCallback)) ]

    public interface IService1 
    {
        [OperationContract(IsOneWay = true)]
        void SomeWork();
        
        User[] GetUsers();
        [OperationContract(IsOneWay = true)]
        void Autorisation(string UserName, string Password);
        [OperationContract]
        bool AddUser(User user);
        [OperationContract(IsOneWay = true)]
        void SendMesage(Message message);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(Message message);
        [OperationContract(IsOneWay = true)]
        void ReceiveUser(User user);
    }

        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
