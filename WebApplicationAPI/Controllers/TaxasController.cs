using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    public class TaxasController : ApiController
    {
        /// <summary>
        /// Calcular o juros de um determinado valor.
        /// https://localhost:xxxx/api/Taxas
        /// 
        /// JSON:
        /// {
        ///     "Juros": 0.5,
        ///     "Valor": 10000
        /// }
        /// </summary>
        /// <param name="valores">Class Valores</param>
        /// <returns>Retorna o valor acrescido dos juros</returns>
        public HttpResponseMessage Post([FromBody]Valores valores)
            {
                if (valores == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                decimal Juros = valores.Juros / 100 * valores.Valor;

                decimal Resultado = Math.Round(valores.Valor + Juros, 2, MidpointRounding.AwayFromZero);

                var response = Request.CreateResponse(HttpStatusCode.OK, Resultado);

                return response;
            }
        }
}
