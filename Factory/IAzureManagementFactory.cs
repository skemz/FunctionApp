using Microsoft.Azure.Management.Fluent;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IAzureManagementFactory
    {
        IAzure getAzureCredentials();
    }
}
