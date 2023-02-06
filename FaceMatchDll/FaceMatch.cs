using AForge.Controls;
using AForge.Video.DirectShow;
using FaceMatchDll.Entity;
using FaceMatchDll.Models;
using FYEntity;
using FYTemperature;
using FYUtils;
using IDCardRead;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceEntity;
using AttendanceService;
using DreamHelper;
namespace FaceMatchDll
{
    public class FaceMatch
    {
        /// <summary>
        /// 引擎Handle
        /// </summary>
        private IntPtr pImageEngine = IntPtr.Zero;
        /// <summary>
        /// 视频引擎Handle
        /// </summary>
        private IntPtr pVideoEngine = IntPtr.Zero;
        /// <summary>
        /// RGB视频引擎 FR Handle 处理   FR和图片引擎分开，减少强占引擎的问题
        /// </summary>
        private IntPtr pVideoRGBImageEngine = IntPtr.Zero;
        /// <summary>
        /// IR视频引擎 FR Handle 处理   FR和图片引擎分开，减少强占引擎的问题
        /// </summary>
        private IntPtr pVideoIRImageEngine = IntPtr.Zero;

        // private FaceTrackUnit trackRGBUnit = new FaceTrackUnit();
        // private FaceTrackUnit trackIRUnit = new FaceTrackUnit();
        private bool isLiveness = false;//是否活体 
        private Font font = new Font(FontFamily.GenericSerif, 28f, FontStyle.Bold);
        private SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        private SolidBrush blueBrush = new SolidBrush(Color.Green);
        private bool isRGBLock = false;
        private bool isIRLock = false;
        private MRECT allRect = new MRECT();
        private object rectLock = new object();
        /// <summary>
        /// 相似度
        /// </summary>
        public float threshold = 0.5f;
        /// <summary>
        /// 身份证人脸特征
        /// </summary>
        IntPtr idcardFeature = IntPtr.Zero;
        public string appId { get; set; }
        public string sdkKey { get; set; }
        /// <summary>
        /// 身份证读取
        /// </summary>
        public GetIdCardInfo cardInfoReader;
        public IDCardInfo cardInfo;

        /// <summary>
        /// 视频输入设备信息
        /// </summary>
        private FilterInfoCollection filterInfoCollection;
        /// <summary>
        /// RGB摄像头设备
        /// </summary>
        private VideoCaptureDevice rgbDeviceVideo;
        /// <summary>
        /// IR摄像头设备
        /// </summary>
        private VideoCaptureDevice irDeviceVideo;
        /// <summary>
        /// RGB视频源
        /// </summary>
        private VideoSourcePlayer rgbVideoSource;
        /// <summary>
        /// IR视频源
        /// </summary>
        private VideoSourcePlayer irVideoSource;
        /// <summary>
        /// RGB摄像头名称
        /// </summary>
        public string rgbCameraName { get; set; }
        /// <summary>
        /// IR摄像头名称
        /// </summary>
        public string irCameraName { get; set; }
        /// <summary>
        /// 是否是双目摄像
        /// </summary>
        public bool isDoubleShot { get; set; }
        /// <summary>
        /// 体温检测
        /// </summary>
        private Temperature temperature;

        /// <summary>
        /// 允许误差范围
        /// </summary>
        private int allowAbleErrorRange = 40;
        public string faceImagePath { get; set; }
        public string res { get; set; }

        //private SpeechHelper speechHelper = new SpeechHelper();
        /// <summary>
        /// 当前体温
        /// </summary>
        public float tempData = 0f;

        public float tempMin = 37.0f;
        public delegate string GetValue(float value,string name,string jobNum);
        public event GetValue FaceEvent;
        /// <summary>
        /// 是否进行人脸识别操作
        /// </summary>
        public bool isMatch { get; set; }
        EmployerService employerService = new EmployerService();
        //JDY-K2002SYC  JDY-K2002SYH
        public FaceMatch(string appId, string sdkKey, VideoSourcePlayer rgbVideoSource, VideoSourcePlayer irVideoSource, string tempCom = "", float threshold = 0.55f, bool isDoubleShot = false, float tempMin = 37f,
            string rgbCameraName = "USB 视频设备", string irCameraName = "K022HZM")// K022CZM K022HZM
        {
            try
            {

                this.appId = appId;
                this.sdkKey = sdkKey;
                this.rgbVideoSource = rgbVideoSource;
                this.irVideoSource = irVideoSource;

                this.threshold = threshold;
                this.rgbCameraName = rgbCameraName;
                this.irCameraName = irCameraName;
                this.isDoubleShot = isDoubleShot;
                this.tempMin = tempMin;
                if (tempCom != null && tempCom != "")
                {
                    temperature = new Temperature(tempCom);
                    temperature.getTemperatureEvent += Temperature_getTemperatureEvent;
                }
                InitEngines();
                initVideo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Temperature_getTemperatureEvent(float data)
        {
            this.tempData = data;
        }
        public void stopMatch()
        {
            if (temperature != null)
                temperature.stop();
            cardInfoReader.stop();
            isMatch = false;

        }
        public void startMatch()
        {
            if (temperature != null)
                temperature.start();
            cardInfoReader.start();
            isMatch = true;
        }

        public bool faceMatch { get; set; } = false;
        /// <summary>
        /// 初始化引擎
        /// </summary>
        public void InitEngines()
        {
            //判断CPU位数
            //var is64CPU = Environment.Is64BitProcess;
            //if (!is64CPU)
            //{
            //    throw new Exception("CPU不是64位");
            //}
            if (string.IsNullOrWhiteSpace(appId) || string.IsNullOrWhiteSpace(sdkKey))
            {
                throw new Exception("授权码不正确");
            }
            //在线激活引擎    如出现错误，1.请先确认从官网下载的sdk库已放到对应的bin中，2.当前选择的CPU为x86或者x64
            int retCode = 0;
            try
            {
                retCode = ASFFunctions.ASFActivation(appId, sdkKey);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("无法加载 DLL"))
                {
                    throw new Exception("请将sdk相关DLL放入bin对应的x86或x64下的文件夹中");
                }
                else
                {
                    throw new Exception("激活引擎失败!");
                }
            }

            //初始化引擎
            uint detectMode = DetectionMode.ASF_DETECT_MODE_IMAGE;
            //Video模式下检测脸部的角度优先值
            int videoDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_HIGHER_EXT;
            //Image模式下检测脸部的角度优先值
            int imageDetectFaceOrientPriority = ASF_OrientPriority.ASF_OP_0_ONLY;
            //人脸在图片中所占比例，如果需要调整检测人脸尺寸请修改此值，有效数值为2-32
            int detectFaceScaleVal = 16;
            //最大需要检测的人脸个数
            int detectFaceMaxNum = 5;
            //引擎初始化时需要初始化的检测功能组合
            int combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_AGE | FaceEngineMask.ASF_GENDER | FaceEngineMask.ASF_FACE3DANGLE;
            //初始化引擎，正常值为0，其他返回值请参考http://ai.arcsoft.com.cn/bbs/forum.php?mod=viewthread&tid=19&_dsign=dbad527e
            retCode = ASFFunctions.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pImageEngine);
            Console.WriteLine("引擎初始化成功 Result:" + retCode);
            //初始化视频模式下人脸检测引擎
            uint detectModeVideo = DetectionMode.ASF_DETECT_MODE_VIDEO;
            int combinedMaskVideo = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION;
            retCode = ASFFunctions.ASFInitEngine(detectModeVideo, videoDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMaskVideo, ref pVideoEngine);
            //RGB视频专用FR引擎
            detectFaceMaxNum = 1;
            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_LIVENESS;
            retCode = ASFFunctions.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pVideoRGBImageEngine);

            //IR视频专用FR引擎
            combinedMask = FaceEngineMask.ASF_FACE_DETECT | FaceEngineMask.ASF_FACERECOGNITION | FaceEngineMask.ASF_IR_LIVENESS;
            retCode = ASFFunctions.ASFInitEngine(detectMode, imageDetectFaceOrientPriority, detectFaceScaleVal, detectFaceMaxNum, combinedMask, ref pVideoIRImageEngine);

        }
        /// <summary>
        /// 初始化人像识别摄像头设备
        /// </summary>
        private void initVideo()
        {
            try
            {
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //必须保证有可用摄像头
                if (filterInfoCollection.Count == 0)
                {
                    throw new Exception("未检测到摄像头，请确保已安装摄像头或驱动!");
                }
                for (int index = 0; index < filterInfoCollection.Count; index++)
                {
                    string camName = filterInfoCollection[index].Name;
                    //if (camName == "Integrated Camera")
                    //{
                    //    rgbDeviceVideo = new VideoCaptureDevice(filterInfoCollection[index].MonikerString);
                    //    rgbVideoSource.VideoSource = rgbDeviceVideo;
                    //}
                    if (camName == rgbCameraName)
                    {
                        rgbDeviceVideo = new VideoCaptureDevice(filterInfoCollection[index].MonikerString);
                        rgbVideoSource.VideoSource = rgbDeviceVideo;
                        isLiveness = true;
                    }
                    else if (isDoubleShot && camName == irCameraName)
                    {
                        irDeviceVideo = new VideoCaptureDevice(filterInfoCollection[index].MonikerString);
                        irVideoSource.VideoSource = irDeviceVideo;
                        isLiveness = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("初始化摄像头异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 打开摄像头
        /// </summary>
        public void openDevice()
        {
            try
            {
                this.rgbVideoSource.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSource_Paint);
                rgbVideoSource.Start();
                if (isDoubleShot)
                {
                    this.irVideoSource.Paint += new System.Windows.Forms.PaintEventHandler(this.irVideoSource_Paint);
                    irVideoSource.Start();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("打开摄像头异常：" + ex.Message);
            }
        }
        /// <summary>
        /// 关闭设备 释放资源
        /// </summary>
        public void closeDevice()
        {
            try
            {
                if (rgbVideoSource.IsRunning)
                {
                    this.rgbVideoSource.Paint -= new System.Windows.Forms.PaintEventHandler(this.videoSource_Paint);
                    rgbVideoSource.SignalToStop();
                }
                if (isDoubleShot && irVideoSource.IsRunning)
                {
                    this.irVideoSource.Paint -= new System.Windows.Forms.PaintEventHandler(this.irVideoSource_Paint);
                    irVideoSource.SignalToStop();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("关闭摄像头异常：" + ex.Message);
            }
        }

        /// <summary>
        /// RGB摄像头Paint事件，图像显示到窗体上，得到每一帧图像，并进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoSource_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Console.WriteLine("人像线程" + Thread.CurrentThread.Name);
                if (rgbVideoSource.IsRunning && true)
                {
                    //得到当前RGB摄像头下的图片
                    Bitmap bitmap = rgbVideoSource.GetCurrentVideoFrame();
                    if (bitmap == null)
                    {
                        return;
                    }
                    //检测人脸，得到Rect框
                    ASF_MultiFaceInfo multiFaceInfo = FaceUtil.DetectFace(pVideoEngine, bitmap);
                    //得到最大人脸
                    ASF_SingleFaceInfo maxFace = FaceUtil.GetMaxFace(multiFaceInfo);
                    //得到Rect
                    MRECT rect = maxFace.faceRect;
                    //检测RGB摄像头下最大人脸
                    Graphics g = e.Graphics;
                    float offsetX = rgbVideoSource.Width * 1f / bitmap.Width;
                    float offsetY = rgbVideoSource.Height * 1f / bitmap.Height;
                    float x = rect.left * offsetX;
                    float width = rect.right * offsetX - x;
                    float y = rect.top * offsetY;
                    float height = rect.bottom * offsetY - y;

                    g.DrawRectangle(Pens.Red, x, y, width, height);

                    if (isLiveness && x > 0 && y > 0)
                    {
                        if (this.tempData > this.tempMin)
                        {
                            g.DrawString(this.tempData + "℃", font, Brushes.Red, x, y - 40);
                        }
                        else if (this.tempData <= this.tempMin && this.tempData > 0)
                        {
                            g.DrawString(this.tempData + "℃", font, Brushes.Green, x, y - 40);
                        }
                    }

                    //保证只检测一帧，防止页面卡顿以及出现其他内存被占用情况
                    if (isRGBLock == false)
                    {
                        isRGBLock = true;
                        //异步处理提取特征值和比对，不然页面会比较卡
                        _ = ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                          {
                              if (rect.left != 0 && rect.right != 0 && rect.top != 0 && rect.bottom != 0)
                              {
                                  try
                                  {
                                      lock (rectLock)
                                      {
                                          allRect.left = (int)(rect.left * offsetX);
                                          allRect.top = (int)(rect.top * offsetY);
                                          allRect.right = (int)(rect.right * offsetX);
                                          allRect.bottom = (int)(rect.bottom * offsetY);
                                      }

                                      // bool isLiveness = false;

                                      //调整图片数据，非常重要
                                      ImageInfo imageInfo = ImageUtil.ReadBMP(bitmap);
                                      if (imageInfo == null)
                                      {
                                          return;
                                      }
                                      if (imageInfo != null)
                                      {
                                          MemoryUtil.Free(imageInfo.imgData);
                                      }
                                      if (isLiveness && faceMatch)
                                      {
                                          //提取人脸特征
                                          IntPtr feature = FaceUtil.ExtractFeature(pVideoRGBImageEngine, bitmap, maxFace);
                                          
                                          List<Employeer> employeers = employerService.findAll();
                                          for (int i = 0; i < employeers.Count; i++)
                                          {
                                             Bitmap bitmap1=DreamHelper. Base64Helper.getImgByBase64(employeers[i].imageFace);
                                              IntPtr feature1 = FaceUtil.ExtractFeature(pVideoRGBImageEngine, bitmap1, maxFace);
                                              float similarity = compareFeature(feature, feature1);
                                              res = similarity.ToString();
                                              if (similarity > 0.5)
                                              {
                                                  FaceEvent(similarity, employeers[i].name,employeers[i].jobNum);
                                                  return;
                                              }
                                          }
                                          FaceEvent(0,"","");
                                          //得到比对结果



                                          MemoryUtil.Free(feature);
                                          //trackRGBUnit.message = "人脸核验完成";
                                          //idcardFeature = IntPtr.Zero;
                                          //trackRGBUnit.score = similarity;


                                      }
                                      //else
                                      //{
                                      //  //显示消息
                                      //  trackRGBUnit.message = string.Format("RGB{0}", isLiveness ? "活体" : "假体");
                                      //}
                                  }
                                  catch (Exception ex)
                                  {
                                      Console.WriteLine(ex.Message);
                                  }
                                  finally
                                  {
                                      if (bitmap != null)
                                      {
                                          bitmap.Dispose();
                                      }
                                      isRGBLock = false;
                                  }
                              }
                              else
                              {
                                  lock (rectLock)
                                  {
                                      allRect.left = 0;
                                      allRect.top = 0;
                                      allRect.right = 0;
                                      allRect.bottom = 0;
                                  }
                              }
                              isRGBLock = false;
                          }));
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void irVideoSource_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (isDoubleShot && irVideoSource.IsRunning && isMatch)
                {
                    //如果双摄，且IR摄像头工作，获取IR摄像头图片
                    Bitmap irBitmap = irVideoSource.GetCurrentVideoFrame();
                    if (irBitmap == null)
                    {
                        return;
                    }
                    //得到Rect
                    MRECT rect = new MRECT();
                    lock (rectLock)
                    {
                        rect = allRect;
                    }
                    float irOffsetX = irVideoSource.Width * 1f / irBitmap.Width;
                    float irOffsetY = irVideoSource.Height * 1f / irBitmap.Height;
                    float offsetX = irVideoSource.Width * 1f / rgbVideoSource.Width;
                    float offsetY = irVideoSource.Height * 1f / rgbVideoSource.Height;
                    //检测IR摄像头下最大人脸
                    Graphics g = e.Graphics;

                    float x = rect.left * offsetX;
                    float width = rect.right * offsetX - x;
                    float y = rect.top * offsetY;
                    float height = rect.bottom * offsetY - y;
                    //根据Rect进行画框
                    g.DrawRectangle(Pens.Red, x, y, width, height);
                    //if (trackIRUnit.message != "" && x > 0 && y > 0)
                    //{
                    //    //将上一帧检测结果显示到页面上
                    //    g.DrawString(trackIRUnit.message, font, trackIRUnit.message.Contains("活体") ? blueBrush : yellowBrush, x, y - 15);
                    //}

                    //保证只检测一帧，防止页面卡顿以及出现其他内存被占用情况
                    if (isIRLock == false)
                    {
                        isIRLock = true;
                        //异步处理提取特征值和比对，不然页面会比较卡
                        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                        {
                            if (rect.left != 0 && rect.right != 0 && rect.top != 0 && rect.bottom != 0)
                            {
                                //bool isLiveness = false;
                                try
                                {
                                    //得到当前摄像头下的图片
                                    if (irBitmap != null)
                                    {
                                        //检测人脸，得到Rect框
                                        ASF_MultiFaceInfo irMultiFaceInfo = FaceUtil.DetectFace(pVideoIRImageEngine, irBitmap);
                                        if (irMultiFaceInfo.faceNum <= 0)
                                        {
                                            return;
                                        }
                                        //得到最大人脸
                                        ASF_SingleFaceInfo irMaxFace = FaceUtil.GetMaxFace(irMultiFaceInfo);
                                        //得到Rect
                                        MRECT irRect = irMaxFace.faceRect;
                                        //判断RGB图片检测的人脸框与IR摄像头检测的人脸框偏移量是否在误差允许范围内
                                        if (isInAllowErrorRange(rect.left * offsetX / irOffsetX, irRect.left) && isInAllowErrorRange(rect.right * offsetX / irOffsetX, irRect.right)
                                            && isInAllowErrorRange(rect.top * offsetY / irOffsetY, irRect.top) && isInAllowErrorRange(rect.bottom * offsetY / irOffsetY, irRect.bottom))
                                        {
                                            int retCode_Liveness = -1;
                                            //将图片进行灰度转换，然后获取图片数据
                                            ImageInfo irImageInfo = ImageUtil.ReadBMP_IR(irBitmap);
                                            if (irImageInfo == null)
                                            {
                                                return;
                                            }
                                            //IR活体检测
                                            ASF_LivenessInfo liveInfo = FaceUtil.LivenessInfo_IR(pVideoIRImageEngine, irImageInfo, irMultiFaceInfo, out retCode_Liveness);
                                            //判断检测结果
                                            if (retCode_Liveness == 0 && liveInfo.num > 0)
                                            {
                                                int isLive = MemoryUtil.PtrToStructure<int>(liveInfo.isLive);
                                                isLiveness = (isLive == 1) ? true : false;
                                            }
                                            if (irImageInfo != null)
                                            {
                                                MemoryUtil.Free(irImageInfo.imgData);
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {

                                    //trackIRUnit.message = string.Format("IR{0}", isLiveness ? "活体" : "假体");
                                    if (irBitmap != null)
                                    {
                                        irBitmap.Dispose();
                                    }
                                    isIRLock = false;
                                }
                            }
                            else
                            {
                                //trackIRUnit.message = string.Empty;
                                isLiveness = false;
                            }
                            isIRLock = false;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }


        /// <summary>
        /// 得到feature比较结果
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        private float compareFeature(IntPtr feature1, IntPtr feature2)
        {
            float similarity = 0f;
            ASFFunctions.ASFFaceFeatureCompare(pVideoRGBImageEngine, feature1, feature2, ref similarity);
            return similarity;
        }

        /// <summary>
        /// 提取图像特征码
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private IntPtr getImgFeature(Image image)
        {

            if (image.Width > 1536 || image.Height > 1536)
            {
                image = (Bitmap)ImageUtil.ScaleImage(image, 1536, 1536);
            }

            if (image.Width % 4 != 0)
            {
                image = ImageUtil.ScaleImage(image, image.Width - (image.Width % 4), image.Height);
            }
            ASF_SingleFaceInfo singleFaceInfo = new ASF_SingleFaceInfo();
            IntPtr feature = FaceUtil.ExtractFeature(pImageEngine, image, out singleFaceInfo);
            return feature;
        }


        /// <summary>
        /// 判断参数0与参数1是否在误差允许范围内
        /// </summary>
        /// <param name="arg0">参数0</param>
        /// <param name="arg1">参数1</param>
        /// <returns></returns>
        private bool isInAllowErrorRange(float arg0, float arg1)
        {
            bool rel = false;
            if (arg0 > arg1 - allowAbleErrorRange && arg0 < arg1 + allowAbleErrorRange)
            {
                rel = true;
            }
            return rel;
        }

    }
}
