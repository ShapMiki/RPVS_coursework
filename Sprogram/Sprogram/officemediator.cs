using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET; // Для DocX
using Xceed.Words.NET;    // Для Xceed.Words.NET
using System.Drawing;
using System.Drawing.Imaging;

namespace Sprogram
{
    internal class OfficeMediator
    {
        private readonly List<(double y, double stress)> _stressTable;
        private readonly double _moment;
        private readonly double _inertiaMoment;
        private readonly double _minY;
        private readonly double _maxY;

        public OfficeMediator(List<(double y, double stress)> stressTable,
                            double moment,
                            double inertiaMoment,
                            double minY,
                            double maxY)
        {
            _stressTable = stressTable;
            _moment = moment;
            _inertiaMoment = inertiaMoment;
            _minY = minY;
            _maxY = maxY;
        }

        public void ExcelSave(string filePath)
        {
            try
            {
                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Напряжения");

                    // Заголовки
                    worksheet.Cell(1, 1).Value = "y (мм)";
                    worksheet.Cell(1, 2).Value = "σ (Н/мм²)";

                    // Данные
                    for (int i = 0; i < _stressTable.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = _stressTable[i].y;
                        worksheet.Cell(i + 2, 2).Value = _stressTable[i].stress;
                    }

                    // Автоширина
                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка экспорта в Excel: {ex.Message}");
            }
        }

        public void WordSave(string filePath, System.Drawing.Image chartImage = null)
        {
            try
            {
                // Создаем новый документ
                using (var document = DocX.Create(filePath))
                {
                    // 1. Добавляем заголовок
                    var title = document.InsertParagraph("Отчет о напряжениях в балке");
                    title.FontSize(16).Bold().SpacingAfter(40).Alignment = Alignment.center;

                    // 2. Добавляем параметры балки
                    var parameters = document.InsertParagraph();
                    parameters.AppendLine($"Изгибающий момент: {_moment} Н·мм")
                             .AppendLine($"Момент инерции: {_inertiaMoment} мм⁴")
                             .AppendLine($"Границы сечения: {_minY}...{_maxY} мм")
                             .SpacingAfter(20);

                    // 3. Добавляем таблицу данных
                    var table = document.AddTable(_stressTable.Count + 1, 2);

                    // Заголовки таблицы
                    table.Rows[0].Cells[0].Paragraphs.First().Append("y (мм)").Bold();
                    table.Rows[0].Cells[1].Paragraphs.First().Append("σ (Н/мм²)").Bold();

                    // Заполняем таблицу данными
                    for (int i = 0; i < _stressTable.Count; i++)
                    {
                        table.Rows[i + 1].Cells[0].Paragraphs.First().Append(_stressTable[i].y.ToString("F2"));
                        table.Rows[i + 1].Cells[1].Paragraphs.First().Append(_stressTable[i].stress.ToString("F4"));
                    }

                    document.InsertTable(table);
                    document.InsertParagraph().SpacingAfter(20);

                    // 4. Добавляем график, если он передан
                    if (chartImage != null)
                    {
                        // Сохраняем изображение во временный файл
                        string tempImagePath = Path.Combine(Path.GetTempPath(), "chart_temp.png");

                        // Убедимся, что сохраняем в правильном формате
                        using (var stream = new FileStream(tempImagePath, FileMode.Create))
                        {
                            chartImage.Save(stream, ImageFormat.Png);
                        }

                        try
                        {
                            // Добавляем изображение в документ
                            var image = document.AddImage(tempImagePath);
                            var picture = image.CreatePicture();

                            // Центрируем изображение
                            var imageParagraph = document.InsertParagraph();
                            imageParagraph.AppendPicture(picture).Alignment = Alignment.center;
                            imageParagraph.SpacingAfter(20);
                        }
                        finally
                        {
                            // Удаляем временный файл
                            if (File.Exists(tempImagePath))
                            {
                                File.Delete(tempImagePath);
                            }
                        }
                    }

                    // Сохраняем документ
                    document.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка экспорта в Word: {ex.Message}");
            }
        }

        private void ReleaseExcelObjects(params object[] objects)
        {
            foreach (var obj in objects)
            {
                try { if (obj != null) Marshal.ReleaseComObject(obj); }
                catch { /* ignored */ }
            }
            GC.Collect();
        }

        private void ReleaseWordObjects(params object[] objects)
        {
            foreach (var obj in objects)
            {
                try { if (obj != null) Marshal.ReleaseComObject(obj); }
                catch { /* ignored */ }
            }
            GC.Collect();
        }
    }
}
