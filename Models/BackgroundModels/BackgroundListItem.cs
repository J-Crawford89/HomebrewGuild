﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Data.Enums;

namespace Models.BackgroundModels
{
    public class BackgroundListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
