using System;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
	public partial class Form1 : Form {

		/// <summary>
		/// Drag Drop Files To TextBox
		/// </summary>
		public Form1() {
			InitializeComponent();
			
			// must have
			this.textBox1.AllowDrop = true;
			// events
			this.textBox1.DragEnter += new DragEventHandler(TextBox1_DragEnter);
			this.textBox1.DragDrop += new DragEventHandler(TextBox1_DragDrop);
		}

		private void TextBox1_DragEnter(object sender, DragEventArgs e) {
			// cursor changed to + sign, if files are dragged
			// otherwise, forbid sign
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.All;
			} else {
				e.Effect = DragDropEffects.None;
			}
		}

		private void TextBox1_DragDrop(object sender, DragEventArgs e) {
			string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			string fileNamesJoined = string.Join(Environment.NewLine, fileNames);
			this.textBox1.Text = fileNamesJoined;
		}
	}
}
