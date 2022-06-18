using MvcWepApp2.dal;
using MvcWepApp2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MvcWepApp2.Models
{
    public class Ogrenci:ModelBase
    {
        SqlDataProcess data;
        public Ogrenci()
        {

            data = new SqlDataProcess();

        }
        public int SinifId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
        public Sinif _Sinif { get; set; }

        public List<Ogrenci> OgrenciGetir()
        {

            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetir", CommandType.Text);
          
            
        
           

            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Ad = dataRow["OgrenciAdi"].ToString(),
                    Soyad = dataRow["OgrenciSoyadi"].ToString(),
                    Numara = dataRow["OgrenciNumarasi"].ToString(),
                    _Sinif=new Sinif
                    {
                        Adi=dataRow["SinifAdi"].ToString(),
                        Kodu= dataRow["SinifKodu"].ToString(),


                    }
                });
            }
            return ogrenciler;
        }
        public List<Ogrenci> OgrencileriGetirSinifId()
        {

            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetirSinifId", CommandType.StoredProcedure,
                new SqlParameter("@SinifId",SinifId
                
                ));

            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Ad = dataRow["OgrenciAdi"].ToString(),
                    Soyad = dataRow["OgrenciSoyadi"].ToString(),
                    Numara = dataRow["OgrenciNumarasi"].ToString(),
             
                });
            }
            return ogrenciler;
        }
        public Ogrenci OgrenciGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Ogrenci_Getir",CommandType.StoredProcedure,new SqlParameter("@id",Id));
            Ogrenci _ogrenci = new Ogrenci();
            if (dt.Rows.Count >0 )
            {

                _ogrenci.Id = dt.Rows[0].Field<int>("Id");
                _ogrenci.Ad = dt.Rows[0].Field<string>("OgrenciAdi");
                _ogrenci.Soyad = dt.Rows[0].Field<string>("OgrenciSoyadi");
                _ogrenci.Numara = dt.Rows[0].Field<string>("OgrenciNumarasi");
                _ogrenci._Sinif = new Sinif { Adi = dt.Rows[0].Field<string>("SinifAdi") };
            }
            return _ogrenci;


        }

        public bool Ekle()
        {
            try
            {

                return data.SetExecuteNonQuery("Insert into Ogrenci (OgrenciAdi, OgrenciSoyadi, OgrenciNumarasi,SinifId) values(@ogrenciadi, @ogrencisoyadi, @ogrencinumarasi,@sinifid)",
                CommandType.Text,
                new SqlParameter("@ogrenciadi", Ad),
                new SqlParameter("@ogrencisoyadi", Soyad),
                new SqlParameter("@ogrencinumarasi", Numara),
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
                return data.SetExecuteNonQuery("Delete from Ogrenci where Id=@id",
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
            return data.SetExecuteNonQuery("Update Ogrenci set SinifId=@sinifid where Id=@id",
                CommandType.Text,
                new SqlParameter("@sinifid", _Sinif.Id),
                new SqlParameter("@id", Id));
        }

    }
}
