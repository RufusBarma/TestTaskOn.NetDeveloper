using System;
using System.Collections.Generic;

namespace TestApplication.YandexForecastResponse
{
    public class Tzinfo
    {
        public string name { get; set; }
        public string abbr { get; set; }
        public bool dst { get; set; }
        public double offset { get; set; }
    }

    public class Info
    {
        public bool n { get; set; }
        public double geoid { get; set; }
        public string url { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public Tzinfo tzinfo { get; set; }
        public double def_pressure_mm { get; set; }
        public double def_pressure_pa { get; set; }
        public string slug { get; set; }
        public double zoom { get; set; }
        public bool nr { get; set; }
        public bool ns { get; set; }
        public bool nsr { get; set; }
        public bool p { get; set; }
        public bool f { get; set; }
        public bool _h { get; set; }
    }

    public class District
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Locality
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Province
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class Country
    {
        public double id { get; set; }
        public string name { get; set; }
    }

    public class GeoObject
    {
        public District district { get; set; }
        public Locality locality { get; set; }
        public Province province { get; set; }
        public Country country { get; set; }
    }

    public class Yesterday
    {
        public double temp { get; set; }
    }

    public class Fact
    {
        public double obs_time { get; set; }
        public double uptime { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_prob { get; set; }
        public double prec_strength { get; set; }
        public bool is_thunder { get; set; }
        public double wind_speed { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public string season { get; set; }
        public string source { get; set; }
        public double soil_moisture { get; set; }
        public double soil_temp { get; set; }
        public double uv_index { get; set; }
        public double wind_gust { get; set; }
    }

    public class NightShort
    {
        public string _source { get; set; }
        public double temp { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class DayShort
    {
        public string _source { get; set; }
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Evening
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Day
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Morning
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Night
    {
        public string _source { get; set; }
        public double temp_min { get; set; }
        public double temp_avg { get; set; }
        public double temp_max { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_prob { get; set; }
        public double prec_period { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double uv_index { get; set; }
        public double feels_like { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
    }

    public class Parts
    {
        public NightShort night_short { get; set; }
        public DayShort day_short { get; set; }
        public Evening evening { get; set; }
        public Day day { get; set; }
        public Morning morning { get; set; }
        public Night night { get; set; }
    }

    public class Hour
    {
        public string hour { get; set; }
        public double hour_ts { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double cloudness { get; set; }
        public double prec_type { get; set; }
        public double prec_strength { get; set; }
        public bool is_thunder { get; set; }
        public string wind_dir { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public double uv_index { get; set; }
        public double soil_temp { get; set; }
        public double soil_moisture { get; set; }
        public double prec_mm { get; set; }
        public double prec_period { get; set; }
        public double prec_prob { get; set; }
    }

    public class Biomet
    {
        public double index { get; set; }
        public string condition { get; set; }
    }

    public class Forecast
    {
        public string date { get; set; }
        public double date_ts { get; set; }
        public double week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string rise_begin { get; set; }
        public string set_end { get; set; }
        public double moon_code { get; set; }
        public string moon_text { get; set; }
        public Parts parts { get; set; }
        public List<Hour> hours { get; set; }
        public Biomet biomet { get; set; }
    }

    public class ForecastResponse 
    {
        public double now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public GeoObject geo_object { get; set; }
        public Yesterday yesterday { get; set; }
        public Fact fact { get; set; }
        public List<Forecast> forecasts { get; set; }
    }
}