﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}