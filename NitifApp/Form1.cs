using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace NitifApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Console.Title = "Send notification for Android";
            //Console.SetWindowSize(20, 20);

            //string title = "";
            //string body = "";
            //var data = new { action = "Play", userId = 5 };

            //Console.Write("Title of notification: ");
            //title = Console.ReadLine();

            //Console.WriteLine();

            //Console.WriteLine("Body of the notification: ");
            //body = Console.ReadLine();

            //Console.WriteLine();
            ///*
            //Console.Write("How many devices are going to receive this notification? ");
            //int.TryParse(Console.ReadLine(), out int devicesCount);
            //var tokens = new string[devicesCount];

            //Console.WriteLine();
            
            //for (int i = 0; i < devicesCount; i++)
            //{
            //    Console.Write($"Token for device number {i + 1}: ");
            //    tokens[i] = Console.ReadLine();
            //    Console.WriteLine();
            //}
            //*/
            //Console.WriteLine("Do you want to send notifications?");
            //Console.WriteLine("1) Yes");
            //Console.WriteLine("2) No.");

            //int.TryParse(Console.ReadLine(), out int sendNotification);
            //if (sendNotification == 1)
            //{
            //    //var pushSent = SendNotificationLogic.SendPushNotificationToSpecificDevices(tokens, title, body, data);
            //    var pushSent = SendNotificationLogic.SendPushNotificationToAll(title, body, data);
            //    Console.WriteLine($"Notification sent.");
            //}
            //else
            //{
            //    Console.WriteLine("Notification erased.");
            //}


            //Console.ReadKey();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string title = "app Ak";
            string body = "app Ak";
            var data = new { action = "Play", userId = 5 };

            // var pushSent SendNotificationLogic.SendPushNotificationToAll(title, body, data);

            //if (SendNotificationLogic.SendPushNotificationToAll(txtTitulo.Text, txtMensaje.Text, data))
            //{
            try {
               
                SendNotificationLogic.SendPushNotificationToAll(txtTitulo.Text, txtMensaje.Text, data);
                MessageBox.Show("Mansaje enviado.");
                txtMensaje.Text = "";
                txtTitulo.Text = "";
            }
            catch
            {
                MessageBox.Show("Error al enviar mensaje.");
            }

            //Console.WriteLine($"Notification sent.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
