namespace LG_Chem
{
    partial class FormErrorInfomation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErrorInfomation));
            this.rtbErrInfoMsg = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbErrInfoMsg
            // 
            this.rtbErrInfoMsg.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rtbErrInfoMsg.Location = new System.Drawing.Point(12, 12);
            this.rtbErrInfoMsg.Name = "rtbErrInfoMsg";
            this.rtbErrInfoMsg.Size = new System.Drawing.Size(271, 52);
            this.rtbErrInfoMsg.TabIndex = 3;
            this.rtbErrInfoMsg.Text = "이미지 또는 시편을 확인해주세요";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SlateBlue;
            this.btnClose.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnClose.Location = new System.Drawing.Point(94, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 42);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormErrorInfomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(298, 119);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rtbErrInfoMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormErrorInfomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error Infomation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbErrInfoMsg;
        private System.Windows.Forms.Button btnClose;
    }
}