﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.SpeechTherapy.Models
{
    public class TestModel
    {
        [PrimaryKey , AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool isImageShow { get; set; } = true;
        public byte[] Data { get; set; }
    }
}
