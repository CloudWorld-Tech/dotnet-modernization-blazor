using System.Windows.Forms;

namespace WindowsFormsAppLegacy
{
    partial class Main
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
            this._movieGridView = new System.Windows.Forms.DataGridView();
            this._actorGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._movieGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._actorGridView)).BeginInit();
            this.SuspendLayout();

            // Movie GridView
            this._movieGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._movieGridView.Location = new System.Drawing.Point(12, 12);
            this._movieGridView.Name = "_movieGridView";
            this._movieGridView.Size = new System.Drawing.Size(776, 200);
            this._movieGridView.TabIndex = 0;
            this._movieGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MovieGridView_CellClick);

            // Actor GridView
            this._actorGridView = new System.Windows.Forms.DataGridView();
            this._actorGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._actorGridView.Location = new System.Drawing.Point(12, 230);
            this._actorGridView.Name = "_actorGridView";
            this._actorGridView.Size = new System.Drawing.Size(776, 200);
            this._actorGridView.TabIndex = 1;
            this.Controls.Add(this._actorGridView);

            // Main Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._actorGridView);
            this.Controls.Add(this._movieGridView);
            this.Name = "Main";
            this.Text = "Movie App";
            ((System.ComponentModel.ISupportInitialize)(this._movieGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._actorGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}