using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HelloMauiApp.Models
{
    public class EpicDto
    {
        public string identifier { get; set; }
        public string caption { get; set; }
        public string image { get; set; }
        public string version { get; set; }
        public CentroidCoordinates centroid_coordinates { get; set; }
        public Position dscovr_j2000_position { get; set; }
        public Position lunar_j2000_position { get; set; }
        public Position sun_j2000_position { get; set; }
        public Position attitude_quaternions { get; set; }
        public string date { get; set; }
        public Coords coords { get; set; }

        [JsonIgnore]
        public string ImageUrl { get; set; }
    }

    public class CentroidCoordinates
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
    }


    public class Coords
    {
        public CentroidCoordinates centroid_coordinates { get; set; }
        public Position dscovr_j2000_position { get; set; }
        public Position lunar_j2000_position { get; set; }
        public Position sun_j2000_position { get; set; }
        public Position attitude_quaternions { get; set; }
    }
}
