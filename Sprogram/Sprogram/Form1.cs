using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sprogram
{
    public partial class Form1 : Form
    {
        private Panel splashPanel;

        private BeamStressCalculator beamStressCalculator = new BeamStressCalculator();

        public Form1()
        {
            InitializeComponent();
            ShowSplashInsideForm();
            DrawIBeamInPictureBox();
        }

        private async void ShowSplashInsideForm()
        {
            // Создаем панель-заставку
            splashPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var label = new Label()
            {
                Text = "БЕЛОРУССКИЙ НАЦИОНАЛЬНЫЙ ТЕХНИЧЕСКИЙ УНИВЕРСИТЕТ\nФакультет ИНФОРМАЦИОННЫХ ТЕХНОЛОГИЙ И РАБОТОТЕХНИКИ\nКурсовой проект по дисциплине РПВС\nТема: Анализ напряжений в балке при изгибе\n\n\nВыполнил: Шаплавский Никита Сергеевич\nГруппа: 10701323\n\n\nМинск 2025",
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            splashPanel.Controls.Add(label);
            this.Controls.Add(splashPanel);
            splashPanel.BringToFront();

            // Ждём 5 секунд, не блокируя интерфейс
            await Task.Delay(5000);

            // Удаляем панель-заставку
            splashPanel.Visible = false;
            splashPanel.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double inter = Convert.ToDouble(textBox1.Text);
                double moment = Convert.ToDouble(textBox2.Text);
                double minY = Convert.ToDouble(textBox3.Text);
                double maxY = Convert.ToDouble(textBox4.Text);
                double step = Convert.ToDouble(textBox5.Text);
                beamStressCalculator.SetParameters(inter, moment, maxY, minY, step);

                label7.Text = "Параметры рассчитаны";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных: " + ex.Message);
                label7.Text = "Ошибка ввода данных: " + ex.Message;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, были ли заданы параметры
                if (beamStressCalculator.Moment == 0 || beamStressCalculator.InertiaMoment == 0)
                {
                    MessageBox.Show("Сначала задайте параметры балки!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var stressTable = beamStressCalculator.GetStressTable();

                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Очищаем ListBox перед заполнением
                listBox1.Items.Clear();

                // Добавляем заголовок таблицы
                listBox1.Items.Add("y (мм)\t\t\tσ (Н/мм²)");
                listBox1.Items.Add("------------------------------------------------");

                // Заполняем ListBox данными
                foreach (var point in stressTable)
                {
                    listBox1.Items.Add($"{point.y:F2}\t\t\t{point.stress:F4}");
                }

                // Создаем и настраиваем область графика
                ChartArea chartArea = new ChartArea("MainArea")
                {
                    AxisX = { Title = "Координата y (мм)" },
                    AxisY = { Title = "Напряжение (Н/мм²)" }
                };
                chart1.ChartAreas.Add(chartArea);

                // Создаем серию данных
                Series series = new Series("Напряжения")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Blue,
                    BorderWidth = 2
                };

                // Заполняем данными
                foreach (var point in stressTable)
                {
                    series.Points.AddXY(point.y, point.stress);
                }

                chart1.Series.Add(series);

                // Настройка масштаба
                chartArea.AxisX.Minimum = beamStressCalculator.MinY;
                chartArea.AxisX.Maximum = beamStressCalculator.MaxY;
                chartArea.AxisX.Interval = (beamStressCalculator.MaxY - beamStressCalculator.MinY) / 10;

                // Добавляем линию нейтральной оси
                AddNeutralAxisLine(chartArea);

                label7.Text = "График успешно построен";
                DrawBeamWithStressDiagram();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                label7.Text = "Ошибка при построении графика";
            }
        }

        private void AddNeutralAxisLine(ChartArea chartArea)
        {
            StripLine neutralLine = new StripLine
            {
                Interval = 0,
                IntervalOffset = 0,
                StripWidth = 0.1,
                BackColor = Color.Red,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 1,
                ToolTip = "Нейтральная ось (y=0)"
            };
            chartArea.AxisY.StripLines.Add(neutralLine);
        }
        private void DrawIBeamInPictureBox()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 2);
                Brush brush = Brushes.Gray;

                // Размеры сечения
                int beamWidth = 100;    // ширина верхней/нижней полки
                int flangeHeight = 25;  // высота полок (верх/низ)
                int webWidth = 65;      // толщина вертикальной стойки (стержня)
                int webHeight = 40;     // высота стойки

                // Начальная точка (левый верхний угол верхней полки)
                int x = (pictureBox1.Width - beamWidth) / 2;
                int y = (pictureBox1.Height - (2 * flangeHeight + webHeight)) / 2;

                // Верхняя полка
                Rectangle topFlange = new Rectangle(x, y, beamWidth, flangeHeight);

                // Вертикальная стойка
                int webX = x + (beamWidth - webWidth) / 2;
                int webY = y + flangeHeight;
                Rectangle web = new Rectangle(webX, webY, webWidth, webHeight);

                // Нижняя полка
                int bottomY = y + flangeHeight + webHeight;
                Rectangle bottomFlange = new Rectangle(x, bottomY, beamWidth, flangeHeight);

                // Рисуем и закрашиваем
                g.FillRectangle(brush, topFlange);
                g.FillRectangle(brush, web);
                g.FillRectangle(brush, bottomFlange);
                g.DrawRectangle(pen, topFlange.X, topFlange.Y, topFlange.Width, topFlange.Height);
                g.DrawRectangle(pen, web.X, web.Y, web.Width, web.Height);
                g.DrawRectangle(pen, bottomFlange.X, bottomFlange.Y, bottomFlange.Width, bottomFlange.Height);
            }

            pictureBox1.Image = bmp;
        }

        private void DrawBeamWithStressDiagram()
        {
            try
            {
                chart2.Series.Clear();
                chart2.ChartAreas.Clear();

                // Создаем область для графика
                ChartArea chartArea = new ChartArea("BeamView")
                {
                    AxisX = {
                Title = "Координата сечения (мм)",
                Minimum = beamStressCalculator.MinY - 20,
                Maximum = beamStressCalculator.MaxY + 20,
                MajorGrid = { Enabled = false }
            },
                    AxisY = {
                Title = "Напряжение (Н/мм²)",
                IntervalAutoMode = IntervalAutoMode.VariableCount
            }
                };
                chart2.ChartAreas.Add(chartArea);

                // Получаем данные напряжений
                var stressData = beamStressCalculator.GetStressTable();

                // 1. Серия для эпюры напряжений
                Series stressSeries = new Series("Эпюра напряжений")
                {
                    ChartType = SeriesChartType.Area,
                    Color = Color.FromArgb(120, 65, 105, 225), // Полупрозрачный синий
                    BorderColor = Color.Blue,
                    BorderWidth = 2
                };

                // 2. Серия для контура балки
                /*Series beamSeries = new Series("Балка")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Black,
                    BorderWidth = 3
                };*/

                // Заполняем данные
                foreach (var point in stressData)
                {
                    stressSeries.Points.AddXY(point.y, point.stress);
                }

                // Рисуем контур балки (вертикальные линии)
                double beamWidth = 5; // Условная толщина для визуализации
                double minY = beamStressCalculator.MinY;
                double maxY = beamStressCalculator.MaxY;

                /*
                // Левая граница балки
                beamSeries.Points.AddXY(minY, 0);
                beamSeries.Points.AddXY(minY, stressData.Min(p => p.stress));

                // Правая граница балки
                beamSeries.Points.AddXY(maxY, stressData.Max(p => p.stress));
                beamSeries.Points.AddXY(maxY, 0);
                chart2.Series.Add(beamSeries);
                 */
                // Добавляем серии
                chart2.Series.Add(stressSeries);


                // Настраиваем внешний вид
                chartArea.AxisY.Minimum = stressData.Min(p => p.stress) * 1.1;
                chartArea.AxisY.Maximum = stressData.Max(p => p.stress) * 1.1;

                // Добавляем нейтральную ось
                StripLine neutralAxis = new StripLine()
                {
                    Interval = 0,
                    IntervalOffset = 0,
                    StripWidth = 0.2,
                    BackColor = Color.Red,
                    BorderDashStyle = ChartDashStyle.Dash
                };
                chartArea.AxisY.StripLines.Add(neutralAxis);

                // Подписи экстремальных значений
                var maxPoint = stressSeries.Points.FindMaxByValue();
                maxPoint.Label = $"σ_max = {maxPoint.YValues[0]:F2}";
                maxPoint.LabelForeColor = Color.Blue;

                var minPoint = stressSeries.Points.FindMinByValue();
                minPoint.Label = $"σ_min = {minPoint.YValues[0]:F2}";
                minPoint.LabelForeColor = Color.Blue;

                label7.Text = "Балка с эпюрой напряжений построена";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Сначала укажите папку для сохранения!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаем полный путь к файлу
                string fileName = "beam_stress_analysis.xlsx";
                string fullPath = Path.Combine(textBox6.Text, fileName);

                // Проверяем и создаем директорию, если нужно
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                var mediator = new OfficeMediator(
                    beamStressCalculator.GetStressTable(),
                    beamStressCalculator.Moment,
                    beamStressCalculator.InertiaMoment,
                    beamStressCalculator.MinY,
                    beamStressCalculator.MaxY);

                mediator.ExcelSave(fullPath);
                MessageBox.Show($"Файл успешно сохранен:\n{fullPath}", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта в Excel:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Сначала укажите папку для сохранения!", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаем полный путь к файлу
                string fileName = "beam_analysis_report.docx";
                string fullPath = Path.Combine(textBox6.Text, fileName);

                // Проверяем и создаем директорию, если нужно
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // Получаем изображение графика
                var chartImage = GetChartImage(chart2);

                var mediator = new OfficeMediator(
                    beamStressCalculator.GetStressTable(),
                    beamStressCalculator.Moment,
                    beamStressCalculator.InertiaMoment,
                    beamStressCalculator.MinY,
                    beamStressCalculator.MaxY);

                mediator.WordSave(fullPath, chartImage);
                MessageBox.Show($"Файл успешно сохранен:\n{fullPath}", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта в Word:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image GetChartImage(Chart chart)
        {
            using (var ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                return Image.FromStream(ms);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Настраиваем диалог выбора папки
            folderBrowserDialog1.Description = "Выберите папку для сохранения результатов";
            folderBrowserDialog1.ShowNewFolderButton = true; // Разрешаем создавать новые папки
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments; // Начальная папка

            // Показываем диалог и проверяем результат
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем выбранный путь и записываем в TextBox
                textBox6.Text = folderBrowserDialog1.SelectedPath;

                // Опционально: добавляем слеш в конце, если его нет
                if (!textBox6.Text.EndsWith("\\"))
                {
                    textBox6.Text += "\\";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Путь к файлу справки (может быть относительным или абсолютным)
                string helpFilePath = "Untitled.chm";

                // Проверяем существование файла
                if (!File.Exists(helpFilePath))
                {
                    // Если файл не найден в текущей директории, попробуем найти в директории приложения
                    helpFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Untitled.chm");

                    if (!File.Exists(helpFilePath))
                    {
                        MessageBox.Show("Файл справки 'Untitled.chm' не найден!", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Открываем CHM-файл с помощью стандартного средства Windows
                Process.Start(new ProcessStartInfo(helpFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл справки: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

