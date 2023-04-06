using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Word;

using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;
using Document = iTextSharp.text.Document;
using NPOI.XWPF.UserModel;
using System.Windows.Forms;

namespace Prueba_pdf.Formularios.OCR
{
    public partial class Form_OCR : Form
    {
        public Form_OCR()
        {
            InitializeComponent();
        }

        private void ConvertTIFFToOCR(string filePath)
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(filePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string ocrText = page.GetText();
                        txtOCR.Text = ocrText;
                    }
                }
            }
        }

        private byte[] BitmapToByte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                return stream.ToArray();
            }
        }

        private void selectfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                ConvertTIFFToOCR(filePath);
            }
        }

        private void guardarocr_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ocrFilePath = saveFileDialog.FileName;
                string ocrText = txtOCR.Text;
                File.WriteAllText(ocrFilePath, ocrText);
            }
        }

        private void selectimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TIFF Files (*.tiff)|*.tiff|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                pbxImage.Image = image;
            }
        }

        private void btnocr_Click(object sender, EventArgs e)
        {


            Bitmap bitmap = new Bitmap(pbxImage.Image);
            using (var engine = new TesseractEngine(@"D:\tessdata\tessdata-main", "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromMemory(BitmapToByte(bitmap)))
                {
                    using (var page = engine.Process(img))
                    {
                        string ocrText = page.GetText();
                        txtOCR.Text = ocrText;
                    }
                }
            }
        }



        private void btnword_Click(object sender, EventArgs e)
        {
            // Crea un diálogo para seleccionar la ruta de guardado
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Word (*.docx)|*.docx";
            saveFileDialog.Title = "Guardar como";

            // Si el usuario selecciona una ruta y presiona "Guardar"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtiene la ruta seleccionada
                string rutaArchivo = saveFileDialog.FileName;

                // Crea un nuevo documento de Word
                XWPFDocument document = new XWPFDocument();

                // Agrega un párrafo con el texto
                XWPFParagraph paragraph = document.CreateParagraph();
                XWPFRun run = paragraph.CreateRun();
                run.SetText(txtOCR.Text);

                // Guarda el documento
                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
                {
                    document.Write(stream);
                }

                MessageBox.Show("Archivo guardado correctamente.");
            }


        }
    }
}
