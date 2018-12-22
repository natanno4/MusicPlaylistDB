﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class Song
    {
        private String name;
        private int year;
        private Double hotness;
        private Double duration;
        private Double tempo;

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                this.year = value;
            }
        }
        public Double Hotness
        {
            get
            {
                return hotness;
            }
            set
            {
                this.hotness = value;
            }
        }
        public Double Duration
        {
            get
            {
                return duration;
            }
            set
            {
                this.duration = value;
            }
        }
        public Double Tempo
        {
            get
            {
                return tempo;
            }
            set
            {
                this.tempo = value;
            }
        }
    }
}