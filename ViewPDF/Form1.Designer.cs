namespace ViewPDF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpThumbnailView = new FlowLayoutPanel();
            lblNoPreview = new Label();
            SuspendLayout();
            // 
            // flpThumbnailView
            // 
            flpThumbnailView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpThumbnailView.AutoScroll = true;
            flpThumbnailView.BorderStyle = BorderStyle.FixedSingle;
            flpThumbnailView.Location = new Point(12, 672);
            flpThumbnailView.Name = "flpThumbnailView";
            flpThumbnailView.Size = new Size(1318, 275);
            flpThumbnailView.TabIndex = 2;
            flpThumbnailView.WrapContents = false;
            // 
            // lblNoPreview
            // 
            lblNoPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNoPreview.AutoSize = true;
            lblNoPreview.Font = new Font("Segoe UI", 29F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoPreview.Location = new Point(311, 264);
            lblNoPreview.Name = "lblNoPreview";
            lblNoPreview.Size = new Size(646, 104);
            lblNoPreview.TabIndex = 0;
            lblNoPreview.Text = "Click to Load PDF";
            lblNoPreview.Click += lblNoPreview_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1342, 952);
            Controls.Add(lblNoPreview);
            Controls.Add(flpThumbnailView);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flpThumbnailView;
        private Label lblNoPreview;
    }
}