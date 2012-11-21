﻿/*
 * Copyright (c) Novedia Group 2012.
 *
 *    This file is part of Hubiquitus
 *
 *    Permission is hereby granted, free of charge, to any person obtaining a copy
 *    of this software and associated documentation files (the "Software"), to deal
 *    in the Software without restriction, including without limitation the rights
 *    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 *    of the Software, and to permit persons to whom the Software is furnished to do so,
 *    subject to the following conditions:
 *
 *    The above copyright notice and this permission notice shall be included in all copies
 *    or substantial portions of the Software.
 *
 *    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 *    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 *    PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 *    FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 *    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 *    You should have received a copy of the MIT License along with Hubiquitus.
 *    If not, see <http://opensource.org/licenses/mit-license.php>.
 */


using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version v0.5
    /// This structure defines a simple condition value for the available operand
    /// </summary>
    public class HValue : JObject
    {
        private string name;

        public HValue()
            : base()
        { 
        }

        public HValue(JObject jsonObj)
            : base(jsonObj)
        { 
        }

        public HValue(string name, JToken value)
        {
            this.name = name;
            SetValue(value);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetValue(JToken value)
        {
            try
            {
                this[name] = value;
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} : Can not update the value attribute", e.ToString());
            }
            
        }

        public JToken GetValue()
        {
            JToken value = null;
            try
            {
                value = this[name];
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} : Can not fetch the value attribute", e.ToString());
            }
            return value;
        }
    }
}
