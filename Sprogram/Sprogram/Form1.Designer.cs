
namespace Sprogram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listBox1 = new ListBox();
            label7 = new Label();
            label6 = new Label();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            textBox5 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            tabPage2 = new TabPage();
            pictureBox1 = new PictureBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tabPage3 = new TabPage();
            button5 = new Button();
            label9 = new Label();
            textBox6 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            label8 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            button6 = new Button();
            button7 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(-4, -2);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(886, 430);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(878, 402);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Главная";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(435, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(331, 364);
            listBox1.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(158, 195);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 15;
            label7.Text = "Нет расчета";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(106, 195);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 14;
            label6.Text = "Статус:";
            // 
            // button2
            // 
            button2.Location = new Point(231, 146);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(109, 33);
            button2.TabIndex = 13;
            button2.Text = "Вывести";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(101, 146);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(109, 33);
            button1.TabIndex = 12;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(100, 114);
            label5.Name = "label5";
            label5.Size = new Size(104, 15);
            label5.TabIndex = 11;
            label5.Text = "Шаг изменения y:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(277, 114);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(101, 23);
            textBox5.TabIndex = 10;
            textBox5.Text = "1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 63);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 9;
            label4.Text = "Верхняя граница (мм)";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(277, 89);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(101, 23);
            textBox4.TabIndex = 8;
            textBox4.Text = "-120";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(101, 89);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 7;
            label3.Text = "Нижняя граница (мм):";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(277, 63);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(101, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "120";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 38);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 5;
            label1.Text = "Момент инерции (мм^4):";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(277, 11);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(101, 23);
            textBox1.TabIndex = 4;
            textBox1.Text = "5e6";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 13);
            label2.Name = "label2";
            label2.Size = new Size(173, 15);
            label2.TabIndex = 3;
            label2.Text = "Изгибающий момент (H*мм):";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(277, 38);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(101, 23);
            textBox2.TabIndex = 2;
            textBox2.Text = "3460e4";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.Add(chart1);
            tabPage2.Controls.Add(chart2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(878, 402);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "График";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 184);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            chart1.Legends.Add(legend5);
            chart1.Location = new Point(286, 262);
            chart1.Margin = new Padding(3, 2, 3, 2);
            chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            chart1.Series.Add(series5);
            chart1.Size = new Size(592, 136);
            chart1.TabIndex = 16;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            chart2.Legends.Add(legend6);
            chart2.Location = new Point(286, 2);
            chart2.Margin = new Padding(3, 2, 3, 2);
            chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            chart2.Series.Add(series6);
            chart2.Size = new Size(589, 256);
            chart2.TabIndex = 17;
            chart2.Text = "chart2";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(textBox6);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(label8);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(3, 2, 3, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 2, 3, 2);
            tabPage3.Size = new Size(878, 402);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Инструменты";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(314, 211);
            button5.Name = "button5";
            button5.Size = new Size(86, 33);
            button5.TabIndex = 5;
            button5.Text = "обзор";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(314, 182);
            label9.Name = "label9";
            label9.Size = new Size(44, 20);
            label9.TabIndex = 4;
            label9.Text = "Путь:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(379, 182);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(193, 23);
            textBox6.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.DeepSkyBlue;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button4.Location = new Point(451, 133);
            button4.Name = "button4";
            button4.Size = new Size(121, 35);
            button4.TabIndex = 2;
            button4.Text = "Word";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LawnGreen;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.Location = new Point(313, 133);
            button3.Name = "button3";
            button3.Size = new Size(121, 35);
            button3.TabIndex = 1;
            button3.Text = "Ecsel";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label8.Location = new Point(314, 91);
            label8.Name = "label8";
            label8.Size = new Size(176, 25);
            label8.TabIndex = 0;
            label8.Text = "Сохранить Отчет:";
            // 
            // button6
            // 
            button6.Location = new Point(437, 214);
            button6.Name = "button6";
            button6.Size = new Size(135, 30);
            button6.TabIndex = 6;
            button6.Text = "Помощь";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(101, 334);
            button7.Name = "button7";
            button7.Size = new Size(135, 30);
            button7.TabIndex = 17;
            button7.Text = "Помощь";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 420);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label5;
        private Label label4;
        private TextBox textBox4;
        private Label label3;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label7;
        private Label label6;
        private Button button2;
        private Button button1;
        private TextBox textBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Button button4;
        private Button button3;
        private Label label8;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label9;
        private TextBox textBox6;
        private FolderBrowserDialog folderBrowserDialog2;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}
