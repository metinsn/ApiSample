using Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int id;
        private void GetirBtn_Click(object sender, EventArgs e)
        {
            Get();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (btnEkle.Text == "Ekle")
            {
                using (var client = new HttpClient())
                {
                    var data = new
                    {
                        FirstName = txtAd.Text,
                        LastName = txtSoyad.Text
                    };

                    client.BaseAddress = new Uri("https://bgapitest.azurewebsites.net");
                    var response = client.PostAsJsonAsync("/api/user", data);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bir hata oluştu.");
                    }
                }
            }
            else if (btnEkle.Text == "Güncelle")
            {
                using (var client = new HttpClient())
                {
                    var data = new
                    {
                        FirstName = txtAd.Text,
                        LastName = txtSoyad.Text
                    };

                    client.BaseAddress = new Uri("https://bgapitest.azurewebsites.net");
                    var response = client.PutAsJsonAsync("/api/user/" + id, data);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Bir hata oluştu.");
                    }
                }
            }

            ClearAll();

            Get();
        }

        public void Get()
        {
            dataGridView1.DataSource = null;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://bgapitest.azurewebsites.net/api/user");

                var result = JsonConvert.DeserializeObject<List<User>>(response.Result.Content.ReadAsStringAsync().Result);

                dataGridView1.DataSource = result;
            }
        }

        public void ClearAll()
        {
            txtSoyad.Clear();
            txtAd.Clear();
            btnEkle.Text = "Ekle";
            id = 0;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://bgapitest.azurewebsites.net");
                var response = client.DeleteAsync("/api/user/" + id);

                if (response.Result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silindi.");
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu.");
                }
            }

            Get();
            ClearAll();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            btnEkle.Text = "Güncelle";
        }
    }
}
