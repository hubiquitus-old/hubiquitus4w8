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
using hubiquitus4w8.hapi.util;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.4
    /// hAPI Command. For more info, see Hubiquitus reference
    /// </summary>
    class HCommand : HJsonObj
    {
        private JObject hcommand = new JObject();

        public HCommand()
        { 
        }

        public HCommand(string entity, string cmd, HJsonObj @params)
        {
            SetEntity(entity);
            SetCmd(cmd);
            SetParams(@params);
        }

        public HCommand(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        public JObject ToJson()
        {
            return this.hcommand;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                hcommand = jsonObj;
            else
                hcommand = null;
        }

        public string GetHType()
        {
            return "hcommand";
        }

        /// <summary>
        /// Check are made on reqid, requester, sender, entity, sent, cmd and transient.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  bool Equals(HCommand obj)
        {
            if (obj.GetReqid() != this.GetReqid())
                return false;
            if (obj.GetRequester() != this.GetRequester())
                return false;
            if (obj.GetSender() != this.GetSender())
                return false;
            if (obj.GetEntity() != this.GetEntity())
                return false;
            if (obj.GetSent() != this.GetSent())
                return false;
            if (obj.GetCmd() != this.GetCmd())
                return false;
            if (obj.GetTransient() != this.GetTransient())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return hcommand.GetHashCode();
        }

        public override string ToString()
        {
            return hcommand.ToString();
        }

        //Getters &setters
        /// <summary>
        /// Mandatory. Filled by the hApi.
        /// </summary>
        /// <returns></returns>
        public string GetReqid()
        {
            string reqid;
            try
            {
                reqid = (string)hcommand["reqid"];
            }
            catch (ArgumentNullException)
            {
                reqid = null;
            }
            return reqid;
        }

        public void SetReqid(string reqid)
        {
            try
            {
                if (reqid == null)
                    hcommand.Remove("reqid");
                else
                    hcommand.Add("reqid", reqid);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Filled by the hApi if empty.
        /// </summary>
        /// <returns>requester jid. Null if undefined.</returns>
        public string GetRequester()
        {
            string requester;
            try
            {
                requester = (string)hcommand["requester"];
            }
            catch (ArgumentNullException)
            {
                requester = null;
            }
            return requester;
        }


        public void SetRequester(string requester)
        {
            try
            {
                if (requester == null)
                    hcommand.Remove("requester");
                else
                    hcommand.Add("requester", requester);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Mandatory. Filled by the hApi.
        /// </summary>
        /// <returns>sender jid. Null if undefined.</returns>
        public string GetSender()
        {
            string sender;
            try
            {
                sender = (string)hcommand["sender"];
            }
            catch (ArgumentNullException)
            {
                sender = null;
            }
            return sender;
        }

        public void SetSender(string sender)
        {
            try
            {
                if (sender == null)
                    hcommand.Remove("sender");
                else
                    hcommand.Add("sender", sender);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Mandatory.
        /// </summary>
        /// <returns>entity jid. Null if undefined.</returns>
        public string GetEntity()
        {
            string entity;
            try
            {
                entity = (string)hcommand["entity"];
            }
            catch (ArgumentNullException)
            {
                entity = null;
            }
            return entity;
        }

        public void SetEntity(string entity)
        {
            try
            {
                if (entity == null)
                    hcommand.Remove("entity");
                else
                    hcommand.Add("entity", entity);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Mandatory. Filled by hApi if empty.
        /// </summary>
        /// <returns>date of submission. Null if undefined.</returns>
        public DateTime? GetSent()
        {
            DateTime? sent;
            try
            {
                sent = (DateTime)hcommand["sent"];
            }
            catch (ArgumentNullException)
            {
                sent = null;
            }
            return sent;
        }

        public void SetSent(DateTime sent)
        {
            try
            {
                if (sent == null)
                    hcommand.Remove("sent");
                else
                    hcommand.Add("sent", sent.ToString(HUtil.DateISO8601Format));
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Mandatory.
        /// </summary>
        /// <returns>Null if undefined.</returns>
        public string GetCmd()
        {
            string cmd;
            try
            {
                cmd = (string)hcommand["cmd"];
            }
            catch (ArgumentNullException)
            {
                cmd = null;    
            }
            return cmd;
        }

        public void SetCmd(string cmd)
        {
            try
            {
                if (cmd == null)
                    hcommand.Remove("cmd");
                else
                    hcommand.Add("cmd", cmd);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>params thrown to the hserver. Null if undefined.</returns>
        public JObject GetParams()
        {
            JObject @params;
            try
            {
                @params = (JObject)hcommand["params"];
            }
            catch (ArgumentNullException)
            {
                @params = null;
            }
            return @params;
        }

        public void SetParams(HJsonObj @params)
        {
            try
            {
                if (@params == null)
                    hcommand.Remove("params");
                else
                    hcommand.Add("params", @params.ToJson());
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>persist message or not. Null if undefined.</returns>
        public bool? GetTransient()
        {
            bool? transient;
            try
            {
                  transient = (bool)hcommand["transient"];
            }
            catch (ArgumentNullException)
            {
                transient = null;
            }
            return transient;
        }

        public void SetTransient(bool? transient)
        {
            try
            {
                if (transient == null)
                    hcommand.Remove("transient");
                else
                    hcommand.Add("transient", transient);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
    }
}
