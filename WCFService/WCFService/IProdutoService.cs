using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProdutoService" in both code and config file together.
    [ServiceContract]
    public interface IProdutoService
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<PRODUTO> FindAll();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        PRODUTO Find(int id);

        [OperationContract]
        PRODUTO New(PRODUTO produto);

        [OperationContract]
        PRODUTO Update(PRODUTO produto);

        [OperationContract]
        PRODUTO DeleteId(int id);

        [OperationContract]
        PRODUTO Delete(PRODUTO produto);

    }

    public class ReferencePreservingDataContractFormatAttribute
      : Attribute, IOperationBehavior
    {
        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description,
            BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description,
            ClientOperation proxy)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyClientBehavior(description, proxy);
        }

        public void ApplyDispatchBehavior(OperationDescription description,
            DispatchOperation dispatch)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyDispatchBehavior(description, dispatch);
        }

        public void Validate(OperationDescription description)
        {
        }

        #endregion
    }



    public class ReferencePreservingDataContractSerializerOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        #region Ctor
        public ReferencePreservingDataContractSerializerOperationBehavior(
            OperationDescription operationDescription)
            : base(operationDescription) { }
        #endregion

        #region Public Methods

        public override XmlObjectSerializer CreateSerializer(Type type,
               XmlDictionaryString name, XmlDictionaryString ns,
               IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                2147483646 /*maxItemsInObjectGraph*/,
                false/*ignoreExtensionDataObject*/,
                true/*preserveObjectReferences*/,
                null/*dataContractSurrogate*/);
        }
        #endregion
    }
}
