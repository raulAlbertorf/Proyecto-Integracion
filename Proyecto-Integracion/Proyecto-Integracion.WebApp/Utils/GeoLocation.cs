using Proyecto_Integracion.Models;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Device.Location;


namespace Proyecto_Integracion.WebApp.Utils
{
    public static class GeoLocation
    {
        /// <summary>
        /// Metodo que muestra la direccion completa dado una ubicacion
        /// </summary>
        /// (sflores)
        /// <param>Ubicacion</param>
        /// <returns>String</returns>
        public static string direccion( Ubicacion u )
        {
            DataRow row = getDataRow( u );
            return row[ "formatted_address" ].ToString( );
        }

        /// <summary>
        /// Metodo que muestra la ciudad dado una ubicacion
        /// </summary>
        /// (sflores)
        /// <param>Ubicacion</param>
        /// <returns>String</returns>
        public static string ciudad( Ubicacion u )
        {
            DataRow row = getDataRow( u );
            try
            {
                var value = row[ "formatted_address" ].ToString( ).Split( ',' );
                var count = value.Length;

                return value[ count - 3 ];
            }
            catch ( Exception ex )
            {
                return "";
            }
        }

        /// <summary>
        /// Metodo que muestra la region dado una ubicacion
        /// </summary>
        /// (sflores)
        /// <param>Ubicacion</param>
        /// <returns>String</returns>
        public static string region( Ubicacion u )
        {
            DataRow row = getDataRow( u );
            try
            {
                var value = row[ "formatted_address" ].ToString( ).Split( ',' );
                var count = value.Length;

                return value[ count - 2 ];
            }
            catch ( Exception ex )
            {
                return "";
            }
        }

        /// <summary>
        /// Metodo que obtiene una ubicacion usando la IP.
        /// </summary>
        /// (sflores)
        /// <param></param>
        /// <returns>Ubiczcion</returns>
        public static Ubicacion ubicacion( )
        {
            //var ip = getUserIP( );
            //var url = "http://freegeoip.net/xml/" + ip;
            //WebRequest request = WebRequest.Create( url );
            //using ( WebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
            //{
            //    using ( StreamReader reader = new StreamReader( response.GetResponseStream( ) , Encoding.UTF8 ) )
            //    {
            //        DataSet dsResult = new DataSet( );
            //        dsResult.ReadXml( reader );

            //        DataRow row = dsResult.Tables[ "response" ].Select( )[ 0 ];
            //        Ubicacion u = new Ubicacion( );
            //        u.Latitud= float.Parse(row["Latitude"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //        u.Longitud = float.Parse(row["Longitude"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //        return u;
            //    }
            //}
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            Ubicacion u = new Ubicacion();
            var permis = watcher.Permission;
            watcher.Start(true);
            var pos = watcher.Position.Location;
            u.Latitud = float.Parse(pos.Latitude.ToString());
            u.Longitud = float.Parse(pos.Longitude.ToString());
            //watcher.PositionChanged += (sender, e) =>
            //{
            //    var coordinate = e.Position.Location;
            //    u.Latitud = float.Parse(coordinate.Latitude.ToString());
            //    u.Longitud = float.Parse(coordinate.Longitude.ToString());
            //    // Uncomment to get only one event.
            //    watcher.Stop(); 
            //};

            // Begin listening for location updates.
            //watcher.Start();
            //var por = watcher.Position;
            //u.Latitud = float.Parse(por.Location.Latitude.ToString());
            //u.Longitud = float.Parse(por.Location.Longitude.ToString());

            //watcher.TryStart(false, TimeSpan.FromSeconds(3));
            //var whereat = watcher.Position.Location;

            //    var Lat = whereat.Latitude.ToString("0.000000");
            //    var Lon = whereat.Longitude.ToString("0.000000");


            //    //optional parameters for future use
            //    whereat.Altitude.ToString();
            //    whereat.HorizontalAccuracy.ToString();
            //    whereat.VerticalAccuracy.ToString();
            //    whereat.Course.ToString();
            //    whereat.Speed.ToString();

            //u.Latitud = float.Parse(Lat);
            //u.Longitud = float.Parse(Lon);
            watcher.Stop();
            return u;
        }

        /// <summary>
        /// Metodo que obtiene una ubicacion dado una ciudad
        /// </summary>
        /// (sflores)
        /// <param>string</param>
        /// <returns>Ubicacion</returns>
        public static Ubicacion buscar(string ciudad)
        {
            try
            {
                var url = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + ciudad + "&sensor=false";
                XmlDocument doc = new XmlDocument( );
                doc.Load( url );
                XmlNode element = doc.SelectSingleNode( "//GeocodeResponse/status" );
                if ( element.InnerText != "ZERO_RESULTS" )
                {
                    element = doc.SelectSingleNode( "//GeocodeResponse/result/geometry/location" );
                    var lat = Convert.ToSingle( element[ "lat" ].Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    var lon = Convert.ToSingle( element[ "lng" ].Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
                    return new Ubicacion( ) { Latitud = lat , Longitud = lon };
                }
            }
            catch ( Exception ex )
            {

            }
            return ubicacion( );


        }

        /// <summary>
        /// Metodo que obtiene datos desde la API de Google
        /// </summary>
        /// (sflores)
        /// <param>Ubicacion</param>
        /// <returns>DataRow</returns>
        private static DataRow getDataRow( Ubicacion u )
        {
            var url = "http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + u.Latitud.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + u.Longitud.ToString(System.Globalization.CultureInfo.InvariantCulture) + "&sensor=false";
            WebRequest request = WebRequest.Create( url );
            using ( WebResponse response = ( HttpWebResponse ) request.GetResponse( ) )
            {
                using ( StreamReader reader = new StreamReader( response.GetResponseStream( ) , Encoding.UTF8 ) )
                {
                    DataSet dsResult = new DataSet( );
                    dsResult.ReadXml( reader );

                    return dsResult.Tables[ "result" ].Select( )[ 0 ];
                    
                }
            }
        }

        /// <summary>
        /// Metodo que la IP del Usuario
        /// </summary>
        /// (sflores)
        /// <param>Ubicacion</param>
        /// <returns>DataRow</returns>
        private static string getUserIP( )
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables[ "HTTP_X_FORWARDED_FOR" ];

            if ( !string.IsNullOrEmpty( ipAddress ) )
            {
                string[ ] addresses = ipAddress.Split( ',' );
                if ( addresses.Length != 0 )
                {
                    return addresses[ 0 ];
                }
            }

            if( context.Request.ServerVariables[ "REMOTE_ADDR" ] != "::1")
            {
                return context.Request.ServerVariables[ "REMOTE_ADDR" ];
            }
            return "" ;
        }
    }
}