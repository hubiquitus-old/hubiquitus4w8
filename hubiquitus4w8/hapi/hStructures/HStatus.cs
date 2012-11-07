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
    /// Version 0.5
    /// This structure describe the connection status
    /// </summary>
    public class HStatus : JObject
    {

        public HStatus()
        { 
        }

        public HStatus(JObject jsonObj)
            : base(jsonObj)
        {
        }


        //Getters & setters
        /// <summary>
        /// Get the status of connection. Null if not defined.
        /// </summary>
        /// <returns></returns>
        public ConnectionStatus? GetStatus()
        {
            ConnectionStatus? status = null;
            try
            {
                status = (ConnectionStatus)this["status"].ToObject<int>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the status attribute", e.ToString());
            }
            return status;
        }

        public void SetStatus(ConnectionStatus? status)
        {
            try
            {
                if (status == null)
                    this.Remove("status");
                else
                    this["status"] = (int)status;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the status attribute", e.ToString());
            }
        }

        /// <summary>
        /// Get the error of connction. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public ConnectionErrors? GetErrorCode()
        {
            ConnectionErrors? errorCode = null;
            try
            {
                errorCode = (ConnectionErrors)this["errorCode"].ToObject<int>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the errorCode attribute", e.ToString());
            }
            return errorCode;
        }

        public void SetErrorCode(ConnectionErrors? errorCode)
        {
            try
            {
                if (errorCode == null)
                    this.Remove("errorCode");
                else
                    this["errorCode"] = (int)errorCode;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the errorCode attribute : ",e);
            }
        }

        /// <summary>
        /// Get error message of connection. Null if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetErrorMsg()
        {
            string errorMsg = null;
            try
            {
                errorMsg = this["errorMsg"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : {0} : Can not fetch the errorMsg attribute", e.ToString());
            }
            return errorMsg;
        }

        public void SetErrorMsg(string errorMsg)
        {
            try
            {
                if (errorMsg == null)
                    this.Remove("errorMsg");
                else
                    this["errorMsg"] = errorMsg;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : {0} : Can not update the errorMsg attribute", e.ToString());
            }
        }


    }
}
