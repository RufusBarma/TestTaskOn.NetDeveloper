using System;
using System.Collections.Generic;

namespace Client.Scripts
{
    [Serializable]
    public class Tzinfo
    {
        public string name;
        public string abbr;
        public bool dst;
        public double offset;
    }

    [Serializable]
    public class Info
    {
        public bool n;
        public double geoid;
        public string url;
        public double lat;
        public double lon;
        public Tzinfo tzinfo;
        public double def_pressure_mm;
        public double def_pressure_pa;
        public string slug;
        public double zoom;
        public bool nr;
        public bool ns;
        public bool nsr;
        public bool p;
        public bool f;
        public bool _h;
    }

    [Serializable]
    public class District
    {
        public double id;
        public string name;
    }

    [Serializable]
    public class Locality
    {
        public double id;
        public string name;
    }

    [Serializable]
    public class Province
    {
        public double id;
        public string name;
    }

    [Serializable]
    public class Country
    {
        public double id;
        public string name;
    }

    [Serializable]
    public class GeoObject
    {
        public District district;
        public Locality locality;
        public Province province;
        public Country country;
    }

    [Serializable]
    public class Yesterday
    {
        public double temp;
    }

    [Serializable]
    public class Fact
    {
        public double obs_time;
        public double uptime;
        public double temp;
        public double feels_like;
        public string icon;
        public string condition;
        public double cloudness;
        public double prec_type;
        public double prec_prob;
        public double prec_strength;
        public bool is_thunder;
        public double wind_speed;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public string daytime;
        public bool polar;
        public string season;
        public string source;
        public double soil_moisture;
        public double soil_temp;
        public double uv_index;
        public double wind_gust;
    }

    [Serializable]
    public class NightShort
    {
        public string _source;
        public double temp;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class DayShort
    {
        public string _source;
        public double temp;
        public double temp_min;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class Evening
    {
        public string _source;
        public double temp_min;
        public double temp_avg;
        public double temp_max;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class Day
    {
        public string _source;
        public double temp_min;
        public double temp_avg;
        public double temp_max;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class Morning
    {
        public string _source;
        public double temp_min;
        public double temp_avg;
        public double temp_max;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class Night
    {
        public string _source;
        public double temp_min;
        public double temp_avg;
        public double temp_max;
        public double wind_speed;
        public double wind_gust;
        public string wind_dir;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_prob;
        public double prec_period;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public string icon;
        public string condition;
        public double uv_index;
        public double feels_like;
        public string daytime;
        public bool polar;
    }

    [Serializable]
    public class Parts
    {
        public NightShort night_short;
        public DayShort day_short;
        public Evening evening;
        public Day day;
        public Morning morning;
        public Night night;
    }

    [Serializable]
    public class Hour
    {
        public string hour;
        public double hour_ts;
        public double temp;
        public double feels_like;
        public string icon;
        public string condition;
        public double cloudness;
        public double prec_type;
        public double prec_strength;
        public bool is_thunder;
        public string wind_dir;
        public double wind_speed;
        public double wind_gust;
        public double pressure_mm;
        public double pressure_pa;
        public double humidity;
        public double uv_index;
        public double soil_temp;
        public double soil_moisture;
        public double prec_mm;
        public double prec_period;
        public double prec_prob;
    }

    [Serializable]
    public class Biomet
    {
        public double index;
        public string condition;
    }

    [Serializable]
    public class Forecast
    {
        public string date;
        public double date_ts;
        public double week;
        public string sunrise;
        public string sunset;
        public string rise_begin;
        public string set_end;
        public double moon_code;
        public string moon_text;
        public Parts parts;
        public List<Hour> hours;
        public Biomet biomet;
    }

    [Serializable]
    public class ForecastResponse 
    {
        public double now;
        public string now_dt;
        public Info info;
        public GeoObject geo_object;
        public Yesterday yesterday;
        public Fact fact;
        public List<Forecast> forecasts;

        public override string ToString()
        {
           return $"Now date: {now_dt}. Temperature: {fact.temp}. Feels like: {fact.feels_like}";
        }
    }
}
