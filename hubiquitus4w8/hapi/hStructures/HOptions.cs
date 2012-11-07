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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace hubiquitus4w8.hapi.hStructures
{   
    
    public class HOptions : JObject
    {

        public HOptions()
        {
        }

        public HOptions(JObject jsonObj)
            : base(jsonObj)
        { 
        }

        public HOptions(HOptions options)
        {
            SetEndpoints(options.GetEndpoints());
            SetTransport(options.GetTransport());
            SetTimeout(options.GetTimeout());
            SetMsgTimeout(options.GetMsgTimeout());
        }

        public string GetTransport()
        {
            string transport = null;
            try
            {
                transport = this["transport"].ToString();
            }
            catch (Exception)
            {
                transport = "socketio";
            }
            return transport;
        }

        public void SetTransport(string transport)
        {
            try
            {
                if (transport == null || transport.Length <= 0)
                    this["transport"] = "socketio";
                else
                    this["transport"] = transport;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the transport attribute", e.ToString());
            }
        }

        public JArray GetEndpoints()
        {
            JArray endpoints = null;
            try
            {
                endpoints = this["endpoints"].ToObject<JArray>();
            }
            catch(Exception e)
            {
                endpoints = new JArray();
                endpoints.Add("http://localhost:8080");
                Console.WriteLine("{0} : Can not fetch the endpoints attribute, return 'http://localhost:8080' instead : {0}", e.ToString());
            }
            return endpoints;
        }

        public void SetEndpoints(JArray endpoints)
        {
            try
            {
                if (endpoints != null && endpoints.Count > 0)
                    this["endpoints"] = endpoints;
                else
                    Console.WriteLine("{0} : The endpoints attribute can not be null or empty.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the endpoints attribute", e.ToString());
            }
        }

        /// <summary>
        /// default timeout value used by the hAPI before rise a connection timeout error during connection attempt
        /// </summary>
        /// <returns></returns>
        public int GetTimeout()
        {
            int timeout = 0;
            try
            {
                timeout = this["timeout"].ToObject<int>();
            }
            catch (Exception)
            {
                timeout = 15000; //15000s by default
            }
            return timeout;
        }

        public void SetTimeout(int timeout)
        {
            try
            {
                if (timeout >= 0)
                    this["timeout"] = timeout;
                else
                    this["timeout"] = 15000; // 15000s by default.
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the timeout attribute", e.ToString());
            }
        }
        /// <summary>
        /// default timeout value used by the hAPI for all the services except the send() one
        /// </summary>
        /// <returns></returns>
        public int GetMsgTimeout()
        {
            int timeout = 0;
            try
            {
                timeout = this["msgTimeout"].ToObject<int>();
            }
            catch (Exception)
            {
                timeout = 30000; //30000s by default
            }
            return timeout;
        }

        public void SetMsgTimeout(int timeout)
        {
            try
            {
                if (timeout >= 0)
                    this["msgTimeout"] = timeout;
                else
                    this["msgTimeout"] = 30000; //30000s by default
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the msgTimerout attribute", e.ToString());
            }
        }

    }
}
