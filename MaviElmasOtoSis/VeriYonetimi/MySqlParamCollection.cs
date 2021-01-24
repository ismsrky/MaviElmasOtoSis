using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace MaviElmasOtoSis.VeriYonetimi
{
    public class MySqlParamCollection : IDisposable
    {
        #region < Yapıcı >
        public MySqlParamCollection()
        {

        }
        #endregion

        #region < Yokedici >
        protected virtual void Dispose(bool disposing)
        {
            _SqlParams.Clear();
            _SqlParams = null;

            //GC.Collect();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #region < Değişkenler >
        List<MySqlParameter> _SqlParams = new List<MySqlParameter>();

        MySqlParameter SqlParam;
        #endregion

        #region < Özellikler >
        public MySqlParameter this[string ParamAdi]
        {
            get
            {
                foreach (MySqlParameter item in _SqlParams)
                {
                    if (item.ParameterName == ParamAdi)
                    {
                        return item;
                    }
                }

                return null;
            }
        }

        public MySqlParameter this[int ParamIndex]
        {
            get
            {
                return _SqlParams[ParamIndex];
            }
        }

        public List<MySqlParameter> Ver_SqlParams
        {
            get
            {
                return _SqlParams;
            }
        }

        public int Adet
        {
            get
            {
                return _SqlParams.Count;
            }
        }
        #endregion

        #region < Metod >
        public void Ekle_Param(string ParamAdi, object ParamDegeri, MySqlDbType ParamDbType, ParameterDirection ParamYonu = ParameterDirection.Input, int ParamSize = 50)
        {
            SqlParam = new MySqlParameter(ParamAdi, ParamDegeri);
            SqlParam.Direction = ParamYonu;
            SqlParam.Size = ParamSize;
            SqlParam.MySqlDbType = ParamDbType;

            _SqlParams.Add(SqlParam);
        }
        public void Ekle_Param(string ParamAdi, MySqlDbType ParamDbType, ParameterDirection ParamYonu = ParameterDirection.Input, int ParamSize = 50)
        {
            Ekle_Param(ParamAdi, null, ParamDbType, ParamYonu, ParamSize);
        }
        public void Sil_Param(string ParamAdi)
        {
            int silinecek_index = -1;
            for (int i = 0; i < _SqlParams.Count; i++)
            {
                if (_SqlParams[i].ParameterName == ParamAdi)
                {
                    silinecek_index = i;
                    break;
                }
            }

            _SqlParams.RemoveAt(silinecek_index);
        }
        public void Degistir_Param(string ParamAdi, object YeniParamDegeri)
        {
            bool Bulundu = false;
            foreach (MySqlParameter item in _SqlParams)
            {
                if (item.ParameterName == ParamAdi)
                {
                    item.Value = YeniParamDegeri;
                    Bulundu = true;
                    break;
                }
            }

            if (Bulundu == false)
            {
                throw new Exception("Sql Paramertre değeri değiştirilken bir hata oluştur. Paramatere bulunamadı.Yer: Degistir_Param()");
            }
        }
        public void Temizle_Param()
        {
            _SqlParams.Clear();
        }
        #endregion
    }
}