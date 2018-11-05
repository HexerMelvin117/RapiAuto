using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            // Datos de inicio para usuarios
            var usuarioAdmin = new Usuario();
            usuarioAdmin.Nombre = "admin";
            usuarioAdmin.Contrasena = "123";

            contexto.Usuarios.Add(usuarioAdmin);

            // Datos de inicio para categorias
            var categoria1 = new Categoria();
            categoria1.Descripcion = "Acción y Aventura";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Deportes";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Disparo";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Educativos";
            contexto.Categorias.Add(categoria4);

            // Datos de inicio clientes
            var cliente1 = new Cliente();
            cliente1.Nombre = "Cliente de prueba";
            contexto.Clientes.Add(cliente1);

            // Datos de inicio tipos

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Sedan";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Pick Up";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Camioneta";
            contexto.Tipos.Add(tipo3);

            var tipo4 = new Tipo();
            tipo4.Descripcion = "Van";
            contexto.Tipos.Add(tipo4);

            var tipo5 = new Tipo();
            tipo5.Descripcion = "Mini Van";
            contexto.Tipos.Add(tipo5);

            var tipo6 = new Tipo();
            tipo6.Descripcion = "Furgon";
            contexto.Tipos.Add(tipo6);

            var tipo7 = new Tipo();
            tipo7.Descripcion = "Camion";
            contexto.Tipos.Add(tipo7);

            var tipo8 = new Tipo();
            tipo8.Descripcion = "Panel";
            contexto.Tipos.Add(tipo8);

            var tipo9 = new Tipo();
            tipo9.Descripcion = "Autobus";
            contexto.Tipos.Add(tipo9);

            var tipo10 = new Tipo();
            tipo10.Descripcion = "Tractor";
            contexto.Tipos.Add(tipo10);

            var tipo11 = new Tipo();
            tipo11.Descripcion = "Otros";
            contexto.Tipos.Add(tipo11);

            base.Seed(contexto);
        }
    }
}
