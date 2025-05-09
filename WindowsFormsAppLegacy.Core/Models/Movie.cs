﻿using System;
using System.Collections.Generic;

namespace WindowsFormsAppLegacy.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public List<Actor> Actors { get; set; } = new();
}