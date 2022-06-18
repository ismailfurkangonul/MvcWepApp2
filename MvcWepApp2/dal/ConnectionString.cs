using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.dal
{
    public static class ConnectionString
    {
        //öneriler resharper
        private static string _connection = @"Data Source= BASB06 ; Initial Catalog =YönetimPaneli; Integrated Security=True";
        public static string Connection { get { return _connection; } }
    }
}