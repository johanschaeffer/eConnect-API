using System.Linq;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests
{
    [TestClass]
    public class SetInboxDocumentStatusTests
    {
        protected DocumentBase InboxDocument;

        public SetInboxDocumentStatusTests()
        {
            var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 1 });
            Assert.IsNotNull(result);
            InboxDocument = result.Documents.Single();
        }
        
        [TestMethod]
        public void SetInboxDocumentStatus()
        {
            var doc = EConnect.Client.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });
            var statuses = doc.PossibleStatuses;

            if (statuses.PreviousStatus != null)
            {
                // Go step back, so there will be a step head
                EConnect.Client.SetInboxDocumentStatus(new SetInboxDocumentStatus()
                    {
                        ConsignmentId = InboxDocument.ConsignmentId,
                        StatusCode = statuses.PreviousStatus.Code
                    });
            }

            doc = EConnect.Client.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });
            statuses = doc.PossibleStatuses;

            var result = EConnect.Client.SetInboxDocumentStatus(new SetInboxDocumentStatus()
                {
                    ConsignmentId = InboxDocument.ExternalId,
                    StatusCode = statuses.NextStatus.Code
                });

            Assert.IsNotNull(result);

            var result2 =
                EConnect.Client.GetInboxDocument(new GetInboxDocument() { ConsignmentId = InboxDocument.ConsignmentId });

            var statuses2 = result2.PossibleStatuses;
            Assert.AreEqual(statuses.NextStatus, statuses2.LatestStatus);
            Assert.AreEqual(statuses.LatestStatus, statuses2.PreviousStatus);
        }
    }
}