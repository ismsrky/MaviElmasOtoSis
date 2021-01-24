using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using MaviElmasOtoSis.VeriYonetimi;

namespace MaviElmasOtoSis.VeriYonetimi
{
    public class VeriErisim : IDisposable
    {
        #region < Yapıcı >
        public VeriErisim()
        {
            _baglanti = Baglanti.Ver_Baglanti();

        }
        public VeriErisim(string _sqlCumlesi)
        {
            _baglanti = Baglanti.Ver_Baglanti();
            SqlCumlesi = _sqlCumlesi;
        }
        #endregion

        #region < Yokedici >
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (_baglanti != null)
                {
                    Kapat_Baglanti();
                    _baglanti.Dispose();
                    _baglanti = null;
                }

                if (_cmd != null)
                {
                    _cmd.Dispose();
                    _cmd = null;
                }

                if (_adp != null)
                {
                    _adp.Dispose();
                    _adp = null;
                }

                if (_SqlParams != null)
                {
                    _SqlParams.Dispose();
                }

                //GC.Collect();
            }
            catch { }           
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #region < Değişkenler >
        MySqlParamCollection _SqlParams = new MySqlParamCollection();

        MySqlConnection _baglanti;
        MySqlCommand _cmd;
        MySqlDataAdapter _adp;
        #endregion

        #region < Özellikler >
        string _SqlCumlesi;
        public string SqlCumlesi
        {
            get
            {
                return _SqlCumlesi;
            }
            set
            {
                _SqlCumlesi = value;
            }
        }
        public MySqlParamCollection SqlParams
        {
            get
            {
                return _SqlParams;
            }
        }

        public MySqlParameter Ver_Param(string ParamAdi)
        {
            return _SqlParams[ParamAdi];
        }
        public MySqlParameter Ver_Param(int ParamIndex)
        {
            return _SqlParams[ParamIndex];
        }

        public object Ver_ParamDeger(string ParamAdi)
        {
            return Ver_Param(ParamAdi).Value;
        }
        public object Ver_ParamDeger(int ParamIndex)
        {
            return Ver_Param(ParamIndex).Value;
        }

        public MySqlCommand cmd
        {
            get
            {
                return _cmd;
            }
        }

        public MySqlDataAdapter adp
        {
            get
            {
                return _adp;
            }
        }

        public MySqlConnection baglanti
        {
            get
            {
                return _baglanti;
            }
        }
        #endregion

        #region < Metodlar >
        public void Ekle_Param(string ParamAdi, object ParamDegeri, MySqlDbType ParamDbType, ParameterDirection ParamYonu = ParameterDirection.Input, int ParamSize = 50)
        {
            _SqlParams.Ekle_Param(ParamAdi, ParamDegeri, ParamDbType, ParamYonu, ParamSize);
        }
        public void Sil_Param(string ParamAdi)
        {
            _SqlParams.Sil_Param(ParamAdi);
        }
        public void Degistir_Param(string ParamAdi, object YeniParamDegeri)
        {
            _SqlParams.Degistir_Param(ParamAdi, YeniParamDegeri);
        }
        public void Temizle_Param()
        {
            _SqlParams.Temizle_Param();
        }

        public void Ata_Params(MySqlParamCollection _ParamCollection)
        {
            _SqlParams = null;
            _SqlParams = _ParamCollection;
        }

        void Ekle_Paramaterleri(ref MySqlCommand _cmd)
        {
            if (_SqlParams.Adet > 0)
            {
                _cmd.Parameters.Clear();
                foreach (MySqlParameter item in _SqlParams.Ver_SqlParams)
                {
                    _cmd.Parameters.Add(item.ParameterName, item.MySqlDbType, item.Size);
                    _cmd.Parameters[item.ParameterName].Value = item.Value;
                    _cmd.Parameters[item.ParameterName].Direction = item.Direction;
                }
            }
        }
        void Ekle_Paramaterleri(ref MySqlDataAdapter _adp)
        {
            if (_SqlParams.Adet > 0 && _adp.SelectCommand != null)
            {
                _adp.SelectCommand.Parameters.Clear();
                foreach (MySqlParameter item in _SqlParams.Ver_SqlParams)
                {
                    _adp.SelectCommand.Parameters.Add(item.ParameterName, item.MySqlDbType, item.Size);
                    _adp.SelectCommand.Parameters[item.ParameterName].Value = item.Value;
                    _adp.SelectCommand.Parameters[item.ParameterName].Direction = item.Direction;
                }
            }
        }

        void Ac_Baglanti()
        {
            if (_baglanti.State != ConnectionState.Open) _baglanti.Open();
            Baglanti.MesgulMu = true;
        }
        void Kapat_Baglanti()
        {
            if (_baglanti.State != ConnectionState.Closed) _baglanti.Close();
            Baglanti.MesgulMu = false;
        }
        #endregion

        #region < Veri Erişim Metodları >
        public int ExecuteNonQuery(bool ParameterKullan = true, CommandType _KomutTipi = CommandType.Text)
        {
            int Sonuc = -1;

            if (string.IsNullOrEmpty(_SqlCumlesi))
                throw new Exception("Sql komutu işletilirken bir hata oluştu.Sql cümlesi yazılmamış.Komut metodu: ExecuteNonQuery");

            Ac_Baglanti();

            using (_cmd = new MySqlCommand(_SqlCumlesi, _baglanti))
            {
                if (ParameterKullan)
                {
                    Ekle_Paramaterleri(ref _cmd);
                }

                _cmd.CommandType = _KomutTipi;
                Sonuc = _cmd.ExecuteNonQuery();
            }

            Kapat_Baglanti();


            return Sonuc;
        }

        public object ExecuteScalar(bool ParameterKullan = true, CommandType _KomutTipi = CommandType.Text)
        {
            object Sonuc = null;

            if (string.IsNullOrEmpty(_SqlCumlesi))
                throw new Exception("Sql komutu işletilirken bir hata oluştu.Sql cümlesi yazılmamış.Komut metodu: ExecuteScalar");

            Ac_Baglanti();

            using (_cmd = new MySqlCommand(_SqlCumlesi, _baglanti))
            {
                if (ParameterKullan)
                {
                    Ekle_Paramaterleri(ref _cmd);
                }

                _cmd.CommandType = _KomutTipi;
                Sonuc = _cmd.ExecuteScalar();
            }

            Kapat_Baglanti();

            return Sonuc;
        }

        public MySqlDataReader ExecuteReader(bool ParameterKullan = true, CommandType _KomutTipi = CommandType.Text)
        {
            if (string.IsNullOrEmpty(_SqlCumlesi))
                throw new Exception("Sql komutu işletilirken bir hata oluştu.Sql cümlesi yazılmamış.Komut metodu: ExecuteReader");

            MySqlDataReader oku = null;

            Ac_Baglanti();

            using (_cmd = new MySqlCommand(_SqlCumlesi, _baglanti))
            {
                if (ParameterKullan)
                {
                    Ekle_Paramaterleri(ref _cmd);
                }

                _cmd.CommandType = _KomutTipi;
                oku = _cmd.ExecuteReader();
            }

            //Kapat_Baglanti();

            return oku;
        }

        public DataSet Ver_DataSet(bool ParameterKullan = true)
        {
            if (string.IsNullOrEmpty(_SqlCumlesi))
                throw new Exception("Sql komutu işletilirken bir hata oluştu.Sql cümlesi yazılmamış.Komut metodu: Ver_DataSet()");

            DataSet Sonuc = new DataSet();

            Ac_Baglanti();

            using (_adp = new MySqlDataAdapter(_SqlCumlesi, _baglanti))
            {
                if (ParameterKullan)
                {
                    Ekle_Paramaterleri(ref _adp);
                }

                _adp.Fill(Sonuc);
            }

            Kapat_Baglanti();

            return Sonuc;
        }

        public DataTable Ver_DataTable(bool ParameterKullan = true)
        {
            if (string.IsNullOrEmpty(_SqlCumlesi))
                throw new Exception("Sql komutu işletilirken bir hata oluştu.Sql cümlesi yazılmamış.Komut metodu: Ver_DataTable()");

            DataTable Sonuc = new DataTable();

            Ac_Baglanti();

            using (_adp = new MySqlDataAdapter(_SqlCumlesi, _baglanti))
            {
                if (ParameterKullan)
                {
                    Ekle_Paramaterleri(ref _adp);
                }

                _adp.Fill(Sonuc);
            }

            Kapat_Baglanti();

            return Sonuc;
        }
        #endregion
    }
}