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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using hubiquitus4w8.hapi.util;
using System.Diagnostics;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// @version 0.5
    /// Describes a measure payload
    /// Message acknowledgements
    /// acknowledgements are used to identify the participants that have received or not received, read or not read a message 
    /// Note, when a hMessage contains a such kind of payload, the convid must be provided with the same value has the acknowledged hMessage.
    /// </summary>
    public class HAck : JObject
    {

        public HAck()
        {
        }

        public HAck(JObject jsonObj)
            : base(jsonObj)
        {
        }


        //Getters & setters
        //ackid will be removed since v0.5

        /// <summary>
        /// Get the status of  the acknowledgement.
        /// </summary>
        /// <returns></returns>
        public string GetAck() // problem with string enum
        {
            string ack = null;
            try
            {
                ack = this["ack"].ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} : Can not fetch the ack attribute : ", e);
            }
            return ack;
        }

        /// <summary>
        /// Set the status of the acknowledgement.
        /// </summary>
        /// <param name="ack"></param>
        public void SetAck(string ack)
        {
            try
            {
                if (ack == null)
                    this.Remove("ack");
                else
                {
                    if (HUtil.CheckAck(ack))
                        Debug.WriteLine("{0} : only 'recv' and 'read' are authorized for ack");
                    else
                        this["ack"] = ack;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("{0} : Can not update the ack attribute", e.ToString());
            }
        }
    }
}
