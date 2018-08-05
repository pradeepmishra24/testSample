﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ccAppCore.Exceptions
{
    public class MyAppException:Exception
    {

        public MyAppException() { }

        public MyAppException(string message) : base(message)
        {

        }

        public MyAppException(string message,Exception innerException) : base(message, innerException)
        {

        }
    }
}
