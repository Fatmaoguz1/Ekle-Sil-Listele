using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödev1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =new SqlConnection("Data Source=DESKTOP-K6LN5D6\\SQLEXPRESS;Initial Catalog=ticaret1;Integrated Security=True");
        
        void temizle()
        {
            textBoxadres.Text = "";
            textBoxtel.Text = "";
            textBox1.Text = "";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ticaret1DataSet.müşteri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.müşteriTableAdapter.Fill(this.ticaret1DataSet.müşteri);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut =new SqlCommand("insert into müşteri (Adres,Tel) values (@adres,@tel)",baglanti);
            komut.Parameters.AddWithValue("@adres", textBoxadres.Text);
            komut.Parameters.AddWithValue("@tel", textBoxtel.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("müsteri eklendi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil =new SqlCommand("Delete From müşteri where id=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1", textBox1.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update müşteri Set Adres=@p1,Tel=@p2 where id=@p3",baglanti);
            guncelle.Parameters.AddWithValue("p1",textBoxadres.Text);
            guncelle.Parameters.AddWithValue("p2", textBoxtel.Text);
            guncelle.Parameters.AddWithValue("p3", textBox1.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("güncelleme basarılı.");
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            this.müşteriTableAdapter.Fill(this.ticaret1DataSet.müşteri);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text= dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBoxadres.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBoxtel.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
