using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class DocumentBase
    {
        [XmlElement(ElementName = "rowkey")]
        public string Rowkey { get; set; }

        public string DocumentId { get; set; }
        public string ExternalId { get; set; }
        public string ConsignmentId { get; set; }
        public string ConsignmentName { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public string SenderAccountId { get; set; }
        public string SenderAccountName { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public string SenderEntityId { get; set; }
        public string SenderEntityName { get; set; }

        public long CreatedDateTime { get; set; }

        private string _rawPossibleConsignmentStatuses;
        private Statuses _possibleStatuses;
        [XmlElement(ElementName = "PossibleConsignmentStatuses")]
        public string RawPossibleConsignmentStatuses
        {
            get { return _rawPossibleConsignmentStatuses; }
            set
            {

                _rawPossibleConsignmentStatuses = value;
                _possibleStatuses = null;
            }
        }

        [XmlIgnore]
        public Statuses PossibleStatuses
        {
            get
            {
                if (_possibleStatuses == null)
                    _possibleStatuses = new Statuses(RawPossibleConsignmentStatuses, LatestStatusCode);
                return _possibleStatuses;
            }
        }

        public bool IsRead { get; set; }
        // TODO: Check IsTask is not bool?
        public int IsTask { get; set; }
        public string LatestStatus { get; set; }
        public string LatestStatusInfo { get; set; }
        public string LatestStatusCode { get; set; }

        public string ReceiverEntityId { get; set; }
        public string ReceiverEntityName { get; set; }

        public string StandardTemplateId { get; set; }
        public string StandardTemplateName { get; set; }

        public string DocumentViewerId { get; set; }
        public string DocumentViewerName { get; set; }

        //[XmlTextAttribute()]
        //[XmlElement(ElementName = "text")]
        //public string[] Text { get; set; }
    }
}