using Service_PK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace Service_PK.Control
{
    public class WordExport
    {
        public static void SaveUstr(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить сведения по устройствам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Создаём объект документа
                Word.Document doc = null;
                try
                {
                    // Создаём объект приложения
                    Word.Application app = new Word.Application();
                    // Открываем
                    doc = app.Documents.Open(System.Windows.Forms.Application.StartupPath.ToString() + "\\Data\\1.docx");
                    doc.Activate();
                    // Добавляем информацию
                    // wBookmarks содержит все закладки
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    wRange = wBookmarks[1].Range;
                    wRange.Text = "Сведения по устройствам в базе сервисного центра";

                    Word.Table _table = doc.Tables[1];

                    int i = 1;

                    var addAP = (from ustr in db.PKs
                                 join cli in db.Clients on ustr.Client_ID equals cli.ID
                                 join typ in db.type_pks on ustr.Type_pk_ID equals typ.ID
                                 select new
                                 {
                                     Name = ustr.Name,
                                     model = typ.Name,
                                     FIO = cli.FIO
                                 }).ToList();

                    foreach (var ust in addAP)
                    {
                        i++;
                        _table.Rows.Add();
                        _table.Rows[i].Cells[1].Range.Text = (i - 1).ToString() + ".";
                        _table.Rows[i].Cells[1].Range.Bold = 0;
                        _table.Rows[i].Cells[2].Range.Text = ust.Name;
                        _table.Rows[i].Cells[2].Range.Bold = 0;
                        _table.Rows[i].Cells[3].Range.Text = ust.model;
                        _table.Rows[i].Cells[3].Range.Bold = 0;
                        _table.Rows[i].Cells[4].Range.Text = ust.FIO;
                        _table.Rows[i].Cells[4].Range.Bold = 0;
                    }

                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Word files(*.docx)|*.docx";    //формат выходных файлов
                                                                  //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = save.FileName;
                    doc.SaveAs2(filename);
                    // Закрываем документ
                    doc.Close();
                    doc = null;
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка, то
                    // закрываем документ и выводим информацию
                    doc.Close();
                    doc = null;
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }

        public static void SaveTypeCompl(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить сведения по типам комплектующих?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Создаём объект документа
                Word.Document doc = null;
                try
                {
                    // Создаём объект приложения
                    Word.Application app = new Word.Application();
                    // Открываем
                    doc = app.Documents.Open(System.Windows.Forms.Application.StartupPath.ToString() + "\\Data\\2.docx");
                    doc.Activate();
                    // Добавляем информацию
                    // wBookmarks содержит все закладки
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    wRange = wBookmarks[1].Range;
                    wRange.Text = "Сведения по типам комплектующих в базе сервисного центра";

                    Word.Table _table = doc.Tables[1];

                    int i = 1;

                    foreach (var ust in db.typeautoparts.ToList())
                    {
                        i++;
                        _table.Rows.Add();
                        _table.Rows[i].Cells[1].Range.Text = (i - 1).ToString() + ".";
                        _table.Rows[i].Cells[1].Range.Bold = 0;
                        _table.Rows[i].Cells[2].Range.Text = ust.Name;
                        _table.Rows[i].Cells[2].Range.Bold = 0;
                    }

                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Word files(*.docx)|*.docx";    //формат выходных файлов
                                                                  //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = save.FileName;
                    doc.SaveAs2(filename);
                    // Закрываем документ
                    doc.Close();
                    doc = null;
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка, то
                    // закрываем документ и выводим информацию
                    doc.Close();
                    doc = null;
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }

        public static void SaveTypeServ(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить сведения по типам услуг?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Создаём объект документа
                Word.Document doc = null;
                try
                {
                    // Создаём объект приложения
                    Word.Application app = new Word.Application();
                    // Открываем
                    doc = app.Documents.Open(System.Windows.Forms.Application.StartupPath.ToString() + "\\Data\\2.docx");
                    doc.Activate();
                    // Добавляем информацию
                    // wBookmarks содержит все закладки
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    wRange = wBookmarks[1].Range;
                    wRange.Text = "Сведения по типам услуг в базе сервисного центра";

                    Word.Table _table = doc.Tables[1];

                    int i = 1;

                    foreach (var ust in db.TypeServices.ToList())
                    {
                        i++;
                        _table.Rows.Add();
                        _table.Rows[i].Cells[1].Range.Text = (i - 1).ToString() + ".";
                        _table.Rows[i].Cells[1].Range.Bold = 0;
                        _table.Rows[i].Cells[2].Range.Text = ust.Name;
                        _table.Rows[i].Cells[2].Range.Bold = 0;
                    }

                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Word files(*.docx)|*.docx";    //формат выходных файлов
                                                                  //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = save.FileName;
                    doc.SaveAs2(filename);
                    // Закрываем документ
                    doc.Close();
                    doc = null;
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка, то
                    // закрываем документ и выводим информацию
                    doc.Close();
                    doc = null;
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }


        public static void Saveworh(ApplicationContext db)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Сохранить сведения по складам?", "Сохранить", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Создаём объект документа
                Word.Document doc = null;
                try
                {
                    // Создаём объект приложения
                    Word.Application app = new Word.Application();
                    // Открываем
                    doc = app.Documents.Open(System.Windows.Forms.Application.StartupPath.ToString() + "\\Data\\2.docx");
                    doc.Activate();
                    // Добавляем информацию
                    // wBookmarks содержит все закладки
                    Word.Bookmarks wBookmarks = doc.Bookmarks;
                    Word.Range wRange;
                    wRange = wBookmarks[1].Range;
                    wRange.Text = "Сведения по складам в базе сервисного центра";

                    Word.Table _table = doc.Tables[1];

                    int i = 1;

                    foreach (var ust in db.warehouses.ToList())
                    {
                        i++;
                        _table.Rows.Add();
                        _table.Rows[i].Cells[1].Range.Text = (i - 1).ToString() + ".";
                        _table.Rows[i].Cells[1].Range.Bold = 0;
                        _table.Rows[i].Cells[2].Range.Text = ust.Name;
                        _table.Rows[i].Cells[2].Range.Bold = 0;
                    }

                    var save = new System.Windows.Forms.SaveFileDialog();
                    save.Filter = "Word files(*.docx)|*.docx";    //формат выходных файлов
                                                                  //Сохраняем файл
                    if (save.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = save.FileName;
                    doc.SaveAs2(filename);
                    // Закрываем документ
                    doc.Close();
                    doc = null;
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка, то
                    // закрываем документ и выводим информацию
                    doc.Close();
                    doc = null;
                    System.Windows.Forms.MessageBox.Show(ex.Message.ToString()); //выводим полученную ошибку
                    System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString());
                }
            }
        }
    }
}

