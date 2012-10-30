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
    /// Describes a measure payload
    /// </summary>
    class HMeasure : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HMeasure));
        public HMeasure()
        {
        }

        public HMeasure(JObject jsonObj)
            : base(jsonObj)
        {
        }

        
        // Getters & Setters 

        /// <summary>
        /// Specifies the unit in which the measure is expressed, should be in lowercase. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetUnit()
        {
            string unit;
            try
            {
                unit = this["unit"].ToString();
            }
            catch (Exception e)
            {
                unit = null;
                log.Info("Message: ", e);
            }
            return unit;
        }

        public void SetUnit(string unit)
        {
            try
            {
                if (unit == null)
                {
                    this.Remove("unit");
                }
                else
                {
                    this.Add("unit", unit);
                }
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Specify the value of the measure (ie : 31.2). NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            string value;
            try
            {
                value = this["value"].ToString();
            }
            catch (Exception e)
            {
                value = null;
                log.Info("Message: ", e);
            }
            return value;
        }

        public void SetValue(string value)
        {
            try
            {
                if (value == null)
                {
                    this.Remove("value");
                }
                else
                {
                    this.Add("value", value);
                }
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

    }
}
