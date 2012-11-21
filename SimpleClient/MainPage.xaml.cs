﻿/*
 * Copyright (c) Novedia Group 2012.
 *
 *    This file is part of Hubiquitus
 *
 *    Permission is hereby granted, free of charge, to any person obtaining a copy
 *    of this software and associated documentation files (the "Software"), to deal
 *    in the Software without restriction, including without limitation the rights
 *    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 *    of the Software, and to permit persons to whom the Software is furnished to do so,
 *    subject to the following conditions:
 *
 *    The above copyright notice and this permission notice shall be included in all copies
 *    or substantial portions of the Software.
 *
 *    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 *    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 *    PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 *    FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 *    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 *    You should have received a copy of the MIT License along with Hubiquitus.
 *    If not, see <http://opensource.org/licenses/mit-license.php>.
 */


using hubiquitus4w8.hapi.client;
using hubiquitus4w8.hapi.hStructures;
using hubiquitus4w8.hapi.transport;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HClient client;
        private HOptions options;
        public MainPage()
        {
            this.InitializeComponent();
            client = new HClient();
            options = new HOptions();

            client.onMessage += client_onMessage;
            client.onStatus += client_onStatus;

        }

        void client_onStatus(HStatus status)
        {
            Debug.WriteLine(">>>client_onStatus: " + status.ToString());
            Update_TextBlock_UI(statusScreen, status.ToString());
        }


        void client_onMessage(HMessage message)
        {
            Debug.WriteLine(">>>client_onMessage: " + message.ToString());
            Update_TextBlock_UI(msgScreen, ">>>onMessage<<< \n" + message.ToString());
        }

        private void callback(HMessage msg)
        {
            Debug.WriteLine(">>>[Callback]<<< \n " + msg.ToString() + "\n");
            Update_TextBlock_UI(msgScreen, ">>>CallBack<<< \n" + msg.ToString());
        }


        private async void Update_TextBlock_UI(TextBlock tb, string text)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High,
                 () =>
                 {
                     if ("clear".Equals(text, StringComparison.OrdinalIgnoreCase))
                         tb.Text = "";
                     else
                         tb.Text += text;
                 }
                 );
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void connBt_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = serverTbx.Text;
            if (options.GetEndpoints() != null)
                options.GetEndpoints().Clear();
            if (!string.IsNullOrEmpty(endpoint))
            {
                JArray ja = new JArray();
                ja.Add(endpoint);
                options.SetEndpoints(ja);
            }
            options.AuthCb = new AuthenticationCallback(
                (username, Login) =>
                {
                    Debug.WriteLine("AuthenticationCallback called!");
                    Login(username, "u1");
                }
                );
            client.Connect(usernamTbx.Text, passwordTbx.Text, options);

        }

        private void disConnBt_Click(object sender, RoutedEventArgs e)
        {
            client.Disconnect();
        }

        private void sendBt_Click(object sender, RoutedEventArgs e)
        {
            HMessageOptions mOptions = new HMessageOptions();
            if (persistentCb.IsChecked.Value)
                mOptions.Persistent = true;
            else
                mOptions.Persistent = false;
            if (!string.IsNullOrEmpty(timeoutTbx.Text))
                mOptions.Timeout = int.Parse(timeoutTbx.Text);
            if (!string.IsNullOrEmpty(relevantTbx.Text))
                mOptions.RelevanceOffset = int.Parse(relevantTbx.Text);
            HMessage hMsg = client.BuildMessage(actorTbx.Text, "text", msgTbx.Text, mOptions);
            client.Send(hMsg, null);
            Debug.WriteLine(">>>Send Message<<<\n" + hMsg.ToString() + "\n");

        }

        private void getThreadBt_Click(object sender, RoutedEventArgs e)
        {
            client.GetThread(actorTbx.Text, convidTbx.Text, callback);
        }

        private void getThreadsBt_Click(object sender, RoutedEventArgs e)
        {
            client.GetThreads(actorTbx.Text, statusTbx.Text, callback);
        }

        private void getsubBt_Click(object sender, RoutedEventArgs e)
        {
            client.GetSubscriptions(callback);
        }

        private void getReleMsgBt_Click(object sender, RoutedEventArgs e)
        {
            client.GetRelevantMessages(actorTbx.Text, callback);
        }

        private void getLastMsgBt_Click(object sender, RoutedEventArgs e)
        {
            int nb = -1;
            try
            {
                nb = int.Parse(nbLastMsgTbx.Text);
            }
            catch (Exception)
            {

            }
            if (nb > 0)
                client.GetLastMessages(actorTbx.Text, nb, callback);
            else
                client.GetLastMessages(actorTbx.Text, callback);
        }

        private void setFilterBt_Click(object sender, RoutedEventArgs e)
        {
            HCondition filter = new HCondition();
            HArrayOfValue valueArray = new HArrayOfValue();
            valueArray.SetName("publisher");
            JArray ja = new JArray();
            ja.Add("u1@hub.novediagroup.com");
            ja.Add("u2@hub.novediagroup.com");
            valueArray.SetValues(ja);
            filter.SetInValue(valueArray);
            //Remove the filter.
            //HCondition filter = new HCondition(JObject.Parse("{}")); 
            client.SetFilter(filter, callback);
        }

        private void subBt_Click(object sender, RoutedEventArgs e)
        {
            client.Subscribe(actorTbx.Text, callback);
        }

        private void unsubBt_Click(object sender, RoutedEventArgs e)
        {
            client.Unsubscribe(actorTbx.Text, callback);
        }

        private void pubCSBt_Click(object sender, RoutedEventArgs e)
        {
            HMessageOptions mOptions = new HMessageOptions();
            if (persistentCb.IsChecked.Value)
                mOptions.Persistent = true;
            else
                mOptions.Persistent = false;
            HMessage hMsg = client.BuildConvState(actorTbx.Text, convidTbx.Text, statusTbx.Text, mOptions);
            client.Send(hMsg, callback);
        }

        private void clearBt_Status_Click(object sender, RoutedEventArgs e)
        {
            Update_TextBlock_UI(statusScreen, "clear");
        }

        private void clearBt_Message_Click(object sender, RoutedEventArgs e)
        {
            Update_TextBlock_UI(msgScreen, "clear");
        }




    }
}
