using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			// Initialize ListView
			this.listView1.View = View.Details;
			this.listView1.FullRowSelect = true;
			this.listView1.Font = new Font("Consolas", 10f);
			this.listView1.Columns.Add(new ColumnHeader { Text = "Name", Width = 100 });
			this.listView1.Columns.Add(new ColumnHeader { Text = "Size", Width = 80 });
			this.listView1.Columns.Add(new ColumnHeader { Text = "Date modified", Width = 150 });

			// add items
			ListViewItem lvItem1 = this.listView1.Items.Add(key: "D:\\Dropbox", text: "Dropbox", imageKey: null);
			lvItem1.SubItems.Add("100 MB");
			lvItem1.SubItems.Add("5/17/2022 3:56 PM");
			ListViewItem lvItem2 = this.listView1.Items .Add(key: "D:\\GoogleDrive", text: "GoogleDrive", imageKey: null);
			lvItem2.SubItems.Add("59 MB");
			lvItem2.SubItems.Add("5/01/2019 8:28 PM");
			ListViewItem lvItem3 = this.listView1.Items.Add(key: "D:\\aaa.txt", text: "aaa.txt", imageKey: null);
			lvItem3.SubItems.Add("15 KB");
			lvItem3.SubItems.Add("5/16/2022 12:30 PM");
			ListViewItem lvItem4 = this.listView1.Items.Add(key: "D:\\bbb.txt", text: "bbb.txt", imageKey: null);
			lvItem4.SubItems.Add("1030 KB");
			lvItem4.SubItems.Add("6/7/2022 02:00 PM");

			// drag drop
			this.listView1.AllowDrop = true;
			this.listView1.DragEnter += new DragEventHandler(ListView1_DragEnter);
			this.listView1.ItemDrag += new ItemDragEventHandler(ListView1_ItemDrag);

			this.textBox1.AllowDrop = true;
			this.textBox1.DragEnter += new DragEventHandler(TextBox1_DragEnter);
			this.textBox1.DragDrop += new DragEventHandler(TextBox1_DragDrop);
		}

		private void ListView1_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.Text))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		private void ListView1_ItemDrag(object sender, ItemDragEventArgs e) {
			string itemText = ((ListViewItem)e.Item).Name;
			DoDragDrop(itemText, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private void TextBox1_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.Text)) { 
				e.Effect = DragDropEffects.Copy;
			} else { 
				e.Effect = DragDropEffects.None;
			}
		}

		private void TextBox1_DragDrop(object sender, DragEventArgs e) {
			this.textBox1.Text += e.Data.GetData(DataFormats.Text)?.ToString() + Environment.NewLine;
		}
	}
}
