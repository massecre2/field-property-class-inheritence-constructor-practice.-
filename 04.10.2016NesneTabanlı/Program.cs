using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; 

namespace _04._10._2016NesneTabanlı
{
    //alanlar field , özellikler property ve methotlardan bahsettik . 
    //bölüm ve fakülte arasında ki ilişkiyi sen yap 

    class Ilce
    {
        public string _adi;
        public int _nufusu;
        public void yaz_dir()
        {
            if(_nufusu > 0 )
                Console.WriteLine("Ilce adı : {0}, Nüfusu : {1}" , _adi , _nufusu);
            else
                Console.WriteLine("Ilce adı : {0}",_adi);
        }

        public Ilce(string ilceAdi)
        {
            _adi = ilceAdi; 
        }

        public Ilce(string ilceAdi, int ilceNufusu)
        {
            _adi = ilceAdi;
            _nufusu = ilceNufusu;
        }
    }
    class Sehir
    {
        public string _adi;
        public ArrayList ilceler;
  
        public void ilceEkle(Ilce X){
            ilceler.Add(X); 
        }

        public void yazdir()
        {
            Console.WriteLine("Sehir adi {0}" , _adi);
            Console.WriteLine("Nüfusu {0} " , _nufusu);

            foreach (Ilce eleman in ilceler)
            {
                eleman.yaz_dir();
            }
            
        }

        public Sehir(string sehirAdi)
        {
            _adi = sehirAdi; 
            ilceler = new ArrayList();
        }

        private int _nufusu;
        public int nufusu //<-- bu bir property ve sadece get set içindir 
        {
            get
            {
                _nufusu = 0;
                foreach (Ilce eleman in ilceler)
                {
                    _nufusu += eleman._nufusu;
                }
                return _nufusu;
            }
        }
    
    }
    class Bolum
    {
        public string _adi;
        public int _ogrenci_sayisi;
        public string _bolum_baskani;

        public void yazdir()
        {
            Console.WriteLine("Bölüm bilgileri ");
            Console.WriteLine("Bölüm adı " + _adi);
            Console.WriteLine("Bölüm başkanı : " + _bolum_baskani);
            Console.WriteLine("Öğrenci sayısı : " + _ogrenci_sayisi);
            Console.WriteLine("######################");
        }

        public Bolum(string bolumAdi)
        {
            _adi = bolumAdi; 
        }

        public Bolum(string bolumAdi, int ogrSayisi)
        {
            _adi = bolumAdi;
            _ogrenci_sayisi = ogrSayisi;
        }
    }
    class Fakulte
    {
        public string _adi;
        private ArrayList bolumler;

        public void bolumEkle(Bolum bolum_)
        {
            bolumler.Add(bolum_);
        }


        public Fakulte(string fakulteAdi)
        {
            _adi = fakulteAdi;
            bolumler = new ArrayList();
        }

        public void yazdir()
        {
            Console.WriteLine("Fakülte bilgileri ");
            Console.WriteLine("Fakülte adı: " + _adi);
            foreach (Bolum eleman in bolumler)
            {
                eleman.yazdir();
            }
            Console.WriteLine("####################");
        }

        public void ozet_yazdir()
        {
            Console.WriteLine("Fakülte bilgileri ");
            Console.WriteLine("Fakülte adı: " + _adi);
        }

    }

    class Ders
    {
        public string _adi;
        public string _kodu;
        public int _kredisi;

        public Ders(string Adi, string Kodu, int Kredisi)
        {
            _adi = Adi;
            _kodu = Kodu;
            _kredisi = Kredisi; 

        }

        public void yazdir()
        {
            Console.WriteLine("Dersin adı : {0} , Kodu : {1} , Kredisi {2}" , _adi , _kodu , _kredisi);
        }
    }

    class Ogrenci
    {
        public string _adi;
        public int _numarasi;
        public Sehir _memleketi;
        public Ilce _ilcesi;
        public Fakulte _fakultesi;
        public Bolum _bolumu;
        public ArrayList _alinandersler; 

        //yapıcı method içerisin de hemen yer ayırt ettireyim
        public Ogrenci(string adi_ , int no_ , Bolum bolum_ , Fakulte fakulte_ )
        {
            _adi = adi_;
            _numarasi = no_;

            _bolumu = bolum_;
            _fakultesi = fakulte_; 

            _memleketi = new Sehir("Gümüşhane"); 
            _ilcesi = new Ilce("Torul") ;
            _alinandersler = new ArrayList();

        }

        public void dersEkle(Ders ders_, float gNotu_)
        {
            OgrenciDers derssss = new OgrenciDers(this, ders_, gNotu_);
            _alinandersler.Add(derssss);
        }

        public void yazdir()
        {
            Console.WriteLine("Öğrenci Bilgileri : ");
            Console.WriteLine("Adı {0} , Numarası {1}  " ,_adi , _numarasi);
            _fakultesi.ozet_yazdir();
            _bolumu.yazdir();

            foreach (OgrenciDers eleman in _alinandersler)
            {
                eleman.yazdir();
            }
        }
    }

    class OgrenciDers
    {
        public Ogrenci _ogrenci;
        public Ders _ders;
        public float _gecmenotu;

        public OgrenciDers(Ogrenci ogrenci_ , Ders ders_ , float gecmeNotu_)
        {
            _ogrenci = ogrenci_;
            _ders = ders_;
            _gecmenotu = gecmeNotu_; 
        }

        public void yazdir()
        {
            Console.WriteLine("Ders {0} , Geçme notu {1}" , _ders._adi , _gecmenotu);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Ilce torul = new Ilce("torul", 3120);
            Ilce kelkit = new Ilce("kelkit", 5320);
            Ilce kose = new Ilce("kose"); 
            

            Sehir gumushane = new Sehir("Gumushane");
            gumushane.ilceEkle(torul);
            gumushane.ilceEkle(kelkit);
            gumushane.ilceEkle(kose);
            gumushane.yazdir();

            Console.WriteLine("Nufus = " + gumushane.nufusu);
            */

            
            Bolum matematik_muh = new Bolum("Matematik Mühendisliği");
            Bolum makina_muh = new Bolum("Makina Mühendisliği",790);

            Fakulte müh_fak = new Fakulte("Mühendislik ve doğa bilimleri fakültesi");
            müh_fak.bolumEkle(matematik_muh);
            müh_fak.bolumEkle(makina_muh);
            //müh_fak.yazdir();

            Ders nyp = new Ders("Nesne tabanlı programlama", "Mat305", 3);
            Ders ym = new Ders("Yazılım mühendisliği ", "MAT307", 3);
            Ders kd = new Ders("Kısmi diferansiyel denklemler", "MAT302", 5);
            //nyp.yazdir();

            Ogrenci oguzhan = new Ogrenci("Oğuzhan oyan", 1401171047, matematik_muh, müh_fak);

            oguzhan.dersEkle(nyp, 2.5f);
            oguzhan.dersEkle(ym, 3.0f);
            oguzhan.dersEkle(kd, 4.0f);
            oguzhan.yazdir();


        }
    }
}
