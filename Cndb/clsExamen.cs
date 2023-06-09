using Cndb.modelos;
using Cndb.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cndb
{    
    public class clsExamen
    {
        public int tipo = 0;
        Servico db = new Servico();
        Procesos db_p = new Procesos();
        public clsExamen(int tipo) 
        {
            this.tipo = tipo;
        }
        public void cambiar_repositorio (int campo)
        {
            this.tipo = campo;
        }
        public Infoestatus Insertar(int Id, string Nombre, string Descripcion)
        {
            if (Id != null && Nombre != "" && Descripcion != "")
            {
                if (tipo == 1)
                {
                    return db.insertar(Id, Nombre, Descripcion);
                }
                else
                {
                    return db_p.insertar(Id, Nombre, Descripcion);
                }
            }
            else
            {
                return new Infoestatus
                {
                    Estado = false,
                    desc = "Error campos"
                };
            }

        }
        public Infoestatus Update(int Id, string Nombre, string Descripcion)
        {
            if (Id != null && Nombre != "" && Descripcion != "")
            {
                if (tipo == 1)
                {
                    return db.update(Id, Nombre, Descripcion);
                }
                else
                {
                    return db_p.update(Id, Nombre, Descripcion);
                }
            }
            else
            {
                return new Infoestatus
                {
                    Estado = false,
                    desc = "Error campos"
                };
            }

        }
        public Infoestatus Eliminar(int Id)
        {
            if (tipo == 1)
            {
                return db.eliminar(Id);
            }
            else
            {
                return db_p.eliminar(Id);
            }

        }
        public List<infotabla> Mostrar(string Nombre, string Descripcion)
        {
            if (Nombre != "" && Descripcion != "")
            {
                if (tipo == 1)
                {
                    return db.mostrar(Nombre, Descripcion);
                }
                else
                {
                    return db_p.mostrar(Nombre, Descripcion);
                }
            }
            else
            {
                return new List<infotabla>();
            }
        }

    }
}
