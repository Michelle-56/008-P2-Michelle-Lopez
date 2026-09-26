
    using System;
    using System.Collections.Generic;

    namespace RegistroBiblioteca
    {
        class Libro
        {
            public string Id { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public bool Disponible { get; set; } = true;
        }

        class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        class Biblioteca
        {
            private List<Libro> libros = new List<Libro>();
            private List<Usuario> usuarios = new List<Usuario>();

            public void AgregarLibro(string id, string titulo, string autor)
            {
                libros.Add(new Libro { Id = id, Titulo = titulo, Autor = autor });
                Console.WriteLine("Libro registrado con éxito.");
            }

            public void RegistrarUsuario(int id, string nombre)
            {
                usuarios.Add(new Usuario { Id = id, Nombre = nombre });
                Console.WriteLine("Usuario registrado con éxito.");
            }

            public void MostrarLibros()
            {
                Console.WriteLine("\n--- Lista de Libros ---");
                foreach (var libro in libros)
                {
                    string estado = libro.Disponible ? "Disponible" : "Prestado";
                    Console.WriteLine($"ID: {libro.Id} | Título: {libro.Titulo} | Autor: {libro.Autor} | Estado: {estado}");
                }
            }

            public void PrestarLibro(string libroId, int usuarioId)
            {
                var libro = libros.Find(l => l.Id == libroId);
                var usuario = usuarios.Find(u => u.Id == usuarioId);

                if (libro == null)
                {
                    Console.WriteLine("Libro no encontrado.");
                    return;
                }

                if (usuario == null)
                {
                    Console.WriteLine("Usuario no encontrado.");
                    return;
                }

                if (!libro.Disponible)
                {
                    Console.WriteLine("El libro ya está prestado.");
                    return;
                }

                libro.Disponible = false;
                Console.WriteLine($"El libro '{libro.Titulo}' fue prestado a {usuario.Nombre}.");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Biblioteca biblio = new Biblioteca();

               
                biblio.AgregarLibro("L01", "Cien años de soledad", "Gabriel García Márquez");
                biblio.RegistrarUsuario(1, "Ana Pérez");

                biblio.MostrarLibros();

                biblio.PrestarLibro("L01", 1);

                biblio.MostrarLibros();
            }
        }
    }
