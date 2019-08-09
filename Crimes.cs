using System;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace DenverCrimeApp
{
    public class Crimes
    {
        
        DateTime Date;
        public string OffenseType { get; set; } = "NA";
        public string OffenseCat { get; set; } = "NA";
        public string GeoLong { get; set; } = "0";


        public string GeoLat { get; set; } = "0";
        public GMarkerGoogleType markerType { get; set; }
        
        public PointLatLng objectspoint { get; set; }
      
        public GMarkerGoogle newmarkerObject { get; set; }
       

        //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(39.67510490, -104.99164970), GMarkerGoogleType.red);
    }
}
