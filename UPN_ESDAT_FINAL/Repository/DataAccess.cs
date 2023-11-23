using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UPN_ESDAT_FINAL.Repository
{
    public class DataAccess<T> where T : new()
    {
        private string RutaArchivo { get; set; }
        private readonly char charSeparator = '|';

        public DataAccess(string nombreArchivo)
        {
            // Obtén la carpeta base de la aplicación
            string carpetaBase = AppDomain.CurrentDomain.BaseDirectory;

            // Combina la carpeta base con la ruta relativa al archivo
            this.RutaArchivo = carpetaBase + @"\Files\CSV\" + nombreArchivo + ".csv";

            //this.RutaArchivo = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\Data\" + nombreArchivo + ".csv");
        }

        // Agregar un nuevo elemento
        public void Crear(T nuevoElemento)
        {
            var entidades = ObtenerTodos();

            // Agrega el nuevo elemento a la lista
            entidades.Add(nuevoElemento);

            // Ahora, reescribe el archivo con las entidades actualizadas
            EscribirArchivo(entidades);
        }

        // Leer todos los elementos desde el archivo
        public List<T> Leer()
        {
            var entidades = new List<T>();

            try
            {
                entidades = ObtenerTodos();
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir al leer el archivo
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }

            return entidades;
        }

        // Actualizar un elemento basado en una condición
        public void Actualizar(Predicate<T> condicion, Action<T> actualizarPropiedades)
        {
            var entidades = ObtenerTodos();

            // Encuentra el índice del elemento que cumple con la condición
            var indice = entidades.FindIndex(condicion);

            if (indice != -1)
            {
                // Actualiza las propiedades utilizando el delegado de actualización
                actualizarPropiedades(entidades[indice]);

                // Ahora, reescribe el archivo con las entidades actualizadas
                EscribirArchivo(entidades);
            }
            else
            {
                Console.WriteLine("Elemento no encontrado para actualizar.");
            }
        }

        // Eliminar un objeto CSV del archivo
        // Eliminar un elemento basado en una condición
        public void Eliminar(Predicate<T> condicion)
        {
            var entidades = ObtenerTodos();
            var entidadesFiltradas = entidades.Where(e => !condicion(e)).ToList();

            // Ahora, reescribe el archivo con las entidades filtradas
            EscribirArchivo(entidadesFiltradas);
        }

        public int ContarRegistros()
        {
            return this.Contar();
        }

        // Convertir una línea de texto CSV a un objeto
        private T ConvertirCsvAObjeto(string linea)
        {
            // Divide la línea en valores utilizando la coma como delimitador
            var valores = linea.Split(charSeparator);

            // Crea una nueva instancia del tipo genérico T
            var entidad = new T();

            // Obtiene las propiedades de T
            var propiedades = typeof(T).GetProperties();

            // Itera sobre las propiedades
            for (int i = 0; i < propiedades.Length; i++)
            {
                // Obtiene la información de la propiedad actual
                var propInfo = propiedades[i];

                if (i > valores.Length - 1)
                {
                    propInfo.SetValue(entidad, null);
                }
                else
                {
                    // Obtiene el valor del campo actual y elimina cualquier espacio en blanco alrededor
                    var valor = valores[i].Trim();

                    // Comprueba el tipo de la propiedad y asigna el valor convertido
                    if (propInfo.PropertyType == typeof(int))
                    {
                        // Si la propiedad es de tipo int, convierte el valor a int y lo asigna
                        propInfo.SetValue(entidad, int.Parse(valor));
                    }
                    else if (propInfo.PropertyType == typeof(float))
                    {
                        // Si la propiedad es de tipo float, convierte el valor a float y lo asigna
                        propInfo.SetValue(entidad, float.Parse(valor));
                    }
                    else
                    {
                        // Si la propiedad es de otro tipo, asigna el valor como string
                        propInfo.SetValue(entidad, valor);
                    }
                }
            }

            // Devuelve la entidad creada y configurada
            return entidad;
        }

        // Obtiene todos los elementos de lista y los transforma en el modelo
        private List<T> ObtenerTodos()
        {
            // Lee todas las líneas del archivo y omite la primera línea si contiene encabezados
            var lineas = File.ReadAllLines(this.RutaArchivo, Encoding.GetEncoding("ISO-8859-1")).Skip(1);

            // Lista para almacenar las entidades
            var entidades = new List<T>();

            // Itera sobre cada línea del archivo
            foreach (var linea in lineas)
            {
                // Convierte la línea en una entidad utilizando el método ConvertirCsvAObjeto
                var entidad = ConvertirCsvAObjeto(linea);

                // Agrega la entidad a la lista
                entidades.Add(entidad);
            }

            // Devuelve la lista de entidades
            return entidades;
        }

        // Obtiene la cantidad de registros que existen en el archivo
        private int Contar()
        {
            // Lee todas las líneas del archivo y omite la primera línea si contiene encabezados
            var lineas = File.ReadAllLines(this.RutaArchivo).Skip(1);

            // se cuenta el total de la lineas
            return lineas.Count();
        }

        // Escribir la lista de entidades en el archivo
        private void EscribirArchivo(List<T> entidades)
        {
            var lineas = new List<string>();

            // Agregar la línea de encabezados
            var encabezados = string.Join(charSeparator.ToString(), typeof(T).GetProperties().Select(p => p.Name));
            lineas.Add(encabezados);

            // Agregar las líneas de datos
            foreach (var entidad in entidades)
            {
                var valores = typeof(T).GetProperties().Select(p => p.GetValue(entidad)?.ToString() ?? "");
                var linea = string.Join(charSeparator.ToString(), valores);
                lineas.Add(linea);
            }

            // Escribir en el archivo
            File.WriteAllLines(this.RutaArchivo, lineas, Encoding.UTF8);
        }
    }
}
