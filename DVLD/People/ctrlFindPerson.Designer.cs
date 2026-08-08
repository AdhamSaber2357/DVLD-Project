namespace DVLD
{
    partial class ctrlFindPerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlPersonDetails1 = new DVLD.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find By ID : ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(166, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(388, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 34);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(11, 52);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(836, 340);
            this.ctrlPersonDetails1.TabIndex = 0;
            this.ctrlPersonDetails1.Load += new System.EventHandler(this.ctrlPersonDetails1_Load);
            // 
            // ctrlFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "ctrlFindPerson";
            this.Size = new System.Drawing.Size(868, 402);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}
