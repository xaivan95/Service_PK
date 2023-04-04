using Microsoft.Office.Interop.Excel;
using Service_PK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Service_PK.Control
{
    public class ExcelExport
    {
        public static void SaveOrder(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные по заказам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Заказы";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Дата начала";
                    sheet.Cells[1, 3] = "Дата окончания";
                    sheet.Cells[1, 4] = "Описание";
                    sheet.Cells[1, 5] = "Тип оплаты";
                    sheet.Cells[1, 6] = "Цена";

                    int i = 1;
                    var n = 0;
                    foreach (var order in db.Orders.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = order.Start_date;
                        sheet.Cells[i, 3] = order.End_date;
                        sheet.Cells[i, 4] = order.Note;
                        sheet.Cells[i, 5] = order.Pay_type_ID == 1 ? "Наличными" : "Безналичными";
                        sheet.Cells[i, 6] = order.Price;
                        var addAP = (from APinOr in db.Autopartinorder
                                     join ap in db.autoparts on APinOr.Autopart_Id equals ap.ID
                                     join Tap in db.typeautoparts on ap.TypeAutopart_ID equals Tap.ID
                                     where APinOr.Order_ID == order.ID
                                     select new
                                     {
                                         Name = ap.Name,
                                         Serial_number = ap.Serial_number,
                                         Price = ap.Price,
                                         type = Tap.Name
                                     }).ToList();
                        if (addAP.Count() > 0)
                        {
                            i++;
                            sheet.Cells[i, 1] = "Комплектующие в заказе";
                            Excel.Range r1 = sheet.Cells[i, 1];
                            Excel.Range r2 = sheet.Cells[i, 6];
                            Excel.Range range = sheet.get_Range(r1, r2);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.Merge(Type.Missing);
                           
                            foreach (var ap in addAP)
                            {
                                i++;
                                sheet.Cells[i, 2] = ap.Name;
                                sheet.Cells[i, 3] = ap.Serial_number;
                                sheet.Cells[i, 4] = ap.Price;
                                sheet.Cells[i, 5] = ap.type;
                            }
                        }
                        var addOR= (from APinOr in db.Serviceinorder
                                     join ap in db.Services on APinOr.services_ID equals ap.ID
                                     join Tap in db.TypeServices on ap.TypeServices_ID equals Tap.ID
                                     where APinOr.Order_ID == order.ID
                                     select new
                                     {
                                         Name = ap.Note,
                                         Price = ap.Price,
                                         type = Tap.Name
                                     }).ToList();
                        if (addOR.Count() > 0)
                        {
                            i++;
                            sheet.Cells[i, 1] = "Услуги в заказе";
                            Excel.Range r3 = sheet.Cells[i, 1];
                            Excel.Range r4 = sheet.Cells[i, 6];
                            Excel.Range range2 = sheet.get_Range(r3, r4);
                            range2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range2.Merge(Type.Missing);

                            foreach (var ap in addOR)
                            {
                                i++;
                                sheet.Cells[i, 2] = ap.Name;
                                sheet.Cells[i, 3] = ap.Price;
                                sheet.Cells[i, 4] = ap.type;
                            }
                        }
                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
            }


        public static void SaveClient(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные по клиентам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Клиенты";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "ФИО";
                    sheet.Cells[1, 3] = "Номер телефона";


                    int i = 1;
                    var n = 0;
                    foreach (var client in db.Clients.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = client.FIO;
                        sheet.Cells[i, 3] = client.Phone;

                        var addAP = (from ustr in db.PKs
                                     join cli in db.Clients on ustr.Client_ID equals cli.ID
                                     join typ in db.type_pks on ustr.Type_pk_ID equals typ.ID
                                     where cli.ID == client.ID
                                     select new 
                                     {
                                         Name = ustr.Name,
                                         model = typ.Name

                                     }).ToList();
                        if (addAP.Count() > 0)
                        {
                            i++;
                            sheet.Cells[i, 1] = "Устройства клиента";
                            Excel.Range r1 = sheet.Cells[i, 1];
                            Excel.Range r2 = sheet.Cells[i, 3];
                            Excel.Range range = sheet.get_Range(r1, r2);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.Merge(Type.Missing);

                            foreach (var ap in addAP)
                            {
                                i++;
                                sheet.Cells[i, 2] = ap.Name;
                                sheet.Cells[i, 3] = ap.model;
                            }
                        }
                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }


        public static void SaveEmpl(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные по сотрудникам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Сотрудники";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "ФИО";
                    sheet.Cells[1, 3] = "Номер телефона";
                    sheet.Cells[1, 4] = "Адрес";
                    sheet.Cells[1, 5] = "Должность";
                    sheet.Cells[1, 6] = "Логин";
                    sheet.Cells[1, 7] = "Пароль";

                    int i = 1;
                    var n = 0;
                    foreach (var emp in db.employees.ToList())
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = emp.FIO;
                        sheet.Cells[i, 3] = emp.Phone;
                        sheet.Cells[i, 4] = emp.Adress;
                        sheet.Cells[i, 5] = emp.Post_ID ==1 ? "Администратор" : "Сотрудник центра";
                        sheet.Cells[i, 6] = emp.Login;
                        sheet.Cells[i, 7] = emp.Password;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 7];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }


        public static void SaveComplect(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные по комплектующим?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Комплектующие";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Название";
                    sheet.Cells[1, 3] = "Серийный номер";
                    sheet.Cells[1, 4] = "Цена";
                    sheet.Cells[1, 5] = "Тип запчасти";
                    sheet.Cells[1, 6] = "Склад хранения";

                    int i = 1;
                    var n = 0;

                    var addAP = (from comp in db.autoparts
                                 join typ in db.typeautoparts on comp.TypeAutopart_ID equals typ.ID
                                 join comInSkla in db.Autopartinwarehouses on comp.ID equals comInSkla.Autopart_Id
                                 join skl in db.warehouses on comInSkla.Warehouse_ID equals skl.ID
                                 select new
                                 {
                                     Name = comp.Name,
                                     Serial_number = comp.Serial_number,
                                     Price = comp.Price,
                                     model = typ.Name,
                                     skl = skl.Name
                                 }).ToList();

                    foreach (var emp in addAP)
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = emp.Name;
                        sheet.Cells[i, 3] = emp.Serial_number;
                        sheet.Cells[i, 4] = emp.Price;
                        sheet.Cells[i, 5] = emp.model;
                        sheet.Cells[i, 6] = emp.skl;

                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 6];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }

        public static void SaveServ(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить данные по услугам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Excel.Application app = new Excel.Application
                    {
                        //Отобразить Excel
                        Visible = false,
                        //Количество листов в рабочей книге
                        SheetsInNewWorkbook = 1
                    };
                    //Добавить рабочую книгу
                    Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
                    //Отключить отображение окон с сообщениями
                    app.DisplayAlerts = false;
                    //Получаем первый лист документа (счет начинается с 1)
                    Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                    //Название листа (вкладки снизу)
                    sheet.Name = "Услуги";

                    sheet.Cells[1, 1] = "№ п/п";
                    sheet.Cells[1, 2] = "Название";
                    sheet.Cells[1, 3] = "Стоимость";
                    sheet.Cells[1, 4] = "Тип Услуги";

                    int i = 1;
                    var n = 0;

                    var addAP = (from ser in db.Services
                                 join typ in db.TypeServices on ser.TypeServices_ID equals typ.ID
                                 select new
                                 {
                                     Name = ser.Note,
                                     Price = ser.Price,
                                     Typ = typ.Name
                                 }).ToList();

                    foreach (var emp in addAP)
                    {
                        n++;
                        i++;
                        sheet.Cells[i, 1] = n;
                        sheet.Cells[i, 2] = emp.Name;
                        sheet.Cells[i, 3] = emp.Price;
                        sheet.Cells[i, 4] = emp.Typ;
                    }
                    Excel.Range r5 = sheet.Cells[1, 1];
                    Excel.Range r6 = sheet.Cells[i, 4];
                    Excel.Range range3 = sheet.get_Range(r5, r6);
                    range3.Borders.Color = ColorTranslator.ToOle(Color.Black);
                    range3.EntireColumn.AutoFit();
                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Excel files(*.xlsx)|*.xlsx";    //формат выходных файлов
                                                                   //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = save.FileName;
                    app.Application.ActiveWorkbook.SaveAs(filename, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    app.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                    app = null;
                    workBook = null;
                    sheet = null;
                    GC.Collect(); // убрать за собой
                }
                catch (Exception ex) //возникает при ошибках
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }
    }
}
