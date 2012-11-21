/*
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
        private string endpointHost = null;
        private int endpointPort = 0;
        private string endpointPath = null;
        private string hserver = "hnode";
        private int timeout = 0;
        public AuthenticationCallback AuthCb { get; set; }

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

        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        public override string ToString()
        {
            return "HTransportOptions [jid=" + jid + ", password=" + password
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
