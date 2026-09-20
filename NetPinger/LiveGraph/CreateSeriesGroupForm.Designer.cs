namespace LiveGraph
{
	partial class CreateSeriesGroupForm
	{
		 
		 
		 
		private System.ComponentModel.IContainer components = null;

		 
		 
		 
		 
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		 
		 
		 
		 
		private void InitializeComponent()
		{
			this._btnOK = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._txtGroupName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			 
			 
			 
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOK.Location = new System.Drawing.Point(173, 38);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(75, 23);
			this._btnOK.TabIndex = 2;
			this._btnOK.Text = "OK";
			this._btnOK.UseVisualStyleBackColor = true;
			 
			 
			 
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(254, 38);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 3;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			 
			 
			 
			this._txtGroupName.Location = new System.Drawing.Point(88, 12);
			this._txtGroupName.Name = "_txtGroupName";
			this._txtGroupName.Size = new System.Drawing.Size(241, 20);
			this._txtGroupName.TabIndex = 1;
			 
			 
			 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Group &Name:";
			 
			 
			 
			this.AcceptButton = this._btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(341, 74);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._txtGroupName);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateSeriesGroupForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "MASA - Create New Group";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.TextBox _txtGroupName;
		private System.Windows.Forms.Label label1;
	}
}