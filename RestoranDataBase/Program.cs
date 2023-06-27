

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RestoranDataBase.MigrationData;
using RestoranDataBase.Modules;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

DBContext db = new DBContext();
DateTime TIME = new DateTime();
List<int> narxlar = new List<int>();


mainPage: Console.Clear();

while (true)
{   
                    Colorful.Console.WriteAscii("  MARKROFT  RESTORANi", Color.FromArgb(20, 100, 200));
    Console.WriteLine("   1 -  ADMINISTRATORs ");
    Console.WriteLine("   2 -  CLIENTs ");
    int answer1 = int.Parse(Console.ReadLine());
    if(answer1 == 1)
    
    {   AdminPage:
        Console.Clear();
        Colorful.Console.WriteAscii("    RESTORAN", Color.FromArgb(20, 100, 200));
        Console.WriteLine("1 - SIGN IN ");
        Console.WriteLine("2 - SIGN UP \n");
        Console.WriteLine("0 - GO BACK");
        int answer2  =  int.Parse(Console.ReadLine());
        if (answer2 == 0) goto mainPage;
        if(answer2 == 1)
        {   retypeLog:
            Console.Write("LOGIN : ");
            string foreignLog = Console.ReadLine();
            Console.WriteLine("Loading...");
            var obj1 = db.Users.FirstOrDefault(p => p.login== foreignLog);
            if(obj1 != null)
            {       RetypePass:
                    Console.Write("Password : ");
                    string foreignPass = Console.ReadLine();
                Console.WriteLine("Loading...");
                var obj2 = db.Users.FirstOrDefault(p => p.password == foreignPass);
                    if (obj2 == null)
                    {
                        Console.WriteLine("ERROR PASSWORD (1 - Retype / 0 - Go Back");
                        int answer5 = int.Parse(Console.ReadLine());
                        if (answer5 == 1) goto RetypePass;
                        if (answer5 == 0) goto AdminPage;
                    } 
                    if(obj2 != null)
                {
                    WellcomeAdmin:
                    Console.Clear();
                    
                    Colorful.Console.WriteAscii("       Welcome", Color.FromArgb(20, 100, 200));
                    Colorful.Console.WriteAscii($" {obj1.UserFirstName}  {obj1.UserLastName }", Color.FromArgb(20, 100, 200));
                    Console.WriteLine("1. MENU ni KO'RISH ");
                    Console.WriteLine("2. TAOM QO'SHISH");
                    Console.WriteLine("3. TAOM O'CHIRISH");
                    Console.WriteLine("4. BUYURTMALARNI BOSHQARISH\n\n");
                    Console.WriteLine("0. PROFILDAN CHIQISH");
                  

                    int answer6 = int.Parse(Console.ReadLine());
                    switch (answer6)
                    {
                        case 1:  ////// MENU ni KO'RISH  ////////
                            {
                                foreach (var t in db.Menu)
                                {
                                    Console.WriteLine($"ID : {t.id}  NOMI : {t.nomi}  NARXI : {t.narxi}");
                                }

                                Console.WriteLine();
                                Console.WriteLine("0 - GO Back");
                                int answer9 = int.Parse(Console.ReadLine());
                                if (answer9 == 0) goto WellcomeAdmin;
                                break;
                            }
                                       
                        case 2:  ////// TAOM QO'SHISH  ////////
                            {
                                Menu taom = new Menu();
                                Console.WriteLine("Taom nomi : ");
                                taom.nomi = Console.ReadLine();
                                Console.WriteLine("Taom narxi : ");
                                taom.narxi = int.Parse(Console.ReadLine());
                                db.Menu.Add(taom);
                                db.SaveChanges();
                                Console.WriteLine("Taom muvafaqqiyatli qo'shildi. ");
                                Console.WriteLine("Type 0 to Go Back");
                                int answer10 = int.Parse(Console.ReadLine());
                                if (answer10 == 0) goto WellcomeAdmin;
                                break;
                            }
                         case 3: /////// TAOM O'CHIRISH ////////
                            {
                                foreach(var t in db.Menu)
                                {
                                    Console.WriteLine($"ID : {t.id}  NOMI : {t.nomi}  NARXI : {t.narxi}");
                                }
                                Console.WriteLine("Ochirish uchun taom ID sini tanlang");
                                int answer8 = int.Parse(Console.ReadLine());
                                var item1 = db.Menu.FirstOrDefault(p => p.id==answer8);
                                db.Menu.Remove(item1);
                                db.SaveChanges();

                                Console.WriteLine("Taom muvafaqqiyatli o'chirildi. ");
                                Console.WriteLine("Type 0 to Go Back");
                                int answer11 = int.Parse(Console.ReadLine());
                                if (answer11 == 0) goto WellcomeAdmin;


                                break;
                            }
                        
                        case 4:
                            {
                                var Blist = db.Buyurtmalar.Include(p => p.Btaomlar);
                                foreach (var b in Blist)
                                {
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                    Console.WriteLine($"Buyurtma ID si - {b.id} || Buyurtma vaqti - {b.vaqti} || Byurtma summasi {b.usum}");
                                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                    foreach (var w in b.Btaomlar)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine($"Taom ID si - {w.id} || Taom nomi - {w.nomi} || Taom Narxi - {w.narxi}");
                                    }
                                }
                                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                                Console.WriteLine("1 - BUYURTMALARDAN BIRINI O'CHIRISH ");
                                Console.WriteLine("0 - GO BACK");
                                int answer13 = int.Parse(Console.ReadLine());
                                if (answer13 == 1) goto deletePage;
                                if (answer13 == 0) goto WellcomeAdmin;
                               deletePage: Console.Write("\n\n BUYURTMANI O'CHIRISH UCHUN ID RAQAMINI KIRITING : ");
                                int BID = int.Parse(Console.ReadLine());
                                var deleteb = db.Buyurtmalar.FirstOrDefault(p=>p.id==BID);
                                db.Buyurtmalar.Remove(deleteb);
                                db.SaveChanges();
                                Console.WriteLine("ORDER SUCCESSFULLY DELETED");
                                Console.WriteLine("0 - GO BACK");
                                int answer12 = int.Parse(Console.ReadLine());
                                if (answer12 == 0) goto WellcomeAdmin;
                                break;

                            }
                        case 0:  /////// PROFILDAN CHIQISH ////////
                            {
                                goto AdminPage;
                            }
                    }


                }


            }
            if (obj1 == null)
            {
                Console.WriteLine("There is no user like this\n Insert 5 to retype");
                int answer4 = int.Parse(Console.ReadLine());
                if (answer4 == 5) goto retypeLog;
                

            }
        }
        if(answer2 == 2)
        {
            Users user = new Users();
            Console.WriteLine("User First Name :");
            user.UserFirstName = Console.ReadLine();
            Console.WriteLine("User Last Name :");
            user.UserLastName = Console.ReadLine();
            Console.WriteLine("User Login ( Must Be Unique )");
                 Console.WriteLine("Type : ");
            user.login = Console.ReadLine();
            Console.WriteLine("User Password : ");
            user.password = Console.ReadLine();
            user.RegistrationTime = DateTime.Now.ToString();
            db.Users.Add(user); db.SaveChanges();
            Console.WriteLine("Admin User Successfully registered");
            Console.WriteLine("Type  0  to back " );
            int answer7 = int.Parse(Console.ReadLine());
            if (answer7 == 0) goto AdminPage;
        }
    }
    if(answer1== 2)
    {
        clientPage:
        Console.Clear();
        Colorful.Console.WriteAscii("  MARKROFT  RESTORANi", Color.FromArgb(20, 100, 200));

        Console.WriteLine("1. TAOM TANLASH");
        Console.WriteLine("2. BUYURTMANI KO'RISH");
        Console.WriteLine("0. GO to WELCOME PAGE");
      


        int a = int.Parse(Console.ReadLine());
        switch (a)
        {
           
            case 1:////// TAOM BUYURTMA QILISH ////////     
                {
                    Buyurtmalar buyurtma = new Buyurtmalar();
                    qaytabuyurish:
                    Console.Clear();
                    Colorful.Console.WriteAscii("  MARKROFT  RESTORANi", Color.FromArgb(20, 100, 200));
                    Console.WriteLine("\n\nLOADING........\n");

                    Console.WriteLine($"Taom ID si  |       Taom nomi        |    Taom narxi     |");
                    Console.WriteLine("______________________________________________________________________");
                    foreach (var n in db.Menu)
                    {
                        Console.WriteLine($"     {n.id}                {n.nomi}              {n.narxi}      \n");
                        Console.WriteLine("______________________________________________________________________");
                    }
                    Console.WriteLine("______________________________________________________________________");
                    Console.WriteLine("ID bo'yicha tanlang : ");
                    int b = int.Parse(Console.ReadLine());
                    var TanlanganTaom = db.Menu.FirstOrDefault(p => p.id == b);
                    Taomlar taom = new Taomlar()
                    {
                        nomi = TanlanganTaom.nomi,
                        narxi = TanlanganTaom.narxi
                    };
                    buyurtma.Btaomlar.Add(taom);
                    narxlar.Add(TanlanganTaom.narxi);
                    Console.WriteLine($" Siz {TanlanganTaom.nomi} ni tanlandingiz. ");
                    Console.WriteLine($"Yana nimadir tanlaysizmi ? (1-Ha / 2-Yo'q");
                    int d = int.Parse(Console.ReadLine());

                    if (d == 1) goto qaytabuyurish;
                    if (d == 2)
                    {
                        buyurtma.vaqti = DateTime.Now.ToString();
                        buyurtma.usum = narxlar.Sum();
                        narxlar.Clear();
                    }

                    db.Buyurtmalar.Add(buyurtma);
                    db.SaveChanges();
                    Console.Clear();
                    Colorful.Console.WriteAscii("  MARKROFT  RESTORANi", Color.FromArgb(20, 100, 200));
                    Console.WriteLine("XURMATLI MIJOZ SIZNING BUYURTMANGIZ MUVAFFAQIYATLI RO'YXATGA OLINDI");
                    Console.WriteLine($"Sizning buyurtmangiz raqami - {buyurtma.id}\n");
                    Console.WriteLine("0 -GO BACK");
                    int answer15 =  int.Parse(Console.ReadLine()) ;
                    if (answer15 == 0) goto clientPage;
                    break;
                }
            case 2://////// BUYURTMALARNI KO'RIH //////////
                {
                    Console.Clear();
                    Colorful.Console.WriteAscii("  MARKROFT  RESTORANi", Color.FromArgb(20, 100, 200));

                    Console.Write("BUYURTMA ID sini KIRITNG : ");
                    int answer16 = int.Parse(Console.ReadLine()) ;
                    Console.WriteLine("\n LOADING....");
                    var Blist = db.Buyurtmalar.Include(e => e.Btaomlar).FirstOrDefault(b => b.id == answer16);

                        Console.WriteLine("__________________________________________________________________________________________________\n");
                        Console.WriteLine($"Buyurtma ID si - {Blist.id} || Buyurtma vaqti - {Blist.vaqti} || Byurtma summasi {Blist.usum}");
                        Console.WriteLine("__________________________________________________________________________________________________");
                        foreach (var w in Blist.Btaomlar)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Taom ID si - {w.id} || Taom nomi - {w.nomi} || Taom Narxi - {w.narxi}");
                        Console.WriteLine("__________________________________________________________________________________________________");
                        
                        }
                    Console.WriteLine("\n 0 - GO BACK ");
                    int answer17 = int.Parse(Console.ReadLine());
                    if (answer17 == 0) goto clientPage;


                    break;

                }
            case 0:
                {
                    goto mainPage; break;
                }
        }




    }

}