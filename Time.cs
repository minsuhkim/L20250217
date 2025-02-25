﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Time
    {
        public static int deltaTime
        {
            get
            {
                return deltaTimeSpan.Milliseconds;
            }
        }
        
        protected static TimeSpan deltaTimeSpan;

        protected static DateTime currentTime;
        protected static DateTime lastTime;

        public static void Update()
        {
            currentTime = DateTime.Now;
            deltaTimeSpan = currentTime - lastTime;
            lastTime = DateTime.Now;
        }
    }
}
