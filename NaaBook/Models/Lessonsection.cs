﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Lessonsection
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int SubjectId { get; set; }

        public int LessonTime { get; set; }

        public Group Group { get; set; }

        public Subject Subject { get; set; }

    }
}