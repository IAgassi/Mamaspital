using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Mamaspital.Common;
using Mamaspital.DAL;
using Mamaspital.UI;



namespace Mamaspital
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager.Menu(new List<Employee>());
            
        }
    }
}
