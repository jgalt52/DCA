﻿using System;
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
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.Position = new PointLatLng(39.73686290, -104.99164970);
            gmap.MinZoom = 10;
            gmap.MaxZoom = 15;
            gmap.Zoom = 10;

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



        /*    GMarkerGoogle gmaplist = csv.Select(x =>
            {

                double GeoLongD = Convert.ToDouble(x.GeoLong);
                double GeoLatD = Convert.ToDouble(x.GeoLat);
                PointLatLng lambdapoint = new PointLatLng(GeoLatD, GeoLatD);

                return new GMarkerGoogle(lambdapoint, GMarkerGoogleType.red);

            }) */
            

            //MessageBox.Show(csv[2].objectspoint.ToString());


            GMapOverlay markersOverlay = new GMapOverlay("Markers");

            foreach (Crimes crime in csv)
            {
 
                        double GeoLongD = Convert.ToDouble(crime.GeoLong);
                        double GeoLatD = Convert.ToDouble(crime.GeoLat);
                        PointLatLng objectspoint = new PointLatLng(GeoLatD, GeoLatD);
                        GMarkerGoogle marker55 = new GMarkerGoogle(objectspoint, GMarkerGoogleType.red);
                        markersOverlay.Markers.Add(marker55);
                        

                        
            }
            gmap.Overlays.Add(markersOverlay);



          
            
           

            


            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(39.67510490, -104.99164970), GMarkerGoogleType.purple);
            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(39.67510490, -104.91057350), GMarkerGoogleType.blue);
            GMarkerGoogle marker4 = new GMarkerGoogle(new PointLatLng(39.82405790, -104.77523330), GMarkerGoogleType.green);
           // GMarkerGoogle marker3 = new GMarkerGoogle(new PointLatLng(latinput, longinput), GMarkerGoogleType.purple);
            markersOverlay.Markers.Add(marker);
            markersOverlay.Markers.Add(marker2);
           // markersOverlay.Markers.Add(marker3);
            markersOverlay.Markers.Add(marker4);
           
           
      

  

        }
    }
}