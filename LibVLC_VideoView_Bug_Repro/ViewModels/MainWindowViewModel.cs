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
            LibVLCZero = new LibVLC();
            LibVLCOne = new LibVLC();
            LibVLCTwo = new LibVLC();
            LibVLCThree = new LibVLC();
            LibVLCFour = new LibVLC();
            LibVLCFive = new LibVLC();

            MediaPlayerZero = new MediaPlayer(LibVLCZero);
            MediaPlayerOne = new MediaPlayer(LibVLCOne);
            MediaPlayerTwo = new MediaPlayer(LibVLCTwo);
            MediaPlayerThree = new MediaPlayer(LibVLCThree);
            MediaPlayerFour = new MediaPlayer(LibVLCFour);
            MediaPlayerFive = new MediaPlayer(LibVLCFive);
        }

        #region Properties

        private LibVLC _libVLCSix;
        public LibVLC LibVLCZero
        {
            get => _libVLCSix;
            set => this.RaiseAndSetIfChanged(ref _libVLCSix, value);
        }

        private LibVLC _libVLCOne;
        public LibVLC LibVLCOne
        {
            get => _libVLCOne;
            set => this.RaiseAndSetIfChanged(ref _libVLCOne, value);
        }

        private LibVLC _libVLCTwo;
        public LibVLC LibVLCTwo
        {
            get => _libVLCTwo;
            set => this.RaiseAndSetIfChanged(ref _libVLCTwo, value);
        }
        
        private LibVLC _libVLCThree;
        public LibVLC LibVLCThree
        {
            get => _libVLCThree;
            set => this.RaiseAndSetIfChanged(ref _libVLCThree, value);
        }
        
        private LibVLC _libVLCFour;
        public LibVLC LibVLCFour
        {
            get => _libVLCFour;
            set => this.RaiseAndSetIfChanged(ref _libVLCFour, value);
        }
        
        private LibVLC _libVLCFive;
        public LibVLC LibVLCFive
        {
            get => _libVLCFive;
            set => this.RaiseAndSetIfChanged(ref _libVLCFive, value);
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

        private string _errors = "No Errors!";
        public string Errors
        {
            get => _errors;
            set => this.RaiseAndSetIfChanged(ref _errors, value);
        }

        #endregion

        #region Commands

        public void StartCommand(Grid theGrid)
        {
            WriteLine("*** Start Command Executing ***", ConsoleColor.Red);
            
            try
            {
                LibVLCSharp.Shared.Core.Initialize();

                var media0 = new Media(LibVLCZero, "v4l2:///dev/video0", FromType.FromLocation);
                var media1 = new Media(LibVLCOne, "v4l2:///dev/video1", FromType.FromLocation);
                var media2 = new Media(LibVLCTwo, "v4l2:///dev/video2", FromType.FromLocation);
                var media3 = new Media(LibVLCThree, "v4l2:///dev/video3", FromType.FromLocation);
                var media4 = new Media(LibVLCFour, "v4l2:///dev/video4", FromType.FromLocation);
                var media5 = new Media(LibVLCFive, "v4l2:///dev/video5", FromType.FromLocation);

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
        
        #region Helper Methods

        private static void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            // Change to param.
            Console.ForegroundColor = color;

            // WriteLine
            Console.Write(message);

            // Reset to default
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            // Change to param.
            Console.ForegroundColor = color;

            // WriteLine
            Console.WriteLine(message);

            // Reset to default
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion

    }
}
