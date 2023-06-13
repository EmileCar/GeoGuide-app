﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Domain
{
    public class Language
    {
        public string Name { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
