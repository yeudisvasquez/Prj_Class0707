using Firebase.Database.Query;
using Prj_Class0707.Conexion;
using Prj_Class0707.Modelo;
using Prj_Class0707.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Class0707.Datos
{
    public class Ddoctores
    {
        public async Task<List<MDoctores>> ListarEspecialidades()
        {
            try
            {
                return (await FirebaseDBConexion.FireBase_Connect
                    .Child("Doctor")
                    .OrderByKey()
                    .OnceAsync<MDoctores>())
                    .Select(datos => new MDoctores
                    {
                        IdDoctorFirebase = datos.Key,
                        DoctorId = datos.Object.DoctorId,
                        NombreApellido = datos.Object.NombreApellido,
                        Estatus = datos.Object.Estatus,
                        FechaNaci = datos.Object.FechaNaci
                    }).ToList();
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");
                return null;
            }
        }

        public async Task<bool> InsertarClientes(MDoctores parametros)
        {
            await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .PostAsync(new MDoctores()
                {
                    Cedula = parametros.Cedula,
                    Direccion = parametros.Direccion,
                    Estatus = parametros.Estatus,
                    DoctorId = parametros.DoctorId,
                    FechaNaci = parametros.FechaNaci,
                    NombreApellido = parametros.NombreApellido,
                    PaisId = parametros.PaisId,
                    Telefono = parametros.Telefono

                });
            return true;
        }

        public async Task<List<MDoctores>> MostrarDoctores()
        {
            return (await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .OrderByKey()
                .OnceAsync<MDoctores>())
                .Where(a => a.Object.Estatus == "ACTIVO")
                .Select(item => new MDoctores
                {
                    Cedula = item.Key,
                    Direccion = item.Object.Direccion,
                    DoctorId = item.Object.DoctorId,
                    Estatus = item.Object.Estatus,
                    FechaNaci = item.Object.FechaNaci,
                    NombreApellido = item.Object.NombreApellido,
                    PaisId = item.Object.PaisId
                }).ToList();
        }

        public async Task<bool> ActualizarCliente(MDoctores obj)
        {
            try
            {
                var actualizarcliente = (await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .OnceAsync<MDoctores>())
                //.Where(a => a.Key == para.DoctorId)
                .Where(a => a.Object.DoctorId == obj.DoctorId)
                .FirstOrDefault();

            await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .Child(actualizarcliente.Key)
                .PutAsync(new MDoctores()
                {
                    DoctorId = obj.DoctorId,
                    Cedula = obj.Cedula,
                    Direccion = obj.Direccion,
                    Estatus = obj.Estatus,
                    FechaNaci = obj.FechaNaci,
                    NombreApellido = obj.NombreApellido,
                    PaisId = obj.PaisId,
                    Telefono = obj.Telefono
                });
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return false;
            }
        }
        public async Task<bool> EliminarCliente(MDoctores parametros)
        {
            string codi = parametros.DoctorId;
            var dataEliminar = (await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .OnceAsync<MDoctores>())
            .Where(a => a.Key == codi) //parametros.Idcliente)
                .FirstOrDefault();

            await FirebaseDBConexion.FireBase_Connect
                .Child("Doctor")
                .Child(dataEliminar.Key)
                .DeleteAsync();
            return true;
        }

    }
}
