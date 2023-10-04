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
        /// 当窗体第一次加载时连接PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            Thread tr = new Thread(ConnectPlc);
            tr.Start();
            if (plc != null && plc.IsConnected)
            {
                ConnectState.Text = "已连接";
                ConnectState.BackColor = Color.Green;
            }
            else
            {
                ConnectState.BackColor = Color.Red;
            }
            SendHeartBeatThread();
        }

        /// <summary>
        /// 向PLC发送心跳,检测是否断开与PLC的连接
        /// </summary>
        private void SendHeartBeatThread()
        {
            Thread heartBeat = new Thread(SendHeartBeatThread);
            heartBeat.Start();
            if (plc != null && plc.IsConnected)
            {
                try
                {
                    plc.WriteAsync("DB5.DBX0.0", 1);
                    ConnectState.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    ConnectState.BackColor = Color.Red;
                    Console.WriteLine("重新连接PLC" + ex.Message);
                    ConnectPlc();
                }
            }
            else if (plc != null && !plc.IsConnected)
            {
                ConnectState.BackColor = Color.Red;
                Console.WriteLine("重新连接PLC");
                ConnectPlc();
            }
        }
        /// <summary>
        /// 连接PLC
        /// </summary>
        public void ConnectPlc()
        {
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            try
            {
                plc.Open();
                ConnectState.Text = "已连接";
                ConnectState.BackColor = Color.Green;
            }
            catch (Exception)
            {
                Console.WriteLine("PLC连接失败");
            }

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

    }
}