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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.stuctures
{

    /// <summary>
    /// version 0.5
    /// JabberID contain the different part of the jid and some method to use it 
    /// A JabberID should look like : my_user@domain/resource
    /// </summary>
    public class JabberID
    {

        private string username = "";      
        private string domain = "";
        private string resource = "";

        /*Getter & Setter*/
        public string Username
        {
            get
            {
                return username;
            }
            set 
            {
                username = value;
            }
        }

        public string Domain
        {
            get
            {
                return domain;
            }
            set 
            {
                domain = value;
            }
        }

        public string Resource
        {
            get
            {
                return resource;
            }
            set 
            {
                resource = value;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="jid">
        /// jabber id (ie:my_user@domain/resource)
        /// </param>
        /// <exception cref="System.Exception">
        /// throw exception if invalid jid format
        /// </exception>
        public JabberID(string jid)
        {
            try
            {
                SetJID(jid);
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} : Invalid jid format in constructor JabberID Handler", e);
                Debug.WriteLine("{0} : Invalid jid format in constructor JabberID Handler: {0}", e.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// bare jid (ie:my_user@domain)
        /// </returns>
        public string GetBareJID()
        {
            return this.username + "@" + this.domain;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// full jid (ie:my_user@domain/resource) 
        /// </returns>
        public string GetFullJID() 
        {
            if (resource != "")
                return this.username + "@" + this.domain + "/" + this.resource;
            else
                return GetBareJID();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jid">
        /// jid(ie:my_user@domain or my_user@domain/resource)
        /// </param>
        /// <exception cref="System.Exception">
        /// throw exception if invalid jid format
        /// </exception>
        public void SetJID(string jid)
        {
            if (jid != null)
            {
                // TODO: does not work when jid format is "my_user"
                string pattern = @"^(?:([^@/<>']+)@)?([^@/<>']+)(?:/([^<>']*))?$";
                Match match = Regex.Match(jid,pattern);
                if (match.Success && match.Groups.Count >= 3 && match.Groups.Count <= 4 && match.Groups[1].Value != "")
                {
                    Username = match.Groups[1].Value;
                    Domain = match.Groups[2].Value;
                    if (match.Groups.Count >= 3)
                        Resource = match.Groups[3].Value;
                }
                else
                    throw new Exception();
            }
            else
                throw new ArgumentNullException();
        }
        
        public override string ToString()
        {
            return "JabberID [username=" + username + ", domain=" +
                domain + ", resource=" + resource + "]";
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((domain == null) ? 0 : domain.GetHashCode());
            result = prime * result + ((resource == null) ? 0 : resource.GetHashCode());
            result = prime * result + ((username == null) ? 0 : username.GetHashCode());
            return result;
        }

        public override bool Equals(Object obj) 
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            JabberID other = (JabberID)obj;
            if (domain == null)
            {
                if (other.domain != null)
                    return false;
            }
            else if (!domain.Equals(other.domain))
                return false;
            if (username == null)
            {
                if (other.username != null)
                    return false;
            }
            else if (!username.Equals(other.username))
                return false;
            if (resource == null)
            {
                if (other.resource != null)
                    return false;
            }
            else if(!resource.Equals(other.resource))
                return false;
            return true;
        }
    }
}
