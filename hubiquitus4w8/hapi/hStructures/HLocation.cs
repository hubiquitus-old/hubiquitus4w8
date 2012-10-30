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
using log4net;

namespace hubiquitus4w8.hapi.hStructures
{
    /// <summary>
    /// Version 0.5
    /// This structure describe the location
    /// </summary>
    class HLocation : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HLocation));
        public HLocation()
        { 
        }

        public HLocation(JObject jsonObj)
            : base(jsonObj)
        {
        }

        
        //Getters & setters

        /// <summary>
        /// Get the pos. null if undefined
        /// </summary>
        /// <returns></returns>
        public HGeo GetPos()
        {
            HGeo pos;
            try
            {
                pos = this["pos"].ToObject<HGeo>();
            }
            catch (Exception e)
            {
                pos = null;
                log.Info("Message: ", e);
            }
            return pos;
        }

        /// <summary>
        /// Set the pos.
        /// </summary>
        /// <param name="pos"></param>

        public void SetLat(HGeo pos)
        {
            try
            {
                    this.Add("pos", pos);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }


        /// <summary>
        /// Get the zip code of the location. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetZip()
        {
            string zip;
            try
            {
                zip = this["zip"].ToString();
            }
            catch (Exception e)
            {
                zip = null;
                log.Info("Message: ", e);
            }
            return zip;
        }

        public void SetZip(string zip)
        {
            try
            {
                if (zip == null)
                    this.Remove("zip");
                else
                    this.Add("zip", zip);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the way number of the location. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetNum()
        {
            string num;
            try
            {
                num = this["num"].ToString();
            }
            catch (Exception e)
            {
                num = null;
                log.Info("Message: ", e);
            }
            return num;
        }

        public void SetNum(string num)
        {
            try
            {
                if (num == null)
                    this.Remove("num");
                else
                    this.Add("num", num);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the type of the way of the location. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetWaytype()
        {
            string waytype;
            try
            {
                waytype = this["waytype"].ToString();
            }
            catch (Exception e)
            {
                waytype = null;
                log.Info("Message: ", e);
            }
            return waytype;
        }

        public void SetWaytype(string waytype)
        {
            try
            {
                if (waytype == null)
                    this.Remove("waytype");
                else
                    this.Add("waytype", waytype);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the name of the street/way of the location. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetWay()
        {
            string way;
            try
            {
                way = this["way"].ToString();
            }
            catch (Exception e)
            {
                way = null;
                log.Info("Message: ", e);
            }
            return way;
        }

        public void SetWay(string way)
        {
            try
            {
                if (way == null)
                    this.Remove("way");
                else
                    this.Add("way", way);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the address complement of the location. NULL if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetAddr()
        {
            string addr;
            try
            {
                addr = this["addr"].ToString();
            }
            catch (Exception e)
            {
                addr = null;
                log.Info("Message: ", e);
            }
            return addr;
        }

        public void SetAddr(string addr)
        {
            try
            {
                if (addr == null)
                    this.Remove("addr");
                else
                    this.Add("addr", addr);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the floor number of the location. NULL if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetFloor()
        {
            string floor;
            try
            {
                floor = this["floor"].ToString();
            }
            catch (Exception e)
            {
                floor = null;
                log.Info("Message: ", e);
            }
            return floor;
        }

        public void SetFloor(string floor)
        {
            try
            {
                if (floor == null)
                    this.Remove("floor");
                else
                    this.Add("floor", floor);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get the building’s identifier of the location. NULL if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetBuilding()
        {
            string building;
            try
            {
                building = this["building"].ToString() ;
            }
            catch (Exception e)
            {
                building = null;
                log.Info("Message: ", e);
            }
            return building;
        }

        public void SetBuilding(string building)
        {
            try
            {
                if (building == null)
                    this.Remove("building");
                else
                    this.Add("building", building);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get city of the location. NULL if undefined
        /// </summary>
        /// <returns></returns>
        public string GetCity()
        {
            string city;
            try
            {
                city = this["city"].ToString();
            }
            catch (Exception e)
            {
                city = null;
                log.Info("Message: ", e);
            }
            return city;
        }

        public void SetCity(string city)
        {
            try
            {
                if (city == null)
                    this.Remove("city");
                else
                    this.Add("city", city);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }

        /// <summary>
        /// Get countryCode of the location. NULL if undefined.
        /// </summary>
        /// <returns></returns>
        public string GetCountryCode()
        {
            string countryCode;
            try
            {
                countryCode = this["countryCode"].ToString();
            }
            catch (Exception e)
            {
                countryCode = null;
                log.Info("Message: ", e);
            }
            return countryCode;
        }

        public void SetCountryCode(string countryCode)
        {
            try
            {
                if (countryCode == null)
                    this.Remove("countryCode");
                else
                    this.Add("countryCode", countryCode);
            }
            catch (Exception e)
            {
                log.Info("Message: ", e);
            }
        }
        
    }
}
