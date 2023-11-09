using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//*Câu 1: Nhập danh sách học viên. Thông tin phải nhập gồm: mã học viên, họ và tên, điểm(nhập nhiều) và email. 
//Câu 2: Xuất danh sách học viên. Thông tin xuất gồm: họ và tên, điểm, email và học lực.
//Câu 3: Tìm kiếm học viên theo khoảng điểm trung bình nhập từ bàn phím. 
//Câu 4: Tìm kiếm học viên theo học lực nhập từ bàn phím 
//Câu 5: Tìm học viên theo mã số và cập nhật thông tin học viên. 
//Câu 6: Sắp xếp học viên theo điểm 
//Câu 7: Xuất 5 học viên có điểm cao nhất 
//Câu 8: Tính điểm trung bình của lớp 
//Câu 9: Xuất danh sách học viên có điểm trên điểm trung bình của lớp 
//Câu 10: Tổng hợp số học viên theo học lực
namespace Assignment_1
{
    internal class Program
    {
        List<HocVien> listHv;
        const int MaxAVR = 5;
        public Program()
        {

            listHv = new List<HocVien>();

        }
        static void Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                Console.WriteLine("===========MENU==========");
                Console.WriteLine("1.Nhap danh sach hoc vien");
                Console.WriteLine("2.Xuat danh sach hoc vien, hoc luc");
                Console.WriteLine("3.Tim kiem theo khoang diem trung binh");
                Console.WriteLine("4.Tim kiem theo hoc luc");
                Console.WriteLine("5.Tim kiem theo ma so va cap nhat");
                Console.WriteLine("6.Sap xep theo diem");
                Console.WriteLine("7.Xuat 5 hoc vien thap diem nhat");
                Console.WriteLine("8.Xuat 5 hoc vien cao diem nhat");
                Console.WriteLine("9.Tinh diem trung binh cua lop");
                Console.WriteLine("10.Xuat danh sach hoc sinh co diem tren trung binh");
                Console.WriteLine("11.Tong hop so hoc vien theo hoc luc");
                Console.WriteLine("---------------------------");
                int n;
                Console.WriteLine("Nhap lua chon cua ban");
                n = Convert.ToInt32(Console.ReadLine());
                // bien input so sanh voi N xem co dung yeu cau khong?

                Console.Clear();
                switch (n)
                {
                    case 1:

                        program.InputHocVien();

                        break;
                    case 2:
                        Console.WriteLine("================");
                        Console.WriteLine("*****************************Danh sach hoc vien*********************");
                        program.DisplayAll();
                        break;
                    case 3:
                        double From, To;
                        Console.WriteLine("Nhap khoang diem: ");
                        Console.Write("Nhap diem bat dau:");
                        From = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Nhap diem ket thuc: ");
                        To = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("================");
                        Console.WriteLine("Danh sach hoc vien co trong khoang" + From + ", " + To);
                        program.DisplayDuartionAVR(From, To);
                        break;
                    case 4:
                        string str;
                        Console.Write("Nhap hoc luc:");
                        str = Console.ReadLine();
                        Console.WriteLine("****************************Hoc luc cua hoc vien************************** ");
                        program.DisplayGPA(str);
                        break;
                    case 5:
                        int id;
                        Console.WriteLine("****************************Hoc Vien update************************* ");
                        Console.Write("Nhap id can tim kiem: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        program.UpdateHV(id);
                        Console.WriteLine("Hoc vien sau khi update:");
                        program.DisplayAll();
                        break;
                    case 6:
                        program.SortbyARV();
                        Console.WriteLine("**************************Sap xep theo thu tu tang dan diem so**********************");
                        program.DisplayAll();
                        break;
                    case 7:
                        Console.WriteLine("******************Danh sach 5 hoc vien co diem thap nhat******************");
                        program.DisplayBad5();
                        break;
                    case 8:
                        Console.WriteLine("******************Danh sach 5 hoc vien co diem cao nhat******************");
                        program.DisplayBest5();
                        break;
                    case 9:
                        Console.WriteLine("******************Diem trung binh cua ca lop******************");
                        Console.Write("Diem trung binh cua ca lop la: ");
                        Console.WriteLine(program.SumAVR());
                        break;
                    case 10:
                        Console.WriteLine("******************Danh sach Hoc vien co diem tren trung binh******************");
                        program.DisplayMaxAVR();
                        break;
                    case 11:
                        Console.WriteLine("********************Tong hop hoc vien theo hoc luc*************************");
                        program.DisplayCLass();
                        break;
                    default:
                        throw new Exception("Chon sai. Vui long chon lai!!!");

                        //    }
                        //}
                        //catch (ArgumentException e)
                        //{ // xu ly khi nguoi dung nhap vao la nhung so ngoai 1-10
                        //    Console.WriteLine(e.Message);
                        //}
                        //catch (FormatException)
                        //{// xu ly khi nhap vao ko phai la 1 so nguyen
                        //    Console.WriteLine("Error: Please your choice");
                        //}
                        //catch (Exception e)
                        //{ // xu ly bat ki ngoai le nao khong xac dinh cu the
                        //    Console.WriteLine("Error:" + e.Message);
                }
            }
        }
        // tong hop hoc vien theo hoc luc
        List<string> list_hocLuc= new List<string> { "Excellent","Very Good","Good","Average","Poor","Fail" };
        void DisplayCLass()
        {
            foreach(var i in list_hocLuc)
            {
                Console.WriteLine($"Hoc luc: " +i);
                foreach(var j in listHv)
                {
                    // duyet danh sach so sanh list_hv co bagn list string hoc luc khong
                    if(j.GPA.ToLower() == i.ToLower())
                    {
                        Console.WriteLine($"{j.ID,5} {j.Name,15} {j.AVR,5}");
                    }
       
                }
                Console.WriteLine("/--------/");
            }
        }

        void DisplayMaxAVR()
        {
            foreach(var i in listHv)
            {
                if(i.AVR >= MaxAVR)
                {
                    Console.WriteLine($"{i.ID,5} {i.Name,15} {i.AVR,5}");
                }
            }
        }
        double SumAVR()
        {
            double sum = 0, count = 0;
            foreach(var i in listHv)
            {
                sum += i.AVR;
                count++;
            }
            return sum / count;
        }
        void DisplayBest5()
        {
            SortByARV_Low();
            int count = 0;
            foreach(var i in listHv)
            {
                if(count < 5)
                {
                    Console.WriteLine($"{"Id: " + i.ID,5}" + "\n" +
                       $"{"Ten:" + i.Name,5}" + "\n" +
                       $"{"Diem mon Toan:" + i.Score1,3}" + "\n" +
                       $"{"Diem mon Ly:" + i.Score2,3}" + "\n" +
                       $"{"Diem mon Hoa:" + i.Score3,3}" + "\n" +
                       $"{"Diem trung binh 3 mon: " + i.AVR}" + "\n" +
                       $"{"Hoc luc: " + i.GPA,8}");
                    count++;
                }
            }
        }
        void DisplayBad5()
        {
            SortbyARV();
            int count = 0;
            foreach(var i in listHv)
            {
                
               if(count < 5)
                { 
                    Console.WriteLine($"{"Id: " + i.ID,5}" + "\n" +
                        $"{"Ten:" + i.Name,5}" + "\n" +
                        $"{"Diem mon Toan:" + i.Score1,3}" + "\n" +
                        $"{"Diem mon Ly:" + i.Score2,3}" + "\n" +
                        $"{"Diem mon Hoa:" + i.Score3,3}" + "\n" +
                        $"{"Diem trung binh 3 mon: " + i.AVR}" + "\n" +
                        $"{"Hoc luc: " + i.GPA,8}");
                    count++;
                }
            }
        }
        // sap xep tang dan
        void SortbyARV()
        {
            listHv.Sort(delegate (HocVien hv1, HocVien hv2)
            {
                return hv1.AVR.CompareTo(hv2.AVR);
            });
        }
        // sap xep giam dan

        void SortByARV_Low()
        {
            listHv.Sort(delegate (HocVien hv1, HocVien hv2)
            {
               return hv2.AVR.CompareTo(hv1.AVR);
            });
        }
        void UpdateHV(int id)
        {
            // tim kiem hoc vien
            HocVien hv = FindId(id);
            if (hv != null)
            {
                Console.Write("Nhap ho ten:");
                string Name = Console.ReadLine();
                if (Name != null && Name.Length > 0)
                    hv.Name = Name;
                Console.Write("Nhap diem Toan: ");
                string a, b, c;
                a = Console.ReadLine();
                if (a != null && a.Length > 0)
                    hv.Score1 = double.Parse(a);
                Console.Write("Nhap diem Ly: ");
                b = Console.ReadLine();
                if (b != null && b.Length > 0)
                    hv.Score2 = double.Parse(b);
                Console.Write("Nhap diem Hoa: ");
                b = c = Console.ReadLine();
                if (c != null && c.Length > 0)
                    hv.Score3 = double.Parse(c);
                Average(hv);
                HocLuc(hv);
            }
            else
            {
                Console.WriteLine("Khong co hoc vien nao!");
            }
        }
        HocVien FindId(int id)
        {
            HocVien search = null;
            if (listHv != null && listHv.Count > 0) //  neu nhu danh sach hoc vien khac rong va co hon 0 hv
            {
                // duyet danh sach va tim
                foreach (var i in listHv)
                {
                    if (id == i.ID)
                    {
                        search = i;

                    }
                }
            }
            return search;
        }
        void DisplayGPA(string str)
        {
            int count = 0;
            foreach (var i in listHv)
            {
                if (str.ToLower() == i.GPA.ToLower())  /// nhap chu thuong
                {
                    Console.WriteLine($"{"ID: " + i.ID} " +
                                      $"{"Ten: " + i.Name}");
                    count++;
                }
            }
            if (count > 0)
            {
                Console.Write($"Co {count} hoc vien: " + count);
            }
            else
            {
                Console.WriteLine("Khong co hoc vien nao co hoc luc tuong ung");
            }
        }
        void DisplayDuartionAVR(double From, double To)
        {
            int count = 0;

            foreach (var i in listHv)
            {
                double AVR = i.AVR;
                if (AVR >= From && AVR <= To)
                {
                    Console.WriteLine($"{"ID: " + i.ID} " +
                        $"{"Ten: " + i.Name}");
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine($"Co {count} hoc vien: " + count);
            }

        }
        void DisplayAll()
        {
            foreach (var i in listHv)
            {

                Console.WriteLine($"{"Id: " + i.ID,5}" + "\n" +
                    $"{"Ten:" + i.Name,5}" + "\n" +
                    $"{"Diem mon Toan:" + i.Score1,3}" + "\n" +
                    $"{"Diem mon Ly:" + i.Score2,3}" + "\n" +
                    $"{"Diem mon Hoa:" + i.Score3,3}" + "\n" +
                    $"{"Diem trung binh 3 mon: " + i.AVR}" + "\n" +
                    $"{"Hoc luc: " + i.GPA,8}");
            }
        }
        void Average(HocVien hv)
        {
            double AVR = (hv.Score1 + hv.Score2 + hv.Score3) / 3;
            hv.AVR = AVR;
        }
        void HocLuc(HocVien hv)
        {

            double AVR = hv.AVR;
            if (AVR >= 9)
            {
                hv.GPA = "Excellent";
            }
            else if (AVR >= 7.5)
            {
                hv.GPA = "Very Good";
            }
            else if (AVR > 6.5)
            {
                hv.GPA = "Good";
            }
            else if (AVR >= 5)
            {
                hv.GPA = "Average";
            }
            else if (AVR <= 3)
            {
                hv.GPA = "Poor";
            }
            else hv.GPA = "Fail";
        }
     void InputHocVien()
        {
            while (true)
            {
                int Id = 0;
                string Name;
                double a, b, c;
                HocVien hv = new HocVien();
                Console.WriteLine("**********************Nhap danh sach Hoc Vien***************************");
                hv.ID = GenerateID();
                Console.Write("Nhap ho va ten: ");
                hv.Name = Console.ReadLine();
                Console.Write("Diem 1: ");
                hv.Score1 = double.Parse(Console.ReadLine());
                Console.Write("Diem 2: ");
                hv.Score2 = double.Parse(Console.ReadLine());
                Console.Write("Diem 3: ");
                hv.Score3 = double.Parse(Console.ReadLine());
                // cap nhat lai diem trung binh
                Average(hv);
                // cap nhat hoc luc,
                HocLuc(hv);
                listHv.Add(hv);
                Console.WriteLine("Ban co muon them hv tiep khong? [y/n]");           
                char val;
                val = Convert.ToChar(Console.ReadLine());
                if (val == 'y')
                {
                    continue;
                }
                else break;

            }
        }
        int GenerateID()
        {
            int max = 1;
            if (listHv != null & listHv.Count > 0)
            {
                max = listHv[0].ID;
                foreach (var i in listHv)
                {
                    if (max < i.ID) max = i.ID;
                }
                max++;
            }
            return max;
        }
    }
}
