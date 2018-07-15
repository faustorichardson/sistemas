using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SisGesEntrenamiento
{
    public static class clsConexion
    {
        public readonly static string ConectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Entrenamiento"].ConnectionString;
    }
}
