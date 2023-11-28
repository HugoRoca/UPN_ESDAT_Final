using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    // La clase BLMenu representa la lógica de negocios para la entidad 'Menu'.
    public class BLMenu
    {
        // El nombre del archivo asociado a la entidad 'Menu' para operaciones de lectura y escritura.
        private readonly string nombreArchivo = "Menu";

        // Instancia de la clase DataAccess parametrizada con el modelo 'MenuModel'.
        private readonly DataAccess<MenuModel> dataMenu;

        // Constructor de la clase BLMenu.
        public BLMenu()
        {
            // Se inicializa la instancia de DataAccess con el nombre del archivo asociado a 'MenuModel'.
            dataMenu = new DataAccess<MenuModel>(nombreArchivo);
        }

        // Método para obtener todos los elementos del menú.
        public List<MenuModel> Obtener()
        {
            // Utiliza el método Leer de la instancia de DataAccess para obtener todos los elementos del menú.
            return dataMenu.Leer();
        }
    }

}
