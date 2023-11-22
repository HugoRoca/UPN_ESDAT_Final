using System.Collections.Generic;
using UPN_ESDAT_FINAL.Model;
using UPN_ESDAT_FINAL.Repository;

namespace UPN_ESDAT_FINAL.BusinessLogic
{
    public class BLMenu
    {
        private readonly string nombreArchivo = "Menu";
        private readonly DataAccess<MenuModel> dataMenu;

        public BLMenu()
        {
            dataMenu = new DataAccess<MenuModel>(nombreArchivo);
        }

        public List<MenuModel> Obtener()
        {
            return dataMenu.Leer();
        }
    }
}
