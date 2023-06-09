using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    BdiExamenEntities db = new BdiExamenEntities();

	public Estatus AgregarExamen(int Id, string Nombre, string Descripcion)
	{
		try
		{
			
 		   db.tblExamen.Add(new tblExaman{
				idExample= Id,
				Nombre = Nombre,
				Descripcion = Descripcion
            });
			db.SaveChanges();
			Estatus ST = new Estatus {
				Estado = true,
				desc = ""
			};
			return ST;

        }
		catch(Exception e)
		{
			Estatus ST = new Estatus
			{
				Estado = false,
				desc = e.Message.ToString()
            };
            return ST;
        }
	}
    public Estatus ActualizarExamen(int Id, string Nombre, string Descripcion)
    {
        try
        {

            var resul = db.tblExamen.Where(x => x.idExample == Id).FirstOrDefault();
            resul.Descripcion= Descripcion;
            resul.Nombre= Nombre;
            db.SaveChanges();
            Estatus ST = new Estatus
            {
                Estado = true,
                desc = ""
            };
            return ST;

        }
        catch (Exception e)
        {
            Estatus ST = new Estatus
            {
                Estado = false,
                desc = e.Message.ToString()
            };
            return ST;
        }
    }
    public Estatus EliminarExamen(int Id)
    {
        try
        {

            var resul = db.tblExamen.Find(Id);
            db.tblExamen.Remove(resul);
            db.SaveChanges();
            Estatus ST = new Estatus
            {
                Estado = true,
                desc = ""
            };
            return ST;

        }
        catch (Exception e)
        {
            Estatus ST = new Estatus
            {
                Estado = false,
                desc = e.Message.ToString()
            };
            return ST;
        }
    }
    public IEnumerable<tblExaman> ConsultarExamen(string Nombre, string Descripcion)
    {
        try
        {

            var resul = db.tblExamen.Where(x => x.Nombre == Nombre && x.Descripcion == Descripcion).ToList();
            return resul;

        }
        catch (Exception e)
        {
            List<tblExaman> resul = new List<tblExaman>();
            return resul;
        }
    }
}
