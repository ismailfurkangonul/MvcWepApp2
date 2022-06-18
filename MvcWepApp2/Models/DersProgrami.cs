using MvcWepApp2.dal;
using MvcWepApp2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class DersProgrami : ModelBase
    {
        SqlDataProcess data;
        public DersProgrami()
        {

            data = new SqlDataProcess();

        }
        
        public int SinifId { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public string DersAdi { get; set; }
        public string EgitmenAdi { get; set; }
        public string SinifAdi { get; set; }

        public List<DersProgrami> DersProgrami_Getir()
        {

            List<DersProgrami> dersprogrami = new List<DersProgrami>();


            DataTable dt = data.GetExecuteDataTable("DersProgrami_Getir", CommandType.StoredProcedure, new SqlParameter("@EgitmenAdi", EgitmenAdi));





            foreach (DataRow dataRow in dt.Rows)
            {
              
                dersprogrami.Add(new DersProgrami
                {
                    Id= dataRow.Field<int>("Id"),
                    SinifId = dataRow.Field<int>("SinifId"),
                    Baslangic = dataRow.Field<DateTime>("Baslangic"),
                    Bitis = dataRow.Field<DateTime>("Bitis"),
                    DersAdi = dataRow.Field<string>("DersAdi").ToString(),
                    SinifAdi = dataRow.Field<string>("SinifAdi").ToString()
                });
             }

            return dersprogrami;
        }

        public bool ProgramEkle()
        {
            try
            {

                return data.SetExecuteNonQuery("Insert into DersProgrami (Baslangic,Bitis,DersAdi,SinifId) values(@baslangic,@bitis,@dersadi,@sinifid)",
                CommandType.Text,
                new SqlParameter("@baslangic", Baslangic),
                new SqlParameter("@bitis", Bitis),
                new SqlParameter("@dersadi",DersAdi),
                new SqlParameter("@sinifid", SinifId));

                //sadece ekleme yapılacağı için nonquery
                
            }

            catch (Exception)

            {
                return false;

            }

        }
    }
}