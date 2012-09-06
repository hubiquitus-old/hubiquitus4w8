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

namespace hubiquitus4w8.hapi.exceptions
{
    /// <summary>
    /// Exception to notify a missing attribute (ONLY used in builders)
    /// </summary>
    class MissingAttrException : Exception
    {
        private static readonly long serialVersionUID = 1L;
        private string attrName = null;

        public string AttrName { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="attrName">
        /// Name of the missing attribute
        /// </param>
        public MissingAttrException(string attrName) 
        {
            this.attrName = attrName;
        }

        public string GetMessage() 
        {
            return "Attribute " + this.attrName + " is required but missing.";
        }

        public string GetLocalizedMessage()
        {
            return GetMessage();
        }

        public override string ToString()
        {
            return GetMessage();
        }

    }
}
