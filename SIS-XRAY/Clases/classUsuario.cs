﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    class ClsUsuario//prueba
    {
        private static string strusuario;
        private static string strNombre;
        private string intId_Usuario;
        private static int intId_perfil;
        private static string strContraseña;
        public  string Id_Usuario
        {
            get
            {
                return intId_Usuario;
            }
            set
            {
                intId_Usuario = value;  // value is an implicit parameter
            }

        }

        public    string Usuario
            {
                get
                {
                    return strusuario;
                }
                set
                {
                    strusuario = value;  // value is an implicit parameter
                }

            }

        public  string Nombre
            {
                get
                {
                    return strNombre;
                }
                set
                {
                    strNombre = value;  // value is an implicit parameter
                }

            }

        public  int Id_perfil { get => intId_perfil; set => intId_perfil = value; }
        public  string Contraseña { get => strContraseña; set => strContraseña = value; }
    }

}