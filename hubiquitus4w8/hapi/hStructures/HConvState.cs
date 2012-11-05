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
  /// <summary>
  /// Version 0.5
  /// This kind of payload is used to describe the status of a thread of correlated messages identified by its convid.
  /// Multiple hConvStates with the same convid can be published into a channel, specifying the evolution of the state of the thread during time.
  /// </summary>
    public class HConvState : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HConvState));
        public HConvState()
        { 
        }

        public HConvState(JObject jsonObj)
            : base(jsonObj)
        {
        }


        //Getter & setter
        /// <summary>
        /// The status of the thread
        /// </summary>
        /// <returns>topic description. Null if undefined.</returns>
        public string GetStatus()
        {
            string status = null;
            try
            {
                status = this["status"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the status attribute : ", e);
            }
            return status;
        }

        public void SetStatus(string status)
        {
            try
            {
                if (status == null)
                    this.Remove("status");
                else
                    this["status"] = status;
            }
            catch (Exception e)
            {
                log.Error("Can not update the status attribute : ", e);
            }
        }
    }
}
