using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MQTTnet;
using MQTTnet.Client;
using Accord.Video;
using Accord.Video.DirectShow;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Accord.IO;
using Accord.Imaging;
using Accord.Controls;

namespace SampleApp
{
    public partial class MainForm : Form
    {
        private Stopwatch stopWatch = null;
        IMqttClient mqttClient;
        string videoStreamUrl;

        // Class constructor
        public MainForm()
        {
            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new KeyEventHandler(this.MainForm_KeyUp);
            InitializeComponent();
        }
        Keys keyy = Keys.None;
        private async void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("dur")
                    .Build();
            switch (e.KeyCode)
            {
                case Keys.W:
                    await mqttClient.PublishAsync(apm, CancellationToken.None);
                    break;
                case Keys.A:
                    await mqttClient.PublishAsync(apm, CancellationToken.None);
                    break;
                case Keys.S:
                    await mqttClient.PublishAsync(apm, CancellationToken.None);
                    break;
                case Keys.D:
                    await mqttClient.PublishAsync(apm, CancellationToken.None);
                    break;
            }
            keyy = Keys.None;
        }

        private async void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {


                case Keys.W:
                    if (keyy != e.KeyCode)
                    {
                        var ileri = new MqttApplicationMessageBuilder()
                        .WithTopic("robot/device1/com")
                        .WithPayload("ileri")
                        .Build();
                        await mqttClient.PublishAsync(ileri, CancellationToken.None);
                        //label2.Invoke(new Action(() => { label2.Text = "ileri"; }));
                        keyy = e.KeyCode;
                    }

                    break;
                case Keys.A:
                    if (keyy != e.KeyCode)
                    {
                        var sol = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("sol")
                    .Build();
                        await mqttClient.PublishAsync(sol, CancellationToken.None);
                        keyy = e.KeyCode;
                    }
                    break;
                case Keys.S:
                    if (keyy != e.KeyCode)
                    {
                        var geri = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("geri")
                    .Build();
                        await mqttClient.PublishAsync(geri, CancellationToken.None);
                        keyy = e.KeyCode;
                    }
                    break;
                case Keys.D:
                    if (keyy != e.KeyCode)
                    {
                        var sag = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("sag")
                    .Build();
                        await mqttClient.PublishAsync(sag, CancellationToken.None);
                        keyy = e.KeyCode;
                    }
                    break;

            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentVideoSource();
        }

        private void OpenVideoSource(IVideoSource source)
        {

            this.Cursor = Cursors.WaitCursor;

            CloseCurrentVideoSource();

            videoSourcePlayer.VideoSource = source;
            videoSourcePlayer.Start();

            stopWatch = null;

            timer.Start();

            this.Cursor = Cursors.Default;
        }

        private void CloseCurrentVideoSource()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();

                for (int i = 0; i < 30; i++)
                {
                    if (!videoSourcePlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (videoSourcePlayer.IsRunning)
                {
                    videoSourcePlayer.Stop();
                }

                videoSourcePlayer.VideoSource = null;
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, NewFrameEventArgs args)
        {
            DateTime now = DateTime.Now;
            Graphics g = Graphics.FromImage(args.Frame);

            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawString(now.ToString(), this.Font, brush, new PointF(5, 5));
            brush.Dispose();

            g.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;

            if (videoSource != null)
            {
                int framesReceived = videoSource.FramesReceived;

                if (stopWatch == null)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();

                    float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
                    fpsLabel.Text = fps.ToString("F2") + " fps";

                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var mqttFactory = new MqttFactory();
            mqttClient = mqttFactory.CreateMqttClient();
            var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                f =>
                {
                    f.WithTopic("robot/device1/status");
                })
                .WithTopicFilter(
                f =>
                {
                    f.WithTopic("robot/cam/IP");
                }).Build();
            await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
            mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;

            cstTriangleUp1.MouseDown += new MouseEventHandler(this.button1_MouseDown);
            cstTriangleUp1.MouseUp += new MouseEventHandler(this.button1_MouseUp);
            cstTriangleDown1.MouseDown += new MouseEventHandler(this.button2_MouseDown);
            cstTriangleDown1.MouseUp += new MouseEventHandler(this.button2_MouseUp);
            cstTriangleRight1.MouseDown += new MouseEventHandler(this.button3_MouseDown);
            cstTriangleRight1.MouseUp += new MouseEventHandler(this.button3_MouseUp);
            cstTriangleLeft1.MouseDown += new MouseEventHandler(this.button4_MouseDown);
            cstTriangleLeft1.MouseUp += new MouseEventHandler(this.button4_MouseUp);

        }

        private async void button4_MouseUp(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("dur")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private async void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("sol")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private async void button3_MouseUp(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("dur")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private async void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("sag")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private async void button2_MouseUp(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("dur")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private async void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("geri")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);

        }

        private async void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }
            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("dur")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);

        }

        private async void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (mqttClient == null)
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.kerembilgicer.com", 1883).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            }

            var apm = new MqttApplicationMessageBuilder()
                    .WithTopic("robot/device1/com")
                    .WithPayload("ileri")
                    .Build();
            await mqttClient.PublishAsync(apm, CancellationToken.None);
        }

        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            string topic = e.ApplicationMessage.Topic;
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            string[] spl = topic.Split('/');
            if (spl[2] == "IP")
            {
                Console.WriteLine(payload);
                string IP = payload;
                videoStreamUrl = $"http://{IP}:81/stream";
            }
            label1.Invoke(new Action(() => { label1.Text = "Cam IP:" + payload; }));

            return Task.CompletedTask;
        }



        private void cstButton1_Click(object sender, EventArgs e)
        {
            MJPEGStream mjpegSource = new MJPEGStream(videoStreamUrl);

            OpenVideoSource(mjpegSource);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            string[] s1 = videoStreamUrl.Split('/');
            string[] s2 = s1[2].Split(':');

            Process.Start("http://" + s2[0]);
        }

        private void cstButton3_Click(object sender, EventArgs e)
        {
            CloseCurrentVideoSource();
        }

        private void cstButton2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = DrawControlToBitmap(videoSourcePlayer);
            bitmap.Save();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Resimler (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string path = save.FileName;
                bitmap.Save(path);
            }
           
            
        }

        private Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width,control.Height);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }

    }
}
