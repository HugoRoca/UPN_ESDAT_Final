using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UPN_ESDAT_FINAL.Common
{
    public class CsvReader<T> where T : class
    {
        // Método para leer un archivo CSV y convertirlo en una lista de objetos de tipo T
        // T => Dinamico, quiere decir que puede recibir cualquier clase con atributos
        public static List<T> LeerArchivoCSV(string rutaArchivo)
        {
            var lista = new List<T>();

            try
            {
                // Leer todas las líneas del archivo CSV
                var lineas = File.ReadAllLines(rutaArchivo);

                // Verificar si el archivo está vacío
                if (lineas.Length == 0) return lista;

                // Obtener los encabezados del archivo CSV desde la primera línea
                var encabezados = lineas[0].Split(',');

                // Iterar sobre cada línea del archivo a partir de la segunda línea
                for (int i = 1; i < lineas.Length; i++)
                {
                    // Dividir los valores de la línea actual usando la coma como separador
                    var valores = lineas[i].Split(',');

                    // Crear una nueva instancia del objeto tipo T
                    var objeto = Activator.CreateInstance<T>();

                    // Iterar sobre cada encabezado y asignar el valor correspondiente a la propiedad
                    for (int j = 0; j < encabezados.Length; j++)
                    {
                        // Obtener la propiedad correspondiente al encabezado
                        var propiedad = typeof(T).GetProperty(encabezados[j].Trim());

                        // Verificar si la propiedad existe en la clase T
                        if (propiedad != null)
                        {
                            // Convertir y asignar el valor a la propiedad
                            var valor = Convert.ChangeType(valores[j].Trim(), propiedad.PropertyType);
                            propiedad.SetValue(objeto, valor);
                        }
                    }

                    // Agregar el objeto a la lista
                    lista.Add(objeto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
