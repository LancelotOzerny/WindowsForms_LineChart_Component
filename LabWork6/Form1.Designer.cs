namespace LabWork6
{
    partial class Form1
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
            this.grapher = new LabWork6.LineChart();
            this.SuspendLayout();
            // 
            // grapher
            // 
            this.grapher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grapher.ChartMargin = 20F;
            this.grapher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.grapher.Location = new System.Drawing.Point(15, 15);
            this.grapher.Margin = new System.Windows.Forms.Padding(6);
            this.grapher.Name = "grapher";
            this.grapher.Size = new System.Drawing.Size(1234, 651);
            this.grapher.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.grapher);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LineChart grapher;
    }
}

