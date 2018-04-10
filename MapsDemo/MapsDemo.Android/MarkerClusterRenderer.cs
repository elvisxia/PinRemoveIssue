using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MapsDemo;
using MapsDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MapsDemo.CustomMap),typeof(MarkerClusterRenderer))]
namespace MapsDemo.Droid
{
    public class MarkerClusterRenderer:MapRenderer,IOnMapReadyCallback
    {
        Pin oMiddle = null;
        Marker myMarker;
        public MarkerClusterRenderer(Context c) : base(c)
        {

        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);
            var markerOptions = new Android.Gms.Maps.Model.MarkerOptions();
            markerOptions.SetTitle("Winffeeeeeeeeeee");
            markerOptions.SetPosition(new Android.Gms.Maps.Model.LatLng(37.051060, -122.014684));
            markerOptions.Draggable(true);
            myMarker=map.AddMarker(markerOptions);
            
            map.MarkerDrag += Map_MarkerDrag;
            Map.PropertyChanged += Map_PropertyChanged;
        }

        private void Map_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var m = (Map)sender;
            if (m.VisibleRegion != null)
            {
                if ((int)(m.VisibleRegion.Center.Latitude - 37.0510)==0 && (int)(m.VisibleRegion.Center.Longitude + 122.0146)==0)
                {
                    if (myMarker != null)
                    {
                        myMarker.Remove();
                        myMarker.Dispose();
                        myMarker = null;
                    }
                     
                }
                //Debug.WriteLine("Lat: " + m.VisibleRegion.Center.Latitude.ToString() + " Lon:" + m.VisibleRegion.Center.Longitude.ToString());
                //if (oMiddle == null)
                //{
                //    oMiddle = new Pin { Position = m.VisibleRegion.Center, Label = "Middle", Address = "test address" };
                //}
                //else
                //{
                //    mRemovePin(oMiddle);
                //    oMiddle.Position = m.VisibleRegion.Center;
                //}
                
                //Map.Pins.Add(oMiddle);
                // mGetUsersInRadius(10000);
            }
        }

        private void RemovePin(Pin oPin)
        {
            Map.Pins.Remove(oPin);
        }

        private void Map_MarkerDrag(object sender, GoogleMap.MarkerDragEventArgs e)
        {
            //implement your marker drag event here
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            Control.GetMapAsync(this);
        }
        
    }
}