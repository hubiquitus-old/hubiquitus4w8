using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hubiquitus4w8.hapi.hStructures
{
    class HGeo : JObject
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HGeo));

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
                log.Error("Can not fetch the lat attribute : ", e);
            }
            return lat;
        }

        public void SetLat(double lat)
        {
            try
            {
                this.Add("lat", lat);
            }
            catch (Exception e)
            {
                log.Error("Can not update the lat attribute : ", e);
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
                log.Error("Can not fetch the lng attribute : ", e);
            }
            return lng;
        }

        public void SetLng(double lng)
        {
            try
            {
                this.Add("lng", lng);
            }
            catch (Exception e)
            {
                log.Error("Can not update the lng attribute : ", e);
            }
        }
        
    }
}
