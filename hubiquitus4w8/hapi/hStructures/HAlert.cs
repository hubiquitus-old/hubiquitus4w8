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
    /// Alert message payload
    /// </summary>
    public class HAlert : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HAlert)); 
        public HAlert()
        { 
        }

        public HAlert(JObject jsonObj)
            : base(jsonObj)
        {
        }

        // Getter & setter
        /// <summary>
        /// Get the message provided by the author to describe the alert. (Eg: Power Failure)
        /// </summary>
        /// <returns>Null if undefined.</returns>
        public string GetAlert()
        {
            string alert = null;
            try
            {
                alert = this["alert"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the alert attribute : ", e);
            }
            return alert;
        }

        /// <summary>
        /// Set the message provided by the author to describe the alert. (Eg: Power Failure)
        /// </summary>
        /// <param name="alert"></param>
        public void SetAlert(string alert)
        {
            try
            {
                if (alert == null)
                    this.Remove("alert");
                else
                    this.Add("alert", alert);
            }
            catch (Exception e)
            {
                log.Error("Can not update the alert attribute : ", e);
            }
        }
    }
}
