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
using log4net;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.5
    /// hAPI Message. For more info, see Hubiquitus reference
    /// </summary>
    public class HMessage : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HMessage));

        public HMessage()
        {
        }

        public HMessage(JObject jsonObj)
            : base(jsonObj)
        {
        }

        /* Getters & Setters */

        /// <summary>
        /// Mandatory. Filled by the hApi. message id. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetMsgid()
        {
            string msgid = null;
            try
            {
                msgid = this["msgid"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the msgid attribute : ", e);
            }
            return msgid;
        }

        public void SetMsgid(string msgid)
        {
            try
            {
                if (msgid == null)
                {
                    this.Remove("msgid");
                }
                else
                {
                    this.Add("msgid", msgid);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the msgid attribute : ", e);
            }
        }

        /// <summary>
        /// Mandatory. channel id. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetActor()
        {
            string actor = null;
            try
            {
                actor = this["actor"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the actor attribute : ", e);
            }
            return actor;
        }

        public void SetActor(string actor)
        {
            try
            {
                if (actor == null)
                {
                    this.Remove("actor");
                }
                else
                {
                    this.Add("actor", actor);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the actor attribute : ", e);
            }
        }

        /// <summary>
        /// Mandatory. Filled by the hApi if empty. conversation id. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetConvid()
        {
            string convid = null;
            try
            {
                convid = this["convid"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the convid attribute : ", e);
            }
            return convid;
        }

        public void SetConvid(string convid)
        {
            try
            {
                if (convid == null)
                {
                    this.Remove("convid");
                }
                else
                {
                    this.Add("convid", convid);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the convid attribute : ", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>reference to another hMessage msgid. NULL if undefined.</returns>
        public string GetRef()
        {
            string @ref = null;
            try
            {
                @ref = this["ref"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the ref attribute : ", e);
            }
            return @ref;
        }

        public void SetRef(string @ref)
        {
            try
            {
                if (@ref == null)
                {
                    this.Remove("ref");
                }
                else
                {
                    this.Add("ref", @ref);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the ref attribute : ", e);
            }
        }



        /// <summary>
        /// Get type of the message payload. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetType()
        {
            string type = null;
            try
            {
                type = this["type"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the type attribute : ", e);
            }
            return type;
        }

        public void SetType(string type)
        {
            try
            {
                if (type == null)
                {
                    this.Remove("type");
                }
                else
                {
                    this.Add("type", type);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the type attribute : ", e);
            }
        }

        /// <summary>
        /// If UNDEFINED, priority lower to 0. 
        /// </summary>
        /// <returns></returns>
        public HMessagePriority? GetPriority()
        {
            HMessagePriority? priority = null;
            try
            {
                priority = this["priority"].ToObject<HMessagePriority>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the priority attribute : ", e);
            }
            return priority;
        }

        public void SetPriority(HMessagePriority? priority)
        {
            try
            {
                if (priority == null)
                    this.Remove("priority");
                else
                    this.Add("priority", (int)priority);
            }
            catch (Exception e)
            {
                log.Error("Can not update the priority attribute : ", e);
            }
        }


        /// <summary>
        /// Date-time until which the message is considered as relevant. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public DateTime? GetRelevance()
        {
            DateTime? relevance = null;
            try
            {
                relevance = this["relevance"].ToObject<DateTime>();

            }
            catch (Exception e)
            {
                log.Error("Can not fetch the relevance attribute : ", e);
            }
            return relevance;
        }

        public void SetRelevance(DateTime? relevance)
        {
            try
            {
                if (relevance == null)
                {
                    this.Remove("relevance");
                }
                else
                {
                    this.Add("relevance", relevance.GetValueOrDefault().ToString(HUtil.DateISO8601Format));
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the relevance attribute : ", e);
            }
        }


        /// <summary>
        /// If true, the message is not persistent. persist message or not. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public bool? GetPersistent()
        {
            bool? persistent = null;
            try
            {
                persistent = this["persistent"].ToObject<bool>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the persistent attribute : ", e);
            }
            return persistent;
        }

        public void SetPersistent(bool? persistent)
        {
            try
            {
                if (persistent == null)
                    this.Remove("persistent");
                else
                    this.Add("persistent", persistent);
            }
            catch (Exception e)
            {
                log.Error("Can not update the persistent attribute : ", e);
            }
        }

        /// <summary>
        /// The geographical location to which the message refer. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public HLocation GetLocation()
        {
            HLocation location = null;
            try
            {
                location = this["location"].ToObject<HLocation>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the location attribute : ", e);
            }
            return location;
        }

        public void SetLocation(HLocation location)
        {
            try
            {
                if (location == null)
                {
                    this.Remove("location");
                }
                else
                {
                    this.Add("location", location);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the location attribute : ", e); ;
            }
        }

        /// <summary>
        /// author of this message. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            string author = null;
            try
            {
                author = this["author"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the author attribute : ", e);
            }
            return author;
        }

        public void SetAuthor(string author)
        {
            try
            {
                if (author == null)
                {
                    this.Remove("author");
                }
                else
                {
                    this.Add("author", author);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the author attribute : ", e);
            }
        }

        /// <summary>
        /// Mandatory. publisher of this message. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetPublisher()
        {
            string publisher = null;
            try
            {
                publisher = this["publisher"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the publisher attribute : ", e);
            }
            return publisher;
        }

        public void SetPublisher(string publisher)
        {
            try
            {
                if (publisher == null)
                {
                    this.Remove("publisher");
                }
                else
                {
                    this.Add("publisher", publisher);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the publisher attribute : ", e);
            }
        }

        /// <summary>
        /// Mandatory. The date and time at which the message has been published. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public DateTime? GetPublished()
        {
            DateTime? published = null;
            try
            {
                published = this["published"].ToObject<DateTime>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the published attribute : ", e);
            }
            return published;
        }

        public void SetPublished(DateTime? published)
        {
            try
            {
                if (published == null)
                {
                    this.Remove("published");
                }
                else
                {
                    this.Add("published", published.GetValueOrDefault().ToString(HUtil.DateISO8601Format));
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the published attribute : ", e);
            }
        }

        /// <summary>
        /// The list of headers attached to this message. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public JObject GetHeaders()
        {
            JObject headers = null;
            try
            {
                headers = this["headers"].ToObject<JObject>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the headers attribute : ", e);
            }
            return headers;
        }

        public void SetHeaders(JObject headers)
        {
            try
            {
                if (headers == null)
                {
                    this.Remove("headers");
                }
                else
                {
                    this.Add("headers", headers);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the headers attribute : ", e);
            }
        }

        /// <summary>
        /// if payload type is JObject
        /// </summary>
        /// <returns>The payload of JObject type.</returns>
        public JObject GetPayloadAsJObject()
        {
            JObject payload = null;
            try
            {
                payload = this["payload"].ToObject<JObject>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is JArray.
        /// </summary>
        /// <returns>The paylaod of JArray type.</returns>
        public JArray GetPayloadAsJArray()
        {
            JArray payload = null;
            try
            {
                payload = this["payload"].ToObject<JArray>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is string.
        /// </summary>
        /// <returns>The payload of string type.</returns>
        public string GetPayloadAsString()
        {
            string payload = null;
            try
            {
                payload = this["payload"].ToObject<string>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is boolean.
        /// </summary>
        /// <returns>The payload of boolean type.</returns>
        public bool? GetPayloadAsBoolean()
        {
            bool? payload = null;
            try
            {
                payload = this["payload"].ToObject<bool>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is int
        /// </summary>
        /// <returns>The payload of int type.</returns>
        public int? GetPayloadAsInt()
        {
            int? payload = null;
            try
            {
                payload = this["payload"].ToObject<int>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is double.
        /// </summary>
        /// <returns>The payload of double type.</returns>
        public double? GetPayloadAsDouble()
        {
            double? payload = null;
            try
            {
                payload = this["payload"].ToObject<double>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HAlert.
        /// </summary>
        /// <returns>The payload of HAlert type.</returns>
        public HAlert GetPayloadAsHAlert()
        {
            HAlert payload = null;
            try
            {
                payload = this["payload"].ToObject<HAlert>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HAck.
        /// </summary>
        /// <returns>The payload of HAck type.</returns>
        public HAck GetPayloadAsHAck()
        {
            HAck payload = null;
            try
            {
                payload = this["payload"].ToObject<HAck>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HMeasure.
        /// </summary>
        /// <returns>The payload of HMeasure type.</returns>
        public HMeasure GetPayloadAsHMeasure()
        {
            HMeasure payload = null;
            try
            {
                payload = this["payload"].ToObject<HMeasure>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HConvState.
        /// </summary>
        /// <returns>The payload of HConvState type.</returns>
        public HConvState GetPayloadAsHConvState()
        {
            HConvState payload = null;
            try
            {
                payload = this["payload"].ToObject<HConvState>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HResult.
        /// </summary>
        /// <returns>The payload of HResult type.</returns>
        public HResult GetPayloadAsHResult()
        {
            HResult payload = null;
            try
            {
                payload = this["payload"].ToObject<HResult>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }

        /// <summary>
        /// If payload type is HCommand.
        /// </summary>
        /// <returns>The payload of HCommand type.</returns>
        public HCommand GetPayloadAsHCommand()
        {
            HCommand payload = null;
            try
            {
                payload = this["payload"].ToObject<HCommand>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the payload attribute : ", e);
            }
            return payload;
        }


        /// <summary>
        /// Payload type could be instance of JSONObject(HAlert, HAck ...), JSONArray, String, Boolean, Number.
        /// </summary>
        /// <param name="payload"></param>
        public void SetPayload(object payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", (JToken)payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(JObject payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(JArray payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(string payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(bool payload)
        {
            try
            {
                this.Add("payload", payload);
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(int payload)
        {
            try
            {
                this.Add("payload", payload);
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(double payload)
        {
            try
            {
                this.Add("payload", payload);
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HAlert payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HAck payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HMeasure payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HConvState payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HResult payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        public void SetPayload(HCommand payload)
        {
            try
            {
                if (payload == null)
                {
                    this.Remove("payload");
                }
                else
                {
                    this.Add("payload", payload);
                }
            }
            catch (Exception e)
            {
                log.Error("Can not update the payload attribute : ", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>timeout. 0 if undefined.</returns>
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
                if (timeout == 0)
                    this.Remove("timeout");
                else
                    this.Add("timeout", timeout);
            }
            catch (Exception e)
            {
                log.Error("Can not update the timeout attribute : ", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>sent. Null if undefined.</returns>
        public DateTime? GetSent()
        {
            DateTime? sent = null;
            try
            {
                sent = this["sent"].ToObject<DateTime>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the sent attribute : ", e);
            }
            return sent;
        }

        public void SetSent(DateTime? sent)
        {
            try
            {
                if (sent ==null)
                    this.Remove("sent");
                else
                    this.Add("sent", sent);
            }
            catch (Exception e)
            {
                log.Error("Can not update the sent attribute : ", e);
            }
        }
    }
}
