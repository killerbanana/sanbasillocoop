using San_Basillo_Credit_Coop_V1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace San_Basillo_Credit_Coop_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        Accounts [] accounts;

        private async void Form1_Load(object sender, EventArgs e)
        {
           string response = await GetAsync("http://localhost:5001/san-basillo-coop/us-central1/app/api/accounts/all");
            
            accounts = Accounts.FromJson(response);

            String[,] datar = new String[5, 10];

            string[] headers = { "First Name", "Middle Name", "Last Name", "Address" , "Age", "Sex", "Civil Status", "Contact Number"};
            
            DataTable _myDataTable = new DataTable();

            // create columns
            for (int i = 0; i < headers.Length; i++)
            {
                _myDataTable.Columns.Add(headers[i]);
            }

            for (int j = 0; j < accounts.Length; j++)
            {
                // create a DataRow using .NewRow()
                DataRow row = _myDataTable.NewRow();

                row[0] = accounts[j].PersonalInfo.FirstName;
                row[1] = accounts[j].PersonalInfo.MiddleName;
                row[2] = accounts[j].PersonalInfo.LastName;
                row[3] = accounts[j].PersonalInfo.Age.ToString();
                row[4] = accounts[j].PersonalInfo.Age.ToString();
                row[5] = accounts[j].PersonalInfo.Sex;
                row[6] = accounts[j].PersonalInfo.CivilStatus;
                row[7] = accounts[j].PersonalInfo.ContactNumber;
                // add the current row to the DataTable
                _myDataTable.Rows.Add(row);
            }

            guna2DataGridView1.DataSource = _myDataTable;
        }

        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
