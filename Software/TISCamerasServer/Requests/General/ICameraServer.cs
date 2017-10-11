using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciclope.Devices.DriverEngine;
using System.IO;

namespace Ciclope.Devices.Camera.Server.Requests
{
    public interface ICameraServer
    {
        void TakeImage(String camera, String path, String name);
        void TakeImage(String camera, String path, String name, Double exposure);
        void TakeImage(String camera, String path, String name, Double exposure, int quality);
        void TakeImage(String camera, String name);
        String[] ListCameras();
        String[] ListOperations();
        void TakeSequence(String camera, int frames, String path, String name);
        void TakeSequence(String camera, int frames, String path, String name, int quality);
        void TakeSequence(String camera, int frames, String name);
        string Echo(String echo);
        void SetDefaultImagesPath(String path);
        string GetDefaultImagesPath();
        void SetDefaultVideoPath(String path);
        string GetDefaultVideoPath();
        void TimeLapse(String camera, int frames, String path, String name, int latency, int quality);
        void TimeLapse(String camera, int frames, String path, String name, int latency);
        void TimeLapse(String camera, int frames, String name, int latency);
        void TakeContinuousImages(String camera, String path, String name, int latency, int quality);
        void TakeContinuousImages(String camera, String path, String name, int latency);
        void TakeContinuousImages(String camera, String name, int latency);
        void CaptureVideo(String camera, String path, String name, String codec, int time);
        void CaptureVideo(String camera, String name, String codec, int time);
        void StartCapture(String camera, String path, String name, String codec);
        void StartCapture(String camera, String name, String codec);
        void StopCapture(String camera);
        void ResumeCapture(String camera);
        void PauseCapture(String camera);
        void SetPropertyValue(String camera, String property, Double value);
        Double GetPropertyValue(String camera, String property);
        Double[] GetPropertyRange(String camera, String property);
        void SetFrameRate(String camera, Double value);
        void SetImageQuality(String camera, int quality);
        int GetImageQuality(String camera);
        Double GetFrameRate(String camera);
        void SetPropertyAuto(String camera, String property, Boolean mode);
        Boolean GetPropertyAuto(String camera, String property);
        String[] GetCameraProperties(String camera);
        String[] GetVideoCodecs(String camera);
        void SetLogPath(String path);
        DriverOperation GetCurrentOperation(String camera);
        DriverOperation GetLastOperation(String camera);
        int Random(int max);
        void CancelAll(String camera);
        MemoryStream GetFile(String path, String file);
        MemoryStream GetFile(String completePath);
        DateTime GetFileTime(String path, String file);
        DateTime GetFileTime(String completePath);
        String[] GetFilenames(String path);
        String[] GetImages();
        String[] GetVideos();
        MemoryStream GetImage(String image);
        MemoryStream GetImage(String image, int width, int height);
        MemoryStream GetVideo(String video);
    }
}
