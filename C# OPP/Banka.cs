using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _391565
{
    enum HesapTuru { KısaVadeli = 15, UzunVadeli = 17, Cari = 0, Ozel = 10 };
    class Banka
    {
        
        List<Hesap> listHesap= new List<Hesap>();
        
        public static int hesapSayisi = 10000000;

        
        public Banka()
        {
            Console.WriteLine("YBS Banka Hoşgeldiniz!");
            this.secMenu();
        }


        


       
        public void secMenu()
        {
            Console.WriteLine("\n-------------------------------------------------------------");
            Console.WriteLine("Hesap Açma İşlemleri: \n \t 1- Kısa Vadeli Hesap Oluşturma \n" +
               " \t 2- Uzun Vadeli Hesap Oluşturma \n" +
               "\t 3- Cari \n" +
               "\t 4- Özel \n" +
               " 5- Para Yatırma İşlemleri:\n" +
               " 6- Para Çekme İşlemleri: \n" +
               " 7- Hesap Listesi: \n" +
               " 8- Hesap Durumu \n" +
               " 9- Hesap İşlem Kayıtları \n" +
               " 10- Çekiliş"
               );
            Console.WriteLine("-------------------------------------------------------------\n");
            Console.WriteLine("Yapmak İstediğiniz İşlemi Seçiniz.");


            string secilenIslem = Console.ReadLine();
            int i;
            if(int.TryParse(secilenIslem, out i))
            {
                 int secilenIslemNo = Convert.ToInt32(secilenIslem);
                switch (secilenIslemNo)
                {
                    case 1:
                        olusturHesap((int)HesapTuru.KısaVadeli);
                        break;
                    case 2:
                        olusturHesap((int)HesapTuru.UzunVadeli);
                        break;
                    case 3:
                        olusturHesap((int)HesapTuru.Cari);
                        break;
                    case 4:
                        olusturHesap((int)HesapTuru.Ozel);
                        break;
                    case 5:
                        yatirPara();
                        break;
                    case 6:
                        cekPara();
                        break;
                    case 7:
                        yazdirHesapListesi();
                        break;
                    case 8:
                        yazdirHesapDurumu();
                        break;
                    case 9:
                        yazdirHesapIslemKayit();
                        break;
                    case 10:
                        cekilis();
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Yanlış Seçim Yaptınız!");
            }
            this.devamIslem();
        }



       
        public void devamIslem()
        {
            Console.WriteLine("\nAna Menüye Dönmek için '*' Çıkış için '#' tuşlayınız:");
            string islem = Console.ReadLine();
            if (islem == "*")
            {
                this.secMenu();
            }
            else
            {
                Console.WriteLine("Bizi Tercih Ettiğiniz İçin Teşekkür Eder, İyi Günler Dileriz! \nYBS Bank");
                Console.ReadLine();
            }
        }



       
        public void yazdirHesapListesi()
        {
            if (listHesap.Count > 0)
            {
                Console.WriteLine("\nHesap Bilgileri");
                Console.WriteLine("**********************************************************");
                foreach (Hesap hesap in listHesap)
                {
                    hesap.getirHesapDurum();
                    Console.WriteLine("**********************************************************");
                }
            }
            else
            {
                Console.WriteLine("Bankamızda Henüz Bir Hesabınız Bulunmamaktadır!");
            }

            this.devamIslem();
        }




        
        public void yatirPara()
        {
            Console.WriteLine("Para Yatırmak İstediğiniz Hesap Numarasını Yazınız: ");
            string hesapNoString = Console.ReadLine();
                int i;
            if(int.TryParse(hesapNoString, out i)) {
                int hesapNo = Convert.ToInt32(hesapNoString);
                Hesap paraYatirilacakHesap = listHesap.Find(obj => obj.hesapNo==hesapNo);

                if(paraYatirilacakHesap != null)
                {
                    string tarihFormat = "dd/MM/yyyy";
                    DateTime dDate;
                    DateTime tarih;
                    Console.WriteLine("Kar hesabı işlem tarihi için Gün/Ay/Yıl formatında tarih bilgisi giriniz:");
                    string girilenTarihString = Console.ReadLine();
                    if (DateTime.TryParse(girilenTarihString, out dDate))
                    {
                        tarih = DateTime.ParseExact(girilenTarihString, tarihFormat, CultureInfo.InvariantCulture);



                        Console.WriteLine("Yatırmak İstediğiniz Para Miktarını (küsüratlı ise virgül kullanarak) Giriniz:");
                        string paraString = Console.ReadLine();
                        float j;
                        if (float.TryParse(paraString, out j))
                        {
                            float oncekiBakiye = paraYatirilacakHesap.bakiye;
                            float para = float.Parse(paraString);
                            paraYatirilacakHesap.islemTarihi = tarih;
                            paraYatirilacakHesap.yatirPara(para);
                            Console.WriteLine("Para Yatırma İşlemi Başarılı!");
                            paraYatirilacakHesap.gosterIslemDekontu("Para Yatirma", oncekiBakiye, paraYatirilacakHesap.bakiye, para);
                        }
                        else
                        {
                            Console.WriteLine("Hatalı Para Miktarı Girdiniz!");
                        }



                    }
                    else
                    {
                        Console.WriteLine("Tarih Bilgisini Hatalı Girdiniz!");
                    }
                }
                else
                {
                    Console.WriteLine("Girdiğiniz Hesap Numarasına Ait Hesap Bulunamadı!");
                }
            }
            else
            {
                Console.WriteLine("Hatalı Hesap Numarası Girdiniz!");
            }
            this.devamIslem();
        }




       
        public void cekPara()
        {
            Console.WriteLine("Para Çekmek İstediğiniz Hesap Numarasını Yazınız: ");
            string hesapNoString = Console.ReadLine();
                int i;
            if(int.TryParse(hesapNoString, out i)) {
                int hesapNo = Convert.ToInt32(hesapNoString);
                Hesap paraCekilecekHesap = listHesap.Find(obj => obj.hesapNo==hesapNo);

                if(paraCekilecekHesap != null)
                {
                    Console.WriteLine("Çekmek İstediğiniz Para Miktarını (küsüratlı ise virgül kullanarak) Giriniz:");
                    string paraString = Console.ReadLine();
                    float j;
                    if(float.TryParse(paraString, out j)) {
                       float para = float.Parse(paraString);
                         if(paraCekilecekHesap.bakiye >= para)
                        {
                            float oncekiBakiye = paraCekilecekHesap.bakiye;
                             paraCekilecekHesap.cekPara(para);
                             paraCekilecekHesap.gosterIslemDekontu("Para Çekme", oncekiBakiye, paraCekilecekHesap.bakiye, para);
                            Console.WriteLine("Para Çekme İşlemi Başarılı!");
                        }
                        else
                        {
                            Console.WriteLine("Çekmek istediğiniz miktar bakiyenizden fazla olamaz.\n İşlem başarısız.");
                        }
                    }
                    else
                    {
                     Console.WriteLine("Hatalı Para Miktarı Girdiniz!");
                    }
                }
                else
                {
                    Console.WriteLine("Girdiğiniz Hesap Numarasına Ait Hesap Bulunamadı!");
                }
            
            }
            else
            {
                Console.WriteLine("Hatalı Hesap Numarası Girdiniz!");
            }

            this.devamIslem();
        }



        
        public void cekilis()
        {
            List<Hesap> filteredList = listHesap.Where(hesap => hesap.yillikKar != 0 && hesap.cekilisHakki > 0).ToList();
            if (filteredList.Count > 0)
            {
                Console.WriteLine("Her 1000 TL için 300 TL kazanma 1 Çekiliş Hakkı!! \nÇekiliş Devam Ediyor...");
                Random rastgele = new Random();
                int kazananHesapIndex = rastgele.Next(0, filteredList.Count);
                Hesap kazananHesap = filteredList[kazananHesapIndex]; 
                float oncekiBakiye = kazananHesap.bakiye;
                kazananHesap.yatirPara(300);
                Console.WriteLine("Tebrikler!..Kazanan Hesap:" + kazananHesap.hesapNo + "\nKalan Çekiliş Hakkı: " + kazananHesap.cekilisHakki);
                kazananHesap.gosterIslemDekontu("Çekiliş", oncekiBakiye, kazananHesap.bakiye, 300);
            }
            else
            {
                Console.WriteLine("Cari hesap ve bakiyesi 1000 TL altında olan hesaplar çekilişe katılamaz.");
            }

            this.devamIslem();
        }


        
        public void yazdirHesapDurumu()
        {
            if (listHesap.Count > 0)
            {
                Console.WriteLine("Durumunu Görmek İstediğiniz Hesap Numarasını Yazınız: ");
                string hesapNoString = Console.ReadLine();
                int i;
                if (int.TryParse(hesapNoString, out i))
                {
                    int hesapNo = Convert.ToInt32(hesapNoString);
                    Hesap hesap = listHesap.Find(obj => obj.hesapNo == hesapNo);

                    if (hesap != null)
                    {
                        Console.WriteLine("\nHesap Bilgileri");
                        Console.WriteLine("**********************************************************");
                        hesap.getirHesapDurum();
                        Console.WriteLine("**********************************************************");
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz Hesap Numarasına Ait Hesap Bulunamadı!");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı Hesap Numarası Girdiniz!");

                }
            }
            else
            {
                Console.WriteLine("Bankamızda Henüz Bir Hesabınız Bulunmamaktadır!");
            }
            
            this.devamIslem();
        }


       
        public void yazdirHesapIslemKayit()
        {
            if (listHesap.Count > 0)
            {
                Console.WriteLine("İşlem Kayıtlarını Görmek İstediğiniz Hesap Numarasını Yazınız: ");
                string hesapNoString = Console.ReadLine();
                int i;
                if (int.TryParse(hesapNoString, out i))
                {
                    int hesapNo = Convert.ToInt32(hesapNoString);
                    Hesap hesap = listHesap.Find(obj => obj.hesapNo == hesapNo);

                    if (hesap != null)
                    {
                        hesap.gosterHesapOzeti();
                    }
                    else
                    {
                        Console.WriteLine("Girdiğiniz Hesap Numarasına Ait Hesap Bulunamadı!");
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı Hesap Numarası Girdiniz!");
                }
            }
            else
            {
                Console.WriteLine("Bankamızda Henüz Bir Hesabınız Bulunmamaktadır!");
            }

            this.devamIslem();
        }


        
        public void olusturHesap(int hesapTuru)
        { 
             Hesap yeniHesap = new Hesap();

             
            if (hesapTuru == 15)
            {
                Console.WriteLine("Kısa Vadeli Hesap Oluşturmak İçin Lütfen 5000 TL ve Üzeri Bakiye Girişi Yapınız:");
                string bakiyeString = Console.ReadLine();
                float i;
                if (float.TryParse(bakiyeString, out i))
                {
                    float bakiye = float.Parse(bakiyeString);

                    if (bakiye >= 5000) { 

                        yeniHesap.bakiye = bakiye;
                        hesapSayisi++;
                        yeniHesap.hesapTuru = "Kısa Vadeli";
                        yeniHesap.olusturHesapNo(hesapSayisi);
                        yeniHesap.yillikKarOrani = hesapTuru;
                        yeniHesap.cekilisHakki = (int)bakiye / 1000;
                        yeniHesap.yillikKar = (bakiye*15)/100;
                        yeniHesap.gunlukKarOrani = yeniHesap.yillikKar/365;

                        listHesap.Add(yeniHesap);

                        Console.WriteLine("\nHesap Bilgileri");
                        Console.WriteLine("**********************************************************");
                        yeniHesap.getirHesapDurum();
                        Console.WriteLine("**********************************************************");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz Bakiye Girdiniz! En az 5000 TL yatırmanız gerekmektedir.");
                    }
                } 
                else
                {
                    Console.WriteLine("Yanlış Seçim Yaptınız!");
                }
            }
      
           
            if (hesapTuru == 17)
            {
                Console.WriteLine("Uzun Vadeli Hesap Oluşturmak İçin Lütfen 10000 TL ve Üzeri Bakiye Girişi Yapınız:");
                string bakiyeString = Console.ReadLine();
                float i;
                if (float.TryParse(bakiyeString, out i))
                {
                    float bakiye = float.Parse(bakiyeString);

                    if (bakiye >= 10000) { 

                        yeniHesap.bakiye = bakiye;
                        hesapSayisi++;
                        yeniHesap.hesapTuru = "Uzun Vadeli";
                        yeniHesap.olusturHesapNo(hesapSayisi);
                        yeniHesap.yillikKarOrani = hesapTuru;
                        yeniHesap.cekilisHakki = (int)bakiye / 1000;
                        yeniHesap.yillikKar = (bakiye*17)/100;
                        yeniHesap.gunlukKarOrani = yeniHesap.yillikKar/365;

                        listHesap.Add(yeniHesap);

                        Console.WriteLine("\nHesap Bilgileri");
                        Console.WriteLine("**********************************************************");
                        yeniHesap.getirHesapDurum();
                        Console.WriteLine("**********************************************************");
                    }
                    else { 
                        Console.WriteLine("Yetersiz Bakiye Girdiniz! En az 10.000 TL yatırmanız gerekmektedir.");
                    }
              
                }
                else
                {
                     Console.WriteLine("Yanlış Seçim Yaptınız!");
                }

            }
 

            
            if (hesapTuru == 0)
            {
                    yeniHesap.bakiye =0;
                    hesapSayisi++;
                    yeniHesap.hesapTuru = "Cari";
                    yeniHesap.olusturHesapNo(hesapSayisi);
                    listHesap.Add(yeniHesap);
                    Console.WriteLine("\nHesap Bilgileri");
                    Console.WriteLine("**********************************************************");
                    yeniHesap.getirHesapDurum();
                    Console.WriteLine("**********************************************************");
            }

            
             if (hesapTuru == 10)
            {
           
                    yeniHesap.bakiye = 0;
                    hesapSayisi++;
                    yeniHesap.hesapTuru = "Özel";
                    yeniHesap.olusturHesapNo(hesapSayisi);
                    yeniHesap.cekilisHakki = 0;
                    yeniHesap.yillikKarOrani = hesapTuru;
                    yeniHesap.yillikKar = 0;
                    yeniHesap.gunlukKarOrani = 0;
                    listHesap.Add(yeniHesap);
                    Console.WriteLine("\nHesap Bilgileri");
                    Console.WriteLine("**********************************************************");
                    yeniHesap.getirHesapDurum();
                    Console.WriteLine("**********************************************************");
               }

             this.devamIslem();
        }
    }


}
