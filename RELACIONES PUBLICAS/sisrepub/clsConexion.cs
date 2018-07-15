using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SisRePub
{
    public static class clsConexion
    {
        public readonly static string ConectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RelacionesPublicas"].ConnectionString;
    }
}
