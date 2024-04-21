using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
		Thread atender;
        bool logeado = false;
        string UsuarioLog = "";
		delegate void DelegadoParaEscribir(string mensaje);
        public Form1()
        {
            InitializeComponent();
			CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                // 4/David/Tonto/Raul
                switch (codigo)
                {
                    case 1:  // respuesta a registro

						MessageBox.Show(mensaje);
                        break;
                    case 2:	//loguearse
                        UsuarioLog = mensaje;
                        if (UsuarioLog != "Error" && !logeado)
                        {
                            usuarioActual.Text = nombreReg.Text;
                            logeado = true;
                           
                        }
                        //else MessageBox.Show("Cierra sesión antes de logearte");

                        break;
                    case 3:      //Enviar partida con mas turnos

						MessageBox.Show("La partida con mas turnos es la numero " + mensaje);
                        break;
                    case 4:       //Recibimos la respuesta de victorias

                        MessageBox.Show("Las victorias de " + nombreConsulta.Text +" son: " + mensaje);
                        break;
                    case 5:     //Mejor jugador
  
                        MessageBox.Show("El mejor jugador es: " + mensaje);

                        break;
					case 6:     //num de muertes
						
						 MessageBox.Show("El jugador " + nombreConsulta.Text + " ha muerto " + mensaje + "veces");
						 
						 break;
                    case 7:		//cerrar sesion
                        if (mensaje == "1") // 1 si el server ha podido eliminar la cuenta
                            MessageBox.Show("Account deleted ");
                        else if (mensaje == "2")
                            MessageBox.Show("Password does not match!");
                        else if (mensaje == "3")
                            MessageBox.Show("User " + nombreReg.Text + " does not exist.");
                        break;
                    case 9:     //recibimos notificacion
                       
                        string nombres = "";
                        
                        for (int i = 2; i < Convert.ToInt32(trozos[1])+2; i++) // A partir de trozos [2] tenemos los nombres de los conectados
                        {
                            // Agregar cada nombre a la cadena de nombres
                            nombres += trozos[i] + Environment.NewLine;
                        }
                        

                        contLbl.Invoke(new Action(() =>
                        {
                            contLbl.Text = nombres;
                        }));
                        break;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e) //boton de registro
        {
			
			string mensaje = "1/" + nombreReg.Text + "/"+ contraReg.Text + "/";
			// Enviamos al servidor el nombre y contrasenya tecleado
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
			server.Send(msg);
			


           

        }
        private void consultaBoton_Click(object sender, EventArgs e)
        {
            if (mayorTurnos.Checked)
            {
                string mensaje = "3/Mayor/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               
            }
            else if (victoriasDe.Checked)
            {
                string mensaje = "4/" + nombreConsulta.Text + "/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
            else if(mejorJugador.Checked)
            {
                string mensaje = "5/Mejor";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               
            }
            else if(muertesDe.Checked)
            {
                string mensaje = "6/" + nombreConsulta.Text + "/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

            }
        }

        private void logeoBoton_Click(object sender, EventArgs e) //boton para loguearse
        {

            
            string mensaje = "2/" + nombreReg.Text + "/" + contraReg.Text + "/";
            // Enviamos al servidor el nombre y contrasenya tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
             
            /*mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
            mensaje = mensaje.Substring(0, mensaje.Length - 1);*/

        }

        private void conectarBoton_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            usuarioActual.Text = "";
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50035);
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
			
			//pongo en marcha el thread q atenderá a los mensajes del server
			ThreadStart ts = delegate {AtenderServidor(); };
			atender = new Thread(ts);
			atender.Start();

        }

        private void desconectarBoton_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Se terminó el servicio. 
            // Nos desconectamos
			atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { //boton para cerrar sesion
		
            string mensaje = "7/" + nombreReg.Text + "/"+ contraReg.Text + "/";
			// Enviamos al servidor el nombre y contrasenya tecleado
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
			server.Send(msg);
           
        }

    }
}
