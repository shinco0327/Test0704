﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
    public interface IDeviceService
    {
        string GetTitle();
        string GetBody();
        void SetContent(string title_in,string body_in);
    }
    
    