using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _391565
{
    class Hesap
    {
        
        public string hesapTuru;
        public int hesapNo;
        public float bakiye;
        public int yillikKarOrani;
        public float yillikKar;
        public float gunlukKarOrani;
        public float toplamGunlukKar;
        public int cekilisHakki;
        public DateTime acilisTarihi = DateTime.Now;
        public DateTime islemTarihi = DateTime.Now;
        public List<HesapIslemKayit> listHesapIslemKayit = new List<HesapIslemKayit>();

        
        public Hesap()
        {

        }

        
        public void yatirPara(float para)
        {
            this.bakiye=this.bakiye+para;
            this.bakiye = (float)Math.Round((decimal)this.bakiye, 2);
            this.cekilisHakki = (int)this.bakiye / 1000;
            this.hesaplaKarTutari();
        }

        
        public void cekPara(float para)
        {
            this.bakiye=this.bakiye-para;
            this.bakiye = (float)Math.Round((decimal)this.bakiye, 2);// iki basamaklıya çevirir
            this.cekilisHakki = (int)this.bakiye / 1000;
            this.hesaplaKarTutari();
        }

        
        public void getirHesapDurum()
        {
            Console.WriteLine("\t Hesap No:" + this.hesapNo);
            Console.WriteLine("\t Hesap Türü:" + this.hesapTuru);
            Console.WriteLine("\t Hesap Açılış Tarihi:" + this.acilisTarihi);
            Console.WriteLine("\t Hesap Bakiye:" + this.bakiye);
            Console.WriteLine("\t Yıllık Kar:" + this.yillikKar);
            Console.WriteLine("\t Günlük Kar:" + this.toplamGunlukKar);
        }


        
        public void olusturHesapNo(int hesapNo)
        {
            this.hesapNo = hesapNo + 1;
        }

       
        public void hesaplaKarTutari()
        {
            this.yillikKar=this.bakiye*this.yillikKarOrani/100;
            this.gunlukKarOrani = this.yillikKar/365;
            this.toplamGunlukKar =(float) ((this.islemTarihi - this.acilisTarihi).TotalDays)*this.gunlukKarOrani;
            this.toplamGunlukKar= this.toplamGunlukKar > 0 ? this.toplamGunlukKar : -this.toplamGunlukKar;
            this.toplamGunlukKar = (float)Math.Round((decimal)this.toplamGunlukKar, 2);
        }



        
        public void gosterHesapOzeti()
        {
            if (this.listHesapIslemKayit.Count > 0)
            {
                Console.WriteLine("İşlem Dekontu");
                Console.WriteLine("**********************************************************");
                foreach (HesapIslemKayit kayit in this.listHesapIslemKayit)
                {
                    kayit.getirIslemDekontu();
                    Console.WriteLine("**********************************************************");
                }
            }
            else
            {
                Console.WriteLine("Henüz hesaplarınız üzerinde herhangi bir işlem yapılmamıştır.");
            }

        }



       
        public void gosterIslemDekontu(string islemTuru, float oncekiBakiye, float sonrakiBakiye, float tutar)
        {
            HesapIslemKayit kayit = new HesapIslemKayit();

            kayit.islemNo = listHesapIslemKayit.Count + 1;
            kayit.islemTuru = islemTuru; 
            kayit.oncekiBakiye = oncekiBakiye;
            kayit.sonrakiBakiye = sonrakiBakiye;
            kayit.tutar = tutar;
            Console.WriteLine("İşlem Dekontu");
            Console.WriteLine("**********************************************************");
            kayit.getirIslemDekontu();
            Console.WriteLine("**********************************************************");
            this.listHesapIslemKayit.Add(kayit);
        }



    }
}
