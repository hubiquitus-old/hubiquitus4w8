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

namespace hubiquitus4w8.hapi.util
{
    class HUtil
    {
        public static string DateISO8601Format = "yyyy-MM-ddTHH:mm:sszz00";

        public static int PickIndex<T>(List<T> list)
        {
            int index = 0;
            Random random = new Random();
            index = (int)(list.Count() * random.NextDouble());
            return index;
        }

        public static string GetHost(string endpoint)
        {
            string host = null;
            try
            {
                Uri uri = new Uri(endpoint);
                host = uri.Host;
            }
            catch (Exception)
            {
                host = null;
                throw;
            }
            return host;
        }

        public static int GetPort(string endpoint)
        {
            int port = 0;
            try
            {
                Uri uri = new Uri(endpoint);
                port = uri.Port;
            }
            catch (Exception)
            {
                port = 0;
                throw;
            }
            return port;
        }

        public static string GetPath(string endpoint)
        {
            string path = null;
            try
            {
                Uri uri = new Uri(endpoint);
                path = uri.PathAndQuery;
            }
            catch (Exception)
            {
                path = null;
                throw;
            }
            return path;
        }

        public static bool CheckAck(string ack)
        {
            List<string> AckValues = new List<string>();
            AckValues.Add("read");
            AckValues.Add("recv");
            if (AckValues.Contains(ack))
                return true;
            else
                return false;
        }

    }
}
