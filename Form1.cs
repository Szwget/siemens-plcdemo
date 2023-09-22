using S7.Net;

namespace SiemensPLCDemo
{
    public partial class Form1 : Form
    {

        Plc plc;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            plc.Open();
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (WriteDBNoTxt.Text == null || WriteDBValue.Text == null)
            {
                MessageBox.Show("要写入的DB块或写入DB块的值不得为空");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("请先连接PLC");
                return;
            }
            int dbValue = int.Parse(WriteDBValue.Text.ToString());
            try
            {
                plc.Write(WriteDBNoTxt.Text, dbValue);

                MessageBox.Show("写入成功");
            }
            catch (Exception ex)
            {

                MessageBox.Show("糟糕,发生异常:" + ex.Message);
            }
        }

        /// <summary>
        /// 读取值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ReadDBNoTxt.Text == null)
            {
                MessageBox.Show("要读取的DB块不得为空");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("请先连接PLC");
                return;
            }
            object? v = plc.Read(ReadDBNoTxt.Text);
            if (v == null)
            {
                MessageBox.Show("读取失败");
                return;
            }
            string val = v.ToString();
            ReadDBValue.Text = val;
            MessageBox.Show("读取成功");
        }

        /// <summary>
        /// 断开PLC连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("PLC已经断开连接");
                return;
            }
            MessageBox.Show("读取成功");
        }
    }
}