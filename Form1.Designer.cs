namespace mapc
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
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            btn_vector_map = new Button();
            btn_uydu_map = new Button();
            btn_hibrit_map = new Button();
            saga_dondur = new Button();
            sola_dondur = new Button();
            bulundugu_konum = new Button();
            bulundugu_enlem = new TextBox();
            bulundugu_boylam = new TextBox();
            hedef_enlem = new TextBox();
            hedef_boylam = new TextBox();
            uygun_rotayi_bul = new Button();
            listBox1 = new ListBox();
            panel_harita = new Panel();
            panel_sol = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel_sag = new Panel();
            dateTimePicker1 = new DateTimePicker();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            panel_sol.SuspendLayout();
            panel_sag.SuspendLayout();
            SuspendLayout();
            // 
            // gMapControl1
            // 
            gMapControl1.BackColor = SystemColors.ActiveCaption;
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.EmptyTileColor = Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new Point(0, 0);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 15;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new Size(1317, 496);
            gMapControl1.TabIndex = 0;
            gMapControl1.Zoom = 15D;
            gMapControl1.Load += gMapControl1_Load;
            // 
            // btn_vector_map
            // 
            btn_vector_map.Anchor = AnchorStyles.Top;
            btn_vector_map.AutoSize = true;
            btn_vector_map.BackColor = Color.Lavender;
            btn_vector_map.Location = new Point(3, 35);
            btn_vector_map.Name = "btn_vector_map";
            btn_vector_map.Size = new Size(122, 60);
            btn_vector_map.TabIndex = 1;
            btn_vector_map.Text = "Vektör";
            btn_vector_map.UseVisualStyleBackColor = false;
            btn_vector_map.Click += btn_vector_map_Click;
            // 
            // btn_uydu_map
            // 
            btn_uydu_map.Anchor = AnchorStyles.Top;
            btn_uydu_map.AutoSize = true;
            btn_uydu_map.BackColor = Color.Lavender;
            btn_uydu_map.Location = new Point(3, 113);
            btn_uydu_map.Name = "btn_uydu_map";
            btn_uydu_map.Size = new Size(122, 60);
            btn_uydu_map.TabIndex = 2;
            btn_uydu_map.Text = "Uydu";
            btn_uydu_map.UseVisualStyleBackColor = false;
            btn_uydu_map.Click += btn_uydu_map_Click;
            // 
            // btn_hibrit_map
            // 
            btn_hibrit_map.BackColor = Color.Lavender;
            btn_hibrit_map.Location = new Point(3, 192);
            btn_hibrit_map.Name = "btn_hibrit_map";
            btn_hibrit_map.Size = new Size(122, 60);
            btn_hibrit_map.TabIndex = 3;
            btn_hibrit_map.Text = "Hibrit";
            btn_hibrit_map.UseVisualStyleBackColor = false;
            btn_hibrit_map.Click += btn_hibrit_map_Click;
            // 
            // saga_dondur
            // 
            saga_dondur.BackColor = Color.Lavender;
            saga_dondur.Location = new Point(3, 302);
            saga_dondur.Name = "saga_dondur";
            saga_dondur.Size = new Size(122, 83);
            saga_dondur.TabIndex = 5;
            saga_dondur.Text = "Sağa Döndür";
            saga_dondur.UseVisualStyleBackColor = false;
            saga_dondur.Click += saga_dondur_Click;
            // 
            // sola_dondur
            // 
            sola_dondur.BackColor = Color.Lavender;
            sola_dondur.Location = new Point(3, 391);
            sola_dondur.Margin = new Padding(3, 3, 3, 0);
            sola_dondur.Name = "sola_dondur";
            sola_dondur.Size = new Size(122, 83);
            sola_dondur.TabIndex = 6;
            sola_dondur.Text = "Sola Döndür";
            sola_dondur.UseVisualStyleBackColor = false;
            sola_dondur.Click += sola_dondur_Click;
            // 
            // bulundugu_konum
            // 
            bulundugu_konum.BackColor = Color.Lavender;
            bulundugu_konum.Location = new Point(29, 16);
            bulundugu_konum.Name = "bulundugu_konum";
            bulundugu_konum.Size = new Size(119, 52);
            bulundugu_konum.TabIndex = 7;
            bulundugu_konum.Text = "Mevcut Konum Bilgilerini Gör";
            bulundugu_konum.TextAlign = ContentAlignment.TopCenter;
            bulundugu_konum.UseVisualStyleBackColor = false;
            bulundugu_konum.Click += bulundugu_konum_Click;
            // 
            // bulundugu_enlem
            // 
            bulundugu_enlem.BackColor = Color.Lavender;
            bulundugu_enlem.Location = new Point(193, 6);
            bulundugu_enlem.Name = "bulundugu_enlem";
            bulundugu_enlem.PlaceholderText = "Enlem";
            bulundugu_enlem.Size = new Size(125, 27);
            bulundugu_enlem.TabIndex = 10;
            // 
            // bulundugu_boylam
            // 
            bulundugu_boylam.BackColor = Color.Lavender;
            bulundugu_boylam.Location = new Point(193, 41);
            bulundugu_boylam.Name = "bulundugu_boylam";
            bulundugu_boylam.PlaceholderText = "Boylam";
            bulundugu_boylam.Size = new Size(125, 27);
            bulundugu_boylam.TabIndex = 11;
            // 
            // hedef_enlem
            // 
            hedef_enlem.BackColor = Color.Lavender;
            hedef_enlem.Location = new Point(193, 86);
            hedef_enlem.Name = "hedef_enlem";
            hedef_enlem.PlaceholderText = "Hedef Enlem";
            hedef_enlem.Size = new Size(125, 27);
            hedef_enlem.TabIndex = 12;
            // 
            // hedef_boylam
            // 
            hedef_boylam.BackColor = Color.Lavender;
            hedef_boylam.Location = new Point(193, 130);
            hedef_boylam.Name = "hedef_boylam";
            hedef_boylam.PlaceholderText = "Hedef Boylam";
            hedef_boylam.Size = new Size(125, 27);
            hedef_boylam.TabIndex = 13;
            // 
            // uygun_rotayi_bul
            // 
            uygun_rotayi_bul.BackColor = Color.Lavender;
            uygun_rotayi_bul.Location = new Point(389, 16);
            uygun_rotayi_bul.Name = "uygun_rotayi_bul";
            uygun_rotayi_bul.Size = new Size(119, 52);
            uygun_rotayi_bul.TabIndex = 14;
            uygun_rotayi_bul.Text = "Uygun Rotayı Bul";
            uygun_rotayi_bul.TextAlign = ContentAlignment.TopCenter;
            uygun_rotayi_bul.UseVisualStyleBackColor = false;
            uygun_rotayi_bul.Click += uygun_rotayi_bul_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.Lavender;
            listBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(29, 364);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(186, 88);
            listBox1.TabIndex = 15;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // panel_harita
            // 
            panel_harita.Location = new Point(335, 64);
            panel_harita.Name = "panel_harita";
            panel_harita.Padding = new Padding(5, 0, 20, 0);
            panel_harita.Size = new Size(282, 252);
            panel_harita.TabIndex = 17;
            // 
            // panel_sol
            // 
            panel_sol.BackColor = SystemColors.ActiveCaption;
            panel_sol.Controls.Add(label2);
            panel_sol.Controls.Add(label1);
            panel_sol.Controls.Add(btn_vector_map);
            panel_sol.Controls.Add(btn_uydu_map);
            panel_sol.Controls.Add(btn_hibrit_map);
            panel_sol.Controls.Add(saga_dondur);
            panel_sol.Controls.Add(sola_dondur);
            panel_sol.Location = new Point(0, 0);
            panel_sol.Name = "panel_sol";
            panel_sol.Size = new Size(276, 496);
            panel_sol.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe Print", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 202);
            label2.Name = "label2";
            label2.Size = new Size(264, 282);
            label2.TabIndex = 8;
            label2.Text = "Kocaeli Kart Hoş Geldiniz";
            // 
            // label1
            // 
            label1.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 0);
            label1.Name = "label1";
            label1.Size = new Size(202, 88);
            label1.TabIndex = 7;
            label1.Text = "Harita Özellikleri";
            // 
            // panel_sag
            // 
            panel_sag.BackColor = SystemColors.ActiveCaption;
            panel_sag.Controls.Add(dateTimePicker1);
            panel_sag.Controls.Add(comboBox2);
            panel_sag.Controls.Add(comboBox1);
            panel_sag.Controls.Add(label4);
            panel_sag.Controls.Add(label3);
            panel_sag.Controls.Add(listBox1);
            panel_sag.Controls.Add(bulundugu_enlem);
            panel_sag.Controls.Add(bulundugu_boylam);
            panel_sag.Controls.Add(hedef_enlem);
            panel_sag.Controls.Add(hedef_boylam);
            panel_sag.Controls.Add(bulundugu_konum);
            panel_sag.Controls.Add(uygun_rotayi_bul);
            panel_sag.Location = new Point(766, 0);
            panel_sag.Name = "panel_sag";
            panel_sag.Size = new Size(551, 496);
            panel_sag.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Lavender;
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Location = new Point(29, 289);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(261, 27);
            dateTimePicker1.TabIndex = 21;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.Lavender;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Nakit", "Kredi Kartı", "KentKart" });
            comboBox2.Location = new Point(193, 234);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 20;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Lavender;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Normal (Genel)", "Öğrenci", "Öğretmen", "+65 Yaş Üzeri" });
            comboBox1.Location = new Point(193, 192);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Lavender;
            label4.Location = new Point(29, 237);
            label4.Name = "label4";
            label4.Size = new Size(166, 20);
            label4.TabIndex = 18;
            label4.Text = "Ödeme Yöntemi Seçiniz";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Lavender;
            label3.Location = new Point(29, 195);
            label3.Name = "label3";
            label3.Size = new Size(135, 20);
            label3.TabIndex = 17;
            label3.Text = "Yolcu Tipini Seçiniz";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 496);
            Controls.Add(panel_sag);
            Controls.Add(panel_sol);
            Controls.Add(panel_harita);
            Controls.Add(gMapControl1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel_sol.ResumeLayout(false);
            panel_sol.PerformLayout();
            panel_sag.ResumeLayout(false);
            panel_sag.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private Button btn_vector_map;
        private Button btn_uydu_map;
        private Button btn_hibrit_map;
        private Button saga_dondur;
        private Button sola_dondur;
        private Button bulundugu_konum;
        private TextBox bulundugu_enlem;
        private TextBox bulundugu_boylam;
        private TextBox hedef_enlem;
        private TextBox hedef_boylam;
        private Button uygun_rotayi_bul;
        private ListBox listBox1;
        private Panel panel_harita;
        private Panel panel_sol;
        private Panel panel_sag;
        private Label label1;
        private Label label2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label3;
        private DateTimePicker dateTimePicker1;
    }
}
