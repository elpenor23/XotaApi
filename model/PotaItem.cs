namespace XotaApi.Models;
public class PotaItem : Models.XotaItem, Models.IXotaItem
{
    public override void FillFromJson(dynamic json_object)
    {
        //TODO: Update ID so that we can more easily remove duplicates
        //      and combine with other Xota types
        
        double freq = json_object["frequency"];

        int band = this.GetBandFromFrequency(freq);

        this._id = json_object["activator"] + "|" + band.ToString() + "|" + json_object["reference"];
        this._source = "POTA";
        this._band = band;
        this._frequency = freq.ToString();
        
        string activatorName = "UNKNOWN";
        if (json_object["activator"] != null) {
            activatorName = json_object["activator"];
        }

        this._activatorCallsign = activatorName;
        this._activatorName = json_object["Unknown"];
        this._locationCode = json_object["reference"];
        this._locationDetails = json_object["name"] + " - " + json_object["locationDesc"];
        this._dateTime = json_object["spotTime"];
        this._mode = json_object["mode"];

    }
}