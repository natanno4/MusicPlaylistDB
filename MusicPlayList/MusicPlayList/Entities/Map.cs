using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class Map
    {
        private const double mapWidthdef = 360;
        private const double mapHeightdef = 180;
        private int mapWidth;
        private int mapHeight;
        private string mapImagePath;
        public Map()
        {
            string settings = ConfigurationManager.AppSettings["mapSettings"];
            string[] settingsArray = settings.Split(';');
            mapImagePath = settingsArray[0];
            Int32.TryParse(settingsArray[2], out mapHeight);
            Int32.TryParse(settingsArray[1], out mapWidth);
            CurrentLatitude = 0;
            CurrentLongitude = 0;
        }

        public int MapHeight
        {
            get
            {
                return this.mapHeight;
            }
        }

        public int MapWidth
        {
            get
            {
                return this.mapWidth;
            }
        }

        public string MapImagePath
        {
            get
            {
                return this.mapImagePath;
            }
        }

        public double CurrentLatitude
        {
            get; set;
        }

        public double CurrentLongitude
        {
            get; set;
        }

        public void fromPixelToCoordinates(double x, double y)
        {
            CurrentLongitude = x - 180;
            CurrentLatitude = 90 - y;
        }

        public double[] getMapSizeDiffernce()
        {
            double[] dif = { MapWidth / mapWidthdef, MapHeight / mapHeightdef };
            return dif;
        }
    }
}
