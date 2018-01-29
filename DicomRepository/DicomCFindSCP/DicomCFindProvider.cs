using Dicom;
using Dicom.Log;
using Dicom.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomCFindSCP
{
    public class DicomCFindProvider : DicomService, IDicomServiceProvider, IDicomService, IDicomCFindProvider
    {
        public DicomCFindProvider(INetworkStream stream, Encoding fallbackEncoding, Logger log) : base(stream, fallbackEncoding, log) { }


        public IEnumerable<DicomCFindResponse> OnCFindRequest(DicomCFindRequest request)
        {
            Console.WriteLine(request.PresentationContext.AbstractSyntax.ToString());
            var responseList = new List<DicomCFindResponse>();
            var r = new DicomCFindResponse(request, DicomStatus.Pending);
            r.Dataset = new DicomDataset();
            r.Dataset.Add(DicomTag.PatientID, request.PresentationContext.AbstractSyntax.ToString());
            responseList.Add(r);
            r = new DicomCFindResponse(request, DicomStatus.Pending);
            r.Dataset = new DicomDataset();
            r.Dataset.Add(DicomTag.SOPClassesInStudy, request.PresentationContext.Result.ToString());
            responseList.Add(r);

            responseList.Add(new DicomCFindResponse(request, DicomStatus.Success));

            return responseList;
        }

        public void OnConnectionClosed(Exception exception)
        {
            Logger.Info("Exited");
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            Logger.Info("Aborted");
            base.SendAbort(source, reason);
        }

        public void OnReceiveAssociationReleaseRequest()
        {
            Logger.Info("AssociationReleased");
            base.SendAssociationReleaseRequest();
        }

        public void OnReceiveAssociationRequest(DicomAssociation association)
        {
            foreach (var context in association.PresentationContexts)
            {
                if (context.AbstractSyntax == DicomUID.ModalityWorklistInformationModelFIND)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else if (context.AbstractSyntax == DicomUID.StudyRootQueryRetrieveInformationModelFIND)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else if (context.AbstractSyntax == DicomUID.PatientRootQueryRetrieveInformationModelFIND)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else
                {
                    context.SetResult(DicomPresentationContextResult.RejectAbstractSyntaxNotSupported);
                }
            }
            base.SendAssociationAccept(association);
        }
    }
}
