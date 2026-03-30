using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace AmlaDeveloperAssistantApp
{
    public partial class App : System.Windows.Application
    {
        private NotifyIcon trayIcon;
        private MainWindow window;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon("app.ico"); // make sure file exists
            trayIcon.Visible = true;
            trayIcon.Text = "Amla Developer Assistant";

            var menu = new ContextMenuStrip();

            menu.Items.Add("Open Assistant", null, OnOpen);
            menu.Items.Add("Exit", null, OnExit);

            trayIcon.ContextMenuStrip = menu;

            trayIcon.DoubleClick += OnOpen;
        }

        private void OnOpen(object sender, EventArgs e)
        {
            if (window == null)
            {
                window = new MainWindow();
                window.Closed += (s, args) => window = null;
                window.Show();
            }
            else
            {
                window.Activate();
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Shutdown();
        }
    }
}
