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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.5
    /// hAPI Command. For more info, see Hubiquitus reference
    /// </summary>
    public class HCommand : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HCommand));
        public HCommand()
        { 
        }

        public HCommand(JObject jsonObj)
            : base(jsonObj)
        {
        }

        public HCommand(string cmd, JObject @params)
        {
            SetCmd(cmd);
            SetParams(@params);
        }

     
        //Getters &setters
       
        /// <summary>
        /// Get the command name. Mandatory.
        /// </summary>
        /// <returns>Null if undefined.</returns>
        public string GetCmd()
        {
            string cmd = null;
            try
            {
                cmd = this["cmd"].ToString();
            }
            catch (Exception e)
            {  
                log.Error("Can not fetch the cmd attribute : ", e);
            }
            return cmd;
        }

        /// <summary>
        /// Set the command name. Mandatory.
        /// </summary>
        /// <param name="cmd"></param>
        public void SetCmd(string cmd)
        {
            try
            {
                if (cmd == null)
                    this.Remove("cmd");
                else
                    this["cmd"] = cmd;
            }
            catch (Exception e)
            {
                log.Error("Can not update the cmd attribute : ", e);
            }
        }
        /// <summary>
        /// Get params thrown to the hserver. 
        /// </summary>
        /// <returns>Null if undefined.</returns>
        public JObject GetParams()
        {
            JObject @params = null;
            try
            {
                @params = this["params"].ToObject<JObject>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the params attribute : ", e);
            }
            return @params;
        }

        /// <summary>
        /// Set params thrown to the hserver.
        /// </summary>
        /// <param name="params"></param>
        public void SetParams(JObject @params)
        {
            try
            {
                if (@params == null)
                    this.Remove("params");
                else
                    this["params"] = @params;
            }
            catch (Exception e)
            {
                log.Error("Can not update the params attribute : ", e);
            }
        }
    }
}
