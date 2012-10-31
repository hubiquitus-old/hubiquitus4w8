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
        private static readonly ILog log = LogManager.GetLogger(typeof(HOptions));

        public HOptions()
        {
        }

        public HOptions(JObject jsonObj)
            : base(jsonObj)
        { 
        }

        public HOptions(HOptions options)
        { 
            
        }

        public string GetTransport()
        {
            string transport = null;
            try
            {
                transport = this["transport"].ToString();
            }
            catch (Exception e)
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
                    this.Add("transport", "socketio");
                else
                    this.Add("transport", transport);
            }
            catch (Exception e)
            {
                log.Error("Can not update the transport attribute : ", e);
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
                log.Error("Can not fetch the endpoints attribute, return 'http://localhost:8080' instead : ", e);
            }
            return endpoints;
        }

        public void SetEndpoints(JArray endpoints)
        {
            try
            {
                if (endpoints != null && endpoints.Count > 0)
                    this.Add("endpoints", endpoints);
                else
                    log.Error("The endpoints attribute can not be null or empty.");
            }
            catch (Exception e)
            {
                log.Error("Can not update the endpoints attribute : ", e);
            }
        }

        public int GetTimeout()
        {
            int timeout = 0;
            try
            {
                timeout = this["timeout"].ToObject<int>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the timeout attribute : ", e);
            }
            return timeout;
        }

        public void SetTimeout(int timeout)
        {
            try
            {
                if (timeout >= 0)
                    this.Add("timeout", timeout);
                else
                    this.Add("timeout", 3000); // 3000s by default.
            }
            catch (Exception e)
            {
                log.Error("Can not update the timeout attribute : ", e);
            }
        }
    }
}
