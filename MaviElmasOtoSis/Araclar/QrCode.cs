using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;

namespace MaviElmasOtoSis.Araclar
{
    public static class QrCode
    {
        #region < Metod >
        /// <summary>
        /// Girilen değeri karekod resim olarak döndürür.
        /// </summary>
        /// <param name="veri">Karekod için gerekli değer.</param>
        /// <param name="kkDuzey">Karekod düzeyi. Genelde 1 olarak ayarlanır.</param>
        /// <returns></returns>
        public static Image KareKodOlustur(string veri, int kkDuzey)
        {
            MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();

            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;

            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

            qe.QRCodeVersion = kkDuzey;

            Bitmap bm = qe.Encode(veri);

            return bm;
        }
        #endregion
    }
}