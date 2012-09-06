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
    /// Alert message payload
    /// </summary>
    class HAlert : HJsonObj
    {
        private JObject halert = new JObject();

        public HAlert()
        { 
        }

        public HAlert(JObject jsonObj)
        {
            FromJson(jsonObj);
        }
        
        //interface HJsonObj
        public JObject ToJson()
        {
            return this.halert;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                halert = jsonObj;
            else
                halert = new JObject();
        }

        public string GetHType()
        {
            return "halert";
        }

        public override bool Equals(object obj)
        {
            return halert.Equals(obj);
        }

        public override int GetHashCode()
        {
            return halert.GetHashCode();
        }

        public override string ToString()
        {
            return halert.ToString();
        }

        // Getter & setter
        /// <summary>
        /// The message provided by the the author to descibe the alert. (Eg: Power Failure)
        /// </summary>
        /// <returns>Null if undefined.</returns>
        public string GetAlert()
        {
            string alert;
            try
            {
                alert = (string)halert["alert"];
            }
            catch (ArgumentNullException)
            {
                alert = null;
            }
            return alert;
        }

        public void SetAlert(string alert)
        {
            try
            {
                if (alert == null)
                    halert.Remove("alert");
                else
                    halert.Add("alert", alert);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
    }
}
