﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightR.Common
{
    public interface IMessage
    {
        Guid ApiKey { get; set; }
        DateTime OccourredAt { get; set; }
        DateTime ReceivedAt { get; set; }
    }
}
