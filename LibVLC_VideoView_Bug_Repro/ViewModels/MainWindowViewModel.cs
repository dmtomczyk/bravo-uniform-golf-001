using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using LibVLCSharp.Avalonia;
using LibVLCSharp.Shared;
using ReactiveUI;
using MessageBox.Avalonia.Enums;
using Avalonia.Controls;
using System.Linq;

namespace LibVLC_VideoView_Bug_Repro.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindowViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            LibVLC = new LibVLC();

            MediaPlayerZero = new MediaPlayer(LibVLC);
            MediaPlayerOne = new MediaPlayer(LibVLC);
            MediaPlayerTwo = new MediaPlayer(LibVLC);
            MediaPlayerThree = new MediaPlayer(LibVLC);
            MediaPlayerFour = new MediaPlayer(LibVLC);
            MediaPlayerFive = new MediaPlayer(LibVLC);
        }

        #region Properties

        private LibVLC _libVLC;
        public LibVLC LibVLC
        {
            get => _libVLC;
            set => this.RaiseAndSetIfChanged(ref _libVLC, value);
        }

        private MediaPlayer _mediaPlayerZero;
        public MediaPlayer MediaPlayerZero
        {
            get => _mediaPlayerZero;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerZero, value);
        }
        
        private MediaPlayer _mediaPlayerOne;
        public MediaPlayer MediaPlayerOne
        {
            get => _mediaPlayerOne;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerOne, value);
        }
        
        private MediaPlayer _mediaPlayerTwo;
        public MediaPlayer MediaPlayerTwo
        {
            get => _mediaPlayerTwo;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerTwo, value);
        }
        
        private MediaPlayer _mediaPlayerThree;
        public MediaPlayer MediaPlayerThree
        {
            get => _mediaPlayerThree;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerThree, value);
        }
        
        private MediaPlayer _mediaPlayerFour;
        public MediaPlayer MediaPlayerFour
        {
            get => _mediaPlayerFour;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerFour, value);
        }
        
        private MediaPlayer _mediaPlayerFive;
        public MediaPlayer MediaPlayerFive
        {
            get => _mediaPlayerFive;
            set => this.RaiseAndSetIfChanged(ref _mediaPlayerFive, value);
        }

        #endregion

        #region Commands

        public void StartCommand(Grid theGrid)
        {
            try
            {
                LibVLCSharp.Shared.Core.Initialize();

                var media0 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
                var media1 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
                var media2 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
                var media3 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
                var media4 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
                var media5 = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));

                Controls allControls = theGrid.Children;

                //allControls[allControls.IndexOf()]
                var videoView0 = (VideoView)allControls.Single(control => control.Name == "VideoView0");
                var videoView1 = (VideoView)allControls.Single(control => control.Name == "VideoView1");
                var videoView2 = (VideoView)allControls.Single(control => control.Name == "VideoView2");
                var videoView3 = (VideoView)allControls.Single(control => control.Name == "VideoView3");
                var videoView4 = (VideoView)allControls.Single(control => control.Name == "VideoView4");
                var videoView5 = (VideoView)allControls.Single(control => control.Name == "VideoView5");

                videoView0?.MediaPlayer?.Play(media0);
                videoView1?.MediaPlayer?.Play(media1);
                videoView2?.MediaPlayer?.Play(media2);
                videoView3?.MediaPlayer?.Play(media3);
                videoView4?.MediaPlayer?.Play(media4);
                videoView5?.MediaPlayer?.Play(media5);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        #endregion
        
    }
}
