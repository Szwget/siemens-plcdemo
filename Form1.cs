using S7.Net;

namespace SiemensPLCDemo
{
    public partial class Form1 : Form
    {

        Plc? plc;

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
            // 连接PLC
            ConnectPlc(); 
            if (plc != null && plc.IsConnected)
            {
                // 修改PLC连接状态显示
                ConnectState.Text = "已连接";
                ConnectState.BackColor = Color.Green;
            }
            else
            {
                ConnectState.Text = "连接断开";
                ConnectState.BackColor = Color.Red;
            }
            // 开启下发心跳线程
            SendHeartBeatThread();
        }

        /// <summary>
        /// 开启线程,发送心跳,检测是否断开与PLC的连接
        /// </summary>
        private void SendHeartBeatThread()
        {
            Thread th = new Thread(SendHeartBeat);
            th.Start();
        }

        /// <summary>
        /// 发送心跳数据
        /// </summary>
        private void SendHeartBeat()
        {
            while (true)
            {
                // PLC连接状态为已连接时进入
                if (plc != null && plc.IsConnected)
                {
                    try
                    {
                        // 下发心跳
                        plc.WriteAsync("DB5.DBX0.0", 1);
                        this.Invoke(() => {
                            ConnectState.BackColor = Color.Green;
                            ConnectState.Text = "已连接";
                        });
                    }
                    catch (Exception ex)
                    {
                        // 下发心跳抛出异常，说明连接已经断开
                        this.Invoke(() => {
                            ConnectState.Text = "连接断开";
                            ConnectState.BackColor = Color.Red;
                        });
                        Console.WriteLine("重新连接PLC" + ex.Message);
                        // 再次连接PLC
                        ConnectPlc();
                    }
                }
                // PLC连接状态为未连接时进入
                else if (plc != null && !plc.IsConnected)
                {
                    this.Invoke(() => {
                        ConnectState.Text = "连接断开";
                        ConnectState.BackColor = Color.Red;
                    });
                    Console.WriteLine("重新连接PLC");
                    // 再次连接PLC
                    ConnectPlc();
                }
                // 加延时,具体延时多长时间,根据下位机要求来做
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// 连接PLC
        /// </summary>
        public void ConnectPlc()
        {
            // 创建PLC连接对象, ip为界面IP输入框的内容, rack和slot采用默认值0(具体值可以参考西门子PLC相关文档)
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            try
            {
                // 打开与PLC的连接
                plc.Open();
                ConnectState.Text = "已连接";
                ConnectState.BackColor = Color.Green;
            }
            catch (Exception)
            {
                Console.WriteLine("PLC连接失败");
                ConnectState.Text = "连接断开";
                ConnectState.BackColor = Color.Red;
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