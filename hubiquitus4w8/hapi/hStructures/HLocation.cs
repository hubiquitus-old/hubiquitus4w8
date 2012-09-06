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
    /// Version 0.3
    /// This structure describe the location
    /// </summary>
    class HLocation : HJsonObj
    {
        private JObject hlocation = new JObject();

        public HLocation()
        { 
        }

        public HLocation(JObject jsonObj)
        {
            FromJson(jsonObj);
        }

        public JObject ToJson()
        {
            return this.hlocation;
        }

        public void FromJson(JObject jsonObj)
        {
            if (jsonObj != null)
                hlocation = jsonObj;
            else
                hlocation = new JObject();
        }

        public string GetHType()
        {
            return "hlocation";
        }

        /// <summary>
        /// Check are made on : lng, lat, zip, num, building, floor, way, waytype, addr, city and countryCode.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  bool Equals(HLocation obj)
        {
            if (obj.GetLat() != this.GetLat())
                return false;
            if (obj.GetLng() != this.GetLng())
                return false;
            if (obj.GetZip() != this.GetZip())
                return false;
            if (obj.GetNum() != this.GetNum())
                return false;
            if (obj.GetBuilding() != this.GetBuilding())
                return false;
            if (obj.GetFloor() != this.GetFloor())
                return false;
            if (obj.GetWay() != this.GetWay())
                return false;
            if (obj.GetWaytype() != this.GetWaytype())
                return false;
            if (obj.GetAddr() != this.GetAddr())
                return false;
            if (obj.GetCity() != this.GetCity())
                return false;
            if (obj.GetCountryCode() != this.GetCountryCode())
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return hlocation.GetHashCode();
        }

        public override string ToString()
        {
            return hlocation.ToString();
        }

        //Getters & setters

        /// <summary>
        /// Get the latitude of the location. 0 if undefined
        /// </summary>
        /// <returns></returns>
        public double GetLat()
        {
            double lat;
            try
            {
                lat = (double)hlocation["lat"];
            }
            catch (ArgumentNullException)
            {
                lat = 0;
            }
            return lat;
        }

        public void SetLat(double lat)
        {
            try
            {
                    hlocation.Add("lat", lat);
            }
            catch (JsonWriterException)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Get the longitude of the location. 0 if undefined
        /// </summary>
        /// <returns></returns>
        public double GetLng()
        {
            double lng;
            try
            {
                lng = (double)hlocation["lng"];
            }
            catch (ArgumentNullException)
            {
                lng = 0;
            }
            return lng;
        }

        public void SetLng(double lng)
        {
            try
            {
                    hlocation.Add("lng", lng);
            }
            catch (JsonWriterException )
            {
                
                throw;
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
                zip = (string)hlocation["zip"];
            }
            catch (ArgumentNullException)
            {
                zip = null;
            }
            return zip;
        }

        public void SetZip(string zip)
        {
            try
            {
                if (zip == null)
                    hlocation.Remove("zip");
                else
                    hlocation.Add("zip", zip);
            }
            catch (JsonWriterException)
            {
                
                throw;
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
                num = (string)hlocation["num"];
            }
            catch (ArgumentNullException)
            {
                num = null;
            }
            return num;
        }

        public void SetNum(string num)
        {
            try
            {
                if (num == null)
                    hlocation.Remove("num");
                else
                    hlocation.Add("num", num);
            }
            catch (JsonWriterException)
            {
                
                throw;
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
                waytype = (string)hlocation["waytype"];
            }
            catch (ArgumentNullException)
            {
                waytype = null;
            }
            return waytype;
        }

        public void SetWaytype(string waytype)
        {
            try
            {
                if (waytype == null)
                    hlocation.Remove("waytype");
                else
                    hlocation.Add("waytype", waytype);
            }
            catch (JsonWriterException)
            {
                
                throw;
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
                way = (string)hlocation["way"];
            }
            catch (ArgumentNullException)
            {
                way = null;
            }
            return way;
        }

        public void SetWay(string way)
        {
            try
            {
                if (way == null)
                    hlocation.Remove("way");
                else
                    hlocation.Add("way", way);
            }
            catch (JsonWriterException)
            {
                
                throw;
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
                addr = (string)hlocation["addr"];
            }
            catch (ArgumentNullException)
            {
                addr = null;
            }
            return addr;
        }

        public void SetAddr(string addr)
        {
            try
            {
                if (addr == null)
                    hlocation.Remove("addr");
                else
                    hlocation.Add("addr", addr);
            }
            catch (JsonWriterException)
            {

                throw;
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
                floor = (string)hlocation["floor"];
            }
            catch (ArgumentNullException)
            {
                floor = null;
            }
            return floor;
        }

        public void SetFloor(string floor)
        {
            try
            {
                if (floor == null)
                    hlocation.Remove("floor");
                else
                    hlocation.Add("floor", floor);
            }
            catch (JsonWriterException)
            {

                throw;
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
                building = (string)hlocation["building"];
            }
            catch (ArgumentNullException)
            {
                building = null;
            }
            return building;
        }

        public void SetBuilding(string building)
        {
            try
            {
                if (building == null)
                    hlocation.Remove("building");
                else
                    hlocation.Add("building", building);
            }
            catch (JsonWriterException)
            {

                throw;
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
                city = (string)hlocation["city"];
            }
            catch (ArgumentNullException)
            {
                city = null;
            }
            return city;
        }

        public void SetCity(string city)
        {
            try
            {
                if (city == null)
                    hlocation.Remove("city");
                else
                    hlocation.Add("city", city);
            }
            catch (JsonWriterException)
            {

                throw;
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
                countryCode = (string)hlocation["countryCode"];
            }
            catch (ArgumentNullException)
            {
                countryCode = null;
            }
            return countryCode;
        }

        public void SetCountryCode(string countryCode)
        {
            try
            {
                if (countryCode == null)
                    hlocation.Remove("countryCode");
                else
                    hlocation.Add("countryCode", countryCode);
            }
            catch (JsonWriterException)
            {

                throw;
            }
        }
        
    }
}
