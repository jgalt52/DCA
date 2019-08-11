using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace DenverCrimeApp
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_map_Click(object sender, EventArgs e)
        {
            
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

            // Basic Settings for greatmaps app
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(39.73686290, -104.99164970);
            gmap.MinZoom = 10;
            gmap.MaxZoom = 15;
            gmap.Zoom = 10;




            // Read in the .csv and create a list of objects with correct paramatetrs
            var lines = File.ReadAllLines(@"C:\\Users\\The Machine\\Desktop\\DenverCrimeApp\\DenverCrimeApp\\crime.csv");
            var csv = lines.Select(x =>
            {
                var parts = x.Split(',');
                return new Crimes()
                {
                    OffenseType = parts[4].Trim(),
                    OffenseCat = parts[5].Trim(),
                    GeoLat = parts[13].Trim().Trim('"').Trim('"'),
                    GeoLong = parts[12].Trim().Trim('"').Trim('"'),
                };
            }).ToList();




            // Create a new list of markers using the csv list created above
           List<GMarkerGoogle> gmaplist = csv.Select(x =>
            {

                //lets set the color type based crime type
                if(x.GeoLat == ""|| x.GeoLong == "") {
                    x.GeoLong = "0.0";
                    x.GeoLat = "0.0";}


                PointLatLng lambdapoint = new PointLatLng(Convert.ToDouble(x.GeoLat), Convert.ToDouble(x.GeoLong));

                switch (x.OffenseCat)
                {
                    case "all-other-crimes":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.blue) { };

                    case "larceny":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.brown_small) { };

                    case "theft-from-motor-vehicle":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.green_big_go) { };

                    case "traffic-accident":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.green) { };

                    case "drug-alcohol":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.purple) { };

                    case "auto-theft":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.orange_dot) { };


                    case "white-collar-crime":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.white_small) { };

                    case "burglary":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.yellow) { };

                    case "public-disorder":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.blue_dot) { };

                    case "aggravated-assault":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.orange) { };

                    case "other-crimes-against-persons":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.orange_small) { };

                    case "robbery":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.orange_dot) { };

                    case "sexual-assault":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.red_dot) { };

                    case "murder":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.red_big_stop) { };

                    case "arson":
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.red_dot) { };

                    default:
                        return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.black_small) { };


                }

                //PointLatLng lambdapoint = new PointLatLng(Convert.ToDouble(x.GeoLat), Convert.ToDouble(x.GeoLong));

                //return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.red)
                {
                    
                };

            }).ToList(); 
            



            //Create an overlay
            GMapOverlay markers = new GMapOverlay("markers");



            //Go through the marker list gmaplist and add them all to the layer
            foreach (GMarkerGoogle gmark in gmaplist)
            {
              
                        markers.Markers.Add(gmark);
            }

            gmap.Overlays.Add(markers);

           // GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(39.67510490, -104.99164970), GMarkerGoogleType.purple);

        }
    }
}
