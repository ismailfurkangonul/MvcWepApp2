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
    public class Egitmen: ModelBase
    {
        //dependency injection
        SqlDataProcess data;
        public Egitmen()
        {

            data = new SqlDataProcess();

        }
       
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Sinif _Sinif { get; set; }
        public string Sifre { get; set; }

        public List<Egitmen> EgitmenGetir()
        {

            List<Egitmen> egitmenler = new List<Egitmen>();


            DataTable dtegitmenler = data.GetExecuteDataTable("Egitmen_ListeGetir", CommandType.Text);





            foreach (DataRow dataRow in dtegitmenler.Rows)
            {
                egitmenler.Add(new Egitmen
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Ad = dataRow["EgitmenAdi"].ToString(),
                    Soyad = dataRow["EgitmenSoyadi"].ToString(),
                    _Sinif = new Sinif
                    {
                        Adi = dataRow["SinifAdi"].ToString(),
                        Kodu = dataRow["SinifKodu"].ToString(),


                    }
                });
            }
            return egitmenler;
        }
        public Egitmen EgitmenGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Egitmen_Getir", CommandType.StoredProcedure, new SqlParameter("@id", Id));
            Egitmen _egitmen = new Egitmen();
            if (dt.Rows.Count > 0)
            {

                _egitmen.Id = dt.Rows[0].Field<int>("Id");
                _egitmen.Ad = dt.Rows[0].Field<string>("EgitmenAdi");
                _egitmen.Soyad = dt.Rows[0].Field<string>("EgitmenSoyadi");
                _egitmen._Sinif = new Sinif { Adi = dt.Rows[0].Field<string>("SinifAdi") };
            }
            return _egitmen;


        }

        public bool Ekle()
        {
            try
            {
                //Eğitmen eklendi
                return data.SetExecuteNonQuery("Insert into Egitmen (EgitmenAdi, EgitmenSoyadi,SinifId) values(@egitmenadi, @egitmensoyadi,@sinifid)",
                CommandType.Text,
                new SqlParameter("@egitmenadi", Ad),
                new SqlParameter("@egitmensoyadi", Soyad),
                new SqlParameter("@sinifid", _Sinif.Id));
                //sadece ekleme yapılacağı için nonquery
                return true;
            }

            catch (Exception)

            {
                return false;

            }

        }
        public bool Sil()
        {
            try
            {
                return data.SetExecuteNonQuery("Delete from Egitmen where Id=@id",
                     CommandType.Text,
                new SqlParameter("@id", Id));



            }
            catch (Exception)
            {
                return false;

            }

        }
        public bool Duzenle()
        {
            return data.SetExecuteNonQuery("Update Egitmen set SinifId=@sinifid where Id=@id",
                CommandType.Text,
                new SqlParameter("@sinifid", _Sinif.Id),
                new SqlParameter("@id", Id));
        }
        public bool GirisYap()
        {
            SqlConnection baglanti = Sqlbaglanti.Baglantial();

            DataTable dt = data.GetExecuteDataTable("Select * from Egitmen where EgitmenAdi=@egitmenadi and Sifre=@sifre",
                CommandType.Text,
                new SqlParameter("@egitmenadi", Ad),
                new SqlParameter("@sifre", Sifre));

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }


        }
    }
}