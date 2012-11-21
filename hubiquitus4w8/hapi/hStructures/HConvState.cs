/*
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace hubiquitus4w8.hapi.hStructures
{
  /// <summary>
  /// Version 0.5
  /// This kind of payload is used to describe the status of a thread of correlated messages identified by its convid.
  /// Multiple hConvStates with the same convid can be published into a channel, specifying the evolution of the state of the thread during time.
  /// </summary>
    public class HConvState : JObject
    {
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
                Debug.WriteLine("{0} : Can not fetch the status attribute", e.ToString());
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
                Debug.WriteLine("{0} : Can not update the status attribute", e.ToString());
            }
        }
    }
}
