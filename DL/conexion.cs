﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()//Buscar la cadena de conexión
        {
            return ConfigurationManager.ConnectionStrings["KGuzmanProgramacionNCapas"].ConnectionString.ToString();
        }
    }
}
