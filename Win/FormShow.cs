using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win
{
    public partial class FormShow : Form
    {
       // string msg="";
        int block;  //物理块数
        int page;   //申请页面次数
        string instructor;  //指令序列
        string[] info;
        string[] colDispatch;
        string[,] result=null;  //页面替换算法交叉矩阵
        public FormShow()
        {
            InitializeComponent();
        }

        public FormShow(string instructor,string msg,int block,int page)
        {
            InitializeComponent();
            this.block = block;
            this.page = page;
            this.instructor = instructor;
            info = msg.Split('-');
        }

        private void FormShow_Load(object sender, EventArgs e)
        {
            txtSort.Text = instructor;
            result=Dispatch();
            createTable();
            //Color();
        }

        private string[,] Dispatch()     //页面调度矩阵
        {
            string[,] result = new string[block, page];
            info[2]=info[2].Replace("\r\n","");
            colDispatch = info[2].Split('+');
            colDispatch[page]=colDispatch[page].Replace("未命中","\r\n未命中").Replace("命中率","\r\n命中率");
            int k = 0;
            for (k = 0; k < colDispatch[page].Length; k++)
            {
                if (colDispatch[page][k]=='率')
                {
                    break;
                }
            }
            string tmp = "";
            for (k=k+2; k < colDispatch[page].Length; k++)
            {
                tmp += colDispatch[page][k];
            }
            if (Convert.ToDouble(tmp)>=0.9)
            {
                colDispatch[page]+= "\r\n命中效果:优";
            }
            else if(Convert.ToDouble(tmp) >= 0.7)
            {
                colDispatch[page] += "\r\n命中效果:良好";
            }
            else if(Convert.ToDouble(tmp) >= 0.4)
            {
                colDispatch[page] += "\r\n命中效果:一般";
            }
            else if(Convert.ToDouble(tmp) >= 0.2)
            {
                colDispatch[page] += "\r\n命中效果:差";
            }
            else colDispatch[page] += "\r\n命中效果:极差";
            txtSummary.Text = colDispatch[page];

            for (int col = 0; col < page; col++)
            {
                string[] cell = colDispatch[col].Split(' ');
                for (int row = 0; row < cell.Length - 1; row++)
                {
                    if (cell[row] != "")
                    {
                        result[row, col] = cell[row];
                    }
                }
            }
            return result;
        }

        private void createTable()
        {
            string[] queue = info[0].Split(' ');
            DataTable dt = new DataTable(); //创建table对象

            dt.Columns.Add(new DataColumn("序号", typeof(string)));
            for(int col = 0; col < page; col++)
            {
                dt.Columns.Add(new DataColumn((col+1).ToString(), typeof(string)));
            }
            DataRow dr;//行
            dr = dt.NewRow();
            dr[0] = "指令页号";
            for(int col = 0; col < page; col++)
            {
                dr[col+1] = queue[col];
            }
            dt.Rows.Add(dr);


            for (int i = 1; i <= block; i++)
            {
                dr = dt.NewRow();
                dr[0] = "物理块" + i;  //第0列

                for (int j = 1; j <= page; j++)
                {
                    if (result[i - 1, j - 1] != null)
                    {
                        dr[j] = result[i - 1, j - 1];
                    }
                }

                dt.Rows.Add(dr);//在表的对象的行里添加此行
            }

            
            dgvExchange.DataSource = dt;
            dgvExchange.RowHeadersVisible = false;
            dgvExchange.Columns[0].Width = 60;
            dgvExchange.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            for(int i = 1; i <= page; i++)
            {
                dgvExchange.Columns[i].Width = 25;
                dgvExchange.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;  
            }
            dgvExchange.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvExchange.ReadOnly = true;
        }

        private void Color()
        {
            bool flag = true;
            for(int col = 1; col < page; col++)
            {
                for(int row = 0; row < block; row++)
                {
                    if (result[row, col] != result[row, col - 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    dgvExchange.Columns[col + 1].DefaultCellStyle.BackColor = System.Drawing.Color.Gold;
                }
            }
        }
    }
}
