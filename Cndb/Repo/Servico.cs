using Cndb.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cndb.Repo
{
    public class Servico
    {
        public Servico() { }

        public Infoestatus insertar(int Id, string Nombre, string Descripcion)
        {
            using (WsApiexamen.ServiceClient cliente = new WsApiexamen.ServiceClient())
            {
                var resul = cliente.AgregarExamen(Id, Nombre, Descripcion);
                Infoestatus agregar = new Infoestatus { 
                    Estado= resul.Estado,
                    desc = resul.desc
                };
                return agregar;
            }
        }
        public Infoestatus update(int Id, string Nombre, string Descripcion)
        {
            using (WsApiexamen.ServiceClient cliente = new WsApiexamen.ServiceClient())
            {
                var resul = cliente.ActualizarExamen(Id, Nombre, Descripcion);
                Infoestatus agregar = new Infoestatus
                {
                    Estado = resul.Estado,
                    desc = resul.desc
                };
                return agregar;
            }
        }
        public Infoestatus eliminar(int Id)
        {
            using (WsApiexamen.ServiceClient cliente = new WsApiexamen.ServiceClient())
            {
                var resul = cliente.EliminarExamen(Id);
                Infoestatus agregar = new Infoestatus
                {
                    Estado = resul.Estado,
                    desc = resul.desc
                };
                return agregar;
            }
        }

        public List<infotabla> mostrar(string Nombre, string Descripcion)
        {
            using (WsApiexamen.ServiceClient cliente = new WsApiexamen.ServiceClient())
            {
                var resul = cliente.ConsultarExamen(Nombre, Descripcion);
                List<infotabla> infotablas = new List<infotabla>();
                foreach(var info in resul)
                {
                    infotablas.Add(new infotabla
                    {
                        idExample= info.idExample,
                        Nombre= info.Nombre,
                        Descripcion = info.Descripcion
                    });
                }

                return infotablas;
            }
        }
    }
}
