﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Shared.Common.Interfaces
{
    public interface IEumModule
    {
        void InitiailzeModule(IServiceCollection services);
    }
}