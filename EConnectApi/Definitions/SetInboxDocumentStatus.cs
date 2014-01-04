using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true, Namespace = "http://ws.vg.pw.com/external/1.0")]
    [XmlRoot(Namespace = "http://ws.vg.pw.com/external/1.0", ElementName = "SetInboxDocumentStatus", IsNullable = false)]
    public class SetInboxDocumentStatus : SetDocumentStatusBase
    {
        public string ConsignmentId { get; set; }
        [XmlIgnore]
        public string ExternalId { get { return ConsignmentId; } set { ConsignmentId = value; } }
    }
}