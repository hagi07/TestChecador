﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checador
{
    public partial class PanelDatosPersonal : Form
    {
        private string usuario;
        private int  opcion;


        public PanelDatosPersonal(int opcion, string usuario, string nombre, string emailLaboral, string emailPersonal)
        {
            InitializeComponent();
            
            this.usuario = usuario;
            textBoxNombre.Text = nombre;
            textBoxEmailLaboral.Text = emailLaboral;
            textBoxEmailPersonal.Text = emailPersonal;
            this.opcion = opcion;

            if (opcion == 1) {
                reordenarDatos();
            }

        }

        private void reordenarDatos() {
            
            System.IO.StreamReader fileReader = new System.IO.StreamReader("BDP_ELYON.elyon");
            string espacios = fileReader.ReadToEnd();
            fileReader.Close();

            string[] x = espacios.Split('\n');

            for (int i = 0; i < x.Length; i++)
            {
                string[] y = x[i].Split('|');
                if (y[0] == usuario)
                {
                   textBoxNombre.Text = y[1];
                   textBoxCURP.Text = y[2];
                   textBoxRFC.Text = y[3];
                   textBoxCelular.Text = y[4];
                   textBoxTelefono.Text = y[5];
                   textBoxDireccion.Text = y[6];
                   if (y[7] == "Masculino") radioButtonMasculino.Checked = true;
                   if (y[7] == "Femenino") radioButtonFemenino.Checked = true; 
                   textBoxLugarDeNacimiento.Text = y[8];
                   textBoxNacFecha1.Text = y[9];
                   textBoxNacFecha2.Text = y[10];
                   textBoxNacFecha3.Text = y[11];
                   textBoxEdad.Text = y[12];
                   textBoxEmailLaboral.Text = y[13];
                   textBoxEmailPersonal.Text = y[14];
                   textBoxTipoDeSangre.Text = y[15];
                   textBoxNumeroDeEmergencia.Text = y[16];
                   textBoxContactoDeEmergencia.Text = y[17];
                   textBoxParentesco.Text  = y[18];
                   textBoxDireccionDelContacto.Text = y[19];
                   textBoxOtrasOcupaciones.Text = y[20];
                   textBoxOtrasOcupaciones.Text = y[21];
                   textBoxEstadoCivil.Text = y[22];
                   textBoxStatusFamiliar.Text = y[23];
                }
            }
        }

        private void buttonImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Title = "Abrir";
            ac.Filter = "Documento JPG|*.jpg";

            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBoxImagen.Image = Image.FromFile(ac.FileName);
            }
        }

        private void PanelDatosPersonal_Load(object sender, EventArgs e)
        {

        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            if (opcion == 0)
            {
                if (textBoxNombre.Text == "" || (radioButtonMasculino.Checked == false && radioButtonFemenino.Checked == false))
                    MessageBox.Show("Es necesario llenar los campos de Nombre y Sexo");
                else
                {
                    string sexo = "";
                    if (radioButtonMasculino.Checked == true) sexo = "Masculino";
                    if (radioButtonFemenino.Checked == true) sexo = "Femenino";

                    string text = usuario + "|" + textBoxNombre.Text + "|" + textBoxCURP.Text + "|" + textBoxRFC.Text + "|" + textBoxCelular.Text + "|" + textBoxTelefono.Text + "|" + textBoxDireccion.Text + "|" + sexo.ToString() + "|" + textBoxLugarDeNacimiento.Text + "|" + textBoxNacFecha1.Text + "|" + textBoxNacFecha2.Text + "|" + textBoxNacFecha3.Text + "|" + textBoxEdad.Text + "|" + textBoxEmailLaboral.Text + "|" + textBoxEmailPersonal.Text + "|" + textBoxTipoDeSangre.Text + "|" + textBoxNumeroDeEmergencia.Text + "|" + textBoxContactoDeEmergencia.Text + "|" + textBoxParentesco.Text + "|" + textBoxDireccionDelContacto.Text + "|" + textBoxOtrasOcupaciones.Text + "|" + textBoxOtrasOcupaciones.Text + "|" + textBoxEstadoCivil.Text + "|" + textBoxStatusFamiliar.Text + "|";
                    
                    System.IO.StreamWriter file = new System.IO.StreamWriter("BDP_ELYON.elyon", true);
                    file.WriteLine(text);
                    file.Flush();
                    file.Close();
                    this.Close();
                }
            }
            if (opcion == 1) {
                string sexo = "";
                if (radioButtonMasculino.Checked == true) sexo = "Masculino";
                if (radioButtonFemenino.Checked == true) sexo = "Femenino";

                string text = usuario + "|" + textBoxNombre.Text + "|" + textBoxCURP.Text + "|" + textBoxRFC.Text + "|" + textBoxCelular.Text + "|" + textBoxTelefono.Text + "|" + textBoxDireccion.Text + "|" + sexo.ToString() + "|" + textBoxLugarDeNacimiento.Text + "|" + textBoxNacFecha1.Text + "|" + textBoxNacFecha2.Text + "|" + textBoxNacFecha3.Text + "|" + textBoxEdad.Text + "|" + textBoxEmailLaboral.Text + "|" + textBoxEmailPersonal.Text + "|" + textBoxTipoDeSangre.Text + "|" + textBoxNumeroDeEmergencia.Text + "|" + textBoxContactoDeEmergencia.Text + "|" + textBoxParentesco.Text + "|" + textBoxDireccionDelContacto.Text + "|" + textBoxOtrasOcupaciones.Text + "|" + textBoxOtrasOcupaciones.Text + "|" + textBoxEstadoCivil.Text + "|" + textBoxStatusFamiliar.Text + "|";
                    
                editarArchivo(1, text);

                this.Close();
            }
        }

        private void editarArchivo(int opcionArchivo, string textoCompleto)
        {

            string archivo = "";
            if (opcionArchivo == 0) archivo = "BDL_ELYON.elyon";
            if (opcionArchivo == 1) archivo = "BDP_ELYON.elyon";
            if (opcionArchivo == 2) archivo = "USU_ELYON.elyon";

            System.IO.StreamReader fileReader = new System.IO.StreamReader(archivo);
            string espacios = fileReader.ReadToEnd();
            fileReader.Close();

            string[] x = espacios.Split('\n');
            for (int i = 0; i < x.Length; i++)
            {
                string[] y = x[i].Split('|');
                if (y[0] == usuario)
                {
                    x[i] = textoCompleto;
                }
            }

            string textoFinal = "";

            for (int i = 0; i < x.Length; i++)
            {
                textoFinal = textoFinal + x[i];
                if (i < (x.Length - 2)) textoFinal += '\n';
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, false);
            file.WriteLine(textoFinal);
            file.Flush();
            file.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        } 


    }
}
