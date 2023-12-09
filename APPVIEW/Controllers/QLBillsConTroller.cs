﻿using _APPAPI.Service;
using APPDATA.Models;
using APPVIEW.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;


using System.IO;
using System.Data;
using Image = APPDATA.Models.Image;

using System.Drawing;
using System.Net.NetworkInformation;
using Microsoft.CodeAnalysis;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Size = APPDATA.Models.Size;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;


namespace APPVIEW.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLBillsConTroller : Controller
    {

        // GET: QLBills
        private readonly ILogger<QLBillsConTroller> _logger;
        private Getapi<ProductDetail> getapi;
        private Getapi<Category> getapiCategory;
        private Getapi<APPDATA.Models.Color> getapiColor;
        private Getapi<Image> getapiImg;
        private Getapi<Size> getapiSize;
        private Getapi<Supplier> getapiSupplier;
        private Getapi<Product> getapiProduct;
        private Getapi<Material> getapiMaterial;
        private Getapi<Bill> bills;
        private Getapi<BillDetail> billDetails;
        private Getapi<Account> _account;
        private static readonly Random random = new Random();
        private string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public QLBillsConTroller(ILogger<QLBillsConTroller> logger)
        {
            _logger = logger;
            getapi = new Getapi<ProductDetail>();
            getapiCategory = new Getapi<Category>();
            getapiColor = new Getapi<APPDATA.Models.Color>();
            getapiImg = new Getapi<Image>();
            getapiSize = new Getapi<Size>();
            getapiSupplier = new Getapi<Supplier>();
            getapiProduct = new Getapi<Product>();
            getapiMaterial = new Getapi<Material>();
            bills = new Getapi<Bill>();
            billDetails = new Getapi<BillDetail>();
            _account = new Getapi<Account>();
          
        }

        public ActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> Xacnhan(Guid id)
        {
            var x = bills.GetApi("Bill").FirstOrDefault(c => c.id == id);

            var billct = billDetails.GetApi("BillDetail").Where(c => c.BIllId == id);
            foreach (var item in billct)
            {
                var prdct = getapi.GetApi("ProductDetails").FirstOrDefault(c => c.Id == item.ProductDetailID);
                var sl = prdct.Quantity = prdct.Quantity - item.Amount;

                if (sl < 0)
                {

                    return BadRequest("Mặt hàng này trong kho không đủ ");
                }
                else
                {
                    prdct.Quantity = sl;
                    await getapi.UpdateObj(prdct, "ProductDetails");
                    x.Status = 2;
                    await bills.UpdateObj(x, "Bill");
                }
            }

            return RedirectToAction("ShowBill");
        }

        public async Task<IActionResult> GiaoHang(Guid id)
        {
            var x = bills.GetApi("Bill").FirstOrDefault(c => c.id == id);
            x.Status = 3;
            await bills.UpdateObj(x, "Bill");
            return RedirectToAction("ShowBillXacNhan");
        }
        public async Task<IActionResult> HuyDon(Guid id)
        {
           
            var x = bills.GetApi("Bill").FirstOrDefault(c => c.id == id);
            var y = billDetails.GetApi("BillDetail").Where(c => c.BIllId == id).ToList();
            foreach (var item in y)
            {
                await billDetails.DeleteObj(item.id, "BillDetail");
            }
            await bills.DeleteObj(id, "Bill");
            return RedirectToAction("DonHuy");
        }

        public ActionResult ShowBill(string search)
        {
            var account = SessionService.GetUserFromSession(HttpContext.Session, "Account");
            var userBills = bills.GetApi("Bill").Where(c => c.Status == 1).OrderByDescending(d => d.CreateDate).ToList();
            ViewBag.viewbill = userBills;


            var billDetailsApi = billDetails.GetApi("BillDetail");
            var productDetailsApi = getapi.GetApi("ProductDetails");
            var productsApi = getapiProduct.GetApi("Product");


            ViewBag.viewbillct = billDetailsApi;
            ViewBag.viewprdct = productDetailsApi;
            ViewBag.viewprd = productsApi;
            ViewBag.sizee = getapiSize.GetApi("Size");
            ViewBag.acc = _account.GetApi("Account");
            ViewBag.Collor = getapiColor.GetApi("Color");
            try
            {
                if (search != "")
                {
                    var tk = bills.GetApi("Bill").Where(c => c.Status == 1 && c.Code.Contains(search)).OrderByDescending(d => d.CreateDate).ToList();
                    ViewBag.viewbill = tk;
                    return View(tk);
                }
                else
                {
                    ViewBag.viewbill = userBills;




                    return View(userBills);
                }

            }
            catch (Exception ex)
            {
                return View(userBills);
            }
            return View(userBills);

        }

        public ActionResult DonHuy(string search)
        {
            if (User.Identity.IsAuthenticated)
            {

                var Uid = User.Claims.FirstOrDefault(c => c.Type == "Id").Value;
                var acc = _account.GetApi("Account").FirstOrDefault(c => c.Id.ToString() == Uid);
                SessionService.SetObjToJson(HttpContext.Session, "Account", acc);
            }
            var account = SessionService.GetUserFromSession(HttpContext.Session, "Account");
            var userBills = bills.GetApi("Bill").Where(c => c.Status == 0).OrderByDescending(d => d.CreateDate).ToList();
            ViewBag.viewbill = userBills;


            var billDetailsApi = billDetails.GetApi("BillDetail");
            var productDetailsApi = getapi.GetApi("ProductDetails");
            var productsApi = getapiProduct.GetApi("Product");


            ViewBag.viewbillct = billDetailsApi;
            ViewBag.viewprdct = productDetailsApi;
            ViewBag.viewprd = productsApi;
            ViewBag.sizee = getapiSize.GetApi("Size");
            ViewBag.acc = _account.GetApi("Account");
            ViewBag.Collor = getapiColor.GetApi("Color");
            try
            {
                if (search != "")
                {
                    var tk = bills.GetApi("Bill").Where(c => c.Status == 0 && c.Code.Contains(search)).OrderByDescending(d => d.CreateDate).ToList();
                    ViewBag.viewbill = tk;
                    return View(tk);
                }
                else
                {
                    ViewBag.viewbill = userBills;




                    return View(userBills);
                }

            }
            catch (Exception ex)
            {
                return View(userBills);
            }
            return View(userBills);

        }
        public ActionResult ShowBillXacNhan(string search)
        {

            var account = SessionService.GetUserFromSession(HttpContext.Session, "Account");
            var userBills = bills.GetApi("Bill").Where(c => c.Status == 2).OrderByDescending(d => d.CreateDate).ToList();
            var billDetailsApi = billDetails.GetApi("BillDetail");
            var productDetailsApi = getapi.GetApi("ProductDetails");
            var productsApi = getapiProduct.GetApi("Product");


            ViewBag.viewbillct = billDetailsApi;
            ViewBag.viewprdct = productDetailsApi;
            ViewBag.viewprd = productsApi;
            ViewBag.sizee = getapiSize.GetApi("Size");
            ViewBag.acc = _account.GetApi("Account");
            ViewBag.Collor = getapiColor.GetApi("Color");
            ViewBag.viewbill = userBills;
            try
            {

                if (search != "")
                {
                    var tk = bills.GetApi("Bill").Where(c => c.Status == 2 && c.Code.Contains(search)).OrderByDescending(d => d.CreateDate).ToList();
                    ViewBag.viewbill = tk;
                    return View(tk);
                }
                else
                {
                    ViewBag.viewbill = userBills;




                    return View(userBills);
                }
            }
            catch (Exception ex)
            {


                return View(userBills);

            }

            return View(userBills);
        }
        [HttpPost]
        public ActionResult ChosenProduct(Guid productId )
        {
            var product = getapi.GetApi("ProductDetails").FirstOrDefault(c => c.Id == productId);
            List<ProductDetail> products = new List<ProductDetail>();

            if (product != null)
            {
                // Kiểm tra xem sản phẩm đã có trong danh sách chưa
                bool productExists = products.Any(p => p.Id == productId);

                if (!productExists)
                {
                    products.Add(product);
                }
                var size = getapiSize.GetApi("Size").FirstOrDefault(c => c.Id == product.Id_Size);
                var color = getapiColor.GetApi("Color").FirstOrDefault(c => c.Id == product.Id_Color);
                return Json(new { success = true, sanphamchitiets = products, size = size.Name, color = color.Name });
            }

            return Json(new { success = false });
        }


        public ActionResult BanHangOff(string inputValue)
        {
            ViewBag.size = getapiSize.GetApi("Size");
            ViewBag.color = getapiColor.GetApi("Color");
            ViewBag.Img = getapiImg.GetApi("Image");
            try
            {
                if (inputValue != "")
                {
                    return View(getapi.GetApi("ProductDetails").Where(c => c.Quantity > 0 && c.Name.ToLower().Contains(inputValue.ToLower())).ToList());
                }
            }
            catch (Exception ex) {

                return View(getapi.GetApi("ProductDetails").Where(c => c.Quantity > 0));
            }
        

         
            return View(getapi.GetApi("ProductDetails").Where(c=>c.Quantity>0));
        }
   

        public string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpPost]
        public async Task<IActionResult> CreateBill(List<Guid> productId, List<int> soluong, float tongtien , string tenkh)
        {
            var account = SessionService.GetUserFromSession(HttpContext.Session, "Account");
            if (account.Id == Guid.Empty) {

                return Redirect("~/Account/Login");
            }
            var prdct = getapi.GetApi("ProductDetails").ToList();
            var billct = billDetails.GetApi("BillDetail");
            var bill = bills.GetApi("Bill");
            Bill newbil = new Bill();
            newbil.id = Guid.NewGuid();
            newbil.AccountId = account.Id;
            newbil.Code = GenerateRandomString(8);
            newbil.CreateDate = DateTime.Now;
            newbil.Type = "Tại Quầy";
            newbil.TotalMoney = tongtien;
            newbil.Status = 4;
            await bills.CreateObj(newbil, "Bill");
            if (productId.Count == soluong.Count)
            {
                for (int i = 0; i < productId.Count; i++)
                {
                    var id = productId[i];
                    var quantity = soluong[i];

                    foreach (var item in prdct)
                    {
                        if (item.Id == id)
                        {
                            var bil = new BillDetail();
                            bil.id = Guid.NewGuid();
                            bil.BIllId = newbil.id;
                            bil.Amount = quantity;
                            bil.Price = quantity * item.Price;
                            bil.Status = 1;
                            bil.ProductDetailID = item.Id;
                            await billDetails.CreateObj(bil, "BillDetail");

                            item.Quantity = item.Quantity-quantity;
                            await getapi.UpdateObj(item,"ProductDetails");
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("BanHangOff");
            }
            if (tenkh=="" || tenkh == null) {


                tenkh = "Khong Luu Ten";
            }
        
            return RedirectToAction("GenerateInvoice", new { billId = newbil.id ,tenkh = tenkh});
        }
 

public ActionResult GenerateInvoice(Guid billId , string tenkh)
        {
            // Lấy thông tin hóa đơn từ billId
            var bill = bills.GetApi("Bill").FirstOrDefault(b => b.id == billId);
            var billDetailss = billDetails.GetApi("BillDetail").Where(bd => bd.BIllId == billId).ToList();
            var products = getapi.GetApi("ProductDetails").ToList();
        
            // Tạo file PDF
            string normalizedString1 = tenkh.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString1)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            string normalizedString = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            // Chuyển chuỗi thành danh sách các từ
            string[] words = normalizedString.Split(' ');

            // Xử lý từng từ trong danh sách
            StringBuilder result = new StringBuilder();
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    // Chuyển chữ cái đầu của từ thành chữ hoa
                    string processedWord = char.ToUpper(word[0]) + word.Substring(1).ToLower();

                    result.Append(processedWord);
                    result.Append(" "); // Thêm dấu cách sau mỗi từ
                }
            }

             var ten = result.ToString().Trim();

            using (var ms = new MemoryStream())
            {
                using (var document = new iTextSharp.text.Document(PageSize.A5, 25, 25, 30, 30))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    document.Open();

                    // Tạo tiêu đề hóa đơn
                    var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                    var titleParagraph = new Paragraph("Hoa Don Ban Hang \n", titleFont);
                    titleParagraph.Alignment = Element.ALIGN_CENTER;
                    document.Add(titleParagraph); 
                    var titleParagraph2 = new Paragraph("  ", titleFont);
                    titleParagraph2.Alignment = Element.ALIGN_CENTER;
                    document.Add(titleParagraph2);

                    // Tạo thông tin khách hàng và nhân viên
                    var infoFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);
                    var infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;
                    infoTable.SetWidths(new int[] { 1, 2 });

                    infoTable.AddCell(new Phrase("Ma Hoa Don :", infoFont));
                    infoTable.AddCell(new Phrase(bill.Code, infoFont));
                    infoTable.AddCell(new Phrase("Ngay Tao :", infoFont));
                    infoTable.AddCell(new Phrase(bill.CreateDate.ToString("dd/MM/yyyy"), infoFont));
                    infoTable.AddCell(new Phrase("Ten Khach Hang :", infoFont));
                    infoTable.AddCell(new Phrase(ten, infoFont));
              
           
              

                    document.Add(infoTable);

                    // Tạo bảng chi tiết hóa đơn
                    var detailFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
                    var detailTable = new PdfPTable(5);
                    detailTable.WidthPercentage = 100;
                    detailTable.SetWidths(new int[] { 1, 3, 2, 2, 2 });
                    detailTable.SpacingBefore = 10f;
                    detailTable.SpacingAfter = 10f;

                    detailTable.AddCell(new Phrase("STT", detailFont));
                    detailTable.AddCell(new Phrase("San Pham", detailFont));
                    detailTable.AddCell(new Phrase("Don Gia", detailFont));
                    detailTable.AddCell(new Phrase("So Luong", detailFont));
                    detailTable.AddCell(new Phrase("Thanh Tien", detailFont));

                    int stt = 1;
                    foreach (var item in billDetailss)
                    {
                       
                            var product = products.FirstOrDefault(p => p.Id == item.ProductDetailID);
                            detailTable.AddCell(new Phrase(stt.ToString(), detailFont));
                            detailTable.AddCell(new Phrase(product.Name, detailFont));
                            detailTable.AddCell(new Phrase(product.Price.ToString("#,##0") + " VND", detailFont));
                            detailTable.AddCell(new Phrase(item.Amount.ToString(), detailFont));
                            detailTable.AddCell(new Phrase((item.Price).ToString("#,##0") + " VND", detailFont));
                            stt++;
                       
                    }

                    document.Add(detailTable);

                    // Tạo tổng tiền và chữ ký
                    var totalFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    var totalParagraph = new Paragraph("Tong Tien: " + bill.TotalMoney.ToString() + " VND");
                    totalParagraph.Alignment = Element.ALIGN_RIGHT;
                    document.Add(totalParagraph);

                    var signFont = FontFactory.GetFont("Arial", 12, Font.ITALIC);
                    var signParagraph = new Paragraph("\n\nNguoi Lap Hoa Don\n(Ky Va Ghi Ro Ho Ten)", signFont); signParagraph.Alignment = Element.ALIGN_RIGHT; document.Add(signParagraph);
                    document.Close();
                   
                 
                }

                // Trả về file PDF


                 RedirectToAction("index");
                return File(ms.ToArray(), "application/pdf", "HoaDon_" + bill.Code + ".pdf");
            } 
        
        }

            // POST: QLBills/Delete/5
            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
