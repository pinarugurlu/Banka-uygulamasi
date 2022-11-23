using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _391565
{
    class HesapIslemKayit
    {
        
        public int islemNo;
        public string islemTuru;
        public DateTime islemTarihi = DateTime.Now;
        public float tutar;
        public float oncekiBakiye;
        public float sonrakiBakiye;
        public string aciklama;


        
        public HesapIslemKayit()
        {

        }


        
        public void getirIslemDekontu()
        {
            Console.WriteLine("\t İşlem No:" + this.islemNo);
            Console.WriteLine("\t İşlem Türü:" + this.islemTuru);
            Console.WriteLine("\t İşlem Tarihi:" + this.islemTarihi);
            Console.WriteLine("\t Önceki Bakiye:" + this.oncekiBakiye);
            Console.WriteLine("\t Tutar:" + this.tutar);
            Console.WriteLine("\t Sonraki Bakiye:" + this.sonrakiBakiye);
            Console.WriteLine("\t Açıklama:" + this.islemTuru +" gerçekleşti.");
        }
   
    }
}
