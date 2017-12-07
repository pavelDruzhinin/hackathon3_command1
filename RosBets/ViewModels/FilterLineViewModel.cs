﻿using System.Collections.Generic;
using RosBets.Models;

namespace RosBets.ViewModels
{
    public class FilterLineViewModel
    {
        public IEnumerable<Sport> Sports { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}