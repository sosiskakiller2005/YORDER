using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YORDER.Model;

namespace YORDER
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static YORDERDbEntities _context;
        public static YORDERDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new YORDERDbEntities();
            }
            return _context;
        }
    }
}
