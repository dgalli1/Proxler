using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{

    public partial class FrmHoster : Form
    {
        private List<String> hosterPriority = new List<string>();

        public List<string> HosterPriority { get => hosterPriority; set => hosterPriority = value; }

        public FrmHoster(List<String> HosterPriority)
        {
            this.HosterPriority = HosterPriority;
            InitializeComponent();
            listView1.MultiSelect = false;
            listView1.ListViewItemSorter = new ListViewIndexComparer();
            ImageList imageList1 = new ImageList();
            imageList1.Images.Add("hellsmedia", Properties.Resources.hellsmedia);
            imageList1.Images.Add("mp4upload", Properties.Resources.mp4upload);
            imageList1.Images.Add("myvi", Properties.Resources.myvi);
            imageList1.Images.Add("novamov", Properties.Resources.novamov);
            imageList1.Images.Add("Openload", Properties.Resources.openload);
            imageList1.Images.Add("proxer-stream", Properties.Resources.proxer_stream);
            imageList1.Images.Add("rutube", Properties.Resources.rutube);
            imageList1.Images.Add("streamcloud", Properties.Resources.streamcloud);
            imageList1.Images.Add("videoweed", Properties.Resources.videoweed);
            imageList1.Images.Add("yourupload", Properties.Resources.yourupload);

            listView1.LargeImageList = imageList1;


            foreach (String item in HosterPriority)
            {
                if (item == "hellsmedia")
                {
                    this.listView1.Items.Add(new ListViewItem("hellsmedia", 0));
                }
                if (item == "myvi")
                {
                    this.listView1.Items.Add(new ListViewItem("myvi", 2));

                }
                if(item == "mp4upload")
                {
                    this.listView1.Items.Add(new ListViewItem("mp4upload", 1));
                }
                if(item == "novamov")
                {
                    this.listView1.Items.Add(new ListViewItem("novamov", 3));

                }
                if (item == "openload")
                {
                    this.listView1.Items.Add(new ListViewItem("openload", 4));

                }
                if (item == "proxer-stream")
                {
                    this.listView1.Items.Add(new ListViewItem("proxer-stream", 5));

                }
                if (item == "rutube")
                {
                    this.listView1.Items.Add(new ListViewItem("rutube", 6));

                }
                if(item == "streamcloud")
                {
                    this.listView1.Items.Add(new ListViewItem("streamcloud", 7));

                }
                if(item == "videoweed")
                {
                    this.listView1.Items.Add(new ListViewItem("videoweed", 8));

                }
                if(item == "yourupload")
                {
                    this.listView1.Items.Add(new ListViewItem("yourupload", 9));

                }

            }

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

            private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            int targetIndex = listView1.InsertionMark.Index;
            if (targetIndex == -1)
            {
                return;
            }

            if (listView1.InsertionMark.AppearsAfterItem)
            {
                targetIndex++;
            }

            ListViewItem draggedItem =
                (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            listView1.Items.Insert(
                targetIndex, (ListViewItem)draggedItem.Clone());

            listView1.Items.Remove(draggedItem);
        }



        private void listView1_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint =
                listView1.PointToClient(new Point(e.X, e.Y));
            int targetIndex = listView1.InsertionMark.NearestIndex(targetPoint);
            if (targetIndex > -1)
            {
                Rectangle itemBounds = listView1.GetItemRect(targetIndex);
                if (targetPoint.X > itemBounds.Left + (itemBounds.Width / 2))
                {
                    listView1.InsertionMark.AppearsAfterItem = true;
                }
                else
                {
                    listView1.InsertionMark.AppearsAfterItem = false;
                }
            }

            listView1.InsertionMark.Index = targetIndex;
        }
        private class ListViewIndexComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
            }
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            listView1.InsertionMark.Index = -1;
        }

        private void FrmHoster_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            hosterPriority.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                HosterPriority.Add(item.Text);
            }
            this.Close();
        }
    }

}
