using System;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

namespace MaviElmasOtoSis.Araclar
{
    public class ExcelClass : IDisposable
    {
        #region < Değişkenler >
        Excel._Application m_ExcelApplication = null;
        Excel._Workbook m_Workbook = null;
        public Excel._Worksheet m_Worksheet = null;
        object missing = System.Reflection.Missing.Value;
        #endregion

        #region < Yapıcı >
        public ExcelClass()
        {
            if (m_ExcelApplication == null)
            {
                m_ExcelApplication = new Excel.Application();
            }
        }

        ~ExcelClass()
        {
            try
            {
                if (m_ExcelApplication != null)
                    m_ExcelApplication.Quit();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }
        #endregion

        #region < Yokedici >
        public void Dispose()
        {
            try
            {
                if (m_ExcelApplication != null)
                {
                    this.Close(false);
                    m_ExcelApplication.Quit();
                    m_ExcelApplication = null;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }
        #endregion

        #region < Metodlar >
        /// <summary>
        /// Geçerli çalışma ayarları
        /// </summary>
        public int CurrentWorksheetIndex
        {
            set
            {
                if (value <= 0 || value > m_Workbook.Worksheets.Count)
                    throw new Exception("Dizin aralık dışında");
                else
                {
                    object index = value;
                    m_Worksheet = m_Workbook.Worksheets[index] as Excel._Worksheet;
                }
            }
        }

        /// <summary>
        /// Excel çalışma kitabı açın.
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenWorkbook(string fileName)
        {
            m_Workbook = m_ExcelApplication.Workbooks.Open(fileName, missing, missing, missing, missing, missing,
                missing, missing, missing, missing, missing, missing, missing, missing, missing);

            if (m_Workbook.Worksheets.Count > 0)
            {
                object index = 1;
                m_Worksheet = m_Workbook.Worksheets[index] as Excel._Worksheet;

            }
        }

        /// <summary>
        /// Değişiklikleri kaydedin.
        /// </summary>
        public void Save()
        {
            if (m_Workbook != null)
            {
                m_Workbook.Save();
            }
        }

        /// <summary>
        /// Belgeyi kapat.
        /// </summary>
        /// <param name="isSave"></param>
        public void Close(bool isSave)
        {
            this.ClearClipboard();

            object obj_Save = isSave;
            if (m_Workbook != null)
                m_Workbook.Close(obj_Save, missing, missing);
        }

        /// <summary>
        /// Geçerli çalışma sayfasındaki bir hücrenin değerini ayarlayın.
        /// </summary>
        /// <param name="cellIndex"></param>
        /// <param name="value"></param>
        public void SetCellValue(string cellIndex, object value)
        {
            if (m_Worksheet != null)
            {
                object cell1 = cellIndex;
                Excel.Range range = m_Worksheet.get_Range(cell1, missing);
                if (range != null)
                {
                    range.Value2 = value;
                }
            }
        }

        /// <summary>
        /// Hücreleri birleştir.
        /// </summary>
        /// <param name="cellIndex1"></param>
        /// <param name="cellIndex2"></param>
        public void Merge(string cellIndex1, string cellIndex2)
        {
            if (m_Worksheet != null)
            {
                object cell1 = cellIndex1;
                object cell2 = cellIndex2;
                Excel.Range range = m_Worksheet.get_Range(cell1, cell2);
                range.Merge(true);
            }
        }

        /// <summary>
        /// Geçerli çalışma sayfasının veri tablosu panoya kopyalanır.
        /// </summary>
        public void Copy()
        {
            if (m_Worksheet != null)
            {
                try
                {
                    m_Worksheet.UsedRange.Select();
                }
                catch { }
                m_Worksheet.UsedRange.Copy(missing);
            }
        }

        /// <summary>
        /// Panoyu temizle.
        /// </summary>
        public void ClearClipboard()
        {
            Clipboard.Clear();
        }
        #endregion

        #region < Static Metodlar >
        public static void ExceleAktar(DataTable dt, string CalismaSayfasiIsmi)
        {
            Excel.Application Excelim;
            Excel.Workbook CalismaKitabi;
            Excel.Worksheet CalismaSayfasi;

            Excelim = new Excel.Application();
            object SalakObje = System.Reflection.Missing.Value;
            CalismaKitabi = Excelim.Workbooks.Add(SalakObje);
            CalismaSayfasi = (Excel.Worksheet)CalismaKitabi.ActiveSheet;
            CalismaSayfasi.Name = CalismaSayfasiIsmi;
            int SutunIndex = 1;
            int SatirIndex = 2;

            // Sütunlar Yazılıyor.
            foreach (DataColumn Sutun in dt.Columns)
            {
                CalismaSayfasi.Cells[1, SutunIndex] = Sutun.ColumnName;
                SutunIndex++;
            }

            // Satırlar Yazılıyor.            
            foreach (DataRow Satir in dt.Rows)
            {
                for (int ci = 0; ci < dt.Columns.Count; ci++)
                {

                    if (Satir[ci].GetType() == typeof(decimal))
                        CalismaSayfasi.Cells[SatirIndex, ci + 1] = Convert.ToSingle(Satir[ci]);
                    else if (Satir[ci].GetType() == typeof(Int32))
                        CalismaSayfasi.Cells[SatirIndex, ci + 1] = Convert.ToInt32(Satir[ci]);
                    else
                        CalismaSayfasi.Cells[SatirIndex, ci + 1] = Satir[ci].ToString();

                }
                SatirIndex++;
            }

            // Excel gösteriliyor
            Excelim.Visible = true;
        }
        //public static void ExceleAktar(DevExpress.XtraGrid.Views.Grid.GridView gridview, string CalismaSayfasiIsmi)
        //{
        //    Excel.Application Excelim;
        //    Excel.Workbook CalismaKitabi;
        //    Excel.Worksheet CalismaSayfasi;

        //    Excelim = new Excel.Application();
        //    object SalakObje = System.Reflection.Missing.Value;
        //    CalismaKitabi = Excelim.Workbooks.Add(SalakObje);
        //    CalismaSayfasi = (Excel.Worksheet)CalismaKitabi.ActiveSheet;
        //    CalismaSayfasi.Name = CalismaSayfasiIsmi;
        //    int SutunIndex = 1;
        //    int SatirIndex = 2;

        //    // Sütunlar Yazılıyor.
        //    foreach (DevExpress.XtraGrid.Columns.GridColumn Sutun in gridview.Columns)
        //    {
        //        if (Sutun.Visible)
        //        {
        //            CalismaSayfasi.Cells[1, SutunIndex] = Sutun.Caption;
        //            SutunIndex++;
        //        }
        //    }

        //    // Satırlar Yazılıyor:
        //    int temp_col = 0;
        //    for (int i = 0; i < gridview.RowCount; i++)
        //    {
        //        for (int ci = 0; ci < gridview.Columns.Count; ci++)
        //        {
        //            if (gridview.Columns[ci].Visible)
        //            {
        //                if (gridview.GetDataRow(i)[gridview.Columns[ci].FieldName].GetType() == typeof(decimal))
        //                    CalismaSayfasi.Cells[SatirIndex, temp_col + 1] = Convert.ToSingle(gridview.GetDataRow(gridview.GetVisibleRowHandle(i))[gridview.Columns[ci].FieldName]);
        //                else if (gridview.GetDataRow(i)[gridview.Columns[ci].FieldName].GetType() == typeof(Int32))
        //                    CalismaSayfasi.Cells[SatirIndex, temp_col + 1] = Convert.ToInt32(gridview.GetDataRow(gridview.GetVisibleRowHandle(i))[gridview.Columns[ci].FieldName]);
        //                else
        //                    CalismaSayfasi.Cells[SatirIndex, temp_col + 1] = gridview.GetDataRow(gridview.GetVisibleRowHandle(i))[gridview.Columns[ci].FieldName].ToString();


        //                temp_col++;
        //            }
        //        }
        //        temp_col = 0;
        //        SatirIndex++;
        //    }

        //    // Excel gösteriliyor
        //    Excelim.Visible = true;
        //}
        #endregion
    }
}