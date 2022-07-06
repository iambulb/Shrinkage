using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace LG_Chem
{
    public partial class CtrlTotalData : UserControl
    {
        Setup setup = Machine._Cfg.mSetup;

        public CtrlTotalData()
        {
            InitializeComponent();
        }
        public delegate void InvokeReadCsvDele();
            
        public void ReadCsv()
        {
                
            try
            {
                if (this.InvokeRequired)
                {
                    InvokeReadCsvDele callback = ReadCsv;
                    BeginInvoke(callback);
                    return;
                }

                string strFilePath = string.Format(@"{0}\{1:00}\{2:00}\{3:00}", System.IO.Directory.GetCurrentDirectory() + "\\Csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (Directory.Exists(strFilePath) == false)
                {
                    Directory.CreateDirectory(strFilePath);
                }
                string strCsvPath = strFilePath + "\\ResultData.csv";

                List<string[]> arr = new List<string[]>();
                ArrayList ali = new ArrayList();

                DataTable dt = new DataTable();

                FileInfo fileinfo = new FileInfo(strCsvPath);
                bool boolfile = fileinfo.Exists;
                if (boolfile)
                {
                    using (StreamReader sr = new StreamReader(strCsvPath))
                    {
                        string[] headers = sr.ReadLine().Split(',');

                        //foreach (string header in headers)
                        //{
                        //    dt.Columns.Add(header);
                        //}
                        dt.Columns.Add("No");
                        dt.Columns.Add("Count");
                        dt.Columns.Add("Min (mm)");
                        dt.Columns.Add("Max (mm)");
                        dt.Columns.Add("Dev (mm)");
                        dt.Columns.Add("Avg (mm)");
                        dt.Columns.Add("수축률 (%)");

                        dt.Columns.Add("Date");


                        while (sr.Peek() != -1)
                        {
                            string strRead = sr.ReadLine();
                            if (strRead.Length > 0)
                            {
                                string[] arval = strRead.Split(',');
                                arr.Add(arval);
                            }
                        }
                        int no = 1;
                        int count = 0;
                        double min = 0;
                        double max = 0;
                        double avg = 0;
                        double arrcount = 0;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            count++;

                            if (count == setup.count)
                            {


                                min = Convert.ToDouble(arr[i][3]);
                                max = Convert.ToDouble(arr[i][3]);
                                
                                for (int j = i - (setup.count -1); j <= i; j++)
                                {
                                    double a = Convert.ToDouble(arr[j][3]);
                                    if (a == 0)
                                    {
                                        arrcount++;
                                    }
                                    if (min > Convert.ToDouble(arr[j][3]) || min == 0)
                                    {
                                        if(Convert.ToDouble(arr[j][3]) != 0)
                                        min = Convert.ToDouble(arr[j][3]);
                                    }

                                    if (max < Convert.ToDouble(arr[j][3]))
                                    {
                                        max = Convert.ToDouble(arr[j][3]);
                                    }

                                    avg += Convert.ToDouble(arr[j][3]);
                                }
                                DataRow dr = dt.NewRow();

                                dr[0] = no;
                                dr[1] = setup.count - arrcount;
                                dr[2] = min;
                                dr[3] = max;
                                dr[4] = Math.Round(max - min, 3);
                                dr[5] = Math.Round(avg / (setup.count - arrcount),3);
                                dr[6] = Math.Round(1000 * (130 - avg / (setup.count - arrcount)) /130, 3);
                                dr[7] = arr[i][4];

                                dt.Rows.Add(dr);
                                arrcount = 0;
                                count = 0;
                                avg = 0;
                                no++;
                            }

                            

                        }
                        dgvTotaldata.DataSource = dt;
                        if (dgvTotaldata.RowCount > 1)
                            dgvTotaldata.CurrentCell = dgvTotaldata.Rows[dgvTotaldata.RowCount - 1].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                //에러출력
                MessageBox.Show(ex.ToString());
            }

        }



    }
}
