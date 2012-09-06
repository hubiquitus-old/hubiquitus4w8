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
    /// This structure describe the connection status
    /// </summary>
    class HStatus : HJsonObj
    {
        
        private JObject hstatus = new JObject();

        public HStatus()
        { 
        }

        public HStatus(JObject jsonObj)
        {
            FromJson(jsonObj);
        }


        public JObject ToJson()
        {
            return this.hstatus;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                hstatus = jsonObj;
            else
                hstatus = new JObject();
        }

        public string GetHType()
        {
            return "hstatus";
        }

        /// <summary>
        /// Check are made on status, errorCode, errorMsg.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(HStatus obj)
        {
            if (obj.GetStatus() != this.GetStatus())
                return false;
            if (obj.GetErrorCode() != this.GetErrorCode())
                return false;
            if (obj.GetErrorMsg() != this.GetErrorMsg())
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return hstatus.GetHashCode();
        }

        public override string ToString()
        {
            return hstatus.ToString();
        }

        //Getters & setters
        /// <summary>
        /// Get the status of connection. Null if not defined.
        /// </summary>
        /// <returns></returns>
        public ConnectionStatus? GetStatus()
        {
            ConnectionStatus? status;
            try
            {
                status = (ConnectionStatus)(int)hstatus["status"];
            }
            catch (ArgumentNullException)
            {
                status = null;
            }
            return status;
        }

        public void SetStatus(ConnectionStatus? status)
        {
            try
            {
                if (status == null)
                    hstatus.Remove("status");
                else
                    hstatus.Add("status", (int)status);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get the error of connction. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public ConnectionErrors? GetErrorCode()
        {
            ConnectionErrors? errorCode;
            try
            {
                errorCode = (ConnectionErrors)(int)hstatus["errorCode"];
            }
            catch (ArgumentNullException)
            {
                errorCode = null;
            }
            return errorCode;
        }

        public void SetErrorCode(ConnectionErrors? errorCode)
        {
            try
            {
                if (errorCode == null)
                    hstatus.Remove("errorCode");
                else
                    hstatus.Add("errorCode", (int)errorCode);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get error message of connection. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetErrorMsg()
        {
            string errorMsg;
            try
            {
                errorMsg = (string)hstatus["errorMsg"];
            }
            catch (ArgumentNullException)
            {
                errorMsg = null;
            }
            return errorMsg;
        }

        public void SetErrorMsg(string errorMsg)
        {
            try
            {
                if (errorMsg == null)
                    hstatus.Remove("errorMsg");
                else
                    hstatus.Add("errorMsg", errorMsg);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }


    }
}
