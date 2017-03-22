namespace MazeGeneratorGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startGenerationButton = new System.Windows.Forms.Button();
            this.generateTimer = new System.Windows.Forms.Timer(this.components);
            this.generationSpeed = new System.Windows.Forms.NumericUpDown();
            this.visGen = new System.Windows.Forms.CheckBox();
            this.lineW = new System.Windows.Forms.NumericUpDown();
            this.mazeW = new System.Windows.Forms.NumericUpDown();
            this.mazeH = new System.Windows.Forms.NumericUpDown();
            this.refreshTimeout = new System.Windows.Forms.NumericUpDown();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mazeGroup = new System.Windows.Forms.GroupBox();
            this.mazeBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.generationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mazeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startGenerationButton
            // 
            this.startGenerationButton.Location = new System.Drawing.Point(688, 591);
            this.startGenerationButton.Name = "startGenerationButton";
            this.startGenerationButton.Size = new System.Drawing.Size(140, 28);
            this.startGenerationButton.TabIndex = 0;
            this.startGenerationButton.Text = "Start Generation";
            this.startGenerationButton.UseVisualStyleBackColor = true;
            this.startGenerationButton.Click += new System.EventHandler(this.startGenerationButton_Click);
            // 
            // generationSpeed
            // 
            this.generationSpeed.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.generationSpeed.Location = new System.Drawing.Point(132, 30);
            this.generationSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.generationSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generationSpeed.Name = "generationSpeed";
            this.generationSpeed.Size = new System.Drawing.Size(120, 20);
            this.generationSpeed.TabIndex = 1;
            this.generationSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // visGen
            // 
            this.visGen.AutoSize = true;
            this.visGen.Location = new System.Drawing.Point(129, 101);
            this.visGen.Name = "visGen";
            this.visGen.Size = new System.Drawing.Size(129, 17);
            this.visGen.TabIndex = 2;
            this.visGen.Text = "Visualizate Generaton";
            this.visGen.UseVisualStyleBackColor = true;
            // 
            // lineW
            // 
            this.lineW.Location = new System.Drawing.Point(129, 88);
            this.lineW.Name = "lineW";
            this.lineW.Size = new System.Drawing.Size(120, 20);
            this.lineW.TabIndex = 4;
            this.lineW.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // mazeW
            // 
            this.mazeW.Location = new System.Drawing.Point(129, 45);
            this.mazeW.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mazeW.Name = "mazeW";
            this.mazeW.Size = new System.Drawing.Size(120, 20);
            this.mazeW.TabIndex = 5;
            this.mazeW.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // mazeH
            // 
            this.mazeH.Location = new System.Drawing.Point(129, 19);
            this.mazeH.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.mazeH.Name = "mazeH";
            this.mazeH.Size = new System.Drawing.Size(120, 20);
            this.mazeH.TabIndex = 6;
            this.mazeH.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // refreshTimeout
            // 
            this.refreshTimeout.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.refreshTimeout.Location = new System.Drawing.Point(132, 56);
            this.refreshTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.refreshTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.refreshTimeout.Name = "refreshTimeout";
            this.refreshTimeout.Size = new System.Drawing.Size(120, 20);
            this.refreshTimeout.TabIndex = 7;
            this.refreshTimeout.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.visGen);
            this.groupBox1.Controls.Add(this.generationSpeed);
            this.groupBox1.Controls.Add(this.refreshTimeout);
            this.groupBox1.Location = new System.Drawing.Point(628, 283);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 129);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen Update";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Generation timeout (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Refresh timeout (ms)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lineW);
            this.groupBox2.Controls.Add(this.mazeH);
            this.groupBox2.Controls.Add(this.mazeW);
            this.groupBox2.Location = new System.Drawing.Point(628, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 125);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maze Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Height (Cells)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Width (Cells)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Line thickness (px)";
            // 
            // mazeGroup
            // 
            this.mazeGroup.Controls.Add(this.mazeBox);
            this.mazeGroup.Location = new System.Drawing.Point(12, 12);
            this.mazeGroup.Name = "mazeGroup";
            this.mazeGroup.Size = new System.Drawing.Size(600, 600);
            this.mazeGroup.TabIndex = 10;
            this.mazeGroup.TabStop = false;
            this.mazeGroup.Text = "Maze";
            // 
            // mazeBox
            // 
            this.mazeBox.Location = new System.Drawing.Point(13, 16);
            this.mazeBox.Name = "mazeBox";
            this.mazeBox.Size = new System.Drawing.Size(575, 575);
            this.mazeBox.TabIndex = 0;
            this.mazeBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 628);
            this.Controls.Add(this.mazeGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startGenerationButton);
            this.Name = "MainForm";
            this.Text = "Maze Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.generationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mazeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startGenerationButton;
        private System.Windows.Forms.Timer generateTimer;
        private System.Windows.Forms.NumericUpDown generationSpeed;
        private System.Windows.Forms.CheckBox visGen;
        private System.Windows.Forms.NumericUpDown lineW;
        private System.Windows.Forms.NumericUpDown mazeW;
        private System.Windows.Forms.NumericUpDown mazeH;
        private System.Windows.Forms.NumericUpDown refreshTimeout;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox mazeGroup;
        private System.Windows.Forms.PictureBox mazeBox;
    }
}

