using Dicom;
using Dicom.Log;
using Dicom.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomCStoreSCP
{
    public class DicomCStoreProvider : DicomService, IDicomServiceProvider, IDicomService, IDicomCStoreProvider
    {
        public DicomCStoreProvider(INetworkStream stream, Encoding fallbackEncoding, Logger log) : base(stream, fallbackEncoding, log)
        { }
        


        public void OnConnectionClosed(Exception exception)
        {
            Logger.Info("Exited");
        }

        public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
        {
            
            var path = Directory.GetCurrentDirectory();
            var directory = Path.Combine(path, request.SOPClassUID.UID);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var filePath = Path.Combine(directory, request.SOPInstanceUID.UID);
            request.File.Save(filePath + ".dcm");
            return new DicomCStoreResponse(request, DicomStatus.Success);
        }

        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            Logger.Error(e.Message);
           
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            Logger.Info("Aborted");
            base.SendAbort(source,reason);
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
                if (context.AbstractSyntax == DicomUID.CTImageStorage)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else if (context.AbstractSyntax == DicomUID.SecondaryCaptureImageStorage)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else if (context.AbstractSyntax == DicomUID.XRay3DAngiographicImageStorage)
                {
                    context.SetResult(DicomPresentationContextResult.Accept);
                }
                else if (context.AbstractSyntax == DicomUID.XRayAngiographicImageStorage)
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
