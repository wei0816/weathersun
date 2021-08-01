using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace Weathersun8889.Controllers
{
    public class HomeController : Controller
    {
        DatabaseWSEntities24 db = new DatabaseWSEntities24();

        public ActionResult Index3()  //管理員登入
        {
            return View();
        }
        public ActionResult Index()  //會員登入
        {
            return View();
        }
        public ActionResult Index1()  //會員管理平台
        {
            var members = db.會員.ToList();
            return View(members);
        }
        public ActionResult announcement()  //公告事項
        {
            var items = db.公告事項.ToList();
            return View(items);
        }
        public ActionResult system()  //系統回報資料
        {
            var checks = db.系統回報資料.ToList();
            return View(checks);
        }
        public ActionResult identity()  //身分驗證資料
        {
            var people = db.身分驗證資料.ToList();
            return View(people);
        }
        public ActionResult products()  //商品
        {
            var goods = db.商品.ToList();
            return View(goods);
        }
        public ActionResult proreclist()  //商品推薦表
        {
            var lists = db.商品推薦表.ToList();
            return View(lists);
        }
        public ActionResult peoplehead()  //虛擬人像
        {
            var people = db.虛擬人像.ToList();
            return View(people);
        }
        public ActionResult douctment()  //貼文管理
        {
            var post = db.貼文.ToList();
            return View(post);
        }
        public ActionResult clothes()  //穿搭資料
        {
            var wear = db.穿搭資料.ToList();
            return View(wear);
        }
        public ActionResult manager()  //管理員
        {
            var man = db.管理員.ToList();
            return View(man);
        }
        public ActionResult Homepage()  //首頁
        {
            return View();
        }
        public ActionResult welcome()  //會員登入之後的畫面
        {
            return View();
        }
        public ActionResult Advise()  //網頁意見回饋資料表
        {
            var adv = db.網頁意見回饋資料表.ToList();
            return View(adv);
        }
        public ActionResult Index2()  //歡迎來到晴穿搭
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index2(網頁意見回饋資料表 advise)
        {
            if (ModelState.IsValid)
            {
                db.網頁意見回饋資料表.Add(advise);
                db.SaveChanges();
                ViewBag.Msg = "您的意見回饋已寄出!🚀";
            }
            return View("Index2");
        }
        [HttpPost]
        public ActionResult Index3(string loginName, string loginPwd)    //管理員登入
        {
            var man = db.管理員
                .Where(m => m.管理員帳號 == loginName && m.管理員密碼 == loginPwd)
                .FirstOrDefault();
            if (man == null)
            {
                ViewBag.Message = "帳號、密碼錯誤，登入失敗!";
                return View("Index3");
            }

            Session["WelCome"] = man.管理員編號 + "歡迎光臨";
            Session["Member"] = man;
            return RedirectToAction("Index1");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index3");
        }
        [HttpPost]
        public ActionResult Index(string loginName, string loginPwd)    //會員登入
        {
            var mem = db.會員
                .Where(m => m.會員帳號 == loginName && m.會員密碼 == loginPwd)
                .FirstOrDefault();
            if (mem == null)
            {
                ViewBag.Message = "帳號、密碼錯誤，登入失敗!";
                return View("Index");
            }

            Session["WelCome"] = mem.用戶名 + "歡迎光臨";
            Session["Member"] = mem;
            return RedirectToAction("welcome");
        }
        public ActionResult Logout1()
        {
            Session.Abandon();
            return RedirectToAction("Index3");
        }
        public ActionResult postcreate()  //貼文新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult postcreate(貼文 post)
        {
            if (ModelState.IsValid)
            {
                db.貼文.Add(post);
                db.SaveChanges();
                return RedirectToAction("douctment");
            }

            return View(post);
        }
        public ActionResult announcementcreate()  //公告新增
        {
            return View();
        }
        [HttpPost]
        public ActionResult announcementcreate(公告事項 announce)
        {
            if (ModelState.IsValid)
            {
                db.公告事項.Add(announce);
                db.SaveChanges();
                return RedirectToAction("announcement");
            }

            return View(announce);
        }
        public ActionResult managerCreate()  //管理員新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult managerCreate(管理員 manager)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var man = db.管理員
                 .Where(m => m.管理員帳號 == manager.管理員帳號)
                 .FirstOrDefault();
            if (man == null)
            {
                db.管理員.Add(manager);
                db.SaveChanges();
                ViewBag.Msg = "新增成功!";
                return View();
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗!";

            return View();
        }
        public ActionResult identityCreate()  //身分驗證資料新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult identityCreate(身分驗證資料 identity)
        {
            if (ModelState.IsValid)
            {
                db.身分驗證資料.Add(identity);
                db.SaveChanges();
                return RedirectToAction("identity");
            }

            return View(identity);
        }
        public ActionResult systemCreate()  //系統回報資料新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult systemCreate(系統回報資料 sys)
        {
            if (ModelState.IsValid)
            {
                db.系統回報資料.Add(sys);
                db.SaveChanges();
                return RedirectToAction("system");
            }

            return View(sys);
        }
        public ActionResult wearCreate()   //穿搭資料新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult wearCreate(穿搭資料 wea)
        {
            if (ModelState.IsValid)
            {
                db.穿搭資料.Add(wea);
                db.SaveChanges();
                return RedirectToAction("clothes");
            }
            return View(wea);
        }
        public ActionResult peopleCreate()   //虛擬人像新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult peopleCreate(虛擬人像 peo)
        {
            if (ModelState.IsValid)
            {
                db.虛擬人像.Add(peo);
                db.SaveChanges();
                return RedirectToAction("peoplehead");
            }
            return View(peo);
        }
        public ActionResult productsCreate()   //商品新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult productsCreate(商品 pro)
        {
            if (ModelState.IsValid)
            {
                db.商品.Add(pro);
                db.SaveChanges();
                return RedirectToAction("products");
            }
            return View(pro);
        }
        public ActionResult proreclistCreate()   //商品推薦表新增
        {
            return View();
        }

        [HttpPost]
        public ActionResult proreclistCreate(商品推薦表 prorec)
        {
            if (ModelState.IsValid)
            {
                db.商品推薦表.Add(prorec);
                db.SaveChanges();
                return RedirectToAction("proreclist");
            }
            return View(prorec);
        }
        public ActionResult Postpic()  //貼文照片
        {
            return View();
        }
        [HttpPost]
        public ActionResult Postpic(HttpPostedFileBase postpic)
        {
            string fileName = "";

            if (postpic != null)
            {
                if (postpic.ContentLength > 0)
                {

                    fileName = Path.GetFileName(postpic.FileName);
                    var path = Path.Combine(Server.MapPath("~/postpics"), fileName);
                    postpic.SaveAs(path);
                }
            }
            string show = "";
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/postpics"));
            FileInfo[] fInfo = dir.GetFiles();
            int n = 0;
            foreach (FileInfo result in fInfo)
            {
                n++;
                show += "<a href='../postpics/" + result.Name + "'target='_blank'><img src='../postpics/" + result.Name
                    + "'width='90' height='60' border='0'></a> ";
            }
            return RedirectToAction("douctment");
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
            return RedirectToAction("products");
        }
      

        public ActionResult Create()  //會員註冊
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(會員 account)  //會員產品物件屬性會對應至表單同名欄位，account這個參數的產品物
                                                //件屬性可接收表單欄位的資料
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var mem = db.會員
                 .Where(m => m.會員帳號 == account.會員帳號)  //m是會員帳號的參數，m的會員帳號值等於account的會員帳號
                                                      //值一樣的話，會拒絕存取
                 .FirstOrDefault();
            if (mem == null)
            {
                db.會員.Add(account);
                db.SaveChanges();
                ViewBag.Msg = "註冊成功!";
                return View();
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗!";

            return View();
        }
        public ActionResult Propics()  //個人頭貼
        {
            return View();
        }
        [HttpPost]
        public ActionResult Propics(HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                if (Photo.ContentLength > 0)
                {
                    string filename = Path.GetFileName(Photo.FileName);
                    var path = Path.Combine(Server.MapPath("C:/Users/wei/Desktop/slnWeathersun8889/Weathersun8889/propics"), filename);
                    Photo.SaveAs(path);
                }
            }
            return RedirectToAction("ShowPhotos");
        }
        public string ShowPhotos()
        {
            string show = string.Empty;
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("C:/Users/wei/Desktop/slnWeathersun8889/Weathersun8889/propics"));
            FileInfo[] fInfo = dir.GetFiles();
            int n = 0;
            foreach (FileInfo result in fInfo)
            {
                n++;
                show += string.Format("<a href='C:/Users/wei/Desktop/slnWeathersun8889/Weathersun8889/propics{0}' target='_blank'>" +
                    "<img src='C:/Users/wei/Desktop/slnWeathersun8889/Weathersun8889/propics{0}' width=90 height=60 border=0 /></a>", result.Name);
                if (n % 4 == 0)
                {
                    show += "<p>";
                }
            }
            show += "<p><a href='Index1'>返回</a></p>";
            return show;
        }
        public ActionResult Delete(string account)  //刪除
        {
            var mem = db.會員
                .Where(m => m.會員帳號 == account).FirstOrDefault();
            db.會員.Remove(mem);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult Edit(string account)  //編輯
        {
            var mem = db.會員
                .Where(m => m.會員帳號 == account).FirstOrDefault();
            return View(mem);
        }
        [HttpPost]
        public ActionResult Edit
                (string 會員帳號, string 性別, string 用戶名, string 個人頭貼, DateTime 生日, string 會員密碼, string 居住地區)
        {
            var mem = db.會員
                 .Where(m => m.會員帳號 == 會員帳號).FirstOrDefault();
            mem.會員帳號 = 會員帳號;
            mem.性別 = 性別;
            mem.用戶名 = 用戶名;
            mem.個人頭貼 = 個人頭貼;
            mem.生日 = 生日;
            mem.會員密碼 = 會員密碼;
            mem.居住地區 = 居住地區;
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        public ActionResult announcementDelete(int manager)  //公告事項刪除
        {
            var ann = db.公告事項
                .Where(m => m.管理員編號 == manager).FirstOrDefault();
            db.公告事項.Remove(ann);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult announcementEdit(int manager)  //公告事項編輯
        {
            var ann = db.公告事項
                .Where(m => m.管理員編號 == manager).FirstOrDefault();
            return View(ann);
        }
        [HttpPost]
        public ActionResult announcementEdit
                (int 管理員編號, string 會員帳號, string 系統公告)
        {
            var ann = db.公告事項
                 .Where(m => m.管理員編號 == 管理員編號).FirstOrDefault();
            ann.管理員編號 = 管理員編號;
            ann.會員帳號 = 會員帳號;
            ann.系統公告 = 系統公告;
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult ProductDelete(string goods)  //商品刪除
        {
            var pro = db.商品
                .Where(m => m.商品標籤 == goods).FirstOrDefault();
            db.商品.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("products");
        }
        public ActionResult productEdit(string goods)  //商品編輯
        {
            var pro = db.商品
                .Where(m => m.商品標籤 == goods).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult productEdit
                (string 商品標籤, int 商品售價, string 商品名稱, string 商品類別, string 廠商名稱, string 商品連結, string 商品貨號, string 商品圖片)
        {
            var pro = db.商品
                 .Where(m => m.商品標籤 == 商品標籤).FirstOrDefault();
            pro.商品標籤 = 商品標籤;
            pro.商品售價 = 商品售價;
            pro.商品名稱 = 商品名稱;
            pro.商品類別 = 商品類別;
            pro.廠商名稱 = 廠商名稱;
            pro.商品連結 = 商品連結;
            pro.商品貨號 = 商品貨號;
            pro.商品圖片 = 商品圖片;
            db.SaveChanges();
            return RedirectToAction("products");
        }

        public ActionResult postDelete(int post)  //貼文刪除
        {
            var doc = db.貼文
                .Where(m => m.貼文編號 == post).FirstOrDefault();
            db.貼文.Remove(doc);
            db.SaveChanges();
            return RedirectToAction("document");
        }

        public ActionResult postedit(int post)  //貼文編輯
        {
            var doc = db.貼文
                .Where(m => m.貼文編號 == post).FirstOrDefault();
            return View(doc);
        }
        [HttpPost]
        public ActionResult postedit
                (int 貼文編號, string 會員帳號, string 貼文照片, string 貼文文字, DateTime 編輯日期, string 商品標籤)
        {
            var doc = db.貼文
                 .Where(m => m.貼文編號 == 貼文編號).FirstOrDefault();
            doc.貼文編號 = 貼文編號;
            doc.會員帳號 = 會員帳號;
            doc.貼文照片 = 貼文照片;
            doc.貼文文字 = 貼文文字;
            doc.編輯日期 = 編輯日期;
            doc.商品標籤 = 商品標籤;
            db.SaveChanges();
            return RedirectToAction("document");
        }
    }
}