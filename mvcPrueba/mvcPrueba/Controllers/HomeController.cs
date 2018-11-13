using mvcPrueba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mvcPrueba.Controllers
{
    public class HomeController : Controller
    {

        /*Controlador asyncronico que comunica con api y trae listado que poteriormente
         es convertido de un objeto json a una lista y enviada a la vista

            la variable url fue incorporada en el web config del proyecto en un appsetting

             */
        public async Task<ActionResult> Index()
        {
           
            string url = ConfigurationManager.AppSettings["UrlApi"].ToString();
            var httpClient = new HttpClient();
            var lista = await httpClient.GetStringAsync(url);
            var modelo_lista = JsonConvert.DeserializeObject<List<Models.modelo_lista>>(lista);
            return View(modelo_lista);
        }


        //sin usar
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        //metodo retorna Detalle cliente
        public ActionResult DetalleCliente(int id, string Nom, string ci, string ad, string e, string FeR)
        {

            //ViewBag.Message = 
            //ViewBag.Message = ;
            //ViewBag.Message = ;
            //ViewBag.Message = "Estado: " + e.ToString();
            //ViewBag.Message = "Fecha registro: " + FeR.ToString();

            IList<modelo_lista> lista = new List<modelo_lista>();
            modelo_lista l = new modelo_lista();
            l.id = id;
            l.nombre = Nom;
            l.ciudad = ci;
            l.direccion = ad;
            l.estado = e;
            l.fecha_registro = FeR;

            lista.Add(l);

            ViewData["lista"] = lista;


            return View();
            //return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = FeR });
        }


        public ActionResult DetalleUsuario(string codigo)
        {

            ViewBag.Message = "estas aqui." ;
            return View();
        }

     


    }
}