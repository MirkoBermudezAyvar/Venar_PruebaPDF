namespace Prueba_pdf.Formularios
{
    partial class Form_Mantenimiento_Plan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dgtablaplantillas = new DataGridView();
            label3 = new Label();
            txtnomplantilla = new TextBox();
            button1 = new Button();
            dgvListaPlantillas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgtablaplantillas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvListaPlantillas).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1157, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1090, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Planillas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.BlueViolet;
            label2.Location = new Point(543, 26);
            label2.Name = "label2";
            label2.Size = new Size(240, 32);
            label2.TabIndex = 2;
            label2.Text = "Detalle de Plantillas";
            // 
            // dgtablaplantillas
            // 
            dgtablaplantillas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgtablaplantillas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgtablaplantillas.Location = new Point(358, 96);
            dgtablaplantillas.Name = "dgtablaplantillas";
            dgtablaplantillas.RowTemplate.Height = 25;
            dgtablaplantillas.Size = new Size(895, 315);
            dgtablaplantillas.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 39);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "Plantilla";
            label3.Click += label3_Click;
            // 
            // txtnomplantilla
            // 
            txtnomplantilla.Location = new Point(67, 35);
            txtnomplantilla.Name = "txtnomplantilla";
            txtnomplantilla.Size = new Size(100, 23);
            txtnomplantilla.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(190, 35);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvListaPlantillas
            // 
            dgvListaPlantillas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaPlantillas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaPlantillas.Location = new Point(12, 96);
            dgvListaPlantillas.Name = "dgvListaPlantillas";
            dgvListaPlantillas.RowTemplate.Height = 25;
            dgvListaPlantillas.Size = new Size(230, 315);
            dgvListaPlantillas.TabIndex = 7;
            // 
            // Form_Mantenimiento_Plan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 450);
            Controls.Add(dgvListaPlantillas);
            Controls.Add(button1);
            Controls.Add(txtnomplantilla);
            Controls.Add(label3);
            Controls.Add(dgtablaplantillas);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "Form_Mantenimiento_Plan";
            Text = "Form_Mantenimiento_Plan";
            ((System.ComponentModel.ISupportInitialize)dgtablaplantillas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvListaPlantillas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private DataGridView dgtablaplantillas;
        private Label label3;
        private TextBox txtnomplantilla;
        private Button button1;
        private DataGridView dgvListaPlantillas;
    }
}