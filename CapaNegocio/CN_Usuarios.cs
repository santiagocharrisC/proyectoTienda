using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();

        public List<Usuarios> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Nombres))
            {
                Mensaje = "El Nombre del Usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Apellidos))
            {
                Mensaje = "El Apellido del Usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje = "El Correo del Usuario no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave = CN_Recursos.GenerarClave();

                string asunto = "Cuenta Creada";
                string mensaje_correo = "<h3> Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.Correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = CN_Recursos.ConvertirShar256(clave);
                    return objCapaDato.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "no se puede enviar el correo";
                    return 0;
                }

            }
            else
            {
                return 0;
            }
        }



        public bool Editar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Nombres))
            {
                Mensaje = "El Nombre del Usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Apellidos))
            {
                Mensaje = "El Apellido del Usuario no puede estar vacio";
            }
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrEmpty(obj.Correo))
            {
                Mensaje = "El Correo del Usuario no puede estar vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
