using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Utilities.IoC;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; set; }
}
