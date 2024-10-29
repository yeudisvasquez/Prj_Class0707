﻿using Prj_Class0707.Datos;
using Prj_Class0707.Modelo;
using Prj_Class0707.Vistas.Maestras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prj_Class0707.VistaModelo
{
    public class MVMaestra_Doctores : BaseModelo
    {
        #region Atributos
        //Campos Modelo

        public string Cedula;
        public string Direccion;
        public string DoctorId;
        public string Estatus;
        public string FechaNaci;
        public string NombreApellido;
        public string PaisId;
        public string Telefono;


        //Botones
        public bool isenebledcrear;
        public bool isenebledmodificar;
        public bool isenebledguardar = true;
        public bool isenebledcancelar = true;
        public bool isenebledborrar;

        //Otros
        public bool chkestado;
        public System.Drawing.Color colorfondoid;
        public bool isrefrescar = false;
        public object listaespecialidades;
        public bool correrbarra;
        public bool isvisible = false;
        #endregion

        #region propiedades

        #region Campos Modelo

        public string txtidespecialidad
        {
            get { return DoctorId; }
            set { SetValue(ref DoctorId, value); }
        }
        public string txtespecialidad
        {
            get { return NombreApellido; }
            set { SetValue(ref NombreApellido, value); }
        }
        public string txtestado
        {
            get { return Estatus; }
            set { SetValue(ref Estatus, value); }
        }

        public string txtfecharegistro
        {
            get { return FechaNaci; }
            set { SetValue(ref FechaNaci, value); }
        }
        #endregion

        #region Botones

        public bool IsEnebledCrear
        {
            get { return isenebledcrear; }
            set { SetValue(ref isenebledcrear, value); }
        }
        public bool IsEnebledModificar
        {
            get { return isenebledmodificar; }
            set { SetValue(ref isenebledmodificar, value); }
        }
        public bool IsEnebledGuardar
        {
            get { return isenebledguardar; }
            set { SetValue(ref isenebledguardar, value); }
        }
        public bool IsEnebledCancelar
        {
            get { return isenebledcancelar; }
            set { SetValue(ref isenebledcancelar, value); }
        }
        public bool IsEnebledBorrar
        {
            get { return isenebledborrar; }
            set { SetValue(ref isenebledborrar, value); }
        }
        #endregion

        #region Otros

        public System.Drawing.Color ColorFondoId
        {
            get { return colorfondoid; }
            set { SetValue(ref colorfondoid, value); }
        }
        public bool ChkEstadoValidar
        {
            get { return chkestado; }
            set { SetValue(ref chkestado, value); }
        }
        public bool IsRefrescar
        {
            get { return isrefrescar; }
            set { SetValue(ref isrefrescar, value); }
        }
        public object ListaEspecialidades
        {
            get { return listaespecialidades; }
            set { SetValue(ref listaespecialidades, value); }
        }
        public bool CorrerBarra
        {
            get { return correrbarra; }
            set { SetValue(ref correrbarra, value); }
        }
        public bool IsVisible
        {
            get { return isvisible; }
            set { SetValue(ref isvisible, value); }
        }
        #endregion

        #endregion

        #region Comandos

        public Command RefrescarCommand { get; }
        public Command SelecionarProveedorCommand { get; }
        public Command CrearCommand { get; }
        public Command ModificarCommand { get; }
        public Command GuardarCambiosCommand { get; }
        public Command CancelarCommand { get; }
        public Command BorrarCommand { get; }
        public Command Ir_CrearProveedorCommand { get; }
        public Command VolverCommand { get; }
        #endregion

        #region Metodos

        //Creamos una instancia de:
        Ddoctores db = new Ddoctores();
        //DBmedicos dbmedico = new DBmedicos();
        //DBAlmacenes dbalmacen = new DBAlmacenes();

        public ObservableCollection<MDoctores> especialidadcollection = new ObservableCollection<MDoctores>();

        private async Task TestListViewBindingAsync()
        {
            var lista = new List<MDoctores>();
            {
                var funcion = new Ddoctores();
                lista = await funcion.ListarEspecialidades();
            }
            foreach (var item in lista)
            {
                especialidadcollection.Add(item);
            }
        }


        public async Task ListarEspecialidades()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            ListaEspecialidades = await db.ListarEspecialidades();
            IsRefrescar = false;
        }
        public async Task Buscar_En_Ddoctores()
        {
            List<MDoctores> Listprov = await db.ListarEspecialidades();
            foreach (var encontrado in Listprov)
            {
                especialidadcollection.Add(encontrado);
            }
        }

        public async Task Crear()
        {
            List<MDoctores> registros = await db.ListarEspecialidades();
            int cant_registros = registros.Count();
            int IdGenerado;
            if (cant_registros == 0)
                IdGenerado = 1;
            else
                IdGenerado = cant_registros + 1;

            txtidespecialidad = string.Format("D{0:000}", IdGenerado);
            txtespecialidad = "";
            txtestado = "";
            txtfecharegistro = DateTime.Now.Date.ToString("dd-MMM-yyy");

            ColorFondoId = System.Drawing.Color.LightGreen;
            IsEnebledModificar = false;
            IsEnebledCrear = false;
            IsEnebledBorrar = false;
            IsEnebledCancelar = true;
            IsEnebledGuardar = true;
        }
        public async Task GuardarCambios()
        {
            try
            {

                if (ColorFondoId == System.Drawing.Color.Transparent)
                {
                    await App.Current.MainPage.DisplayAlert("Información", "No existen datos que guardar.", "Aceptar");
                    return;
                }
                #region Reglas para la insercion de los datos
                if (string.IsNullOrEmpty(txtespecialidad))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar la especialidad.", "Aceptar");
                    return;
                }
                if (ChkEstadoValidar == true)
                    Estatus = "Inactivo";
                else
                    Estatus = "Activo";
                #endregion

                //Instanciamos el modelo para obtener los datos introducidos por el usuario
                var obj = new MDoctores
                {
                    DoctorId = DoctorId,
                    NombreApellido = NombreApellido,
                    Estatus = Estatus,
                    FechaNaci = FechaNaci
                };

                if (ColorFondoId == System.Drawing.Color.LightGreen)
                {
                    if (obj.Estatus == "Inactivo")
                    {
                        await App.Current.MainPage.DisplayAlert("Advertencia", "No puede insertar una especialidad como inactivo.", "Aceptar");
                    }
                    else
                    {
                        CorrerBarra = true;
                        IsVisible = true;
                        await Task.Delay(1000);

                        bool respuesta = await db.InsertarClientes(obj);

                        CorrerBarra = false;
                        IsVisible = false;
                        if (respuesta == true)
                        {
                            ColorFondoId = System.Drawing.Color.Transparent;
                            IsEnebledCancelar = false;
                            IsEnebledGuardar = false;
                            IsEnebledCrear = true;
                            IsEnebledModificar = true;
                            IsEnebledBorrar = true;
                            await App.Current.MainPage.DisplayAlert("Información", "Datos registrados exitosamente.", "Aceptar");
                            await Navigation.PushAsync(new AgregarModificar_DoctoresPage());
                        }
                        //else
                        //{
                        //    await App.Current.MainPage.DisplayAlert("Advertencia", mensaje, "Aceptar");
                        //}
                    }
                }
                else
                {
                    CorrerBarra = true;
                    IsVisible = true;
                    await Task.Delay(1000);

                    bool respuesta = await db.ActualizarCliente(obj);

                    CorrerBarra = false;
                    IsVisible = false;
                    if (respuesta == true)
                    {
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos modificados exitosamente.", "Aceptar");
                        await App.Current.MainPage.Navigation.PushAsync(new AgregarModificar_DoctoresPage());
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Advertencia", mensaje, "Aceptar");
            }
        }

        //public async Task Borrar()
        //{
        //    try
        //    {
        //        List<Mmedicos> ListEspObtenida = await dbmedico.ListarMedicos();
        //        var objespecialidad = new Mespecialidad()
        //        {
        //            Id_Especialidad = id_especialidad
        //        };

        //        if (string.IsNullOrEmpty(txtidespecialidad))
        //        {
        //            await App.Current.MainPage.DisplayAlert("Información", "Debe seleccionar una especialidad.", "Aceptar");
        //        }
        //        else
        //        {
        //            string respuesta = await App.Current.MainPage.DisplayActionSheet("¿Seguro que desea borrar esta especialidad?", "Cancelar", null, "Si", "No");
        //            if (respuesta == "Si")
        //            {
        //                bool relacion = ListEspObtenida.Select(r => r.Especialidad.Id_Especialidad == objespecialidad.Id_Especialidad).FirstOrDefault();
        //                if (relacion == true)
        //                {
        //                    await App.Current.MainPage.DisplayAlert("Advertecia", "No se puede borrar una especialidad que esté relacionada a un doctor.", "Aceptar");
        //                }
        //                else
        //                {
        //                    CorrerBarra = true;
        //                    IsVisible = true;
        //                    await Task.Delay(1000);

        //                    await db.BorrarEspecialidad(objespecialidad);

        //                    CorrerBarra = false;
        //                    IsVisible = false;
        //                    ColorFondoId = System.Drawing.Color.Transparent;
        //                    ChkEstadoValidar = false;
        //                    IsEnebledCancelar = false;
        //                    IsEnebledGuardar = false;
        //                    await App.Current.MainPage.DisplayAlert("Información", "Datos borrados exitosamente.", "Aceptar");
        //                    await App.Current.MainPage.Navigation.PushAsync(new AgregarModificar_DoctoresPage());
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
        //    }
        //}

        public async Task Cancelar()
        {
            if (ColorFondoId == System.Drawing.Color.LightGreen)
            {
                txtidespecialidad = "";
                txtespecialidad = "";
                txtestado = "";
                txtfecharegistro = "";
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsEnebledBorrar = true;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
            }
            else
            {
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsEnebledBorrar = true;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
            }
        }
        //public List<OpcionCombo> DatosEstado()
        //{
        //    var estado = new List<OpcionCombo>()
        //    {
        //        new OpcionCombo(){ IdPos = 0, Texto="Activo" },
        //        new OpcionCombo(){ IdPos = 1, Texto ="Inactivo" }
        //    };
        //    return estado;
        //}

        public async Task NavegarEspecialidad()
        {
            await Navigation.PushAsync(new MaestraDoctores());
            //await Navigation.PushAsync(new EspecialidadMaestra());

        }


        public async Task Ir_CrearEspecialidad()
        {
            //await Navigation.PushAsync(new EspecialidadMaestra());
            await Navigation.PushAsync(new MaestraDoctores());
            _ = Crear();
        }
        public async Task Volver()
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }

        #endregion

        #region Constructor

        public MVMaestra_Doctores(INavigation navegar)
        {
            Navigation = navegar;


            NavegarEspecialidadCommand = new Command(async () => await NavegarEspecialidad());
            //Controlar estados al iniciar el componente
            ColorFondoId = System.Drawing.Color.Transparent;

            IsEnebledGuardar = false;
            IsEnebledCancelar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = false;
            IsEnebledBorrar = false;

            RefrescarCommand = new Command(async () => await ListarEspecialidades());
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            //ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => await Cancelar());
            //BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());


            //este va
            //Ir_CrearProveedorCommand = new Command(async () => await Ir_CrearProveedor());


            //PkEstado = DatosEstado().OrderBy(e => e.Texto).ToList();
            _ = ListarEspecialidades();
            _ = TestListViewBindingAsync();
            _ = Crear();
            //Buscar_En_DBProveedores();
        }

        //Creamos un segundo constructor de la misma clase, para poder cargar los datos seleccionados en la clase ListaProveedores.xaml.cs
        public MVMaestra_Doctores(MDoctores obj)
        {
            //Cargar datos del id seleccionado
            txtidespecialidad = obj.DoctorId;
            txtespecialidad = obj.NombreApellido;
            txtestado = obj.Estatus;
            txtfecharegistro = obj.FechaNaci;
            if (obj.Estatus == "Inactivo")
                ChkEstadoValidar = true;
            else
                ChkEstadoValidar = false;

            //Controlar estados al iniciar el componente
            ColorFondoId = System.Drawing.Color.Orange;
            IsEnebledGuardar = false;
            IsEnebledCancelar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;

            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            //ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => await Cancelar());
            //BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());
            //PkEstado = DatosEstado().OrderBy(e => e.Texto).ToList();
            _ = ListarEspecialidades();
        }

        public MVMaestra_Doctores(INavigation navigation
    , MDoctores esp = null)
        {

            txtidespecialidad = esp.DoctorId;
            txtespecialidad = esp.NombreApellido;
            txtestado = esp.Estatus;
        }

        public Command NavegarEspecialidadCommand { get; }

        #endregion

    }

}
