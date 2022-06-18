using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MvcWepApp2
{
    public static class Sqlbaglanti
    {

        
        public static SqlConnection Baglantial() //Sql Bağlantı Parm.
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source= BASB06 ; Initial Catalog =YönetimPaneli; Integrated Security=True"); //sqle bağlantı sağladım
           
            return baglanti; //Bağlantı döndür.
        }
       

    }
}