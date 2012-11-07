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

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    public class HGeo : JObject
    {

        public HGeo()
        {
        }

        public HGeo(JObject jsonObj)
            : base(jsonObj)
        {
        }

        public HGeo(double lat, double lng)
            : base()
        {
            SetLat(lat);
            SetLng(lng);
        }

        //Getter & Setter

        public double GetLat()
        {
            double lat = 0;
            try
            {
                lat = this["lat"].ToObject<double>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the lat attribute", e.ToString());
            }
            return lat;
        }

        public void SetLat(double lat)
        {
            try
            {
                this["lat"] = lat;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the lat attribute", e.ToString());
            }
        }

        public double GetLng()
        {
            double lng = 0;
            try
            {
                lng = this["lng"].ToObject<double>();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not fetch the lng attribute", e.ToString());
            }
            return lng;
        }

        public void SetLng(double lng)
        {
            try
            {
                this["lng"] = lng;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} : Can not update the lng attribute", e.ToString());
            }
        }
        
    }
}
