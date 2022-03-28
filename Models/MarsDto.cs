using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Models
{
    public class MarsDto
    {
        public List<MarsPhoto> photos { get; set; }
    }

    public class Camera
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rover_id { get; set; }
        public string full_name { get; set; }
    }

    public class Rover
    {
        public int id { get; set; }
        public string name { get; set; }
        public string landing_date { get; set; }
        public string launch_date { get; set; }
        public string status { get; set; }
    }

    public class MarsPhoto
    {
        public int id { get; set; }
        public int sol { get; set; }
        public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Rover rover { get; set; }
    }

}
