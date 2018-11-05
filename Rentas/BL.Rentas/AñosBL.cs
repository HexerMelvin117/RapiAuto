using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class AñosBL
    {
         Contexto _contexto;

        public BindingList<Año> ListaAños { get; set; }

        public AñosBL()
        {
            _contexto = new Contexto();
            ListaAños = new BindingList<Año>();
        }

        public BindingList<Año> ObtenerAño()
        {
            _contexto.Años.Load();
            ListaAños = _contexto.Años.Local.ToBindingList();

            return ListaAños;
        }
    }
    public class Año
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}