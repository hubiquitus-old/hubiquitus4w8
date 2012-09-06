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
    /// @version 0.4
    /// Describes a measure payload
    /// Message acknowledgements
    /// acknowledgements are used to identify the participants that have received or not received, read or not read a message 
    /// Note, when a hMessage contains a such kind of payload, the convid must be provided with the same value has the acknowledged hMessage.
    /// </summary>
    class HAck : HJsonObj
    {
        private JObject hack = new JObject();

        public HAck()
        { 
        }

        public HAck(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        // interface HJsonObj
        public JObject ToJson()
        {
            return this.hack;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                this.hack = jsonObj;
            else
                this.hack = new JObject();
        }

        public string GetHType()
        {
            return "hack";
        }


        /// <summary>
        /// Check are made on ackid and ack.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  bool Equals(HAck obj)
        {
            if (obj.GetAckid() != this.GetAckid())
                return false;
            if (obj.GetAck() != this.GetAck())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return hack.GetHashCode();
        }

        public override string ToString()
        {
            return this.hack.ToString();
        }


        //Getters & setters
        //ackid will be removed since v0.5
       
       /// <summary>
       /// Mandatory.
       /// The “msgid” of the message to which this acknowledgment refers.
       /// </summary>
       /// <returns>Null if undefined</returns
        public string GetAckid()
        {
            string ackid;
            try
            {
                ackid = (string)hack["ackid"];
            }
            catch (ArgumentNullException)
            {
                ackid = null;
            }
            return ackid;
        }

        public void SetAckid(string ackid)
        {
            try
            {
                if (ackid == null)
                    hack.Remove("ackid");
                else
                    hack.Add("ackid", ackid);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get the status of  the acknowledgement.
        /// </summary>
        /// <returns></returns>
        public string GetAck() // problem with string enum
        {
            string ack;
            try
            {
                ack = (string)hack["ack"];
            }
            catch (ArgumentNullException)
            {
                ack = null;
            }
            return ack;
        }

        public void SetAck(string ack)
        {
            try
            {
                if (ack == null)
                    hack.Remove("ack");
                else
                {
                    if (HUtil.CheckAck(ack))
                        throw new Exception("only 'recv' and 'read' are authorized for ack");
                    hack.Add("ack", ack);
                }
                    
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }       
    }
}
