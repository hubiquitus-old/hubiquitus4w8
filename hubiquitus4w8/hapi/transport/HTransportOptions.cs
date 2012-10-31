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
using hubiquitus4w8.hapi.stuctures;

namespace hubiquitus4w8.hapi.transport
{
    public class HTransportOptions
    {
        private JabberID jid = null;
        private string password = null;
        private string serverHost = null;
        private int serverPort = 0;
        private string endpointHost = null;
        private int endpointPort = 0;
        private string endpointPath = null;
        private string hserver = "hnode";

        public HTransportOptions()
        {
        }

        public string GetUsername()
        {
            if (jid == null)
                throw new NullReferenceException("Error: " + this.GetType() + " need a jid");
            return jid.Username;
        }

        public string GetResource()
        {
            if (jid == null)
                throw new NullReferenceException("Error: " + this.GetType() + " need a jid");
            return jid.Resource;
        }

        /// <summary>
        /// return hserver service name (by default if should be "hnode@domain")
        /// </summary>
        /// <returns></returns>
        public string GetHserverService()
        {
            string nodeService = null;
            if (this.jid != null)
                nodeService = this.hserver + "@" + this.jid.Domain;
            return nodeService;
        }

        /// <summary>
        /// return pubsub service name (by default it should be "pubsub")
        /// </summary>
        /// <returns></returns>
        public string GetPubsubService() 
        {
            return "pubsub" + "." + this.jid.Domain;
        }

        //getter & setter 

        public JabberID Jid 
        {
            get { return jid; }
            set { jid = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string ServerHost
        {
            get { return serverHost; }
            set
            {
                if (value == null || value.Equals(""))
                    this.serverHost = null;
                else
                    this.serverHost = value;
            }
        }

        public int ServerPort
        {
            get { return serverPort; }
            set { serverPort = value; }
        }

        public string EndpointHost
        {
            get { return endpointHost; }
            set { endpointHost = value; }
        }

        public int EndpointPort
        {
            get { return endpointPort; }
            set { endpointPort = value; }
        }

        public string EndpointPath
        {
            get { return endpointPath; }
            set { endpointPath = value; }
        }

        public string Hserver 
        {
            get { return hserver; }
            set { hserver = value; }
        }

        public override string ToString()
        {
            return "HTransportOptions [jid=" + jid + ", password=" + password
                + ", serverHost=" + serverHost + ", serverPort=" + serverPort
                + ", endpointHost=" + endpointHost + ", endpointPort="
                + endpointPort + ", endpointPath=" + endpointPath + ", hNode="
                + hserver + "]";
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result
                    + ((endpointHost == null) ? 0 : endpointHost.GetHashCode());
            result = prime * result
                    + ((endpointPath == null) ? 0 : endpointPath.GetHashCode());
            result = prime * result + endpointPort;
            result = prime * result + ((hserver == null) ? 0 : hserver.GetHashCode());
            result = prime * result + ((jid == null) ? 0 : jid.GetHashCode());
            result = prime * result
                    + ((password == null) ? 0 : password.GetHashCode());
            result = prime * result
                    + ((serverHost == null) ? 0 : serverHost.GetHashCode());
            result = prime * result + serverPort;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            HTransportOptions hobj = (HTransportOptions)obj;
            if (this.jid.Equals(hobj.jid))
                return false;
            if (this.password != hobj.password)
                return false;
            if (this.serverHost != hobj.serverHost)
                return false;
            if (this.serverPort != hobj.serverPort)
                return false;
            if (this.endpointHost != hobj.endpointHost)
                return false;
            if (this.endpointPath != hobj.endpointPath)
                return false;
            if (this.endpointPort != hobj.endpointPort)
                return false;
            if (this.hserver != hobj.hserver)
                return false;
            return true;
        }
    }
}
