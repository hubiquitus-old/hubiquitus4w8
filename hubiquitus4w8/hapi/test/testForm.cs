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
            client.onStatus += client_onStatus;

            InitializeComponent();
            usernameTextBox.Text = "u1@hub.novediagroup.com";
            passwordTextBox.Text = "u1";
            endpointTextBox.Text = "http://hub.novediagroup.com:8080";
            actorTextBox.Text = "#test@hub.novediagroup.com";
        }


        void client_onStatus(HStatus status)
        {
            string output = "\n\n---HClient API OnStatus---\n" + status.ToString() + "\n---------------------------\n\n";
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
            if (options.GetEndpoints() != null)
                options.GetEndpoints().Clear();
            if (endpoint == null || endpoint == "")
                options.SetEndpoints(null);
            else
            {
                JArray jArray = new JArray();
                jArray.Add(endpoint);
                options.SetEndpoints(jArray);

            }            

            client.Connect(usernameTextBox.Text, passwordTextBox.Text, options);


        }

        private void disconnectBt_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

      

        private void subscribeBt_Click(object sender, EventArgs e)
        {
            client.Subscribe(actorTextBox.Text, MessageDelegateSubscirbe);
        }

        private void unsubscribeBt_Click(object sender, EventArgs e)
        {
            client.Unsubscribe(actorTextBox.Text, MessageDelegateUnsubscirbe);
        }

        private void sendBt_Click(object sender, EventArgs e)
        {
            HMessageOptions msgOptions = new HMessageOptions();
            if (persistentRBt.Checked)
                msgOptions.Persistent = true;
            else
                msgOptions.Persistent = false;

            if (!string.IsNullOrEmpty(timeoutTextBox.Text))
                msgOptions.Timeout = int.Parse(timeoutTextBox.Text);

            if (!string.IsNullOrEmpty(relevanceOffsetTextBox.Text))
                msgOptions.RelevanceOffset = int.Parse(relevanceOffsetTextBox.Text);

            
            HMessage msg = client.BuildMessage(actorTextBox.Text, "text", messageTextBox.Text, msgOptions);
            Console.WriteLine(msg.ToString());

            client.Send(msg,MessageDelegateSend);
        }

        private void getLastMsgsBt_Click(object sender, EventArgs e)
        {
            string actor = actorTextBox.Text;
            int nbLastMsg;
            try
            {
                try
                {
                    nbLastMsg = int.Parse(nbLastMessagesTextBox.Text);
                    
                }
                catch (FormatException)
                {
                    nbLastMsg = -1;
                }
                if (nbLastMsg > 0)
                    client.GetLastMessages(actor, nbLastMsg, MessageDelegateGetLastMessages);
                else
                    client.GetLastMessages(actor, MessageDelegateGetLastMessages);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void getSubscriptionsBt_Click(object sender, EventArgs e)
        {
            client.GetSubscriptions(MessageDelegateGetSubcriptions);
        }


        private void getThreadBt_Click(object sender, EventArgs e)
        {
            string actor = actorTextBox.Text;
            string convid = convidTextBox.Text;

            try
            {
                client.GetThread(actor, convid, MessageDelegateGetThread);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getThreadsBt_Click(object sender, EventArgs e)
        {
            string actor = actorTextBox.Text;
            string status = statusTextBox.Text;
            try
            {
                client.GetThreads(actor, status, MessageDelegateGetThreads);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void setFilterBt_Click(object sender, EventArgs e)
        {
            HCondition filter = new HCondition();
            HArrayOfValue arrayOfValue = new HArrayOfValue();
            arrayOfValue.SetName("publisher");
            JArray j = new JArray();
            j.Add("u1@hub.novediagroup.com");
            j.Add("u2@hub.novediagroup.com");
            arrayOfValue.SetValue(j);
            filter.SetInValue(arrayOfValue);
            client.SetFilter(filter, MessageDelegateSetFilter);         
        }

      
        private void getRelevantMsgBt_Click(object sender, EventArgs e)
        {
            string actor = actorTextBox.Text;
            client.GetRelevantMessages(actor, MessageDelegateGetRelevantMsg);
        }


        private void pubConvStateBt_Click(object sender, EventArgs e)
        {
            string actor = actorTextBox.Text;
            string convid = convidTextBox.Text;
            string status = statusTextBox.Text;

            HMessageOptions mOptions = new HMessageOptions();
            if (persistentRBt.Checked)
                mOptions.Persistent = true;
            else
                mOptions.Persistent = false;
            try
            {
                HMessage pubMsg = client.BuildConvState(actor, convid, status, mOptions);
                client.Send(pubMsg, MessageDelegatePubConvState);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} exception caught.", ex.ToString());
            }
        }
        
        //result delegates
        private void MessageDelegateSend(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for Command---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateSubscirbe(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for Subscribe---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateUnsubscirbe(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for Unsubscribe---\n" + result.ToString() + "\n\n");
        }

        
        private void MessageDelegateGetLastMessages(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for GetLastMessages---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateGetSubcriptions(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for GetSubcriptions---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateGetThread(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for GetThread---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateGetThreads(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for GetThreads---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateSetFilter(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for SetFilter---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegateGetRelevantMsg(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for GetRelevantMsg---\n" + result.ToString() + "\n\n");
        }

        private void MessageDelegatePubConvState(HMessage result)
        {
            Console.WriteLine("\n\n---MessageDelegate for PubConvState---\n" + result.ToString() + "\n\n");
        }


        private void createChannelBt_Click(object sender, EventArgs e)
        {
            JObject channelToCreate = new JObject();
          
                channelToCreate.Add("type", "channel");
                channelToCreate.Add("actor", actorTextBox.Text);
                channelToCreate.Add("owner", usernameTextBox.Text);
				JArray jsonArray = new JArray();
				jsonArray.Add("u1@hub.novediagroup.com");
				jsonArray.Add("u2@hub.novediagroup.com");
				channelToCreate.Add("subscribers", jsonArray);
				channelToCreate.Add("active", true);
				HMessage message = client.BuildCommand("hnode@hub.novediagroup.com",
						"hcreateupdatechannel", channelToCreate, null);
				client.Send(message, null);
        }
    }
}
