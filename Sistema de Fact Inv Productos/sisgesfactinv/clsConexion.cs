﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SisGesFactInv
{
    public static class clsConexion
    {
        public readonly static string ConectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Ventas"].ConnectionString;        
    }
}
