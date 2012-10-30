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
    /// hAPI Message. For more info, see Hubiquitus reference
    /// </summary>
    class HMessage : HJsonObj
    {
        private JObject hmessage = new JObject();

        public HMessage()
        {
        }

        public HMessage(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        /* HJsonObj interface */

        public JObject ToJson()
        {
            return this.hmessage;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
            {
                this.hmessage = jsonObj;
            }
            else
            {
                this.hmessage = new JObject();
            }
        }

        public string GetHType()
        {
            return "hmessage";
        }

        public override string ToString()
        {
            return hmessage.ToString();
        }

        /// <summary>
        /// Check are made on : msgid, actor, convid, type, priority, relevance, transient, author, publisher, published and location. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool equals(HMessage obj)
        {
            if (obj.GetMsgid() != this.GetMsgid())
                return false;
            if (obj.GetChid() != this.GetChid())
                return false;
            if (obj.GetConvid() != this.GetConvid())
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            if (obj.GetPriority() != this.GetPriority())
                return false;
            if (obj.GetRelevance() != this.GetRelevance())
                return false;
            if (obj.GetTransient() != this.GetTransient())
                return false;
            if (obj.GetAuthor() != this.GetAuthor())
                return false;
            if (obj.GetPublisher() != this.GetPublisher())
                return false;
            if (obj.GetPublished() != this.GetPublished())
                return false;
            if (obj.GetLocation().Equals(this.GetLocation()))
                return false;
            return true;
        }


        public override int GetHashCode()
        {
            return hmessage.GetHashCode();
        }

        /* Getters & Setters */

        /// <summary>
        /// Mandatory. Filled by the hApi. message id. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetMsgid()
        {
            string msgid;
            try
            {
                msgid = (string)hmessage["msgid"];
            }
            catch (ArgumentNullException)
            {
                msgid = null;
            }
            return msgid;
        }

        public void SetMsgid(string msgid)
        {
            try
            {
                if (msgid == null)
                {
                    hmessage.Remove("msgid");
                }
                else
                {
                    hmessage.Add("msgid", msgid);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Mandatory. channel id. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetChid()
        {
            string actor;
            try
            {
                actor = (string)hmessage["actor"];
            }
            catch (ArgumentNullException)
            {
                actor = null;
            }
            return actor;
        }

        public void SetChid(string actor)
        {
            try
            {
                if (actor == null)
                {
                    hmessage.Remove("actor");
                }
                else
                {
                    hmessage.Add("actor", actor);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Mandatory. Filled by the hApi if empty. conversation id. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetConvid()
        {
            string convid;
            try
            {
                convid = (string)hmessage["convid"];
            }
            catch (ArgumentNullException)
            {
                convid = null;
            }
            return convid;
        }

        public void SetConvid(string convid)
        {
            try
            {
                if (convid == null)
                {
                    hmessage.Remove("convid");
                }
                else
                {
                    hmessage.Add("convid", convid);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Get type of the message payload. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetType()
        {
            string type;
            try
            {
                type = (string)hmessage["type"];
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            return type;
        }

        public void SetType(string type)
        {
            try
            {
                if (type == null)
                {
                    hmessage.Remove("type");
                }
                else
                {
                    hmessage.Add("type", type);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// If UNDEFINED, priority lower to 0. 
        /// </summary>
        /// <returns></returns>
        public HMessagePriority? GetPriority()
        {
            HMessagePriority? priority;
            try
            {

                priority = (HMessagePriority)(int)hmessage["priority"];

            }
            catch (ArgumentNullException)
            {
                priority = null;
            }
            return priority;
        }

        public void SetPriority(HMessagePriority? priority)
        {
            try
            {
                if (priority == null)
                    hmessage.Remove("priority");
                else
                    hmessage.Add("priority", (int)priority);
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }


        /// <summary>
        /// Date-time until which the message is considered as relevant. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public DateTime? GetRelevance()
        {
            DateTime? relevance;
            try
            {
                relevance = (DateTime)hmessage["relevance"];
              
            }
            catch (JsonReaderException)
            {
                relevance = null;
            }
            return relevance;
        }

        public void SetRelevance(DateTime relevance)
        {
            try
            {
                if (relevance == null)
                {
                    hmessage.Remove("relevance");
                }
                else
                {
                    hmessage.Add("relevance", relevance.ToString(HUtil.DateISO8601Format));
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }


        /// <summary>
        /// If true, the message is not persistent. persist message or not. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public bool? GetTransient()
        {
            bool? transient;
            try
            {
                transient = (bool)hmessage["transient"];
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
                    hmessage.Remove("transient");
                else
                    hmessage.Add("transient", transient);
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// The geographical location to which the message refer. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public HLocation GetLocation()
        {
            HLocation location;
            try
            {
                location = new HLocation((JObject)hmessage["location"]);
            }
            catch (ArgumentNullException)
            {
                location = null;
                throw;
            }
            return location;
        }

        public void SetLocation(HLocation location)
        {
            try
            {
                if (location == null)
                {
                    hmessage.Remove("location");
                }
                else
                {
                    hmessage.Add("location", location.ToJson());
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// author of this message. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetAuthor()
        {
            string author;
            try
            {
                author = (string)hmessage["author"];
            }
            catch (ArgumentNullException)
            {
                author = null;
            }
            return author;
        }

        public void SetAuthor(string author)
        {
            try
            {
                if (author == null)
                {
                    hmessage.Remove("author");
                }
                else
                {
                    hmessage.Add("author", author);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Mandatory. publisher of this message. NULL if undefined 
        /// </summary>
        /// <returns></returns>
        public string GetPublisher()
        {
            string publisher;
            try
            {
                publisher = (string)hmessage["publisher"];
            }
            catch (ArgumentNullException)
            {
                publisher = null;
            }
            return publisher;
        }

        public void SetPublisher(string publisher)
        {
            try
            {
                if (publisher == null)
                {
                    hmessage.Remove("publisher");
                }
                else
                {
                    hmessage.Add("publisher", publisher);
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// Mandatory. The date and time at which the message has been published. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public DateTime? GetPublished()
        {
            DateTime? published;
            try
            {
                published = (DateTime)hmessage["published"];
            }
            catch (ArgumentNullException)
            {
                published = null;
            }
            return published;
        }

        public void SetPublished(DateTime published)
        {
            try
            {
                if (published == null)
                {
                    hmessage.Remove("published");
                }
                else
                {
                    hmessage.Add("published", published.ToString(HUtil.DateISO8601Format));
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// The list of headers attached to this message. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public HJsonObj GetHeaders()
        {
            HJsonDictionnary headers = new HJsonDictionnary();
            try
            {
                headers.FromJson((JObject)hmessage["headers"]);
            }
            catch (ArgumentNullException)
            {
                headers = null;
            }
            return headers;
        }

        public void SetHeaders(HJsonObj headers)
        {
            try
            {
                if (headers == null)
                {
                    hmessage.Remove("headers");
                }
                else
                {
                    hmessage.Add("headers", headers.ToJson());
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }

        /// <summary>
        /// The content of the message. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public HJsonObj GetPayload()
        {
            HJsonObj payload;
            try
            {
                JObject jsonPayload = (JObject)hmessage["payload"];
                string type = this.GetHType();
                if (type.Equals("hmeasure", StringComparison.OrdinalIgnoreCase))
                {
                    payload = new HMeasure(jsonPayload);
                }
                else if (type.Equals("halert", StringComparison.OrdinalIgnoreCase))
                {
                    payload = new HAlert(jsonPayload);
                }
                else if (type.Equals("hack", StringComparison.OrdinalIgnoreCase))
                {
                    payload = new HAck(jsonPayload);
                }
                else if (type.Equals("hconvstate", StringComparison.OrdinalIgnoreCase))
                {
                    payload = new HConvState(jsonPayload);
                }
                else
                {
                    payload = new HJsonDictionnary(jsonPayload);
                }
            }
            catch (ArgumentNullException)
            {
                payload = null;
            }
            return payload;
        }

        public void SetPayload(HJsonObj payload)
        {
            try
            {
                if (payload == null)
                {
                    hmessage.Remove("payload");
                }
                else
                {
                    hmessage.Add("payload", payload.ToJson());
                }
            }
            catch (JsonWriterException)
            {
                throw;
            }
        }


    }


}
