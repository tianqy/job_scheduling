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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int MAX_INSTRUCTION =320;                          //指令总数
        static int MAX_PAGE =32;                                  //总页数
        static int[] instructions_order = new int[MAX_INSTRUCTION];      //指令数组
        static int[] page_order = new int[MAX_INSTRUCTION];     //页面数组
        static int MAX_BLOCK ;                                 //物理块总数
        static int clear_period = 10;                           //清零周期      
        string instructor = "";

        public void ShowText(string msg)                      //显示结果文本框
        {
            TextForm f1 = new TextForm(msg);
            f1.Show();
        }

        public void FormShow(string instructor, string msg,int block,int page)
        {
            FormShow fs = new FormShow(instructor,msg,block,page);
            fs.Show();
        }

        public string Create_Order(string msg)                //生成随机指令序列
        {
            Random r = new Random();
            int m = r.Next(0, MAX_INSTRUCTION - 2);                //生成m为0到最大数之间的随机数
            int m1 = m;
            for (int i = 0; i < MAX_INSTRUCTION; )
            {
                instructions_order[i++] = m1 + 1;                     //执行m1
                m1 = r.Next(0, m + 1);
                instructions_order[i++] = m1;
                instructions_order[i++] = m1 + 1;
                m1 = r.Next(m + 1, MAX_INSTRUCTION - 2);
                instructions_order[i++] = m1;
            }
            instructor = "";
            //将指令序列转换为页面序列
            for (int i = 0; i < MAX_INSTRUCTION; i++)
            {
                page_order[i] = instructions_order[i] / 10;             //除以10
                msg = msg + page_order[i] + " ";
                instructor += instructions_order[i] + " ";
            }
            return msg;
        }

        private void txt_instructions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_instructions.Text != "")
                {
                    MAX_INSTRUCTION = int.Parse(txt_instructions.Text);                     //获取指令总数
                    int x = MAX_INSTRUCTION;
                    MAX_PAGE = MAX_INSTRUCTION / 10;
                    if (txt_block.Text != "")
                    {
                        btnStart.Visible = true;
                    }
                    else btnStart.Visible = false;
                }
                else btnStart.Visible = false;
            }
            catch
            {
                txt_instructions.Text = null;
                MessageBox.Show("请输入整数！");
                btnStart.Visible = false;
            }
        }

        private void txt_block_TextChanged(object sender, EventArgs e)
        {
            try {
                if (txt_block.Text != "")
                {
                    MAX_BLOCK = int.Parse(txt_block.Text);                   //获取物理块数
                    if (txt_instructions.Text != "")
                    {
                        btnStart.Visible = true;
                    }
                    else btnStart.Visible = false;
                }
                else btnStart.Visible = false;
            }
            catch
            {
                txt_block.Text = null;
                MessageBox.Show("请输入整数");
                btnStart.Visible = false;
            }
        }

        private void FIFO()
        {
            string msg = "";
           // string msg = "指令序列:\r\n";                        //用来保存输出信息
            msg=Create_Order(msg);                          //生成随机序列
            //msg = msg + "-\r\n" + "页面调度:";
            msg = msg + "-\r\n" + "页面调度:-";
            List<Block> block_list = new List<Block>();  //block数组
            int shot_num = 0;                         //命中个数
            int unshot_num = 0;                      //未命中个数
            for (int i = 0; i < MAX_INSTRUCTION; i++)               //遍历指令序列里每一个序列
            {
                Block temp_block = new Block(page_order[i]);        //将页数赋值给临时存储块
                bool flag = false;
                for (int j = 0; j < block_list.Count; j++)           //判断是否命中
                {
                    if (block_list[j].Equals(temp_block))
                    {
                        flag = true;
                    }
                }
                //bool flag = block_list.Contains(temp_block);        //查找是否有temp_block
                if (flag == true)                  //如果找到该块,即命中
                {
                    shot_num++;
                }
                else                              //未命中
                {
                    unshot_num++;
                    //将该块添加进去
                    if (block_list.Count < MAX_BLOCK)           //如果页面未满
                    {
                        block_list.Insert(0, temp_block);            //因为是先进先出,所以将新元素插入到第一个位置 
                    }
                    else                                      //如果页面已满
                    {
                        block_list.RemoveAt(MAX_BLOCK - 1);          //移除最前面的块数
                        block_list.Insert(0, temp_block);
                    }
                }
                msg = msg + "\r\n";
                for (int j = 0; j < block_list.Count; j++)
                {
                    msg = msg + block_list[j].get_page() + " ";
                }
                msg += "+";
            }

            msg = msg + "\r\n" + "命中次数:" + shot_num + "\r\n" + "未命中次数:" + unshot_num + "\r\n" + "命中率:" + shot_num * 1.0 / MAX_INSTRUCTION;
            FormShow(instructor,msg,MAX_BLOCK,MAX_INSTRUCTION);
        }

        private void LRU()
        {
            string msg = "";
           // string msg = "指令序列:\r\n";                        //用来保存输出信息
            msg = Create_Order(msg);                          //生成随机序列
            msg = msg + "-\r\n" + "页面调度:-";
            List<Block> block_list = new List<Block>();  //block数组
            int shot_num = 0;                         //命中个数
            int unshot_num = 0;                      //未命中个数
            for (int i = 0; i < MAX_INSTRUCTION; i++)               //遍历指令序列里每一个序列
            {
                Block temp_block = new Block(page_order[i]);        //将页数赋值给临时存储块
                bool flag = false;
                for (int j = 0; j < block_list.Count; j++)           //判断是否命中
                {
                    if (block_list[j].Equals(temp_block))
                    {
                        flag = true;
                        //此处与FIFO不同,若命中,也需变动
                        block_list.RemoveAt(j);
                        block_list.Insert(0, temp_block);
                        break;
                    }
                }
                //              bool flag = block_list.Contains(temp_block);              //查找是否有temp_block
                if (flag == true)                  //如果找到该块,即命中
                {
                    shot_num++;
                }
                else                              //未命中
                {
                    unshot_num++;
                    //将该块添加进去
                    if (block_list.Count < MAX_BLOCK)           //如果页面未满
                    {
                        block_list.Insert(0, temp_block);            //因为是最近最少使用算法,所以将新元素插入到第一个位置 
                    }
                    else                                      //如果页面已满
                    {
                        block_list.RemoveAt(MAX_BLOCK - 1);          //移除最前面的块数
                        block_list.Insert(0, temp_block);
                    }
                }
            //    System.Console.WriteLine();
                msg = msg + "\r\n";
                for (int j = 0; j < block_list.Count; j++)
                {
              //      System.Console.Write(block_list[j].get_page() + " ");
                    msg = msg + block_list[j].get_page() + " ";
                }
                msg += "+";
            }
            msg = msg + "\r\n" + "命中次数:" + shot_num + "\r\n" + "未命中次数:" + unshot_num + "\r\n" + "命中率:" + shot_num * 1.0 / MAX_INSTRUCTION;
           // ShowText(msg);
            FormShow(instructor,msg,MAX_BLOCK, MAX_INSTRUCTION);
            //    System.Console.WriteLine("shot_num="+shot_num+" unshot_num="+unshot_num);
        }

        private void LFU()
        {
            string msg = "";
           // string msg = "指令序列:\r\n";                        //用来保存输出信息
            msg = Create_Order(msg);                          //生成随机序列
            msg = msg + "-\r\n" + "页面调度:-";
            List<Block> block_list = new List<Block>();  //block数组
            int shot_num = 0;                         //命中个数
            int unshot_num = 0;                      //未命中个数
            for (int i = 0; i < MAX_INSTRUCTION; i++)               //遍历指令序列里每一个序列
            {
                Block temp_block = new Block(page_order[i], 0);        //将页数赋值给临时存储块
                bool flag = false;
                for (int j = 0; j < block_list.Count; j++)           //判断是否命中
                {
                    if (block_list[j].Equals(temp_block))
                    {
                        flag = true;
                        block_list[j].add_count();                   //将它的计数器加1
                    }
                }
                //              bool flag = block_list.Contains(temp_block);              //查找是否有temp_block
                if (flag == true)                  //如果找到该块,即命中
                {
                    shot_num++;
                }
                else                              //未命中
                {
                    unshot_num++;
                    //将该块添加进去
                    //因为是最少使用算法,所以寻找最少的块
                    int min = 9999;
                    int min_index = 0;
                    for (int j = 0; j < block_list.Count; j++)
                    {
                        if (min > block_list[j].get_count())
                        {
                            min = block_list[j].get_count();
                            min_index = j;
                        }
                    }

                    if (block_list.Count < MAX_BLOCK)           //如果页面未满
                    {
                        block_list.Add(temp_block);            //直接添加进去
                    }
                    else                                      //如果页面已满
                    {
                        block_list.RemoveAt(min_index);          //移除最少的块数
                        block_list.Add(temp_block);              //添加新块
                    }
                }
                msg = msg + "\r\n";
                for (int j = 0; j < block_list.Count; j++)
                {
                    //  System.Console.Write(block_list[j].get_page() + " ");
                    msg = msg + block_list[j].get_page() + " ";
                }
                msg += "+";
            }
            msg = msg + "\r\n" + "命中次数:" + shot_num + "\r\n" + "未命中次数:" + unshot_num + "\r\n" + "命中率:" + shot_num * 1.0 / MAX_INSTRUCTION;
           // ShowText(msg);
            FormShow(instructor,msg,MAX_BLOCK, MAX_INSTRUCTION);
        }

        private void NUR()
        {
            string msg = "";
           // string msg = "指令序列:\r\n";                        //用来保存输出信息
            msg = Create_Order(msg);                          //生成随机序列
            msg = msg + "-\r\n" + "页面调度:-";
            List<Block> block_list = new List<Block>();  //block数组
            int shot_num = 0;                         //命中个数
            int unshot_num = 0;                      //未命中个数
            for (int i = 0; i < MAX_INSTRUCTION; i++)               //遍历指令序列里每一个序列
            {
                Block temp_block = new Block(page_order[i], 1);        //将页数赋值给临时存储块
                bool flag = false;
                for (int j = 0; j < block_list.Count; j++)           //判断是否命中
                {
                    if (block_list[j].Equals(temp_block))
                    {
                        flag = true;
                        block_list[j].add_count();                   //将它的计数器加1
                    }
                }
                //              bool flag = block_list.Contains(temp_block);              //查找是否有temp_block
                if (flag == true)                  //如果找到该块,即命中
                {
                    shot_num++;
                }
                else                              //未命中
                {
                    unshot_num++;
                    //将该块添加进去
                    //因为是最少使用算法,所以寻找最少的块
                    int min = 9999;
                    int min_index = 0;
                    for (int j = 0; j < block_list.Count; j++)
                    {
                        if (min > block_list[j].get_count())
                        {
                            min = block_list[j].get_count();
                            min_index = j;
                        }
                    }

                    if (block_list.Count < MAX_BLOCK)           //如果页面未满
                    {
                        block_list.Add(temp_block);            //直接添加进去
                    }
                    else                                      //如果页面已满
                    {
                        block_list.RemoveAt(min_index);          //移除最少的块数
                        block_list.Add(temp_block);              //添加新块
                    }
                }
                //定时清零
                if (i % clear_period == 0 && i != 0)
                {
              //      System.Console.WriteLine("\n计数器清零");
                    msg = msg + "\r\n计数器清零";
                    for (int j = 0; j < block_list.Count; j++)
                    {
                        block_list[j].clear_count();                        //全部清零
                    }
                }

                msg = msg + "\r\n";
                for (int j = 0; j < block_list.Count; j++)
                {
                    //  System.Console.Write(block_list[j].get_page() + " ");
                    msg = msg + block_list[j].get_page() + " ";
                }
                msg += "+";
            }
            msg = msg + "\r\n" + "命中次数:" + shot_num + "\r\n" + "未命中次数:" + unshot_num + "\r\n" + "命中率:" + shot_num * 1.0 / MAX_INSTRUCTION;
           // ShowText(msg);
            FormShow(instructor,msg,MAX_BLOCK, MAX_INSTRUCTION);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            switch (cbb_Algo.SelectedIndex)
            {
                case 0:         
                    {
                        FIFO();
                        break;
                    }
                case 1:
                    {
                        LRU();
                        break;
                    }
                case 2:
                    {
                        LFU();
                        break;
                    }
                case 3:
                    {
                        NUR();
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbb_Algo.SelectedIndex = 0;
            btnStart.Visible = false;
            txt_block.Text = "";
            txt_instructions.Text = "";
        }
    }
}
