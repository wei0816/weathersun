using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity.Validation;

namespace Weathersun8889.Controllers
{
    public class HomeController : Controller
    {
        WeathersunEntities1 db = new WeathersunEntities1();

        public ActionResult AdminLogin()  //管理員登入
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string loginName, string loginPwd)    
        {
            var man = db.Admin
                .Where(m => m.Aaccount == loginName && m.Apassword == loginPwd)
                .FirstOrDefault();
            if (man == null)
            { 
                ViewBag.Message = "帳號、密碼錯誤，登入失敗!";
                return View("AdminLogin");
            }

            Session["WelCome"] = man.Aaccount + "歡迎光臨";
            Session["Member"] = man;
            return RedirectToAction("Member");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("AdminLogin");
        }
        public ActionResult MemberLogin()  //會員登入
        {
            return View();
        }
        [HttpPost]
        public ActionResult MemberLogin(string loginName, string loginPwd)    //會員登入
        {
            var mem = db.Member
                .Where(m => m.Account == loginName && m.Password == loginPwd)
                .FirstOrDefault();
            if (mem == null)
            {
                ViewBag.Message = "帳號、密碼錯誤，登入失敗!";
                return View("MemberLogin");
            }

            Session["WelCome"] = mem.Name + "歡迎光臨";
            Session["Member"] = mem;
            return RedirectToAction("Welcome");
        }
        public ActionResult Logout1()
        {
            Session.Abandon();
            return RedirectToAction("MemberLogin");
        }
        public ActionResult Member()  //會員管理平台
        {
            var members = db.Member.ToList();
            return View(members);
        }
        public ActionResult Announcement()  //公告事項
        {
            var items = db.Announcement.ToList();
            return View(items);
        }
        public ActionResult MemberFeedback()  //系統回報資料
        {
            var checks = db.MemberFeedback.ToList();
            return View(checks);
        }
        public ActionResult Product()  //商品
        {
            var goods = db.Product.ToList();
            return View(goods);
        }
        public ActionResult Admin()  //管理員
        {
            var man = db.Admin.ToList();
            return View(man);
        }
        public ActionResult Homepage()  //首頁
        {
            return View();
        }
        public ActionResult Welcome()  //會員登入之後的畫面
        {
            return View();
        }
        public ActionResult Calendar()  //日曆
        {
            string Account = "";
            if (Session["Member"] != null)
                Account = ((Member)Session["Member"]).Account;
            else
            {
                Account = "尚未登入";
            }
            var calList = db.Calendar.Where(m => m.Account == Account).ToList();
            string str = "";
            for (int i = 0; i < calList.Count; i++)
            {
                var cal = calList[i];
                string temp = string.Format("title:'{0}',start:'{1}-{2}-{3}'",
                    cal.WearNote, cal.Cdate.Year, cal.Cdate.Month.ToString("00"), cal.Cdate.Day.ToString("00"));
                if (i < calList.Count - 1)
                    str += "{" + temp + "},";
                else
                    str += "{" + temp + "}";
            }
            //str = string.Format("title:'{0}',start:'{1}'", "Long Event", "2021-09-10");
            str = "events: [" + str + "]";
            ViewBag.calList = str;
            return View();
        }
        public ActionResult DeleteEvent( string Title) //刪除紀錄
        {
            var wear = db.Calendar
               .Where(m => m.WearNote == Title).FirstOrDefault();
            db.Calendar.Remove(wear);
            db.SaveChanges();
            return View();
        }
        public string SaveEvent(string sday, string smonth, string syear, string eday, string emonth, string eyear, string Title)
        {
            string account = "";
            if (Session["Member"] != null)
                account = ((Member)Session["Member"]).Account;
            else
                account = "尚未登入";
            string str = string.Format("儲存成功!\n標題{6}",
                syear, smonth, sday, eyear, emonth, eday, Title, account);
            Calendar todo = new Calendar();
            todo.Account = account;
            todo.WearNote = Title;
            todo.Cdate = DateTime.Parse(syear + "/" + smonth + "/" + sday);
            db.Calendar.Add(todo);
            db.SaveChanges();
            return str;
        }
        public ActionResult Weather()  //天氣
        {
            return View();
        }
        public ActionResult Shop()  //商城
        {
            return View();
        }
        public ActionResult Shop_Top_All()  //商城_上衣_All
        {
            return View();
        }
        public ActionResult Shop_Top_Shirt()  //商城_上衣_短袖
        {
            return View();
        }
        public ActionResult Shop_Top_LongShirt()  //商城_上衣_長袖
        {
            return View();
        }
        public ActionResult Shop_Bottom_Pants()  //商城_下身_短褲
        {
            return View();
        }
        public ActionResult Shop_Bottom_LongPants()  //商城_下身_長褲
        {
            return View();
        }
        public ActionResult Shop_Bottom_Dress()  //商城_下身_洋裝
        {
            return View();
        }
        public ActionResult Shop_Bottom_Skirts()  //商城_下身_裙子
        {
            return View();
        }
        public ActionResult WebpageFeedback()  //網頁意見回饋資料表
        {
            var adv = db.WebpageFeedback.ToList();
            return View(adv);
        }
        public ActionResult WebHomepage()  //歡迎來到晴穿搭
        {
            return View();
        }
        [HttpPost]
        public ActionResult WebHomepage(WebpageFeedback advise)
        {
            if (ModelState.IsValid)
            {
                db.WebpageFeedback.Add(advise);
                db.SaveChanges();
                ViewBag.Msg = "您的意見回饋已寄出!🚀";
            }
            return View("WebHomepage");
        }
 
      
        public ActionResult Announcementcreate()  //公告新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult Announcementcreate(Announcement announce)
        {
            if (ModelState.IsValid)
            {
                db.Announcement.Add(announce);
                db.SaveChanges();
                ViewBag.Msg = "新增成功!";
                return View();
            }

            return View(announce);
        }
        public ActionResult AdminCreate()  //管理員新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCreate(Admin manager)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var man = db.Admin
                 .Where(m => m.Aaccount == manager.Aaccount)
                 .FirstOrDefault();
            if (man == null)
            {
                db.Admin.Add(manager);
                db.SaveChanges();
                ViewBag.Msg = "新增成功!";
                return View();
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗!";

            return View();
        }

        public ActionResult AdminDelete(string aaccount)  //管理員刪除
        {
            var adm = db.Admin
                .Where(m => m.Aaccount == aaccount).FirstOrDefault();
            db.Admin.Remove(adm);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        public ActionResult AdminEdit(string aaccount)  //管理員編輯
        {
            var adm = db.Admin
                .Where(m => m.Aaccount == aaccount).FirstOrDefault();
            return View(adm);
        }
        [HttpPost]
        public ActionResult AdminEdit
                (string Aaccount, string Apassword, string Aemail)
        {
            var adm = db.Admin
                 .Where(m => m.Aaccount == Aaccount).FirstOrDefault();
            adm.Aaccount = Aaccount;
            adm.Apassword = Apassword;
            db.SaveChanges();
            ViewBag.Msg = "修改成功!";
            return View();
        }

        public ActionResult MemberFeedbackDelete(string account)  //意見回饋刪除
        {
            var mem = db.MemberFeedback
                .Where(m => m.Account == account).FirstOrDefault();
            db.MemberFeedback.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("MemberFeedback");
        }

        public ActionResult WebpageFeedbackDelete(string email)  //網頁意見回饋刪除
        {
            var mem = db.WebpageFeedback
                .Where(m => m.Email == email).FirstOrDefault();
            db.WebpageFeedback.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("WebpageFeedback");
        }

        public ActionResult ProductsCreate()   //商品新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductsCreate(Product pro)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Product");
            }
            return View(pro);
        }
        public ActionResult Productpics()  //商品圖片
        {
            return View();
        }
        [HttpPost]
        public ActionResult Productpics(HttpPostedFileBase productpics)
        {
            string fileName = "";

            if (productpics != null)
            {
                if (productpics.ContentLength > 0)
                {

                    fileName = Path.GetFileName(productpics.FileName);
                    var path = Path.Combine(Server.MapPath("~/productpics"), fileName);
                    productpics.SaveAs(path);
                }
            }
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/productpics"));
            FileInfo[] fInfo = dir.GetFiles();
            int n = 0;
            foreach (FileInfo result in fInfo)
            {
                n++;
                show += "<a href='../productpics/" + result.Name + "'target='_blank'><img src='../productpics/" + result.Name
                    + "'width='90' height='60' border='0'></a> ";
            }
            return RedirectToAction("Product");
        }

        public ActionResult MemberSignup()  //會員註冊
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberSignup(string Account,string Gender,string Name,string Password,DateTime Birdate,string Location) 
        //會員產品物件屬性會對應至表單同名欄位，account這個參數的產品物件屬性可接收表單欄位的資料
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var sign = db.Member
                 .Where(m => m.Account == Account)   //m是會員帳號的參數，m的會員帳號值等於account的會員帳號值一樣的話，會拒絕存取
                 .FirstOrDefault();
            if (sign == null)
            {
                Member mem = new Member();
                mem.Account = Account;
                mem.Gender = Gender;
                mem.Name = Name;
                mem.Password = Password;
                mem.Birdate = Birdate;
                mem.Location = Location;
                db.Member.Add(mem);
                db.SaveChanges();
                ViewBag.Msg = "註冊成功!";
                return View();
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗!";

            return View();
        }
        public ActionResult MemberDelete(string account)  //會員刪除
        {
            var mem = db.Member
                .Where(m => m.Account == account).FirstOrDefault();
            db.Member.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("Member");
        }

        public ActionResult AnnouncementDelete(string announce)  //公告事項刪除
        {
            var ann = db.Announcement
                .Where(m => m.Aaccount == announce).FirstOrDefault();
            db.Announcement.Remove(ann);
            db.SaveChanges();
            return RedirectToAction("Announcement");
        }
        public ActionResult AnnouncementEdit(string announce)  //公告事項編輯
        {
            var ann = db.Announcement
                .Where(m => m.Aaccount == announce).FirstOrDefault();
            return View(ann);
        }
        [HttpPost]
        public ActionResult AnnouncementEdit
                (int AID ,string Aaccount, string Account, string SystemAnnounce, DateTime Date)
        {
            var ann = db.Announcement
                 .Where(m => m.Aaccount == Aaccount).FirstOrDefault();
            ann.Aaccount = Aaccount;
            ann.Account = Account;
            ann.SystemAnnounce = SystemAnnounce;
            ann.Date = Date;
            db.SaveChanges();
            ViewBag.Msg = "修改成功!";
            return View();
        }
        public ActionResult ProductDelete(int goods)  //商品刪除
        {
            var pro = db.Product
                .Where(m => m.ProId == goods).FirstOrDefault();
            db.Product.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        public ActionResult ProductEdit(int goods)  //商品編輯
        {
            var pro = db.Product
                .Where(m => m.ProId == goods).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult ProductEdit
                (int ProId, int ProPrice, string ProName, string ProCategory, string ProShopName, string ProUrl, string ProItemNo, string ProPic)
        {
            var pro = db.Product
                 .Where(m => m.ProId == ProId).FirstOrDefault();
            pro.ProId = ProId;
            pro.ProPrice = ProPrice;
            pro.ProName = ProName;
            pro.ProCategory = ProCategory;
            pro.ProShopName = ProShopName;
            pro.ProUrl = ProUrl;
            pro.ProItemNo = ProItemNo;
            pro.ProPic = ProPic;
            db.SaveChanges();
            return RedirectToAction("Product");
        }
    }
}