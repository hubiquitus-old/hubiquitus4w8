/*
 * Copyright (c) Novedia Group 2012.
 *
 *     This file is part of Hubiquitus.
 *
 *     Hubiquitus is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     Hubiquitus is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with Hubiquitus.  If not, see <http://www.gnu.org/licenses/>.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hubiquitus4w8.hapi.hStructures;
using hubiquitus4w8.hapi.client;
using hubiquitus4w8.hapi.util;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace hubiquitus4w8.hapi.test
{
    public partial class testForm : Form
    {
        private HOptions options;
        private HClient client;

        public testForm()
        {
            options = new HOptions();
            client = new HClient();

            client.onMessage += client_onMessage;
            client.onCommand += client_onCommand;
            client.onStatus += client_onStatus;

            InitializeComponent();
            usernameTextBox.Text = "u1@hub.novediagroup.com";
            passwordTextBox.Text = "u1";
            endpointTextBox.Text = "http://hub.novediagroup.com:8080";
            serverHostTextBox.Text = "hub.novediagroup.com";
            serverPortTextBox.Text = "8080";
            channelIDTextBox.Text = "#test@hub.novediagroup.com";
        }


        void client_onStatus(HStatus status)
        {
            string output = "\n\n---HClient API OnStatus---\n" + status.ToString() + "\n---------------------------\n\n";
            Console.WriteLine(output);
        }

        void client_onCommand(HCommand command)
        {
            string output = "\n\n---HClient API OnCommand---\n" + command.ToString() + "\n---------------------------\n\n";
            Console.WriteLine(output);
        }

        void client_onMessage(HMessage message)
        {
            string output = "\n\n---HClient API OnMessage---\n" + message.ToString() + "\n---------------------------\n\n";
            Console.WriteLine(output);
        }

        private void connectBt_Click(object sender, EventArgs e)
        {
            string endpoint = endpointTextBox.Text;
            if (options.endpoints != null)
                options.endpoints.Clear();
            if (endpoint == null || endpoint == "")
                options.endpoints = null;
            else
            {
                options.endpoints = new List<string>();
                options.endpoints.Add(endpoint);
            }
            string serverHost = serverHostTextBox.Text;
            if (serverHost != null)
                options.serverHost = serverHost;
            string serverPort = serverPortTextBox.Text;
            if (serverPort != null)
                options.serverPort = int.Parse(serverPort);

            client.Connect(usernameTextBox.Text, passwordTextBox.Text, options);


        }

        private void disconnectBt_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void commandBt_Click(object sender, EventArgs e)
        {
            HJsonDictionnary jsonObj = new HJsonDictionnary();
            try
            {
                jsonObj.Add("text", messageTextBox.Text);
                HCommand cmd = new HCommand("hnode@hub.novediagroup.com", "hecho", jsonObj);
                if (transientRBt.Checked)
                    cmd.SetTransient(true);
                client.Command(cmd, commandResultDelegate);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void subscribeBt_Click(object sender, EventArgs e)
        {
            client.Subscribe(channelIDTextBox.Text, ResultDelegateSubscirbe);
        }

        private void unsubscribeBt_Click(object sender, EventArgs e)
        {
            client.Unsubscribe(channelIDTextBox.Text, ResultDelegateUnsubscirbe);
        }

        private void publisherBt_Click(object sender, EventArgs e)
        {
            HMessage message = new HMessage();
            message.SetPublisher(usernameTextBox.Text);
            message.SetActor(channelIDTextBox.Text);
            message.SetPublished(DateTime.Now);
            message.SetType("obj");
            //message.SetRelevance(DateTime.Now);

            if (transientRBt.Checked)
                message.SetPersistent(true);
            else
                message.SetPersistent(false);

            HJsonDictionnary payload = new HJsonDictionnary();
            payload.Add("text", messageTextBox.Text);
            message.SetPayload(payload);
            Console.WriteLine(message.ToString());
            client.Publish(message, ResultDelegatePublisher);
        }

        private void getLastMsgsBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            int nbLastMsg;
            try
            {
                try
                {
                    nbLastMsg = int.Parse(nbLastMessagesTextBox.Text);
                    
                }
                catch (FormatException)
                {
                    nbLastMsg = 10;
                }
                if (nbLastMsg > 0)
                    client.GetLastMessages(chid, nbLastMsg, ResultDelegateGetLastMessages);
                else
                    client.GetLastMessages(chid, ResultDelegateGetLastMessages);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void getSubscriptionsBt_Click(object sender, EventArgs e)
        {
            client.GetSubscriptions(ResultDelegateGetSubcriptions);
        }


        private void getThreadBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            string convid = convidTextBox.Text;

            try
            {
                client.GetThread(chid, convid, ResultDelegateGetThread);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getThreadsBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            string status = statusTextBox.Text;
            try
            {
                client.GetThreads(chid, status, ResultDelegateGetThreads);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void setFilterBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            string filterName = filterNameTextBox.Text;
            string filterAttr = filterAttrTextBox.Text;
            string filterValue = filterValueTextBox.Text;

            JObject jsonObj = new JObject();
            try
            {
                jsonObj.Add(filterAttr, filterValue);
            }
            catch (JsonWriterException)
            {

                throw;
            }

            HMessage template = new HMessage(jsonObj);


            Console.WriteLine("----> Template:\n " + template.ToString());
            HFilterTemplate filter = new HFilterTemplate();

            filter.SetChid(chid);
            filter.SetName(filterName);
            filter.SetTemplate(template);
            client.SetFilter(chid, filter, ResultDelegateSetFilter);
        }

        private void listFilterBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            if (chid == "")
                client.ListFilters(null, ResultDelegateListFilter);
            else
                client.ListFilters(chid, ResultDelegateListFilter);
        }

        private void unSetFilterBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            string filterName = filterNameTextBox.Text;
            client.UnSetFilter(filterName, chid, ResultDelegateUnSetFilter);
        }

        private void getRelevantMsgBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            client.GetRelevantMessages(chid, ResultDelegateGetRelevantMsg);
        }



        //result delegates
        private void commandResultDelegate(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for Command---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateSubscirbe(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for Subscribe---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateUnsubscirbe(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for Unsubscribe---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegatePublisher(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for Publisher---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateGetLastMessages(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for GetLastMessages---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateGetSubcriptions(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for GetSubcriptions---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateGetThread(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for GetThread---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateGetThreads(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for GetThreads---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateSetFilter(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for SetFilter---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateListFilter(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for Listfilter---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateUnSetFilter(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for UnSetFilter---\n" + result.ToString() + "\n\n");
        }

        private void ResultDelegateGetRelevantMsg(HResult result)
        {
            Console.WriteLine("\n\n---ResultDelegate for GetRelevantMsg---\n" + result.ToString() + "\n\n");
        }

        private void pubConvStateBt_Click(object sender, EventArgs e)
        {
            string chid = channelIDTextBox.Text;
            string convid = convidTextBox.Text;
            string status = statusTextBox.Text;

            HMessageOptions mOptions = new HMessageOptions();
            if (transientRBt.Checked)
                mOptions.Transient = true;
            else
                mOptions.Transient = false;
            try
            {
                HMessage pubMsg = client.BuildConvState(chid, convid, status, mOptions);
                client.Publish(pubMsg, ResultDelegatePublisher);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
