using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LotoScanServices
{
    #region IRESTService Interface
    [ServiceContract]
    public interface IRESTService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "obtenerListaPremios?diaDesde={diaDesde}&mesDesde={mesDesde}&anyoDesde={anyoDesde}", Method = "GET")]
        RespuestaListaPremios obtenerListaPremios(string diaDesde, string mesDesde, string anyoDesde);

        [OperationContract]
        [WebInvoke(UriTemplate = "obtenerFechaListaDePremios", Method = "GET")]
        RespuestaFechaUltimaActualizacion obtenerFechaListaDePremios();        
    }

    #endregion

    #region DataContracts
    #region CodigoRespuesta
    [DataContract]
    public enum CodigoRespuesta
    {
        [EnumMember]
        Correcto = 1,                       // Success = 1, 
        [EnumMember]
        ErrorDesconocido = -1,              //Error = -1,        
        [EnumMember]
        TokenUsuarioNoEncontrado = -2,      //InvalidToken = -2,
        [EnumMember]
        TokenUsuarioCaducado = -3,          //ExpiredToken = -3,
        [EnumMember]
        CredencialIncorrecta = -4,          //InvalidUser = -4,       
        [EnumMember]
        ErrorValidacion = -5,
        [EnumMember]
        FormatoIncorrecto = -6,
        [EnumMember]
        ListaPremiosVacia = -7,
    }
    #endregion
    #region Respuesta
    [DataContract]
    public abstract class Respuesta
    {
        [DataMember]
        public CodigoRespuesta Codigo { get; set; }
        [DataMember]
        public String TextoRespuesta { get; set; }
    }
    #endregion
    #region PremioInfo
    [DataContract]
    public class PremioInfo
    {
        [DataMember]
        public string numero { get; set; }
        [DataMember]
        public string serie { get; set; }
        [DataMember]
        public int tipoSorteo { get; set; }
        [DataMember]
        public DateTime fechaSorteo { get; set; }
        [DataMember]
        public int categoriaPremio { get; set; }
    }
    #endregion
    #region RespuestaFechaUltimaActualizacion
    [DataContract]
    public class RespuestaFechaUltimaActualizacion : Respuesta
    {
        [DataMember]
        public DateTime ultimaActualizacion{ get; set; }
    }
    #endregion
    #region RespuestaListaPremios
    [DataContract]
    public class RespuestaListaPremios : Respuesta
    {
        [DataMember]
        public DateTime ultimaActualizacion { get; set; }
        [DataMember]
        public List<PremioInfo> listaPremios { get; set; }
    }
    #endregion

    /*
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
     */
    #endregion
        
}
