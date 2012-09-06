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

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.4
    /// This structure describe the location
    /// </summary>
    class HFilterTemplate : HJsonObj
    {
        private JObject hFilter = new JObject();

        public HFilterTemplate()
        { 
        }

        public HFilterTemplate(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        public JObject ToJson()
        {
            return this.hFilter;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                hFilter = jsonObj;
            else
                hFilter = new JObject();
        }

        public string GetHType()
        {
            return "hfiltertemplate";
        }


        public override int GetHashCode()
        {
            return hFilter.GetHashCode();
        }

        public override string ToString()
        {
            return hFilter.ToString();
        }

        //Getters & setters
        /// <summary>
        /// The channel id where the filter must be applied.
        /// NULL if not defined. Mandatory
        /// </summary>
        /// <returns></returns>
        public string GetChid()
        {
            string chid;
            try
            {
                chid = (string)hFilter["chid"];
            }
            catch (ArgumentNullException)
            {
                chid = null;
            }
            return chid;
        }

        public void SetChid(string chid)
        {
            try
            {
                if (chid == null)
                    hFilter.Remove("chid");
                else
                    hFilter.Add("chid", chid);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get the name of the filter to apply. 
        /// This name will be the filter’s unique name in a channel.
        /// NULL if not defined. Mandatory
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            string name;
            try
            {
                name = (string)hFilter["name"];
            }
            catch (ArgumentNullException)
            {
                name = null;
            }
            return name;
        }

        public void SetName(string name)
        {
            try
            {
                if (name == null)
                    hFilter.Remove("name");
                else
                    hFilter.Add("name", name);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        ///  Return  an instance of a hmessage used as template for filtering upcoming messages.
        ///  If not defined then a radius or relevant flag must be set. 
        ///  This name will be the filter’s unique name in a channel.
        /// </summary>
        /// <returns>
        /// NULL if not defined.
        /// </returns>
        public HMessage GetTemplate()
        {
            HMessage template;
            try
            {
                template = new HMessage((JObject)hFilter["template"]);
            }
            catch (ArgumentNullException)
            {
                template = null;
            }
            return template;
        }

        public void SetTemplate(HMessage template)
        {
            try
            {
                if (template == null)
                    hFilter.Remove("template");
                else
                    hFilter.Add("template", template.ToJson());
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// When specified, the upcoming messages must be located within ‘x’ meters radius starting from the template location, ‘x’ being the value specified 0 if not defined
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public int GetRadius()
        {
            int radius;
            try
            {
                radius = (int)hFilter["radius"];
            }
            catch (ArgumentNullException)
            {
                radius = 0;
            }
            return radius;
        }

        public void SetRadius(int radius)
        {
            try
            {
                if (radius <= 0)
                    hFilter.Remove("radius");
                else
                    hFilter.Add("radius", radius);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// When specified to true, the upcoming messages must be relevant Null if not defined
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public bool? GetRelevant()
        {
            bool? relevant;
            try
            {
                relevant = (bool)hFilter["relevant"];
            }
            catch (ArgumentNullException)
            {
                relevant = null;
            }
            return relevant;
        }

        public void SetRelevant(bool? relevant)
        {
            try
            {
                if (relevant == null)
                    hFilter.Remove("relevant");
                else
                    hFilter.Add("relevant", relevant);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
    }
}
