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
    /// hAPI result. For more info, see Hubiquitus reference
    /// </summary>
    class HResult : HJsonObj
    {
        private JObject hresult = new JObject();

        public HResult()
        {
        }

        public HResult(JObject jsonObj)
        {
                FromJson(jsonObj);
        }


        public JObject ToJson()
        {
            return this.hresult;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                this.hresult = jsonObj;
            else
                this.hresult = new JObject();
        }

        public string GetHType()
        {
            return "hresult";
        }

        /// <summary>
        /// Checks are made on cmd, reqid, status
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  bool Equals(HResult obj)
        {
            if (obj.GetCmd() != this.GetCmd())
                return false;
            if (obj.GetReqid() != this.GetReqid())
                return false;
            if (obj.GetStatus() != this.GetStatus())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return hresult.GetHashCode();
        }

        public override string ToString()
        {
            return hresult.ToString();
        }

        //Getters & setters
        public string GetCmd()
        {
            string cmd;
            try
            {
                cmd = (string)hresult["cmd"];
            }
            catch (ArgumentNullException)
            {
                cmd = null;
            }
            return cmd;
        }

        public void SetCmd(string cmd)
        {
            try
            {
                if (cmd == null)
                    hresult.Remove("cmd");
                else
                    hresult.Add("cmd", cmd);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        public string GetReqid()
        {
            string reqid;
            try
            {
                reqid = (string)hresult["reqid"];
            }
            catch (ArgumentNullException)
            {
                reqid = null;
            }
            return reqid;
        }

        public void SetReqid(string reqid)
        {
            try
            {
                if (reqid == null)
                    hresult.Remove("reqid");
                else
                    hresult.Add("reqid", reqid);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get the status of the result. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public ResultStatus? GetStatus()
        {
            ResultStatus? status;
            try
            {
                status = (ResultStatus)(int)hresult["status"];
            }
            catch (ArgumentNullException)
            {
                status = null;
            }
            return status;
        }

        public void SetStatus(ResultStatus? status)
        {
            try
            {
                if (status == null)
                    hresult.Remove("status");
                else
                    hresult.Add("status", (int)status);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// If result type is a JObjet.
        /// If not, see GetResultArray() or GetResultValue().
        /// </summary>
        /// <returns>Result of a command operation or a subscription operation.</returns>
        public HJsonObj GetResult()
        {
            HJsonObj result;
            try
            {
                result = new HJsonDictionnary((JObject)hresult["result"]);
            }
            catch (JsonReaderException)
            {
                result = null;
                throw;
            }
            return result;
        }

        /// <summary>
        /// If result type is JArray.
        /// If not, see GetResult() or GetResultValue().
        /// </summary>
        /// <returns>Result of a command operation or a subscription operation.</returns>
        public JArray GetResultArray()
        {
            JArray result;
            try
            {
                result = (JArray)hresult["result"];
            }
            catch (JsonReaderException)
            {
                result = null;
                throw;
            }
            return result;
        }

        /// <summary>
        /// If result type is string, interger, date etc.
        /// If not, see GetResult() or GetResultArray();
        /// </summary>
        /// <returns>Result of a command operation or a subscription operation.</returns>
        public JValue GetResultValue()
        {
            JValue result;
            try
            {
                result = (JValue)hresult["result"];
            }
            catch (JsonReaderException)
            {
                result = null;
                throw;
            }
            return result;
        }

        public void SetResult(HJsonObj result)
        {
            try
            {
                if (result == null)
                    hresult.Remove("result");
                else
                    hresult.Add("result", result.ToJson());
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        
    }
}
