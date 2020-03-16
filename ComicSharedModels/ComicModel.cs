using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ComicSharedModels
{
    public class ComicModel
    {
        public int Month { get; set; }
        public int Num { get; set; }
        public string Link { get; set; }
        public int Year { get; set; }
        public string News { get; set; }
        public string Safe_title { get; set; }
        public string Transcript { get; set; }
        public string Alt { get; set; }
        public int Img { get; set; }
        public int Title { get; set; }
        public int Day { get; set; }
    }
}
