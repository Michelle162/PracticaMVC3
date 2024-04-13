using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica3.Models;

namespace Practica3.Controllers
{
	public class EquiposController1 : Controller
	{
        private readonly EquiposDbContext1 _EquiposDbContext1;

        public EquiposController1(EquiposDbContext1 EquiposDbContext1)
        {
            _EquiposDbContext1 = EquiposDbContext1;
        }

        public IActionResult Index()
		{
            //Tipo de equipos
            var listaTipoDeEquipos = (from t in _EquiposDbContext1.tipo_Equipo
                                      select t).ToList();
            ViewData["listadoTipoDeEquipos"] = new SelectList(listaTipoDeEquipos, "id_tipo_equipo", "descripcion", "estado");


            //Marcas
            var listaDeMarcas = (from m in _EquiposDbContext1.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            //Estado de equipo
            var listaEstadoDeEquipos = (from e in _EquiposDbContext1.estados_equipo
                                        select e).ToList();
            ViewData["listadoEstadoDeEquipos"] = new SelectList(listaEstadoDeEquipos, "id_estados_equipo", "descripcion", "estado");

            //Extraer listado de equipos
            var listadoDeEquipos = (from e in _EquiposDbContext1.equipos
                                    join m in _EquiposDbContext1.marcas on e.id_marcas equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.id_marcas,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["ListadoEquipo"] = listadoDeEquipos;

            return View();
		}
        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _EquiposDbContext1.Add(nuevoEquipo);
            _EquiposDbContext1.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
