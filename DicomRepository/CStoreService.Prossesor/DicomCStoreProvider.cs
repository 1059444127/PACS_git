using Dicom;
using Dicom.Log;
using Dicom.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CStoreService.Prossesor
{
    public class DicomCStoreProvider : DicomService, IDicomServiceProvider, IDicomService, IDicomCStoreProvider
    {
        public DicomCStoreProvider(INetworkStream stream, Encoding fallbackEncoding, Logger log) : base(stream, fallbackEncoding, log)
        { }


        public void OnConnectionClosed(Exception exception)
        {
            Logger.Info(exception==null?"Exited with no exception": "Exited with exception:"+exception.Message);
        }

        public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
        {
            var path = CStoreProcessor.TempFilePath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, Guid.NewGuid().ToString());
            request.File.Save(filePath + ".dcm");
            return new DicomCStoreResponse(request, DicomStatus.Success);
        }

        public void OnCStoreRequestException(string tempFileName, Exception e)
        {
            Logger.Error(tempFileName + "|" + e.Message);
        }

        public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
        {
            Logger.Info(source.ToString()+" Aborted for " +reason.ToString());
            base.SendAbort(source, reason);
        }

        public void OnReceiveAssociationReleaseRequest()
        {
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
