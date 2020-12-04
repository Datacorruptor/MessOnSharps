namespace ClientFormsSharps
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
      this.components = new System.ComponentModel.Container();
      this.Update = new System.Windows.Forms.Timer(this.components);
      this.TextBoxMessages = new System.Windows.Forms.TextBox();
      this.UserNameTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.MessageText = new System.Windows.Forms.TextBox();
      this.SendButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.PassWordTextBox = new System.Windows.Forms.TextBox();
      this.Emoji1 = new System.Windows.Forms.Button();
      this.Emoji2 = new System.Windows.Forms.Button();
      this.Emoji3 = new System.Windows.Forms.Button();
      this.Emoji4 = new System.Windows.Forms.Button();
      this.GoOnlineButton = new System.Windows.Forms.Button();
      this.OnlineTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // Update
      // 
      this.Update.Enabled = true;
      this.Update.Tick += new System.EventHandler(this.Update_Tick);
      // 
      // TextBoxMessages
      // 
      this.TextBoxMessages.Cursor = System.Windows.Forms.Cursors.No;
      this.TextBoxMessages.Location = new System.Drawing.Point(10, 50);
      this.TextBoxMessages.Multiline = true;
      this.TextBoxMessages.Name = "TextBoxMessages";
      this.TextBoxMessages.ReadOnly = true;
      this.TextBoxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.TextBoxMessages.Size = new System.Drawing.Size(430, 390);
      this.TextBoxMessages.TabIndex = 0;
      // 
      // UserNameTextBox
      // 
      this.UserNameTextBox.Location = new System.Drawing.Point(462, 98);
      this.UserNameTextBox.Name = "UserNameTextBox";
      this.UserNameTextBox.Size = new System.Drawing.Size(98, 20);
      this.UserNameTextBox.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(459, 82);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Username";
      // 
      // MessageText
      // 
      this.MessageText.Enabled = false;
      this.MessageText.Location = new System.Drawing.Point(10, 13);
      this.MessageText.Name = "MessageText";
      this.MessageText.Size = new System.Drawing.Size(430, 20);
      this.MessageText.TabIndex = 3;
      // 
      // SendButton
      // 
      this.SendButton.Enabled = false;
      this.SendButton.Location = new System.Drawing.Point(460, 13);
      this.SendButton.Name = "SendButton";
      this.SendButton.Size = new System.Drawing.Size(100, 21);
      this.SendButton.TabIndex = 4;
      this.SendButton.Text = "Send";
      this.SendButton.UseVisualStyleBackColor = true;
      this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(461, 137);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Password";
      // 
      // PassWordTextBox
      // 
      this.PassWordTextBox.Location = new System.Drawing.Point(464, 153);
      this.PassWordTextBox.Name = "PassWordTextBox";
      this.PassWordTextBox.PasswordChar = '*';
      this.PassWordTextBox.Size = new System.Drawing.Size(98, 20);
      this.PassWordTextBox.TabIndex = 5;
      // 
      // Emoji1
      // 
      this.Emoji1.Enabled = false;
      this.Emoji1.Location = new System.Drawing.Point(460, 50);
      this.Emoji1.Name = "Emoji1";
      this.Emoji1.Size = new System.Drawing.Size(20, 20);
      this.Emoji1.TabIndex = 7;
      this.Emoji1.Text = "🚀";
      this.Emoji1.UseVisualStyleBackColor = true;
      this.Emoji1.Click += new System.EventHandler(this.Emoji1_Click);
      // 
      // Emoji2
      // 
      this.Emoji2.Enabled = false;
      this.Emoji2.Location = new System.Drawing.Point(486, 50);
      this.Emoji2.Name = "Emoji2";
      this.Emoji2.Size = new System.Drawing.Size(20, 20);
      this.Emoji2.TabIndex = 8;
      this.Emoji2.Text = "😀";
      this.Emoji2.UseVisualStyleBackColor = true;
      this.Emoji2.Click += new System.EventHandler(this.Emoji2_Click);
      // 
      // Emoji3
      // 
      this.Emoji3.Enabled = false;
      this.Emoji3.Location = new System.Drawing.Point(512, 50);
      this.Emoji3.Name = "Emoji3";
      this.Emoji3.Size = new System.Drawing.Size(20, 20);
      this.Emoji3.TabIndex = 9;
      this.Emoji3.Text = "🤔";
      this.Emoji3.UseVisualStyleBackColor = true;
      this.Emoji3.Click += new System.EventHandler(this.Emoji3_Click);
      // 
      // Emoji4
      // 
      this.Emoji4.Enabled = false;
      this.Emoji4.Location = new System.Drawing.Point(538, 50);
      this.Emoji4.Name = "Emoji4";
      this.Emoji4.Size = new System.Drawing.Size(20, 20);
      this.Emoji4.TabIndex = 10;
      this.Emoji4.Text = "😎";
      this.Emoji4.UseVisualStyleBackColor = true;
      this.Emoji4.Click += new System.EventHandler(this.Emoji4_Click);
      // 
      // GoOnlineButton
      // 
      this.GoOnlineButton.Location = new System.Drawing.Point(464, 192);
      this.GoOnlineButton.Name = "GoOnlineButton";
      this.GoOnlineButton.Size = new System.Drawing.Size(98, 23);
      this.GoOnlineButton.TabIndex = 11;
      this.GoOnlineButton.Text = "GO ONLINE!";
      this.GoOnlineButton.UseVisualStyleBackColor = true;
      this.GoOnlineButton.Click += new System.EventHandler(this.GoOnlineButton_Click);
      // 
      // OnlineTextBox
      // 
      this.OnlineTextBox.Cursor = System.Windows.Forms.Cursors.No;
      this.OnlineTextBox.Location = new System.Drawing.Point(464, 230);
      this.OnlineTextBox.Multiline = true;
      this.OnlineTextBox.Name = "OnlineTextBox";
      this.OnlineTextBox.ReadOnly = true;
      this.OnlineTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.OnlineTextBox.Size = new System.Drawing.Size(98, 209);
      this.OnlineTextBox.TabIndex = 12;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(574, 451);
      this.Controls.Add(this.OnlineTextBox);
      this.Controls.Add(this.GoOnlineButton);
      this.Controls.Add(this.Emoji4);
      this.Controls.Add(this.Emoji3);
      this.Controls.Add(this.Emoji2);
      this.Controls.Add(this.Emoji1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.PassWordTextBox);
      this.Controls.Add(this.SendButton);
      this.Controls.Add(this.MessageText);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.UserNameTextBox);
      this.Controls.Add(this.TextBoxMessages);
      this.Name = "Form1";
      this.Text = "Messenger+";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Resize += new System.EventHandler(this.Form1_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer Update;
    private System.Windows.Forms.TextBox TextBoxMessages;
    private System.Windows.Forms.TextBox UserNameTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox MessageText;
    private System.Windows.Forms.Button SendButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox PassWordTextBox;
    private System.Windows.Forms.Button Emoji1;
    private System.Windows.Forms.Button Emoji2;
    private System.Windows.Forms.Button Emoji3;
    private System.Windows.Forms.Button Emoji4;
    private System.Windows.Forms.Button GoOnlineButton;
    private System.Windows.Forms.TextBox OnlineTextBox;
  }
}

