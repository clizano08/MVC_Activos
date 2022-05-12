using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class AseguradorBL
    {
        public AseguradorEL GetAseguradorById(int pIdAsegurador)
        {
            AseguradorDB aseguradorDB = new AseguradorDB();
            return aseguradorDB.GetAseguradorById(pIdAsegurador);
        }
        public List<AseguradorEL> GetAllAsegurador()
        {
            AseguradorDB aseguradorDB = new AseguradorDB();
            return aseguradorDB.GetAllAsegurador();
        }
        public AseguradorEL InsertAsegurador(AseguradorEL pAsegurador)
        {
            AseguradorDB AseguradorDB = new AseguradorDB();
            return AseguradorDB.InsertAsegurador(pAsegurador);
        }
        public AseguradorEL UpdateAsegurador(AseguradorEL pAsegurador)
        {
            AseguradorDB AseguradorDB = new AseguradorDB();
            return AseguradorDB.UpdateAsegurador(pAsegurador);
        }
        public bool DeleteAsegurador(int pIdAsegurador)
        {
            AseguradorDB aseguradorDB = new AseguradorDB();
            return aseguradorDB.DeleteAsegurador(pIdAsegurador);
        }
    }
}
