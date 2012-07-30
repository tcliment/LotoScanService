using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace LotoScanServices
{
    /// <summary>
    /// Basically this code is developed for HTTP GET, PUT, POST & DELETE operation.
    /// Based in article: http://www.codeproject.com/Articles/255684/Create-and-Consume-RESTFul-Service-in-NET-Framewor
    /// 
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RESTService: IRESTService
    {
        //Aunque desde es un DateTime, lo debemos capturar como string y realizar la conversion 
        public RespuestaListaPremios obtenerListaPremios(string diaDesde, string mesDesde, string anyoDesde)
        {
            return componerSetPrueba();
        }

        private RespuestaListaPremios componerSetPrueba()
        {
            RespuestaListaPremios result = new RespuestaListaPremios
            {
                Codigo = CodigoRespuesta.Correcto,
                ultimaActualizacion = DateTime.Now,
                listaPremios = new List<PremioInfo>{
                     new PremioInfo{ numero="123456", tipoSorteo=1, fechaSorteo=new DateTime(2012,1,1), categoriaPremio=1, serie="0012"},
                     new PremioInfo{ numero="789012", tipoSorteo=1, fechaSorteo=new DateTime(2012,2,1), categoriaPremio=2, serie="0034"},
                     new PremioInfo{ numero="345678", tipoSorteo=2, fechaSorteo=new DateTime(2012,3,1), categoriaPremio=3, serie="0056"},
                     new PremioInfo{ numero="901234", tipoSorteo=2, fechaSorteo=new DateTime(2012,4,1), categoriaPremio=4, serie="0078"},
                 }
            };

            return result;
        }

        public RespuestaFechaUltimaActualizacion obtenerFechaListaDePremios()
        {
            return new RespuestaFechaUltimaActualizacion
            {
                Codigo = CodigoRespuesta.Correcto,
                ultimaActualizacion = new DateTime(2012,6,22)
            };
        }
    }
}