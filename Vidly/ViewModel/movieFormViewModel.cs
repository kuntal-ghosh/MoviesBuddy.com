﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {
        public ICollection<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}