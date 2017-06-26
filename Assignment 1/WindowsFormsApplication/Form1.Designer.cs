namespace WindowsFormsApplication
{
    partial class Form1
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
            this.ageLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.yearsInUSTextBox = new System.Windows.Forms.TextBox();
            this.yearsInUSLabel = new System.Windows.Forms.Label();
            this.citizenCheckBox = new System.Windows.Forms.CheckBox();
            this.determineEligibilityButton = new System.Windows.Forms.Button();
            this.eligibleLabel = new System.Windows.Forms.Label();
            this.priorTermsLabel = new System.Windows.Forms.Label();
            this.priorTermsTextBox = new System.Windows.Forms.TextBox();
            this.rebelledUSCheckBox = new System.Windows.Forms.CheckBox();
            this.validLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(9, 61);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(131, 20);
            this.ageLabel.TabIndex = 0;
            this.ageLabel.Text = "How old are you?";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(329, 55);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(100, 26);
            this.ageTextBox.TabIndex = 1;
            // 
            // yearsInUSTextBox
            // 
            this.yearsInUSTextBox.Location = new System.Drawing.Point(329, 98);
            this.yearsInUSTextBox.Name = "yearsInUSTextBox";
            this.yearsInUSTextBox.Size = new System.Drawing.Size(100, 26);
            this.yearsInUSTextBox.TabIndex = 2;
            // 
            // yearsInUSLabel
            // 
            this.yearsInUSLabel.AutoSize = true;
            this.yearsInUSLabel.Location = new System.Drawing.Point(9, 101);
            this.yearsInUSLabel.Name = "yearsInUSLabel";
            this.yearsInUSLabel.Size = new System.Drawing.Size(309, 20);
            this.yearsInUSLabel.TabIndex = 3;
            this.yearsInUSLabel.Text = "How many years were you living in the US?";
            // 
            // citizenCheckBox
            // 
            this.citizenCheckBox.AutoSize = true;
            this.citizenCheckBox.Location = new System.Drawing.Point(13, 23);
            this.citizenCheckBox.Name = "citizenCheckBox";
            this.citizenCheckBox.Size = new System.Drawing.Size(203, 24);
            this.citizenCheckBox.TabIndex = 4;
            this.citizenCheckBox.Text = "Natural Born US Citizen";
            this.citizenCheckBox.UseVisualStyleBackColor = true;
            // 
            // determineEligibilityButton
            // 
            this.determineEligibilityButton.Location = new System.Drawing.Point(152, 239);
            this.determineEligibilityButton.Name = "determineEligibilityButton";
            this.determineEligibilityButton.Size = new System.Drawing.Size(137, 57);
            this.determineEligibilityButton.TabIndex = 5;
            this.determineEligibilityButton.Text = "Determine Eligibility";
            this.determineEligibilityButton.UseVisualStyleBackColor = true;
            this.determineEligibilityButton.Click += new System.EventHandler(this.determineEligibilityButton_Click_1);
            // 
            // eligibleLabel
            // 
            this.eligibleLabel.AutoSize = true;
            this.eligibleLabel.Location = new System.Drawing.Point(15, 326);
            this.eligibleLabel.Name = "eligibleLabel";
            this.eligibleLabel.Size = new System.Drawing.Size(17, 20);
            this.eligibleLabel.TabIndex = 6;
            this.eligibleLabel.Text = "  ";
            // 
            // priorTermsLabel
            // 
            this.priorTermsLabel.AutoSize = true;
            this.priorTermsLabel.Location = new System.Drawing.Point(9, 141);
            this.priorTermsLabel.Name = "priorTermsLabel";
            this.priorTermsLabel.Size = new System.Drawing.Size(289, 20);
            this.priorTermsLabel.TabIndex = 7;
            this.priorTermsLabel.Text = "How many prior terms have you served?";
            // 
            // priorTermsTextBox
            // 
            this.priorTermsTextBox.Location = new System.Drawing.Point(329, 141);
            this.priorTermsTextBox.Name = "priorTermsTextBox";
            this.priorTermsTextBox.Size = new System.Drawing.Size(100, 26);
            this.priorTermsTextBox.TabIndex = 8;
            // 
            // rebelledUSCheckBox
            // 
            this.rebelledUSCheckBox.AutoSize = true;
            this.rebelledUSCheckBox.Location = new System.Drawing.Point(13, 183);
            this.rebelledUSCheckBox.Name = "rebelledUSCheckBox";
            this.rebelledUSCheckBox.Size = new System.Drawing.Size(248, 24);
            this.rebelledUSCheckBox.TabIndex = 9;
            this.rebelledUSCheckBox.Text = "I have rebelled against the US";
            this.rebelledUSCheckBox.UseVisualStyleBackColor = true;
            // 
            // validLabel
            // 
            this.validLabel.AutoSize = true;
            this.validLabel.Location = new System.Drawing.Point(15, 377);
            this.validLabel.Name = "validLabel";
            this.validLabel.Size = new System.Drawing.Size(17, 20);
            this.validLabel.TabIndex = 10;
            this.validLabel.Text = "  ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 432);
            this.Controls.Add(this.validLabel);
            this.Controls.Add(this.rebelledUSCheckBox);
            this.Controls.Add(this.priorTermsTextBox);
            this.Controls.Add(this.priorTermsLabel);
            this.Controls.Add(this.eligibleLabel);
            this.Controls.Add(this.determineEligibilityButton);
            this.Controls.Add(this.citizenCheckBox);
            this.Controls.Add(this.yearsInUSLabel);
            this.Controls.Add(this.yearsInUSTextBox);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.ageLabel);
            this.Name = "Form1";
            this.Text = "US Presidential Eligibility Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.TextBox yearsInUSTextBox;
        private System.Windows.Forms.Label yearsInUSLabel;
        private System.Windows.Forms.CheckBox citizenCheckBox;
        private System.Windows.Forms.Button determineEligibilityButton;
        private System.Windows.Forms.Label eligibleLabel;
        private System.Windows.Forms.Label priorTermsLabel;
        private System.Windows.Forms.TextBox priorTermsTextBox;
        private System.Windows.Forms.CheckBox rebelledUSCheckBox;
        private System.Windows.Forms.Label validLabel;
    }
}

