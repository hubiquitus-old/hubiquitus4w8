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
    /// hAPI result. For more info, see Hubiquitus reference
    /// </summary>
    public class HResult : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HResult));

        public HResult()
        {
        }

        public HResult(JObject jsonObj)
            : base(jsonObj)
        {
        }


        //Getters & setters

        /// <summary>
        /// Get the status of the result. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public ResultStatus? GetStatus()
        {
            ResultStatus? status = null;
            try
            {
                status = this["status"].ToObject<ResultStatus>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the status attritbute : ", e);
            }
            return status;
        }

        public void SetStatus(ResultStatus? status)
        {
            try
            {
                if (status == null)
                    this.Remove("status");
                else
                    this.Add("status", (int)status);
            }
            catch (Exception e)
            {
                log.Error("Can not update the status attribute : ", e);
            }
        }

        /// <summary>
        /// If we don't know the type of result.
        /// </summary>
        /// <returns></returns>
        public object GetResult()
        {
            object result = null;
            try
            {
                result = this["result"];
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }

        /// <summary>
        /// If result type is JObject.
        /// </summary>
        /// <returns></returns>
        public JObject GetResultAsJObject()
        {
            JObject result = null;
            try
            {
                result = this["result"].ToObject<JObject>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }
        /// <summary>
        /// If result type is JArray.
        /// </summary>
        /// <returns></returns>
        public JArray GetResultASJArray()
        {
            JArray result = null;
            try
            {
                result = this["result"].ToObject<JArray>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }

        /// <summary>
        /// If result type is string.
        /// </summary>
        /// <returns></returns>
        public string GetResultAsString()
        {
            string result = null;
            try
            {
                result = this["result"].ToString();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }

        /// <summary>
        /// If the result type is bool.
        /// </summary>
        /// <returns></returns>
        public bool? GetResultAsBoolean()
        {
            bool? result = null;
            try
            {
                result = this["result"].ToObject<bool>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }

        /// <summary>
        /// If the result type is int.
        /// </summary>
        /// <returns></returns>
        public int? GetResultAsInt()
        {
            int? result = null;
            try
            {
                result = this["result"].ToObject<int>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }

        /// <summary>
        /// If the result type is double.
        /// </summary>
        /// <returns></returns>
        public double? GetResultAsDouble()
        {
            double? result = null;
            try
            {
                result = this["result"].ToObject<double>();
            }
            catch (Exception e)
            {
                log.Error("Can not fetch the result attribute : ", e);
            }
            return result;
        }


        /// <summary>
        /// The result type could be JObject, JArray, String, Boolean, Number.
        /// </summary>
        /// <param name="result"></param>
        public void SetResult(Object result)
        {
            try
            {
                if (result == null)
                    this.Remove("result");
                else
                    this.Add("result", (JToken)result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }


        public void SetResult(JObject result)
        {
            try
            {
                if (result == null)
                    this.Remove("result");
                else
                    this.Add("result", result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

        public void SetResult(JArray result)
        {
            try
            {
                if (result == null)
                    this.Remove("result");
                else
                    this.Add("result", (JToken)result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

        public void SetResult(string result)
        {
            try
            {
                if (result == null)
                    this.Remove("result");
                else
                    this.Add("result", result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

        public void SetResult(bool result)
        {
            try
            {
                this.Add("result", result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

        public void SetResult(int result)
        {
            try
            {
                this.Add("result", result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

        public void SetResult(double result)
        {
            try
            {
                this.Add("result", result);
            }
            catch (Exception e)
            {
                log.Error("Can not update the result attribute : ", e);
            }
        }

    }
}
