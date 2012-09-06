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
  /// Version 0.3
  /// This kind of payload is used to describe the status of a thread of correlated messages identified by its convid.
  /// Multiple hConvStates with the same convid can be published into a channel, specifying the evolution of the state of the thread during time.
  /// </summary>
    class HConvState : HJsonObj
    {
        
        private JObject hconvstate = new JObject();

        public HConvState()
        { 
        }

        public HConvState(JObject jsonObj)
        {
            FromJson(jsonObj);
        }




        public JObject ToJson()
        {
            return this.hconvstate;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                hconvstate = jsonObj;
            else
                hconvstate = new JObject();
        }

        public string GetHType()
        {
            return "hconvstate";
        }

        public bool Equals(HConvState obj)
        {
            if (obj.GetStatus() != this.GetStatus())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return hconvstate.GetHashCode();
        }

        public override string ToString()
        {
            return hconvstate.ToString();
        }

        //Getter & setter
        /// <summary>
        /// The status of the thread
        /// </summary>
        /// <returns>topic description. Null if undefined.</returns>
        public string GetStatus()
        {
            string status;
            try
            {
                status = (string)hconvstate["status"];
            }
            catch (ArgumentNullException)
            {
                status = null;
            }
            return status;
        }

        public void SetStatus(string status)
        {
            try
            {
                if (status == null)
                    hconvstate.Remove("status");
                else
                    hconvstate.Add("status", status);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }
    }
}
