using LibrosBiblicos.Entidades;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System;
using System.Data.Entity;

namespace LibrosBiblicos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Libros> Libro { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
