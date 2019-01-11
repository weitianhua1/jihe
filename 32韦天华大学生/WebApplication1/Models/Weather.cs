using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Weather
    {
  //      "result":{
		//"sk":{
		//	"temp":"6",
		//	"wind_direction":"北风",
		//	"wind_strength":"3级",
		
		//	"time":"10:20"
		//},
		//"today":{
		
		
		//	"weather_id":{
		//		"fa":"21",
		//		"fb":"02"
		//	},
		//	"wind":"北风微风",
		//	"week":"星期五",
		
		//	"date_y":"2019年01月11日",
		//	"dressing_index":"较冷",
		
		//	"uv_index":"最弱",
		//	"comfort_index":"",
		//	"wash_index":"不宜",
		//	"travel_index":"较不宜",
		//	"exercise_index":"较不宜",
		//	"drying_index":""
		//},
        [DisplayName("温度")]
        //result/today/temperature":"8℃~10℃",
        public string Temperature { get; set; }
        [DisplayName("城市")]
        // result/today/city":"柳州",
        public string City { get; set; }
        [DisplayName("湿度")]
        //	result/sk/humidity:"99%",
        public string Humidity { get; set; }
        [DisplayName("日期")]
        //result/today/date_y
        public string Date_y { get; set; }
        [DisplayName("空气")]
        //result/today/temperature":"8℃~10℃",
        public string test { get; set; }

    }
}