﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    public interface IPlatformInfo
    {
        string GetModel();

        string GetVersion();
    }
}
