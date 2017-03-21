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
            ((System.ComponentModel.ISupportInitialize)(this.generationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeH)).BeginInit();
            this.SuspendLayout();
            // 
            // startGenerationButton
            // 
            this.startGenerationButton.Location = new System.Drawing.Point(873, 562);
            this.startGenerationButton.Name = "startGenerationButton";
            this.startGenerationButton.Size = new System.Drawing.Size(182, 54);
            this.startGenerationButton.TabIndex = 0;
            this.startGenerationButton.Text = "Start";
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
            this.generationSpeed.Location = new System.Drawing.Point(908, 536);
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
            this.visGen.Location = new System.Drawing.Point(738, 599);
            this.visGen.Name = "visGen";
            this.visGen.Size = new System.Drawing.Size(129, 17);
            this.visGen.TabIndex = 2;
            this.visGen.Text = "Visualizate Generaton";
            this.visGen.UseVisualStyleBackColor = true;
            // 
            // lineW
            // 
            this.lineW.Location = new System.Drawing.Point(908, 510);
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
            this.mazeW.Location = new System.Drawing.Point(738, 573);
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
            this.mazeH.Location = new System.Drawing.Point(738, 547);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 628);
            this.Controls.Add(this.mazeH);
            this.Controls.Add(this.mazeW);
            this.Controls.Add(this.lineW);
            this.Controls.Add(this.visGen);
            this.Controls.Add(this.generationSpeed);
            this.Controls.Add(this.startGenerationButton);
            this.Name = "MainForm";
            this.Text = "Maze Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.generationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGenerationButton;
        private System.Windows.Forms.Timer generateTimer;
        private System.Windows.Forms.NumericUpDown generationSpeed;
        private System.Windows.Forms.CheckBox visGen;
        private System.Windows.Forms.NumericUpDown lineW;
        private System.Windows.Forms.NumericUpDown mazeW;
        private System.Windows.Forms.NumericUpDown mazeH;
    }
}

