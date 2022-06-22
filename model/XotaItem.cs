
namespace XotaApi.Models
{
    public class XotaItem : IXotaItem
    {
        public XotaItem(){
            //empty constructor
        }

        protected string? _id;
        public string? Id { get { return _id; } }
        protected string? _source;
        public string? Source { get { return _source;} }
        protected int? _band;
        public int? Band { get { return _band;} }
        protected string? _frequency;
        public string? Frequency { get { return _frequency; } }
        protected string? _locationDetails;
        public string? LocationDetails { get { return _locationDetails; } }
        protected string? _locationCode;
        public string? LocationCode { get { return _locationCode; } }
        protected string? _activatorName;
        public string ActivatorName 
        { 
            get 
            {
                if (_activatorName == null) return "N/A";
                return _activatorName; 
            }
        }
        protected string? _activatorCallsign;
        public string? ActivatorCallsign { get { return _activatorCallsign; } }
        protected DateTime? _dateTime;
        public DateTime? DateTime { get { return _dateTime; } }
        protected string? _mode;
        public string? Mode 
        { get 
            { 
                if (_mode == null) return "UNKNOWN";
                return _mode.ToUpper(); 
            } 
        }

        public virtual void FillFromJson(dynamic json)
        {
            throw new NotImplementedException();
        }

        protected int GetBandFromFrequency(double freq){
            int band = 0;
            if ((freq >= 1800 && freq <= 2000) ||
                (freq >= 1.8 && freq <= 2.0))
            {
                band = 16000;
            } else if ((freq >= 3500 && freq <= 4000) ||
                (freq >= 3.5 && freq <= 4.0))
            {
                band = 8000;
            } else if ((freq >= 5300 && freq <= 5500) ||
                (freq >= 5.3 && freq <= 5.5))
            {
                band = 6000;
            } else if ((freq >= 7000 && freq <= 7300) ||
                (freq >= 7.0 && freq <= 7.3))
            {
                band = 4000;
            } else if ((freq >= 10100 && freq <= 10150) ||
                (freq >= 10.1 && freq <= 10.15))
            {
                band = 3000;
            } else if ((freq >= 14000 && freq <= 14350) ||
                (freq >= 14.0 && freq <= 14.35))
            {
                band = 2000;
            } else if ((freq >= 18068 && freq <= 18160) ||
                (freq >= 18.068 && freq <= 18.160))
            {
                band = 1700;
            } else if ((freq >= 21000 && freq <= 21450) ||
                (freq >= 21.0 && freq <= 21.450))
            {
                band = 1500;
            } else if ((freq >= 24890 && freq <= 24990) ||
                (freq >= 24.890 && freq <= 24.990))
            {
                band = 1200;
            } else if ((freq >= 28000 && freq <= 29700) ||
                (freq >= 28.0 && freq <= 29.7))
            {
                band = 1000;
            } else if ((freq >= 50000 && freq <= 54000) ||
                (freq >= 50.0 && freq <= 54.0))
            {
                band = 600;
            } else if ((freq >= 144000 && freq <= 148000) ||
                (freq >= 144.0 && freq <= 148.0))
            {
                band = 200;
            } else if ((freq >= 144000 && freq <= 148000) ||
                (freq >= 144.0 && freq <= 148.0))
            {
                band = 200;
            } else if ((freq >= 420000 && freq <= 450000) ||
                (freq >= 420.0 && freq <= 450.0))
            {
                band = 70;
            } else if ((freq >= 902000 && freq <= 928000) ||
                (freq >= 902.0 && freq <= 928.0))
            {
                band = 33;
            } else if ((freq >= 1240000 && freq <= 1300000) ||
                (freq >= 1240.0 && freq <= 1300.0))
            {
                band = 23;
            }

            return band;
        }

        protected double FixFrequency(double frequency){
            if (frequency > 500){
                frequency = frequency / 1000;
            }

            return frequency;
        }
    }
}