using PDFiumSharp;

namespace ViewPDF
{
    public partial class Form1 : Form
    {
        private PdfDocument doc = null!;
        private int selectedPage = 0;

        public Form1()
        {
            InitializeComponent();

            this.Text = "PDF Viewer";

            this.Resize += Resized;
        }

        private void Resized(object? sender, EventArgs e)
        {
            if (doc is null) return;

            this.Controls.RemoveByKey("PageViewer");
            ViewPage(selectedPage);
        }

        private void lblNoPreview_Click(object sender, EventArgs e)
        {
            this.Controls.Remove((Label)sender);

            LoadPDF();
            GenerateThumbnails();

            ViewPage(selectedPage);
        }

        private void SelectPage(object? sender, EventArgs e)
        {
            PictureBox thumbnail = (PictureBox)sender!;

            if (thumbnail.Tag.Equals(selectedPage))
            {
                var pageViewer = (PictureBox)Controls[Controls.IndexOfKey("PageViewer")];

                pageViewer.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pageViewer.Refresh();
            }
            else
            {
                this.Controls.RemoveByKey("PageViewer");
                selectedPage = (int)thumbnail.Tag;
                ViewPage(selectedPage);
            }
        }

        private void LoadPDF()
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "PDF Files|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                doc = new PdfDocument(openFileDialog.FileName);
            else
                doc = new PdfDocument("./TestPDF.pdf");
        }

        private void GenerateThumbnails()
        {
            foreach (var page in doc.Pages)
            {
                var scaledHeight = flpThumbnailView.Height - 50;
                var scaledWidth = ((int)page.Width * scaledHeight) / (int)page.Height;
                var thumbnail = new PictureBox() { Height = scaledHeight, Width = scaledWidth };
                var bitmap = new Bitmap(thumbnail.Width, thumbnail.Height);

                page.Render(bitmap);
                thumbnail.Image = bitmap;
                thumbnail.Tag = page.Index;

                thumbnail.Click += SelectPage;

                flpThumbnailView.Controls.Add(thumbnail);
            }
        }

        private void ViewPage(int index, bool rotate = false)
        {
            var pdfPage = doc.Pages[index];
            var height = this.Height - flpThumbnailView.Height - 110;
            var width = ((int)pdfPage.Width * height) / (int)pdfPage.Height;
            var pageViewer = new PictureBox() { Height = height, Width = width, Name = "PageViewer" };
            var bmp = new Bitmap(pageViewer.Width, pageViewer.Height);

            int x = (this.ClientSize.Width - pageViewer.Width) / 2;
            int y = 10;
            pageViewer.Location = new Point(x, y);

            pdfPage.Render(bmp);
            pageViewer.Image = bmp;

            this.Controls.Add(pageViewer);
        }
    }
}