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
    /// JSON serializable interface for hstructures
    /// Should be implemented by all hstructures    
    /// </summary>
    interface HJsonObj 
    {
        
       /// <summary>
       /// Get the JObject type of object.
       /// </summary>
       /// <returns></returns>
        JObject ToJson();

        /// <summary>
        /// Deserialize object from JObject.
        /// </summary>
        /// <param name="jsonObj"></param>
        void FromJson(JObject jsonObj);

        /// <summary>
        /// Get the type of HJsonObj.
        /// </summary>
        /// <returns></returns>
        string GetHType();
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
        
    }
}
