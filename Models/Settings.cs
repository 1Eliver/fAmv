using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fAmv.Models
{
    public class Settings
    {
        // 单例实例
        private static Settings _instance = new Settings();

        // 私有属性
        private string resolution = "160x128";
        private int frameRate = 18;
        private int audioSampleRate = 22050;
        private int audioChannels = 1;
        private int blockSize = 1225;
        private int threadCount = 0;
        private string outputPath = "./output";

        // 静态属性
        public static string Resolution
        {
            get => _instance.resolution;
            set => _instance.resolution = value;
        }

        public static int FrameRate
        {
            get => _instance.frameRate;
            set => _instance.frameRate = value;
        }

        public static int AudioSampleRate
        {
            get => _instance.audioSampleRate;
            set => _instance.audioSampleRate = value;
        }

        public static int AudioChannels
        {
            get => _instance.audioChannels;
            set => _instance.audioChannels = value;
        }

        public static int BlockSize
        {
            get => _instance.blockSize;
            set => _instance.blockSize = value;
        }

        public static int ThreadCount
        {
            get => _instance.threadCount;
            set => _instance.threadCount = value;
        }

        public static string OutputPath
        {
            get => _instance.outputPath;
            set => _instance.outputPath = value;
        }

        // 构造函数
        private Settings()
        {
            // 初始化时加载配置
            InitializeSettings();
        }

        // 初始化或加载配置
        private void InitializeSettings()
        {
            string configPath = "settings.json";
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                JsonConvert.PopulateObject(json, this);
            }
        }

        // 保存配置到文件
        public static void SaveSettings()
        {
            string configPath = "settings.json";
            string json = JsonConvert.SerializeObject(_instance, Formatting.Indented);
            File.WriteAllText(configPath, json);
        }

        // 确保在程序退出时保存配置
        public static void OnApplicationExit()
        {
            SaveSettings();
        }

        // 恢复默认设置
        public static void RestoreDefaultSettings()
        {
            _instance.resolution = "160x128";
            _instance.frameRate = 18;
            _instance.audioSampleRate = 22050;
            _instance.audioChannels = 1;
            _instance.blockSize = 1225;
            _instance.threadCount = 0;
            _instance.outputPath = "./output";

            // 保存默认设置到文件
            SaveSettings();
        }
    }
}
