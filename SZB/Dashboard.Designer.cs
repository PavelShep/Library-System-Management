namespace SZB
{
    partial class Dashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.książkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodawaćKsiążkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przeglądaćKsiążkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodaćStudentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przeglądaćStudentówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeBookDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.książkiToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.issueBooksToolStripMenuItem,
            this.returnBooksToolStripMenuItem,
            this.completeBookDetailsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // książkiToolStripMenuItem
            // 
            this.książkiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodawaćKsiążkiToolStripMenuItem,
            this.przeglądaćKsiążkiToolStripMenuItem});
            this.książkiToolStripMenuItem.Name = "książkiToolStripMenuItem";
            this.książkiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.książkiToolStripMenuItem.Text = "Książki";
            // 
            // dodawaćKsiążkiToolStripMenuItem
            // 
            this.dodawaćKsiążkiToolStripMenuItem.Name = "dodawaćKsiążkiToolStripMenuItem";
            this.dodawaćKsiążkiToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.dodawaćKsiążkiToolStripMenuItem.Text = "Dodać książku";
            this.dodawaćKsiążkiToolStripMenuItem.Click += new System.EventHandler(this.dodawaćKsiążkiToolStripMenuItem_Click);
            // 
            // przeglądaćKsiążkiToolStripMenuItem
            // 
            this.przeglądaćKsiążkiToolStripMenuItem.Name = "przeglądaćKsiążkiToolStripMenuItem";
            this.przeglądaćKsiążkiToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.przeglądaćKsiążkiToolStripMenuItem.Text = "Przeglądać książki";
            this.przeglądaćKsiążkiToolStripMenuItem.Click += new System.EventHandler(this.przeglądaćKsiążkiToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodaćStudentaToolStripMenuItem,
            this.przeglądaćStudentówToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // dodaćStudentaToolStripMenuItem
            // 
            this.dodaćStudentaToolStripMenuItem.Name = "dodaćStudentaToolStripMenuItem";
            this.dodaćStudentaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dodaćStudentaToolStripMenuItem.Text = "Dodać studenta";
            this.dodaćStudentaToolStripMenuItem.Click += new System.EventHandler(this.dodaćStudentaToolStripMenuItem_Click);
            // 
            // przeglądaćStudentówToolStripMenuItem
            // 
            this.przeglądaćStudentówToolStripMenuItem.Name = "przeglądaćStudentówToolStripMenuItem";
            this.przeglądaćStudentówToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.przeglądaćStudentówToolStripMenuItem.Text = "Przeglądać studentów";
            this.przeglądaćStudentówToolStripMenuItem.Click += new System.EventHandler(this.przeglądaćStudentówToolStripMenuItem_Click);
            // 
            // issueBooksToolStripMenuItem
            // 
            this.issueBooksToolStripMenuItem.Name = "issueBooksToolStripMenuItem";
            this.issueBooksToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.issueBooksToolStripMenuItem.Text = "Issue Books";
            this.issueBooksToolStripMenuItem.Click += new System.EventHandler(this.issueBooksToolStripMenuItem_Click);
            // 
            // returnBooksToolStripMenuItem
            // 
            this.returnBooksToolStripMenuItem.Name = "returnBooksToolStripMenuItem";
            this.returnBooksToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.returnBooksToolStripMenuItem.Text = "Return Books";
            this.returnBooksToolStripMenuItem.Click += new System.EventHandler(this.returnBooksToolStripMenuItem_Click);
            // 
            // completeBookDetailsToolStripMenuItem
            // 
            this.completeBookDetailsToolStripMenuItem.Name = "completeBookDetailsToolStripMenuItem";
            this.completeBookDetailsToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.completeBookDetailsToolStripMenuItem.Text = "Complete Book Details";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 483);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem książkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodawaćKsiążkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przeglądaćKsiążkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodaćStudentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem przeglądaćStudentówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeBookDetailsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}