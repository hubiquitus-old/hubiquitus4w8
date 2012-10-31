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
using hubiquitus4w8.hapi.util;
using log4net;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// @version 0.5
    /// Describes a measure payload
    /// Message acknowledgements
    /// acknowledgements are used to identify the participants that have received or not received, read or not read a message 
    /// Note, when a hMessage contains a such kind of payload, the convid must be provided with the same value has the acknowledged hMessage.
    /// </summary>
    public class HAck : JObject
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(HAck));

        public HAck()
        { 
        }

        public HAck(JObject jsonObj)
            : base(jsonObj)
        {
        }


        //Getters & setters
        //ackid will be removed since v0.5
       
        /// <summary>
        /// Get the status of  the acknowledgement.
        /// </summary>
        /// <returns></returns>
        public string GetAck() // problem with string enum
        {
            string ack = null;
            try
            {
                ack = this["ack"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the ack attribute : ",e);
            }
            return ack;
        }

        /// <summary>
        /// Set the status of the acknowledgement.
        /// </summary>
        /// <param name="ack"></param>
        public void SetAck(string ack)
        {
            try
            {
                if (ack == null)
                    this.Remove("ack");
                else
                {
                    if (HUtil.CheckAck(ack))
                        throw new Exception("only 'recv' and 'read' are authorized for ack");
                    this.Add("ack", ack);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the ack attribute : ", e);
            }
        }       
    }
}
