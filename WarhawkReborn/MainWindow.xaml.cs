using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using WarhawkReborn.Model;

namespace WarhawkReborn
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebAPI api = new WebAPI();
        private List<ServerEntry> serverList;
        private Timer timerSecond = new Timer();
        private int timeRemaining = 1;

        private Service service = new Service();
        private static readonly string TEXT_BTN_UPDATE_SERVERLIST = "Update ({0}s)";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ContentRendered += (s,e) => {
                timerSecond.Elapsed += TimerSecond_Elapsed;
                timerSecond.Interval = 1000;
                timerSecond.AutoReset = true;
                timerSecond.Enabled = true;
                this.UpdateServerList();
            };
        }

        private void TimerSecond_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeRemaining--;
            if(timeRemaining < 1)
            {
                this.Dispatcher.Invoke(this.UpdateServerList);
            }
            this.Dispatcher.Invoke(() => { btn_update_serverlist.Content = String.Format(TEXT_BTN_UPDATE_SERVERLIST, timeRemaining); });
        }

        private void Btn_update_serverlist_Click(object sender, RoutedEventArgs e)
        {
            this.UpdateServerList();
        }

        private void UpdateServerList()
        {
            serverList = api.GetServers();
            serverList.RemoveAll(isOffline);
            this.service.SetServerList(serverList);
            this.dg_servers.ItemsSource = serverList;
            timeRemaining = 60;
            btn_update_serverlist.Content = String.Format(TEXT_BTN_UPDATE_SERVERLIST, timeRemaining);
        }

        private static bool isOffline(ServerEntry e)
        {
            return e.IsOnline != true;
        }
    }
}
