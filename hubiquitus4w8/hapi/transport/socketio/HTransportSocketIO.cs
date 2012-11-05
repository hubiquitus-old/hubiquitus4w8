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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using hubiquitus4w8.hapi.hStructures;
using hubiquitus4w8.hapi.transport;
using SocketIOClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace hubiquitus4w8.hapi.transport.socketio
{
    public class HTransportSocketIO : HTransport
    {

        private ConnectionStatus connStatus = ConnectionStatus.DISCONNECTED;
        private HTransportOptions options = null;
        Client socketIO;
        private Timer timeout = null;

        public event DataEventHandler onData;
        public event StatusEventHandler onStatus;




        public void Connect(HTransportOptions options)
        {
            this.connStatus = ConnectionStatus.CONNECTING;
            this.options = options;

            string endpointHost = options.EndpointHost;
            int endpointPort = options.EndpointPort;
            string endpointPath = options.EndpointPath;

            string endpointAdress = ToEndpointAdress(endpointHost, endpointPort, endpointPath);

            timeout = new Timer(10000);
            timeout.Elapsed += timeout_Elapsed;
            timeout.Enabled = true;

            socketIO = new Client(endpointAdress);

            socketIO.Message += socketIO_Message;
            socketIO.SocketConnectionClosed += socketIO_SocketConnectionClosed;
            socketIO.Error += socketIO_Error;
            socketIO.On("connect", (fn) =>
                {
                    string publisher = options.Jid.GetFullJID();
                    string password = options.Password;
               
                    JObject data = new JObject();
                    try
                    {
                        data.Add("publisher", publisher);
                        data.Add("password", password);
                        //data.Add("serverHost", serverHost);
                        //data.Add("serverPort", serverPort);
                        socketIO.Emit("hConnect", data);

                    }
                    catch (JsonReaderException e)
                    {
                        if (socketIO != null)
                            Disconnect();
                        if (timeout != null)
                        {
                            timeout.Close();
                            timeout = null;
                        }
                        updateStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.TECH_ERROR, e.Message);
                        throw;
                    }
                });


            socketIO.Connect();

        }

        void socketIO_Message(object sender, MessageEventArgs e)
        {

            if (e.Message.Json.Name == "hStatus" && e.Message.Json.Args != null && e.Message.Json.Args.GetType().IsSerializable)
            {
                JObject data = (JObject)e.Message.Json.Args[0];
                try
                {
                    HStatus status = new HStatus(data);
                    if (timeout != null)
                    {
                        timeout.Close();
                        timeout = null;
                    }
                    updateStatus((ConnectionStatus)status.GetStatus(), (ConnectionErrors)status.GetErrorCode(), status.GetErrorMsg());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} exception caught.", ex);
                    if (timeout != null)
                    {
                        timeout.Close();
                        timeout = null;
                    }
                    socketIO.Close();
                    updateStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.TECH_ERROR,ex.Message);  
                }

            }
            else
            {
                if (e.Message.Json.Args != null)
                {
                    JObject data = (JObject)e.Message.Json.Args[0];
                    try
                    {
                        if (timeout != null)
                        {
                            timeout.Close();
                            timeout = null;
                        }
                        onData(e.Message.Json.Name, data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0} exception caught.", ex);
                        if (timeout != null)
                        {
                            timeout.Close();
                            timeout = null;
                        }
                    }
                }

            }
        }


        void socketIO_Error(object sender, ErrorEventArgs e)
        {
            if (socketIO != null && socketIO.IsConnected)
            {
                socketIO.Close();
            }
            socketIO = null;
            string errorMsg = null;
            if (e != null)
            {
                errorMsg = e.Message;
            }
            if (timeout != null)
            {
                timeout.Close();
                timeout = null;
            }
            updateStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.TECH_ERROR, errorMsg);
        }

        void socketIO_SocketConnectionClosed(object sender, EventArgs e)
        {
            if (timeout != null)
            {
                timeout.Close();
                timeout = null;
            }
            if (this.connStatus != ConnectionStatus.DISCONNECTED)
            {
                updateStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.NO_ERROR, null);
            }
        }

        void socketIO_Opened(object sender, EventArgs e)
        {
        }




        public void updateStatus(ConnectionStatus status, ConnectionErrors error, string errorMsg)
        {
            this.connStatus = status;
            if (onStatus != null)
                onStatus(status, error, errorMsg);
            else
                throw new ArgumentNullException("Error: " + this.GetType() + " require a StatusEventHandler onStatus");
        }

        void timeout_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeout.Stop();
            timeout = null;
            updateStatus(ConnectionStatus.DISCONNECTED, ConnectionErrors.CONN_TIMEOUT, null);
            if (socketIO.IsConnected)
                socketIO.Close();
            socketIO = null;
        }

        public void Disconnect()
        {
            connStatus = ConnectionStatus.DISCONNECTING;
            try
            {
                Close();
                if (socketIO.IsConnected == false)
                {
                    connStatus = ConnectionStatus.DISCONNECTED;
                    updateStatus(connStatus, ConnectionErrors.NO_ERROR, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendObject(JObject obj)
        {
            if (connStatus == ConnectionStatus.CONNECTED)
                socketIO.Emit("hCommand", obj);
            else
                throw new Exception("Not connected");
        }

        /// <summary>
        /// make an endpoint adress from endpoints components (ie http://host:port/path)
        /// </summary>
        /// <param name="endpointHost"></param>
        /// <param name="endpointPort"></param>
        /// <param name="endpointPath"></param>
        /// <returns></returns>
        public string ToEndpointAdress(string endpointHost, int endpointPort, string endpointPath)
        {
            string endpointAdress = "";
            endpointAdress += "http://";
            if (endpointHost != null)
                endpointAdress += endpointHost;
            if (endpointPort != 0)
                endpointAdress += ":" + endpointPort;
            if (endpointPath != null)
                endpointAdress += endpointPath;
            return endpointAdress;
        }

        public void Close()
        {
            if (this.socketIO != null)
            {
                socketIO.Opened -= socketIO_Opened;
                socketIO.Message -= socketIO_Message;
                socketIO.SocketConnectionClosed -= socketIO_SocketConnectionClosed;
                socketIO.Error -= socketIO_Error;
                this.socketIO.Dispose(); // close & dispose of socket client
            }
        }


    }
}
