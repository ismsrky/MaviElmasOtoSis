
namespace MaviElmasOtoSis
{
    public class Enumlar
    {
        public enum BirimTipleri
        {
            Idari=1,
            Atolye=2
        }

        public enum LogTurleri
        {
            SistemeGiris = 1,
            SistemdenCikis = 2,
            Hata = 3
        }

        public enum IslemTurleri
        {
            KasaTahsilatFisi = 1,
            KasaOdemeFisi = 2,
            KasaVirmani = 3,
            KasaAcilisFisiBorclu = 4,
            KasaAcilisFisiAlacakli = 5,
            BankayaYatirilan = 6,
            BankadanCekilen = 7,
            CariTahsilatFisi = 8,
            CariOdemeFisi = 9,
            GelenHavale = 10,
            GidenHavale = 11,
            SatisFaturasi = 12,
            AlisFaturasi = 13,
            FaturasizSatis = 14,
            FaturasizAlis = 15,
            BankaGelirFisi = 16,
            BankaGiderFisi = 17,
            PersonelMaasOdemesi = 18,
            PersonelAvansOdemesi = 19,
            PersonelAgiOdemesi = 20,
            BankaCariyeOdenen=21,
            BankaCariTahsilat=22
        }

        public enum DetayModelari
        {
            Tum,
            SadeceKaydet,
            SadeceOku
        }

        public enum DetayOlaylari
        {
            AramaGerekli,
            Kaydedildi,
            YuklemeGerekli,
            AramaYapildi,
            YeniKayit,
            Yukleme
        }

        public enum FaturaTipleri
        {
            AlisIrsaliyesi = 1,
            AlisFaturasi = 2,
            SatisFaturasi = 3,
            SatisIrsaliyesi = 4,
            FaturasizSatis = 5,
            FaturasizAlis = 6
        }

        public enum StokHareketTipleri
        {
            AlisIrsaliye = 1,
            AlisFatura = 2,
            SatisIrsaliye = 3,
            SatisFatura = 4,
            StokTahsisi = 5,
            DepoTransfer = 6,
            FaturasizAlis = 7,
            FaturasizSatis = 8,
            StokSayimEsitleme=9
        }

        public enum IsemriKapatmalari
        {
            Acik=1,
            GarantisiVar=2,
            Faturalandirildi=3
        }
    }
}