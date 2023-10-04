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
        /// �������һ�μ���ʱ����PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            // ����PLC
            ConnectPlc(); 
            if (plc != null && plc.IsConnected)
            {
                // �޸�PLC����״̬��ʾ
                ConnectState.Text = "������";
                ConnectState.BackColor = Color.Green;
            }
            else
            {
                ConnectState.Text = "���ӶϿ�";
                ConnectState.BackColor = Color.Red;
            }
            // �����·������߳�
            SendHeartBeatThread();
        }

        /// <summary>
        /// �����߳�,��������,����Ƿ�Ͽ���PLC������
        /// </summary>
        private void SendHeartBeatThread()
        {
            Thread th = new Thread(SendHeartBeat);
            th.Start();
        }

        /// <summary>
        /// ������������
        /// </summary>
        private void SendHeartBeat()
        {
            while (true)
            {
                // PLC����״̬Ϊ������ʱ����
                if (plc != null && plc.IsConnected)
                {
                    try
                    {
                        // �·�����
                        plc.WriteAsync("DB5.DBX0.0", 1);
                        ConnectState.BackColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        // �·������׳��쳣��˵�������Ѿ��Ͽ�
                        ConnectState.Text = "���ӶϿ�";
                        ConnectState.BackColor = Color.Red;
                        Console.WriteLine("��������PLC" + ex.Message);
                        // �ٴ�����PLC
                        ConnectPlc();
                    }
                }
                // PLC����״̬Ϊδ����ʱ����
                else if (plc != null && !plc.IsConnected)
                {
                    ConnectState.Text = "���ӶϿ�";
                    ConnectState.BackColor = Color.Red;
                    Console.WriteLine("��������PLC");
                    // �ٴ�����PLC
                    ConnectPlc();
                }
                // ����ʱ,������ʱ�೤ʱ��,������λ��Ҫ������
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// ����PLC
        /// </summary>
        public void ConnectPlc()
        {
            // ����PLC���Ӷ���, ipΪ����IP����������, rack��slot����Ĭ��ֵ0(����ֵ���Բο�������PLC����ĵ�)
            plc = new Plc(CpuType.S71200, IPTxt.Text, 0, 0);
            try
            {
                // ����PLC������
                plc.Open();
                ConnectState.Text = "������";
                ConnectState.BackColor = Color.Green;
            }
            catch (Exception)
            {
                Console.WriteLine("PLC����ʧ��");
                ConnectState.Text = "���ӶϿ�";
                ConnectState.BackColor = Color.Red;
            }

        }

        /// <summary>
        /// д��ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (WriteDBNoTxt.Text == null || WriteDBValue.Text == null)
            {
                MessageBox.Show("Ҫд���DB���д��DB���ֵ����Ϊ��");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("��������PLC");
                return;
            }
            int dbValue = int.Parse(WriteDBValue.Text.ToString());
            try
            {
                plc.Write(WriteDBNoTxt.Text, dbValue);
                MessageBox.Show("д��ɹ�");
            }
            catch (Exception ex)
            {

                MessageBox.Show("���,�����쳣:" + ex.Message);
            }
        }

        /// <summary>
        /// ��ȡֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ReadDBNoTxt.Text == null)
            {
                MessageBox.Show("Ҫ��ȡ��DB�鲻��Ϊ��");
                return;
            }
            if (plc == null || plc.IsConnected == false)
            {
                MessageBox.Show("��������PLC");
                return;
            }
            object? v = plc.Read(ReadDBNoTxt.Text);
            if (v == null)
            {
                MessageBox.Show("��ȡʧ��");
                return;
            }
            string val = v.ToString();
            ReadDBValue.Text = val;
            MessageBox.Show("��ȡ�ɹ�");
        }

    }
}